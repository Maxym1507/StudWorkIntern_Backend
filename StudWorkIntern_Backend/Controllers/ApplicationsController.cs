using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudWorkIntern_Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class ApplicationsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ApplicationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Applications
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Application>>> GetAllApplications()
    {
        return await _context.Applications.ToListAsync();
    }

    // GET: api/Applications/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Application>> GetApplicationById(int id)
    {
        var application = await _context.Applications.FindAsync(id);

        if (application == null)
        {
            return NotFound();
        }

        return application;
    }

    // PUT: api/Applications/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateApplication(int id, Application application)
    {
        if (id != application.ApplicationId)
        {
            return BadRequest();
        }

        _context.Entry(application).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ApplicationExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Applications
    //[HttpPost]
    //public async Task<ActionResult<Application>> CreateApplication(Application application)
    //{
    //    _context.Applications.Add(application);
    //    await _context.SaveChangesAsync();

    //    return CreatedAtAction("GetApplicationById", new { id = application.ApplicationId }, application);
    //}

    [HttpPost]
    public async Task<ActionResult<Application>> CreateApplication(Application application)
    {
        var student = await _context.Students.FindAsync(application.StudentId);
        if (student == null)
        {
            return NotFound("Student not found.");
        }

        if (application.JobPostingId.HasValue)
        {
            var jobPosting = await _context.JobPostings.FindAsync(application.JobPostingId.Value);
            if (jobPosting == null)
            {
                return NotFound("Job posting not found.");
            }
        }

        if (application.InternshipId.HasValue)
        {
            var internship = await _context.Internships.FindAsync(application.InternshipId.Value);
            if (internship == null)
            {
                return NotFound("Internship not found.");
            }
        }

        _context.Applications.Add(application);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetApplicationById), new { id = application.ApplicationId }, application);
    }


    // DELETE: api/Applications/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteApplication(int id)
    {
        var application = await _context.Applications.FindAsync(id);
        if (application == null)
        {
            return NotFound();
        }

        _context.Applications.Remove(application);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ApplicationExists(int id)
    {
        return _context.Applications.Any(e => e.ApplicationId == id);
    }
}
