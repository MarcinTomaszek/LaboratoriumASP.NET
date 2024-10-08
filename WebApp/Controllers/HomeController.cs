using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Calculator(Operator? op, double? x, double? y)
    {
        // var op = Request.Query["op"];
        // var x = double.Parse(Request.Query["x"]);
        // var y = double.Parse(Request.Query["y"]);
        if (x is null || y is null)
        {
            ViewBag.ErrorMessage = "Wrong number format in parimeter x or y";
            if (x is  null && op != Operator.sin)
            {
                return View("CalculatorError");
            }
        }

        if (op is null)
        {
            ViewBag.ErrorMessage = "Unknown operator";
            return View("CalculatorError");
        }
            
        switch (op)
        {
            case Operator.add:
                ViewBag.Result = x + y;
                break;
            case Operator.sub:
                ViewBag.Result = x - y;
                break;
            case Operator.mul:
                ViewBag.Result = x * y;
                break;
            case Operator.div:
                ViewBag.Result = x / y;
                break;
            case Operator.pow:
                ViewBag.Result = Math.Pow((double)x,(double)y);
                break;
            case Operator.sin:
                ViewBag.Result = Math.Sin((double)x);
                break;
        }
            
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public enum Operator
    {
        add,sub,mul,div,pow,sin
    }
}