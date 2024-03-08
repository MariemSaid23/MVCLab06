using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TrainningSystem.Models
{
    public class UniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string name = value.ToString();

            Course courseSend = (Course)validationContext.ObjectInstance;

            ITIContext context = new ITIContext();

            var courseFromDB = context.courses
                .FirstOrDefault(course => course.Name == name && course.DepartmentId == courseSend.DepartmentId);

            if (courseFromDB == null || courseFromDB.Id == courseSend.Id)
            {
                return ValidationResult.Success;
            }


            return new ValidationResult("Course Name Already Exists");
        }
    }
}
