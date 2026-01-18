using asp.net_tuto_03.Models.Auth;
using asp.net_tuto_03.Models.Employees;
using asp.net_tuto_03.Models.Users;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) =>
{
    context.Response.StatusCode = 201;
    return $"Hello world";
});

app.MapGet("/employees/{id:int?}", async ([FromRoute] int? id) =>
{
    if(id is not null)
    {
        var employee = EmployeeRepository.GetEmployee(id);
        return Results.Ok(employee);
    }

    var employees = EmployeeRepository.GetAllEmployees();
    return Results.Ok(employees);  
});

app.MapPost("/employees", async ([FromBody] Employee employee) =>
{
    EmployeeRepository.AddEmployee(employee);
    return Results.Ok(new {message= "Employee successfully created!"});
}).WithParameterValidation();

app.MapPut("/employees", async ([FromQuery] int? id, [FromBody] Employee employee) =>
{
    if(id is not null && employee is not null)
    {
        var updatedEmployee = EmployeeRepository.UpdateEmployee(id, employee);
        return Results.Ok(updatedEmployee);
    }
    return Results.NotFound();
});

app.MapDelete("/employees/{id:int?}", async ([FromRoute] int? id) =>
{
    if(id is null ) return Results.NotFound();
    EmployeeRepository.DeleteEmployee(id);
    return Results.Ok(new { message = "Delete success!" });
});

// Users
app.MapGet("/users/{id:int?}", async (int? id) =>
{
    if(id is not null)
    {
        var user = UserRepo.GetUser(id);
        return Results.Ok(user);
    }
    return Results.Ok(UserRepo.GetUsers());
});

app.MapPost("/users", async ([FromBody] User? user) =>
{
    UserRepo.AddUser(user);
    return Results.Ok(user);
}).WithParameterValidation();

app.MapPut("/users", async ([FromQuery] int? id, [FromBody] User? user) =>
{
    if(id is not null && user is not null)
    {
        var updatedUser = UserRepo.UpdateUser(id, user);
        return Results.Ok(updatedUser);
    }
    return Results.Problem("user update fail!");
}).WithParameterValidation();

app.MapDelete("/users/{id:int?}", async ([FromRoute] int? id) =>
{
    if(id is null) return Results.Problem("Id is not found");

    UserRepo.DeleteUser(id);
    return Results.Ok(new { message = "Delete success!" });
});


// Auth
//app.MapGet("/register", async ([FromQuery] string? email, string? password, string? confrimPassword ) =>
//{
//    var registerObj = new Register() { Email = email, Password = password, ConfrimPassword = confrimPassword };
//    return Results.Ok(registerObj);
//}).WithParameterValidation();

app.MapPost("/register", async ([FromBody] Register? registerDto) =>
{
    if (registerDto is null) return Results.Problem("Register fail!");
    var registerObj = new Register() { Email = registerDto.Email, Password = registerDto.Password, ConfrimPassword = registerDto.ConfrimPassword };
    return Results.Ok(new {message="register success",registerObj});
}).WithParameterValidation();

app.Run();
