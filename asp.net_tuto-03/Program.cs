using asp.net_tuto_03.Models.Employees;
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

app.Run();
