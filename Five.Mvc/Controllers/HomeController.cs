using System.Diagnostics;
using Five.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Five.Mvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppSettings _appSettings;
    private readonly IUsuarioRepository _usuarioRepository;

    public HomeController(ILogger<HomeController> logger, AppSettings appSettings, IUsuarioRepository usuarioRepository)
    {
        _logger = logger;
        _appSettings = appSettings;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<IActionResult> Index()
    {
        var usuarios = await _usuarioRepository.BuscarUsuarioPorEmail("ane.duarte@smn.com.br");
        Console.WriteLine(usuarios.Nome);
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}
