using ItscEf.Repositoies.Interface;

namespace ItscEf.Repositoies
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public string GetName()
        {
            return "Patawee Intarat";
        }
    }
}
