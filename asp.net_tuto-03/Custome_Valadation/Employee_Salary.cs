using asp.net_tuto_03.Models.Employees;
using System.ComponentModel.DataAnnotations;

namespace asp.net_tuto_03.Custome_Valadation
{
    public class Employee_Salary :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var employee = validationContext.ObjectInstance as Employee;

            if(employee is not null &&
                !string.IsNullOrWhiteSpace(employee.Position) &&
                employee.Position.Equals("manager",StringComparison.OrdinalIgnoreCase))
            {
                if(employee.Salary < 10000)
                {
                    return new ValidationResult("A manager salary more than $10000");
                }
            }

            return ValidationResult.Success;
        }
    }
}
