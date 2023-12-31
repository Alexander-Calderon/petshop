using ApiPetshop.Dtos;

namespace ApiPetshop.Services;

public interface IUserService
{
    Task<string> RegisterAsync(RegisterDto model);
    Task<string> AddRoleAsync(AddRoleDto model); 
    Task<DataUserDto> GetTokenAsync(LoginDto model);
    Task<DataUserDto> RefreshTokenAsync(string refreshToken);
}
