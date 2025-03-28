using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TH_WEB_4_UP.Models;
using TH_WEB_4_UP.Repository;

namespace TH_WEB_4_UP.Controllers;

public class HomeController : Controller
{
    private readonly IProductRepository _productRepository;
    public HomeController(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    public async Task<IActionResult> Index()
    {
        var products = await _productRepository.GetAllAsync();
        return View(products);
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
}
