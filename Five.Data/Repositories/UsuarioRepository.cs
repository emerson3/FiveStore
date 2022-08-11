namespace Five.Data.Repositories
{
    public class UsuarioRepository : BaseRepository, IUsuarioRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;
        
        public UsuarioRepository (ApplicationDbContext dbContext) : base(dbContext)
        {
            _applicationDbContext = dbContext;
        }

        public async Task<Usuario> BuscarUsuarioPorEmailAsync(string email)
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
        
        public async Task<IEnumerable<Item>> BuscarItemAsync()
        {
            return await _applicationDbContext.Itens
                .Select(x => new Item
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Preco = x.Preco,
                    Cor = x.Cor,
                    IdCategoria = x.IdCategoria,
                    QtdEstoque = x.QtdEstoque
                })
                .ToArrayAsync();
        }
    }
}