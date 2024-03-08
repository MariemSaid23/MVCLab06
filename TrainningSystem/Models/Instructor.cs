using System.ComponentModel.DataAnnotations.Schema;

namespace TrainningSystem.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Imag { get; set; }
        public decimal? salary { get; set; }
        public string? address { get; set; }
        [ForeignKey ("Department")]
        public int? DepartmentId { get; set; }

        [ForeignKey("Course")]
        public int? CourseId { get; set; }
        public Department? Department { get; set; }
        public Course? Course { get; set; }  


    }
}
