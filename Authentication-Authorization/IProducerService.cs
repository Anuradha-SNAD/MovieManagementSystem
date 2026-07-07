using MovieManagementSystem.DTOs;

namespace MovieManagementSystem.Service
{
    public interface IProducerService
    {
        Task Register(RegisterRequestDTO dto);
        Task<string> LoginAsync(LoginRequestDTO dto);
    }
}
