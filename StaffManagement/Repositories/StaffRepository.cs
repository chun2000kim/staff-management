using Microsoft.EntityFrameworkCore;
using StaffManagement.Data;
using StaffManagement.Models;

namespace StaffManagement.Repositories
{

    public class StaffRepository : IStaffRepository
    {
        private readonly AppDbContext _context;
        public StaffRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Staff staff)
        {
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string? staffId)
        {
            var staff = _context.Staffs.FirstOrDefault(s => s.StaffId == staffId);

            if (staff != null)
            {
                _context.Staffs.Remove(staff);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Staff>> GetAllAsync()
        {
            return await _context.Staffs.ToListAsync();
        }

        public async Task<Staff?> GetByIdAsync(string? staffId)
        {
            return await _context.Staffs
                .FirstOrDefaultAsync(s => s.StaffId == staffId);
        }

        public async Task<IEnumerable<Staff>> SearchAsync(string? staffId, int? gender, DateOnly? dateFrom, DateOnly? dateTo)
        {
            var query = _context.Staffs.AsQueryable().Where(s=>s.StaffId == staffId || s.Gender ==  gender || (s.Birthday >= dateFrom && s.Birthday <= dateTo));
            return await query.ToListAsync();
        }

        public async Task UpdateAsync(Staff staff)
        {
            _context.Staffs.Update(staff);
            await _context.SaveChangesAsync();
        }
    }
}
