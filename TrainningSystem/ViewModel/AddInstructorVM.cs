using TrainningSystem.Models;

namespace TrainningSystem.ViewModel
{
    public class AddInstructorVM
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public decimal Salary { get; set; }
        public int? DeptId { get; set; }
        public int? CourseId { get; set; }

        public List<Department> Departments { get; set; }
        public List<Course> Courses { get; set; }
    }
}
