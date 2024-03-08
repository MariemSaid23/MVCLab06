using Microsoft.AspNetCore.Mvc;
using TrainningSystem.Models;
using TrainningSystem.ViewModel;

namespace TrainningSystem.Controllers
{
    public class CourseController : Controller
    {
        ITIContext context = new ITIContext();

        public IActionResult ShowCourseResult(int id)
        {


            var course = context.courses.FirstOrDefault(c => c.Id == id);

            var CourseResults = context.crsResults.FirstOrDefault(c => c.Id == id);


            if (course == null)
            {
                return NotFound();
            }
            var crsResults = context.crsResults.Where(r => r.Id == id).ToList();

            var traineeNamesAndGrades = new List<(string Name, string Grade)>();
            foreach (var crsResult in crsResults)
            {
                var trainee = context.Trainees.FirstOrDefault(t => t.Id == crsResult.TraineeId);

                traineeNamesAndGrades.Add((trainee.Name, crsResult.Degree.ToString()));

            }


            var viewModel = new TraineeNamesInCourseViewModel
            {

                CourseName = course.Name,
                color = CourseResults.Degree > 50 ? "green" : "red",
                TraineeNamesAndGrades = traineeNamesAndGrades
                

            };
            return View("ShowCourseResult",viewModel);
        }


        public IActionResult All()
        {
            var courses = context.courses.ToList();
            var courseViewModels = new List<CourseWithDepartmentList>();
            foreach (var course in courses)
            {
                var viewModel = new CourseWithDepartmentList
                {
                    Id = course.Id,
                    Name = course.Name,
                    degree =Convert.ToInt32( course.Degree),
                    minDegree =Convert.ToInt32( course.minDegree),
                    dept_id = course.DepartmentId,
                    departments = context.Departments.ToList()
                };
                courseViewModels.Add(viewModel);
            }

            return View("All", courseViewModels);
        }
        public IActionResult New()
        {
            var viewModel = new CourseWithDepartmentList
            {
                departments = context.Departments.ToList()
            };
            return View("New", viewModel);

        }
        [HttpPost]
        public IActionResult SaveNew(Course crs)
        {
            if (ModelState.IsValid==true)
            {
                context.Add(crs);
                context.SaveChanges();
                return RedirectToAction("All");
            }

            var viewModle = new CourseWithDepartmentList
            {
                Name = crs.Name,
                degree = Convert.ToInt32( crs.Degree),
                minDegree = Convert.ToInt32(crs.minDegree),
                dept_id = crs.DepartmentId,
                departments = context.Departments.ToList()
            };
            return View("New", viewModle);
        }
        public IActionResult CheckMinDegree(int MinDegree, int Degree)
        {
            if (MinDegree > Degree)
            {
                return Json(false);

            }
            return Json(true);
        }


    }
}

