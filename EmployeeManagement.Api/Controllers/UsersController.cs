using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Models;

namespace EmployeeManagement.Api.Controllers;

public class LoginRequest
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public string? FullName { get; set; }
    public string? Username { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly AppDbContext _db;

    public UsersController(AppDbContext db)
    {
        _db = db;
    }

    // Registration
    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        var exists = await _db.Users.AnyAsync(u => u.Username == user.Username);
        if (exists)
            return BadRequest("এই ইউজারনেম আগে থেকেই আছে।");

        user.IsActive = false; // registration করলে সবসময় inactive থাকবে, admin approve করবে
        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return Ok("রেজিস্ট্রেশন সফল হয়েছে। Admin approve করলে লগইন করতে পারবেন।");
    }

    // Login
    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u =>
            u.Username == request.Username && u.Password == request.Password);

        if (user == null)
            return Ok(new LoginResponse { Success = false, Message = "ভুল ইউজারনেম অথবা পাসওয়ার্ড।" });

        if (!user.IsActive)
            return Ok(new LoginResponse { Success = false, Message = "আপনার অ্যাকাউন্ট এখনও Active করা হয়নি। Admin-এর সাথে যোগাযোগ করুন।" });

        return Ok(new LoginResponse
        {
            Success = true,
            Message = "সফলভাবে লগইন হয়েছে।",
            FullName = user.FullName,
            Username = user.Username
        });
    }

    // Admin: সব ইউজার দেখা
    [HttpGet]
    public async Task<ActionResult<List<User>>> GetAll()
    {
        return await _db.Users.ToListAsync();
    }

    // Admin: IsActive টগল/আপডেট করা
    [HttpPut("{id}/toggle-active")]
    public async Task<IActionResult> ToggleActive(int id)
    {
        var user = await _db.Users.FindAsync(id);
        if (user == null) return NotFound();

        user.IsActive = !user.IsActive;
        await _db.SaveChangesAsync();

        return Ok(user);
    }
}