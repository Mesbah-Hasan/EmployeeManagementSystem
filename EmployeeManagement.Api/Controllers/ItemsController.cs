using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Models;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly AppDbContext _db;

    public ItemsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Item>>> GetAll()
    {
        return await _db.Items.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Item>> Create(Item item)
    {
        _db.Items.Add(item);
        await _db.SaveChangesAsync();
        return Ok(item);
    }
}