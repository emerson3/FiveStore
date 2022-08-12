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

    public async Task<IActionResult> Index(ItemViewModel itemViewModel)
    {
        var itens = await _usuarioRepository.BuscarItemAsync();

        itemViewModel.itens = itens;
        return View("Index", itemViewModel);
    }

    [HttpGet("informacao-roupa")]
    public IActionResult InformacaoRoupa()
    {
        return View("_InformacaoRoupa");
    }
}
