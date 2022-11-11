using ItscEf.DatabaseModels;

namespace ItscEf.Services.Interface
{
    public interface IEmployeeService
    {
        public string GetEmployeeName();
        public Task<List<TblPosition>> GetPositions(string text, int? id);


    }
}
