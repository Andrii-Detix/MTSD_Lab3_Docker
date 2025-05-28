using DockerLab.Database;
using DockerLab.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DockerLab.Extensions;

public static class UserEndPoints
{
    public static void UseUserEndPoints(this IEndpointRouteBuilder endpoints)
    {
        endpoints.CreateUser();
        endpoints.GetUsers();
        endpoints.GetUserById();
    }
    
    private static void CreateUser(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapPost("/users", async (CreateUserDto cu, MyDbContext db) =>
        {
            try
            {
                User user = new User(cu.Name, cu.Age);

                await db.Users.AddAsync(user);
                await db.SaveChangesAsync();

                return Results.Created($"/users/{user.Id}", user);
            }
            catch (Exception e)
            {
                return Results.BadRequest(e.Message);
            }
        });
    }

    private static void GetUsers(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/users", async (MyDbContext db) =>
        {
            List<GetUserDto> users = await db.Users
                .Select(u => new GetUserDto(u.Id, u.Name, u.Age))
                .ToListAsync();

            return Results.Ok(users);
        });
    }

    private static void GetUserById(this IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/users/{id:long}", async (long id, MyDbContext db) =>
        {
            User? user = await db.Users.FindAsync(id);

            if (user is null)
            {
                return Results.NotFound();
            }

            GetUserDto res = new GetUserDto(user.Id, user.Name, user.Age);

            return Results.Ok(res);
        });
    }
}