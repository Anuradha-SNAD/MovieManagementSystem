using MovieManagementSystem.Model;

namespace MovieManagementSystem.Repository
{
    public interface IProducerRepository
    {
        Task Add(Producer producer);
        Task<Producer?> GetByEmail(string email);
    }
}
