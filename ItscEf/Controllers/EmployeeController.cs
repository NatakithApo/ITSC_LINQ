using ItscEf.DatabaseModels;
using ItscEf.Services;
using ItscEf.Services.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ItscEf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("")]
        public string GetEmployee()
        {
            return _employeeService.GetEmployeeName();
        }

        [HttpGet("positions")]
        public async Task<List<TblPosition>> GetPositions([FromQuery] string? searchText, [FromQuery] int? id)
        {
            return await _employeeService.GetPositions("", 1);
        }
    }
}
