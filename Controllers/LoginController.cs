using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ControleDeProdutos.Models;
using ControleDeProdutos.Security;

namespace ControleDeProdutos.Controllers
{
    public class LoginController : Controller
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Login
        public async Task<IActionResult> Index()
        {
            return View();
        }

        
        [HttpPost("ValidarCredenciais")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ValidarCredenciais([Bind("Email,Password")] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var cripto = new Criptografia();
                loginModel.Password = cripto.Criptografar(loginModel.Password);

                var usuario = await _context.UserModel.Where(o => o.Email == loginModel.Email && o.Password == loginModel.Password).FirstOrDefaultAsync();

                if (usuario != null)
                {
                    return RedirectToAction("Index", "Home");
                }               
            }
            return View("Index");
        }
    }
}
