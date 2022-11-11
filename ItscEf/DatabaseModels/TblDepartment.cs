using Microsoft.JSInterop.Infrastructure;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ItscEf.DatabaseModels
{
    public class TblDepartment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TblPosition> Positions { get; set; }

        
    }
}
