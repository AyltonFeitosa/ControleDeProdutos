using ControleDeProdutos.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ControleDeProdutos.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.ProdutosCadastrados = _context.ProductModel.Count();
            ViewBag.TotalProdutosEstoque = _context.ProductModel.Sum(o => o.QuantidadeEstoque);
            ViewBag.EstoqueBaixo = _context.ProductModel.Where(o => o.QuantidadeEstoque < 3).ToList().Take(3);    
            ViewBag.AjustarEstrategiaVenda = _context.ProductModel.Where(o => o.QuantidadeEstoque > 10).ToList().Take(3);

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
    }
}
