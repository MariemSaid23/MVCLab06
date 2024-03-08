//using Microsoft.AspNetCore.Mvc;
//using TrainningSystem.Models;
//using TrainningSystem.ViewModel;

//namespace TrainningSystem.Controllers
//{
//    public class AddInstrctorController : Controller
//    {
//        ITIContext context = new ITIContext();

//        public IActionResult Index()
//        {
//            AddInstructorVM addInstructorVM = new AddInstructorVM();
//            addInstructorVM.Departments = context.Departments.ToList();
//            addInstructorVM.Courses = context.courses.ToList();
//            return View(addInstructorVM);
//        }
//        [HttpPost]
//        public IActionResult NewInstructor(AddInstructorVM addInstructorVM)
//        {
//            if (ModelState.IsValid)
//            {
//                Instructor instructor = new Instructor
//                {
//                    Name = addInstructorVM.Name,
//                    Imag = addInstructorVM.Image,
//                    salary = addInstructorVM.Salary,
//                    DepartmentId = addInstructorVM.DeptId,
//                    CourseId = addInstructorVM.CourseId
//                };

//                context.instructors.Add(instructor);
//                context.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            // Set Departments and Courses before returning View
//            addInstructorVM.Departments = context.Departments.ToList();
//            addInstructorVM.Courses = context.courses.ToList();
//            return View("Index", addInstructorVM);
//        }
//    }
//}
