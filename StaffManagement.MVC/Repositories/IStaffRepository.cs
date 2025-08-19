using StaffManagement.MVC.Models;

namespace StaffManagement.MVC.Repositories
{
    public interface IStaffRepository
    {
        Task<IEnumerable<Staff>> GetAllAsync();
        Task<Staff?> GetByIdAsync(string id);
        Task<string> CreateAsync(Staff staff);
        Task<bool> UpdateAsync(string id, Staff staff);
        Task<bool> DeleteAsync(string id);
    }
}
