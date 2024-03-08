using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TrainningSystem.Models;

namespace TrainningSystem.ViewModel

{
    public class CourseWithDepartmentList
    {
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }

        [Range(50, 100, ErrorMessage = "Degree Must be between 50 and 100")]
        public int degree { get; set; }
        [Remote("CheckMinDegree", "Course",
            ErrorMessage = "Min Degree must less than Degree", AdditionalFields = "degree")]
        [Display(Name = "Minimum Degree")]

        public int minDegree { get; set; }

        [Display(Name = "Department")]
        public int? dept_id { get; set; }
        public List<Department>? departments { get; set; }
    }
}
