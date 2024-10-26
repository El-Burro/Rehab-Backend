using RehabBackend.Core.Entities;
using RehabBackend.Data;
using RehabBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RehabBackend.Services.Repositories
{
    public class ExerciseRepository : IRepository<Exercise>
    {
        private readonly AppDbContext _context;

        public ExerciseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Exercise> Add(Exercise entity)
        {
            _context.Exercises.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var Exercise = await _context.Exercises.FindAsync(id);
            if (Exercise == null) return false;
            _context.Exercises.Remove(Exercise);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Exercise>> GetAll()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise> GetById(int id)
        {
            return await _context.Exercises.FindAsync(id);
        }

        public async Task<Exercise> Update(Exercise entity)
        {
            _context.Exercises.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

// Similarly, create repositories for Patient, Plan, and Exercise
