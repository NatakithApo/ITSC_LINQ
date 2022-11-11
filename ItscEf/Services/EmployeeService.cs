using ItscEf.Repositoies.Interface;
using ItscEf.Services.Interface;

namespace ItscEf.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public string GetEmployeeName()
        {
            string name = _employeeRepository.GetName();
            return string.Format("Mr. {0}", name);
        }
    }
}
