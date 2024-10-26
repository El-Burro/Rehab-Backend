using RehabBackend.Core.Entities;
using RehabBackend.Data;
using RehabBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RehabBackend.Services.Repositories
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly AppDbContext _context;

        public ClientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Client> Add(Client entity)
        {
            _context.Clients.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null) return false;
            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await _context.Clients.ToListAsync();
        }

        public async Task<Client> GetById(int id)
        {
            return await _context.Clients.FindAsync(id);
        }

        public async Task<Client> Update(Client entity)
        {
            _context.Clients.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

// Similarly, create repositories for Patient, Plan, and Exercise
