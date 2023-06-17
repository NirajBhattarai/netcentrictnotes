# View Model

A ViewModel is a class that holds the data for a specific UI component (or View) in an MVVM architecture. The ViewModel is responsible for exposing the data objects from the Model in such a way that those objects are easily managed and consumed by the View. Here is a basic example of a ViewModel in C#:

```

using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get; }
        public string? CurrentCategory { get; }

        public PieListViewModel(IEnumerable<Pie> pies, string? currentCategory)
        {
            Pies = pies;
            CurrentCategory = currentCategory;
        }
    }
}


```

And Pie Controller List will change this way

```

-......


 public IActionResult List()
        {

            PieListViewModel piesListViewModel = new PieListViewModel(_pieRepository.AllPies, "Cheese cakes");
            return View(piesListViewModel);
        }

        ```