using System.Data;

namespace ItscEf.DatabaseModels
{
    public class TblEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime StartDate { get; set; }
        public string? Address { get; set; }
        public float Salary { get; set; }

        public TblPosition Position { get; set; }
        public List<TblProject> Projects { get; set; }

    }
}
