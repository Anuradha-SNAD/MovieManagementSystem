using Microsoft.EntityFrameworkCore;
using MovieManagementSystem.Data;
using MovieManagementSystem.Model;

namespace MovieManagementSystem.Repository
{
    public class ProducerRepository : IProducerRepository
    {
        private readonly AppDbContext context;

        public ProducerRepository(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Producer producer)
        {
            await context.Producers.AddAsync(producer);
            await context.SaveChangesAsync();
        }

        public async Task<Producer?> GetByEmail(string email)
        {
            return await context.Producers.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
