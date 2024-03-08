namespace TrainningSystem.ViewModel
{
    public class ShowTraineeResultViewModel
    {
        public int TraineeId { get; set; }
        public string TraineeName { get; set; }
        
        public string color { get; set; }
        public List<TraineeCourseAndGradeViewModel> Courses { get; set; }

    }
}
