namespace Tutorial.Dapper.Feaatures.Employees.ReqResModels
{
    public class EmployeeCreateRequestModel
    {
        public string FirstName { get; set; } =string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Department { get; set; } = string.Empty;

        public DateTime? BirthDate { get; set; } = null;

        public char? Gender { get; set; }

        public int? Salary { get; set; }

        public int? ManagerID { get; set; }



    }
}
