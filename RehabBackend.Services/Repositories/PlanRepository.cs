using RehabBackend.Core.Entities;
using RehabBackend.Data;
using RehabBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RehabBackend.Services.Repositories
{
    public class PlanRepository : IRepository<Plan>
    {
        private readonly AppDbContext _context;

        public PlanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Plan> Add(Plan entity)
        {
            _context.Plans.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var Plan = await _context.Plans.FindAsync(id);
            if (Plan == null) return false;
            _context.Plans.Remove(Plan);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Plan>> GetAll()
        {
            return await _context.Plans.ToListAsync();
        }

        public async Task<Plan> GetById(int id)
        {
            return await _context.Plans.FindAsync(id);
        }

        public async Task<Plan> Update(Plan entity)
        {
            _context.Plans.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

// Similarly, create repositories for Patient, Plan, and Exercise
