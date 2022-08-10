namespace Five.Data.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public UsuarioRepository (ApplicationDbContext dbContext) : base(dbContext)
        {
            _applicationDbContext = dbContext;
        }

        public async Task<Usuario> BuscarUsuarioPorEmail(string email)
        {
            return await _applicationDbContext.Usuarios
                .AsSingleQuery()
                .Where(x => x.Email.Equals(email))
                .Select(x => new Usuario
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Email = x.Email,
                    Senha = x.Senha
                })
                .FirstOrDefaultAsync();
        }
    }
}