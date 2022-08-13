namespace Five.Mvc.Controllers
{
    [Route("Admin")]
    public class AdminController : AuthenticatedController
    {

        private readonly AppSettings _appSettings;
        private readonly IUsuarioRepository _usuarioRepository;

        public AdminController(AppSettings appSettings, IUsuarioRepository usuarioRepository)
        {
            _appSettings = appSettings;
            _usuarioRepository = usuarioRepository;
        }

        public IActionResult Index()
        {
            Console.WriteLine(UsuarioSession.IdTipoUsuario);
            if (UsuarioSession != null && UsuarioSession.IdTipoUsuario == 1)
                return View();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("cadastrar")]
        public async Task<IActionResult> CadastrarFuncionarioView()
        {
            return View("CadastrarFuncionario", "Admin");

        }

        [HttpPost("cadastrar-usuario")]
        public async Task<IActionResult> CadastrarFuncionario(CadastrarUsuarioViewModel cadastrarUsuarioViewModel)
        {
            if (cadastrarUsuarioViewModel == null)
                return BadRequest("Nenhum parâmetro foi enviado");
            var usuario = await _usuarioRepository.BuscarPorEmailAsync(cadastrarUsuarioViewModel.Email);

            if (usuario != null)
                return BadRequest("Usuário já cadastrado!");

            await _usuarioRepository.CadastrarUsuarioAsync(new Usuario
            {
                Nome = cadastrarUsuarioViewModel.Nome,
                Email = cadastrarUsuarioViewModel.Email,
                Senha = "111111",
                IdTipoUsuario = 2,
                Rua = "Praia de Mucuripé",
                Bairro = "Cuiá",
                Numero = 83,
                Cep = 58077008,
                Cidade = "João Pessoa",
                Estado = "PB"
            });

            return Ok();
        }

        [HttpGet("cadastrar-item")]
        public async Task<IActionResult> CadastrarItemView()
        {
            return View("CadastrarItem", "Admin");

        }

        [HttpPost("cadastrar-item")]
        public async Task<IActionResult> CadastrarItem(CadastrarItemViewModel cadastrarItemViewModel)
        {
            if (cadastrarItemViewModel == null)
                return BadRequest("Nenhum parâmetro foi enviado");

            await _usuarioRepository.CadastrarItemAsync(new Item
            {
                Nome = cadastrarItemViewModel.Nome,
                Cor = cadastrarItemViewModel.Cor,
                Preco = cadastrarItemViewModel.Preco,
                QtdEstoque = cadastrarItemViewModel.QtdEstoque,
                IdCategoria = cadastrarItemViewModel.IdCategoria
            });

            return Ok();
        }

    }
}
