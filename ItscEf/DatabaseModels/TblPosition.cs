using System.ComponentModel.DataAnnotations.Schema;

namespace ItscEf.DatabaseModels
{
    public class TblPosition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public TblDepartment Department { get; set; }
    }
}
