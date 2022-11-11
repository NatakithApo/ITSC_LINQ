using System.ComponentModel.DataAnnotations.Schema;

namespace ItscEf.DatabaseModels
{
    public class TblProject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Budget { get; set; }
        public string? Description { get; set; }
        
        public List<TblEmployee> Employees { get; set; }
    }
}
