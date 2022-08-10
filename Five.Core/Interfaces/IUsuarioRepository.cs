namespace Five.Core.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> BuscarUsuarioPorEmail(string email);
    }
}