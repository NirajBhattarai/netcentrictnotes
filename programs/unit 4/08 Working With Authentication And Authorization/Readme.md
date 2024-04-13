# .NET Core Server Side Session Managemen

## Introduction
This guide walks you through the process of adding session support to your .NET Core application. Sessions in ASP.NET Core allow you to store and retrieve user data while that user is interacting with your web application.


## Setup

1. In the Program.cs file, locate the Configure method.

2. Add the following code:

```
services.AddSession(options =>
    {
        options.IdleTimeout = TimeSpan.FromMinutes(30);
        options.Cookie.HttpOnly = true; 
        options.Cookie.IsEssential = true; 
    });

app.UseSession();

```    

We will demonstrate this session on our application using cartsystem

1. Create ShoppingCartItem.cs within in model with following code 

```
namespace BethanysPieShop.Models
{
    public class ShoppingCartItem
    {
        public int ShoppingCartItemId { get; set; }
        public Pie Pie { get; set; } = default!;
        public int Amount { get; set; }
        public string? ShoppingCartId { get; set; }
    }
}
```
2. Add Shopping Cart to DbContext on file BethanysPieShopDbContext

```
........
 public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
 .....

```

3. Run Migration Script

```
dotnet ef migrations add InitialCreate

dotnet ef database update

```

4. Add Repository To perform Action as ShoppingCart.cs

```
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly BethanysPieShopDbContext _bethanysPieShopDbContext;

        public string? ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

        private ShoppingCart(BethanysPieShopDbContext bethanysPieShopDbContext)
        {
            _bethanysPieShopDbContext = bethanysPieShopDbContext;
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

            BethanysPieShopDbContext context = services.GetService<BethanysPieShopDbContext>() ?? throw new Exception("Error initializing");

            string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

            session?.SetString("CartId", cartId);

            return new ShoppingCart(context) { ShoppingCartId = cartId };
        }

        public void AddToCart(Pie pie)
        {
            var shoppingCartItem =
                    _bethanysPieShopDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1
                };

                _bethanysPieShopDbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _bethanysPieShopDbContext.SaveChanges();
        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCartItem =
                    _bethanysPieShopDbContext.ShoppingCartItems.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            var localAmount = 0;

            if (shoppingCartItem != null)
            {
                if (shoppingCartItem.Amount > 1)
                {
                    shoppingCartItem.Amount--;
                    localAmount = shoppingCartItem.Amount;
                }
                else
                {
                    _bethanysPieShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
                }
            }

            _bethanysPieShopDbContext.SaveChanges();

            return localAmount;
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItems ??=
                       _bethanysPieShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                           .Include(s => s.Pie)
                           .ToList();
        }

        public void ClearCart()
        {
            var cartItems = _bethanysPieShopDbContext
                .ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

            _bethanysPieShopDbContext.ShoppingCartItems.RemoveRange(cartItems);

            _bethanysPieShopDbContext.SaveChanges();
        }

        public decimal GetShoppingCartTotal()
        {
            var total = _bethanysPieShopDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                .Select(c => c.Pie.Price * c.Amount).Sum();
            return total;
        }
    }
}
```

5. Register Services on Startup.cs

```

builder.Services.AddScoped<IShoppingCart, ShoppingCart>(sp => ShoppingCart.GetCart(sp));
builder.Services.AddSession(); 
builder.Services.AddHttpContextAccessor();

app.UseStaticFiles();
app.UseSession();
.......
.....

```

6. Add ShoppingCartController.cs

```
using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartController(IPieRepository pieRepository, IShoppingCart shoppingCart)
        {
            _pieRepository = pieRepository;
            _shoppingCart = shoppingCart;

        }
        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel(_shoppingCart, _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
            {
                _shoppingCart.AddToCart(selectedPie);
            }
            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPie = _pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }
            return RedirectToAction("Index");
        }
    }
}
```

7. Add ShoppingCartViewModel.cs Inside View Model

```
using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCartViewModel(IShoppingCart shoppingCart, decimal shoppingCartTotal)
        {
            ShoppingCart = shoppingCart;
            ShoppingCartTotal = shoppingCartTotal;
        }

        public IShoppingCart ShoppingCart { get; }
        public decimal ShoppingCartTotal { get; }
    }
}
```

8. Add ShoppingCart View Now

```
@model ShoppingCartViewModel

<h3 class="my-5">
    Shopping cart
</h3>


<div class="row gx-3">
    <div class="col-8">
        @foreach (var line in Model.ShoppingCart.ShoppingCartItems)
        {
            <div class="card shopping-cart-card mb-2">
                <div class="row">
                    <div class="col-md-4">
                        <img src="@line.Pie.ImageThumbnailUrl" class="img-fluid rounded-start p-2" alt="@line.Pie.Name">
                    </div>
                    <div class="col-md-8">
                        <div class="card-body">
                            <h5 class="card-text">@line.Amount x @line.Pie.Name</h5>
                            <div class="d-flex justify-content-between">
                                <h6>@line.Pie.ShortDescription</h6>
                                <h2>@line.Pie.Price.ToString("c")</h2>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        }
    </div>
    <div class="col-4">
        <div class="card shopping-cart-card p-3">
            <div class="row">
                <h4 class="col">Total:</h4>
                <h4 class="col text-end">@Model.ShoppingCartTotal.ToString("c")</h4>
            </div>
            <hr />
            <div class="text-center d-grid">
                
            </div>
        </div>
    </div>
</div>
```










 







