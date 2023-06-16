using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ChefNDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefNDishes.Controllers;

public class DishController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyContext _context;

    public DishController(ILogger<HomeController> logger, MyContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet("dishes")]
    public IActionResult AllDishes()
    {   
        List<Dish> allDishes = _context.Dishes.Include(dish => dish.Creator).ToList();
        
        return View("AllDishes", allDishes);
    }

    
    [HttpGet("dishes/new")]
    public IActionResult NewDish()
    {
        ViewBag.ChefsList = _context.Chefs.ToList(); 
        return View("CreateDish");
    }

    [HttpPost("dishes/create")]
    public IActionResult CreateDish(Dish newDish)
    {
        if(!ModelState.IsValid){
            ViewBag.ChefsList = _context.Chefs.ToList(); 
            return View("CreateDish");
        }

        _context.Dishes.Add(newDish);

        _context.SaveChanges();

        return RedirectToAction("AllDishes");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
