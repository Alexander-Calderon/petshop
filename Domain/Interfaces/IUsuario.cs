
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IUsuario : IGenericRepository<Usuario>
    {
        Task<Usuario> GetByUsernameAsync(string username);
        Task<Usuario> GetByRefreshTokenAsync(string refreshToken);
    }
}