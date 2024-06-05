using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudWorkIntern_Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class JobPostingsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public JobPostingsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/JobPostings
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobPosting>>> GetAllJobPostings()
    {
        return await _context.JobPostings.ToListAsync();
    }

    // GET: api/JobPostings/5
    [HttpGet("{id}")]
    public async Task<ActionResult<JobPosting>> GetJobPostingById(int id)
    {
        var jobPosting = await _context.JobPostings.FindAsync(id);

        if (jobPosting == null)
        {
            return NotFound();
        }

        return jobPosting;
    }

    // PUT: api/JobPostings/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateJobPosting(int id, JobPosting jobPosting)
    {
        if (id != jobPosting.JobPostingId)
        {
            return BadRequest();
        }

        _context.Entry(jobPosting).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!JobPostingExists(id))
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

    // POST: api/JobPostings
    [HttpPost]
    public async Task<ActionResult<JobPosting>> CreateJobPosting(JobPosting jobPosting)
    {
        _context.JobPostings.Add(jobPosting);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetJobPostingById", new { id = jobPosting.JobPostingId }, jobPosting);
    }

    // DELETE: api/JobPostings/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteJobPosting(int id)
    {
        var jobPosting = await _context.JobPostings.FindAsync(id);
        if (jobPosting == null)
        {
            return NotFound();
        }

        _context.JobPostings.Remove(jobPosting);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool JobPostingExists(int id)
    {
        return _context.JobPostings.Any(e => e.JobPostingId == id);
    }
}
