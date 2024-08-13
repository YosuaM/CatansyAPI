using System.Diagnostics;
using Bogus;
using EFCore.BulkExtensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatansyAPI.Context;
using CatansyAPI.Entities;
using CatansyAPI.Models.Requests;
using CatansyAPI.Services.Interfaces;

namespace CatansyAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController(CatansyContext _catansyContext, IUsersService _usersService) : ControllerBase
{
    [HttpGet("users/all")]
    public async Task<IActionResult> Get()
    {
        var users = await _catansyContext.Users.AsNoTracking().ToListAsync();
        return Ok(users);
    }

    [HttpPost("users")]
    public async Task<IActionResult> CreateUser(CreateUserRequest req)
    {
        var newUser = Entities.User.CreateUser(req.ToDto());
        await _catansyContext.Users.AddAsync(newUser);
        await _catansyContext.SaveChangesAsync();
        return Ok(newUser);
    }

    [HttpGet("users/{id}")]
    public async Task<IActionResult> LoadUser(int id)
    {
        var user = await _usersService.SearchUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPut("users/{id}")]
    public async Task<IActionResult> UpdateUser(int id, UpdateUserRequest req)
    {
        var user = await _catansyContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        
        if (user == null) 
        {
            return NotFound();
        }

        user.UpdateUser(req.ToDto());

        await _catansyContext.SaveChangesAsync();
        
        return Ok();
    }
    
    [HttpGet("items-categories/all")]
    public async Task<IActionResult> GetItemsCat() => Ok(await _catansyContext.ItemsCategories.AsNoTracking().ToListAsync());
    
    [HttpPost("generate")]
    public async Task<IActionResult> GenerateUsers(int usersToGenerate)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var generatedUsers = new Faker<User>()
            .RuleFor(r => r.Mail, f => f.Person.Email)
            .RuleFor(r => r.Password, f => f.Person.FullName)
            // .RuleFor(r => r.Created, f => f.Person.DateOfBirth.ToUniversalTime())
            .RuleFor(r => r.Uid, f => Guid.NewGuid().ToString());

        //
        // var generatedUsers = new Faker<ItemCategory>()
        //     .RuleFor(r => r.Name, f => f.Company.CompanyName())
        //     ;
    
        var users = generatedUsers.Generate(usersToGenerate);
    
        // var users = new List<User>()
        // {
        //     Entities.User.CreateUser(new CreateUserRequest("a"))
        // };

        stopWatch.Stop();
        
        Console.WriteLine($"{stopWatch.Elapsed} - Tiempo Generados en bogus");
    
        stopWatch.Reset();
        
        stopWatch.Start();
        
        await _catansyContext.BulkInsertAsync(users, config =>
        {
            config.PropertiesToExclude =
            [
                "Created"
            ];
        });
        
        stopWatch.Stop();
        Console.WriteLine($"{stopWatch.Elapsed} - Tiempo Insertados en bogus");
        
        return Ok("oko");
    }
}