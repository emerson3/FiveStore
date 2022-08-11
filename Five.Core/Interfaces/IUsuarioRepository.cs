namespace Five.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> BuscarUsuarioPorEmailAsync(string email);
        Task<IEnumerable<Item>> BuscarItemAsync();
    }
}