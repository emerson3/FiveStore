namespace Five.Mvc.Controllers
{
    [Route("Login")]
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

        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var usuario = await _usuarioRepository.BuscarPorEmailAsync(loginViewModel.Email);
            
            if (usuario == null || loginViewModel.Senha != usuario.Senha)
                return BadRequest("Email ou senha incorretos!");

            HttpContext.Session.Set<Usuario>("Usuario", usuario);

            return View("Index", "Home");
        }


        [HttpGet("cadastrar-usuario")]
        public IActionResult IndexCadastrarUsuario() {
            return View("_Cadastrar", "Home");
        }

        [HttpPost("cadastrar-usuario")]
        public async Task<IActionResult> CadastrarUsuario(CadastrarUsuarioViewModel cadastrarUsuarioViewModel)
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
                IdTipoUsuario = 3,
                Rua = cadastrarUsuarioViewModel.Rua,
                Bairro = cadastrarUsuarioViewModel.Bairro,
                Numero = cadastrarUsuarioViewModel.Numero,
                Cep = cadastrarUsuarioViewModel.Cep,
                Complemento = cadastrarUsuarioViewModel.Complemento,
                Cidade = cadastrarUsuarioViewModel.Cidade,
                Estado = cadastrarUsuarioViewModel.Estado 
            });

            return Ok();
        }
    }
}
