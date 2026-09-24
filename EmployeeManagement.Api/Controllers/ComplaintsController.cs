using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Api.Data;
using EmployeeManagement.Api.Models;

namespace EmployeeManagement.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ComplaintsController : ControllerBase
{
    private readonly AppDbContext _db;

    public ComplaintsController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<Complaint>>> GetAll()
    {
        return await _db.Complaints.OrderByDescending(c => c.Id).ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Complaint>> Create(Complaint complaint)
    {
        _db.Complaints.Add(complaint);
        await _db.SaveChangesAsync();
        return Ok(complaint);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Complaint complaint)
    {
        if (id != complaint.Id) return BadRequest();

        var existing = await _db.Complaints.FindAsync(id);
        if (existing == null) return NotFound();

        existing.SubmissionDate = complaint.SubmissionDate;
        existing.ComplainantName = complaint.ComplainantName;
        existing.ComplainantMobile = complaint.ComplainantMobile;
        existing.DesignationDepartment = complaint.DesignationDepartment;
        existing.CompanyName = complaint.CompanyName;
        existing.ComplaintDetails = complaint.ComplaintDetails;
        existing.ActionTaken = complaint.ActionTaken;
        existing.Status = complaint.Status;
        existing.ResolvingOfficer = complaint.ResolvingOfficer;
        existing.Comments = complaint.Comments;

        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var existing = await _db.Complaints.FindAsync(id);
        if (existing == null) return NotFound();

        _db.Complaints.Remove(existing);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}