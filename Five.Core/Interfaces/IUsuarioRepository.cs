namespace Five.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> BuscarPorEmailAsync(string email);
        Task<IEnumerable<Item>> BuscarItemAsync();
    }
}