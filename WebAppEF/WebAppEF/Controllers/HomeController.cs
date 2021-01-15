using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppEF.Models;
using Microsoft.EntityFrameworkCore;
using WebAppEF.Repositorio;
using System.Linq;

namespace WebAppEF.Controllers
{
    public class HomeController : Controller
    {
        DbContext _dbContext;
        public HomeController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // restante da classe continua aqui em baixo

        public IActionResult Index()
        {
            var usuarios = _dbContext.Set<Usuario>().OrderBy(u => u.Nome).ToList();
            return View(usuarios);
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

        [HttpPost]
        public IActionResult Create(Usuario usuario)
        {
            _dbContext.Set<Usuario>().Add(usuario);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
