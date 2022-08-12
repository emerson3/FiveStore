using System.Diagnostics;
using Five.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Krita.Mvc.Controllers
{
    [Route("login")]
    public class LoginController : Controller
    {
        private readonly ApplicationDbContext _applicationDbcontext;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly AppSettings _appSettings;
        
        public LoginController(
            ApplicationDbContext applicationDbContext,
            IUsuarioRepository usuarioRepository,
            AppSettings appSettings
        )
        {
            _applicationDbcontext = applicationDbContext;
            _usuarioRepository = usuarioRepository;
            _appSettings = appSettings;
        }

        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.Get("Usuario") != null)
                return View("Index", "Home");

            return View();
        }            
    }
}