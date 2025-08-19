using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using StaffManagement.DTOs;
using StaffManagement.Models;
using StaffManagement.Repositories;

namespace StaffManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffRepository _staffRepository;

        public StaffController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }
        [HttpGet()]
        public async Task<ActionResult<List<Staff>>> GetAll()
        {
            var staffList = (await _staffRepository.GetAllAsync()).ToList();
            return Ok(new ApiResponse()
            {
                Code = 200,
                Status = "Success",
                Message = "",
                TotalRecord = staffList.Count,
                Data = staffList
            });
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] StaffDto staffDto)
        {
            if (staffDto == null)
            {
                return BadRequest(new ApiResponse()
                {
                    Code = StatusCodes.Status500InternalServerError,
                    Status = "Error",
                    Message = "Internal Server error."
                });

            }

            var staff = await _staffRepository.GetByIdAsync(staffDto.StaffId);

            if (staff != null)
            {
                return BadRequest(new ApiResponse()
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = "Error",
                    Message = "Staff id already exists.",
                });
            }

            var nesStaff = new Staff
            {
                StaffId = staffDto.StaffId,
                FullName = staffDto.FullName,
                Birthday = staffDto.Birthday,
                Gender = staffDto.Gender
            };

            await _staffRepository.AddAsync(nesStaff);

            return CreatedAtAction(
                 nameof(GetById),
                 new { id = nesStaff.StaffId },
                 new ApiResponse
                 {
                     Code = StatusCodes.Status201Created,
                     Status = "Success",
                     Message = "Staff created successfully."
                 });
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var staff = await _staffRepository.GetByIdAsync(id);
            if (staff == null)
            {
                return NotFound(new ApiResponse()
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = "Success",
                    Message = "Staff id not found!",
                    TotalRecord = 0
                });
            }
            return Ok(new ApiResponse()
            {
                Code = StatusCodes.Status200OK,
                Status = "Success",
                Message = "",
                TotalRecord = new List<Staff> { staff }.Count,
                Data = new List<Staff> { staff }
            });
        }

        [HttpDelete("Delete/{staffId}")]
        public async Task<ActionResult<ApiResponse>> Delete(string staffId)
        {
            var staff = _staffRepository.GetByIdAsync(staffId);
            if (staff == null)
            {
                return NotFound(new ApiResponse()
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = "Error",
                    Message = "Staff id not found."
                });
            }

            await _staffRepository.DeleteAsync(staffId);

            return Ok(new ApiResponse()
            {
                Code = StatusCodes.Status200OK,
                Status = "Success",
                Message = "Staff delete successfully."
            });
           
        }

        [HttpPut("Update/{staffId}")]
        public async Task<IActionResult> Update(string staffId, [FromBody] StaffDto staffDto)
        {
            if (staffDto == null)
            {
                return BadRequest(new ApiResponse
                {
                    Code = StatusCodes.Status400BadRequest,
                    Status = "Error",
                    Message = "Invalid staff data."
                });
            }

            var staff = await _staffRepository.GetByIdAsync(staffId);
            if (staff == null)
            {
                return NotFound(new ApiResponse
                {
                    Code = StatusCodes.Status404NotFound,
                    Status = "Error",
                    Message = "Staff ID not found."
                });
            }
            staff.FullName = staffDto.FullName;
            staff.Birthday = staffDto.Birthday;
            staff.Gender = staffDto.Gender;

            await _staffRepository.UpdateAsync(staff);

            return Ok(new ApiResponse
            {
                Code = StatusCodes.Status200OK,
                Status = "Success",
                Message = "Staff updated successfully."
            });
        }


        [HttpPost("search")]
        public async Task<IActionResult> Search([FromBody] SearchCriteria criteria)
        {
            var results = await _staffRepository.SearchAsync(criteria.StaffId, criteria.Gender, criteria.DateFrom, criteria.DateTo);
            return Ok(new ApiResponse()
            {
                Code = StatusCodes.Status200OK,
                Status = "Success",
                Message = "",
                TotalRecord = results.Count(),
                Data = new List<Staff>(results)
            });
                
        }

    }
}
