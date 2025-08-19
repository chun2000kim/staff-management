using Microsoft.AspNetCore.Mvc;
using StaffManagement.MVC.Models;
using StaffManagement.MVC.Repositories;

namespace StaffManagement.MVC.Controllers
{
    public class StaffController : Controller
    {
        IStaffRepository _staffRepository;
        public StaffController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var staffList = await _staffRepository.GetAllAsync();
            return View(staffList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Staff staff)
        {
            if (!ModelState.IsValid) 
                return View(staff);

            await _staffRepository.CreateAsync(staff);
            //if (!success) ModelState.AddModelError("", "Failed to create staff");
            return RedirectToAction(nameof(Index));

        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var staff = await _staffRepository.GetByIdAsync(id);
            if (staff == null) return NotFound();
            return View(staff);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            await _staffRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
