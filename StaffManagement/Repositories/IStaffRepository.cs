using StaffManagement.Models;

namespace StaffManagement.Repositories
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetAllAsync();
        Task<Staff?> GetByIdAsync(string? staffId);
        Task AddAsync(Staff staff);
        Task UpdateAsync(Staff staff);
        Task DeleteAsync(string? staffId);

        Task<IEnumerable<Staff>> SearchAsync(string? staffId, int? gender, DateOnly? dateFrom, DateOnly? dateTo);
    }
}
