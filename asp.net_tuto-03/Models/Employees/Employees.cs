namespace asp.net_tuto_03.Models.Employees
{
    public class Employee
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Position { get; set; } = null!;

        public int Salary { get; set; }

        public Employee() { }

        public Employee(int id,string name,string position,int salary)
        {
            Id = id;
            Name = name;
            Position = position;
            Salary = salary;
        }
    }

    public static class EmployeeRepository
    {
        private static List<Employee> _employees = new List<Employee>()
        {
            new Employee(){Name= "susu",Id = 1, Position= "Sale",Salary = 2000},
            new Employee(){Name= "koko",Id = 2, Position= "Developer",Salary = 69000},
        };

        public static List<Employee> GetAllEmployees() => _employees;

        public static Employee? GetEmployee(int? id) => _employees.FirstOrDefault(e=>e.Id == id);

        public static void AddEmployee(Employee employee) => _employees.Add(employee);

        public static Employee? UpdateEmployee(int? id, Employee employee)
        {
            var oldEmployee = _employees.FirstOrDefault(x => x.Id == id);
            oldEmployee!.Name = employee.Name;
            oldEmployee!.Position = employee.Position;
            oldEmployee!.Salary = employee.Salary;

            return oldEmployee;
        }

        public static void DeleteEmployee(int? id) => _employees.Remove(_employees.FirstOrDefault(x => x.Id == id)!);

    }
}
