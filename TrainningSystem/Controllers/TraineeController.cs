using Humanizer;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;
using TrainningSystem.Models;
using TrainningSystem.ViewModel;

namespace TrainningSystem.Controllers
{
    public class TraineeController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult TraineeCourseAndGradWithVM(int id,int crsId)
        {
            var Trainee=context.Trainees.FirstOrDefault(t=>t.Id==id);
            var course=context.courses.FirstOrDefault(c=>c.Id==crsId);
            var crsResult=context.crsResults.FirstOrDefault(r=>r.TraineeId==id&&r.CourseId==crsId);
            if (Trainee == null && course == null &&crsResult==null) {
            
            return NotFound();
            }


            var viewModel = new TraineeCourseAndGradeViewModel
            {
                TraineeId = Trainee.Id,
                TraineeName = Trainee.Name,
                CourseName = course.Name,
                //CourseDegree = course.Degree;
                CourseDegree = Convert.ToInt32(Trainee.grade), // Convert to the appropriate type if necessary
                color = Trainee.grade >= course.minDegree ? "green" : "red"
            };




      


            return View("TraineeCourseAndGradWithVM", viewModel);
        }
        public IActionResult ShowTraineeResult (int id)
        {
            var Trainee = context.Trainees.FirstOrDefault(t => t.Id == id);
            if(Trainee== null) { return NotFound(); }
            var TraineeCourse = context.crsResults.Where(cr => cr.TraineeId == id)
                .Select(cr => new TraineeCourseAndGradeViewModel
                {
                    CourseName = cr.Course.Name,
                    CourseDegree = Convert.ToInt32(cr.Degree),
                    


                }).ToList();
            var viewModel = new ShowTraineeResultViewModel
            {
                TraineeId = Trainee.Id,
                TraineeName = Trainee.Name,
                Courses = TraineeCourse,
                //color=Trainee.grade>50?"green":"red"
                color=Trainee.grade>=50?"green":"red"


            };
            return View("ShowTraineeResult",viewModel);
        }

    }
}
