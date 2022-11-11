using ItscEf.DatabaseModels;
using ItscEf.Repositoies.Interface;

namespace ItscEf.Repositoies
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DatabaseContext _dbContext;

        public EmployeeRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string GetName()
        {
            IEnumerable<TblDepartment> enumerable = _dbContext.TblDepartments.AsEnumerable();
            var eWhere = enumerable.Where(i => i.Id == 1);
            string e = eWhere.Select(i => i.Name).Single();

            IQueryable<TblDepartment> queryable = _dbContext.TblDepartments.AsQueryable();
            var qWhere = queryable.Where(i => i.Id == 1);
            string q = qWhere.Select(i => i.Name).Single();

            string result = _dbContext.TblDepartments.Select(i => i.Name).First();
            return result;
        }
    }
}
