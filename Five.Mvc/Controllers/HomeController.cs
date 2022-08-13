namespace Five.Mvc.Controllers;
public class HomeController : AuthenticatedController
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
        var itens = await _usuarioRepository.ItemAsync();

        itemViewModel.itens = itens;
        return View("Index", itemViewModel);
    }

    [HttpGet("informacao-roupa")]
    public async Task<IActionResult> InformacaoRoupa(int id, ItemViewModel itemViewModel)
    {
        Console.WriteLine(id);

        var item = await _usuarioRepository.BuscarItemAsync(id);

        itemViewModel.item = item;

        return View("_InformacaoRoupa", new { itemViewModel = itemViewModel });
    }
}
