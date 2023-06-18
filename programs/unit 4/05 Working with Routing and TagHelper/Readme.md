# Routing in ASP.NET Core and ASP.NET Core MVC

## Introduction
Routing in ASP.NET Core is the mechanism used to map incoming requests to the appropriate handlers. It is a crucial component of any ASP.NET Core application. This document explains the key concepts and provides basic examples to help you get started.

# Components of Routing

## Routes
A route is a URL pattern that is mapped to a handler. The handler can be a Razor page, an action method, etc. Routes can extract values from the URL contained in the request, which can then be used to process the request.

## Route Template
A route template is a string composed of literals and placeholders (aka variables). Placeholders are enclosed in curly braces { }.

Example: "blog/{year}/{month}/{day}".

## Route Values
Values extracted from the URL. In the example above, year, month, and day are route values.

## Route Constraints
Specify restrictions on the values of placeholders.

Example: "blog/{year:minlength(4)}".

## Route Data
Data that is associated with a route, usually derived from route values and defaults.

## Route Handler
The code that executes when a route matches. This can be a Razor Page, MVC action, etc.

## Configuring Routing
Routing configuration in ASP.NET Core is typically done in the Startup.cs file's Configure method.

1. Default Route:

```
app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");
    });
``` 

In this pattern, controller, action, and id are placeholders that get replaced by the controller name, action method name, and optional identifier, respectively. The equals sign (=) sets a default value, while the question mark (?) denotes that the id parameter is optional.

2. Named Route:
You can give a name to your route and set a unique pattern:

```

endpoints.MapControllerRoute(
    name: "product_detail",
    pattern: "product/{id}",
    defaults: new { controller = "Product", action = "Detail" });

```

3. Attribute Routing:
You can apply route configurations directly to controllers and actions using attributes:

```
[Route("api/[controller]")]
public class ProductsController : Controller
{
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        //...
    }
}
``` 

4. Route Constraints:
You can add constraints to control the matching behavior of your routes:

```
endpoints.MapControllerRoute(
    name: "product_detail",
    pattern: "product/{id:int}");
```
In this example, the :int constraint ensures that this route will only be selected if the id segment of the URL is an integer.

Multiple Routes in Startup.cs

You can define multiple routes in the Configure method of the Startup.cs file. The order matters because the framework stops at the first match:

```
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "product_detail",
        pattern: "product/{id}",
        defaults: new { controller = "Product", action = "Detail" });

    endpoints.MapControllerRoute(
        name: "user_profile",
        pattern: "user/{username}",
        defaults: new { controller = "User", action = "Profile" });

    // The default route should be last
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

```