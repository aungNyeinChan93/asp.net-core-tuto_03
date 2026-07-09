namespace Tutorial.Dapper.Models
{
    public class EmployeeModel
    {
        public int EmployeeID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Department { get; set; }

        public DateTime? BirthDate { get; set; }

        public char? Gender { get; set; }

        public int? Salary { get; set; }

        public int? ManagerID { get; set; }

        public string? Test { get; set; }
    }
}
