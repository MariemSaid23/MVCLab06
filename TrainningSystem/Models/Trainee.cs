using System.ComponentModel.DataAnnotations.Schema;

namespace TrainningSystem.Models
{
    public class Trainee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Iamg { get; set; }
        public int? address {  get; set; }
        public int? grade { get; set; }
        [ForeignKey("Department")]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
