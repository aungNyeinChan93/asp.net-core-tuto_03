using System;
using System.Collections.Generic;

namespace Dapper.Database.Database.AppDbContext.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Department { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Gender { get; set; }

    public int? Salary { get; set; }

    public int? ManagerId { get; set; }
}
