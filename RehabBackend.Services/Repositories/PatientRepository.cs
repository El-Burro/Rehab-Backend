using RehabBackend.Core.Entities;
using RehabBackend.Data;
using RehabBackend.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RehabBackend.Services.Repositories
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly AppDbContext _context;

        public PatientRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Patient> Add(Patient entity)
        {
            _context.Patients.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(int id)
        {
            var Patient = await _context.Patients.FindAsync(id);
            if (Patient == null) return false;
            _context.Patients.Remove(Patient);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Patient>> GetAll()
        {
            return await _context.Patients.ToListAsync();
        }

        public async Task<Patient> GetById(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task<Patient> Update(Patient entity)
        {
            _context.Patients.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}

// Similarly, create repositories for Patient, Plan, and Exercise
