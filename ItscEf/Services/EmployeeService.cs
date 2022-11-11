using CMU.Budget.API.Exceptions.HttpExceptions;
using ItscEf.DatabaseModels;
using ItscEf.Repositoies.Interface;
using ItscEf.Services.Interface;

namespace ItscEf.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IPositionRepository _positionRepository;
        public EmployeeService(
            IEmployeeRepository employeeRepository,
            IPositionRepository positionRepository
            )
        {
            _employeeRepository = employeeRepository;
            _positionRepository = positionRepository;
        }

        public string GetEmployeeName()
        {
            string name = _employeeRepository.GetName();
            return string.Format("Mr. {0}", name);
        }

        public async Task<List<TblPosition>> GetPositions(string text, int? id)
        {
            Console.WriteLine("Start service");
            //List<TblPosition> positions = await _positionRepository.GetPositionsAsync();
            List<TblPosition> positions = new List<TblPosition>();

            var positionTask = Task.Run(() =>
            {
                return _positionRepository.GetPositionsAsync();
            });

            ////Do something ////
            Console.WriteLine("Work1");
            Console.WriteLine("Work2");
            Console.WriteLine("Work3");

            positions = positionTask.Result;

            Console.WriteLine("Finish service");



            return positions;
        }

        public void ThrowError()
        {
            throw new HttpBadRequestException("Invalid request data");
        }
    }
}
