using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TrainningSystem.Models
{
    public class Course
    {
       public int Id { get; set; }

       
        [Unique]
        public string? Name { get; set; }
        [Range(50,100, ErrorMessage = "Degree Must be between 50 and 100")]
        public int? Degree { get; set; }
        [Remote("CheckMinDegree", "Course",
        ErrorMessage = "Min Degree must less than Degree", AdditionalFields = "degree")]
        public int? minDegree { get; set; }

        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }

    }
}
