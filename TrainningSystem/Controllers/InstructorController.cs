using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainningSystem.Models;
using TrainningSystem.ViewModel;

namespace TrainningSystem.Controllers
{
    public class InstructorController : Controller
    {
        ITIContext context = new ITIContext();
        public IActionResult Index()
        {
            //List<Instructor> InsListModel =
            // context.instructors.ToList();
            //return View("Index", InsListModel);
            //      List<Instructor> instructorsModel = context.instructors
            //.Include(i => i.Course)
            //.Include(i => i.Department)
            //.ToList();
            //      return View("Index", instructorsModel);

            List<Instructor> InstructorModel = context.instructors.ToList();
            return View("Index", InstructorModel);

        }
        public IActionResult Detail(int id)
        {
            var instructor = context.instructors.FirstOrDefault(i => i.Id == id);
            if (instructor != null)
            {
                context.Entry(instructor).Reference(i => i.Course).Load();
                context.Entry(instructor).Reference(i => i.Department).Load();
            }
            return View("Detail", instructor);
        }

        //public IActionResult New()
        //{
        //    //return View ("new");
        //    var viewModel = new InstructoraWithDepartmentAndCourseLists
        //    {
        //        departments = context.Departments.ToList(),
        //        courses = context.courses.ToList()
        //    };
        //    return View(viewModel);
        //}
        public IActionResult New()
        {
            var viewModel = new InstructoraWithDepartmentAndCourseLists
            {
                departments = context.Departments.ToList(),
                courses = context.courses.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult SaveNew(Instructor inst)
        {
            if (inst.Name != null)
            {
                context.Add(inst);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("new", inst);
        }

        public IActionResult CoursePerDepartment(int DepartmentId)
        {
            var courses = context.courses.Where(c => c.DepartmentId == DepartmentId).ToList();
            return Json(courses);
        }

    }
}
