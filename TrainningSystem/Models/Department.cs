namespace TrainningSystem.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MangerName { get; set; }
        public List<Instructor> Ins { get; set; }
        public List<Trainee> Trainees { get; set; }
        public List<Course> Courses { get; set; }

    }
}
