using asp.net_tuto_03.Models.Users;
using Microsoft.AspNetCore.Mvc;

namespace asp.net_tuto_03.EndPoints
{
    public static class UsersEndPoint
    {
        public static void MapUserEndPoint(this WebApplication app)
        {
            // Users
            app.MapGet("/users/{id:int?}", async (int? id) =>
            {
                if (id is not null)
                {
                    var user = UserRepo.GetUser(id);
                    return Results.Ok(user);
                }
                return Results.Ok(UserRepo.GetUsers());
            });

            app.MapPost("/users", async ([FromBody] User? user) =>
            {
                if (user?.Id < 0)
                {
                    return Results.ValidationProblem(new Dictionary<string, string[]>()
        {
             //{"id",new[] {"User is not invalid" ,"user id is not invalid" } },
             {"id",["user is not invalid", "user Id is not invalid"] },
        });
                }
                UserRepo.AddUser(user);
                return Results.Created($"/users/{user?.Id}", user);
            }).WithParameterValidation();

            app.MapPut("/users", async ([FromQuery] int? id, [FromBody] User? user) =>
            {

                if (id is not null && user is not null)
                {
                    var updatedUser = UserRepo.UpdateUser(id, user);
                    return Results.Ok(updatedUser);
                }

                return Results.ValidationProblem(new Dictionary<string, string[]>()
    {
         { "message",["User update fail!"]}
    });
            }).WithParameterValidation();

            app.MapDelete("/users/{id:int?}", async ([FromRoute] int? id) =>
            {
                if (id is null) return Results.Problem("Id is not found");

                UserRepo.DeleteUser(id);
                return Results.Ok(new { message = "Delete success!" });
            });
        }
    }
}
