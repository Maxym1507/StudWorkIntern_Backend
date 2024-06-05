using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudWorkIntern_Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EmployersController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public EmployersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Employers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employer>>> GetAllEmployers()
    {
        return await _context.Employers.ToListAsync();
    }

    // GET: api/Employers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Employer>> GetEmployerById(int id)
    {
        var employer = await _context.Employers.FindAsync(id);

        if (employer == null)
        {
            return NotFound();
        }

        return employer;
    }

    // PUT: api/Employers/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployer(int id, Employer employer)
    {
        if (id != employer.EmployerId)
        {
            return BadRequest();
        }

        _context.Entry(employer).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EmployerExists(id))
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

    // POST: api/Employers
    [HttpPost]
    public async Task<ActionResult<Employer>> CreateEmployer(Employer employer)
    {
        _context.Employers.Add(employer);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEmployerById", new { id = employer.EmployerId }, employer);
    }

    // DELETE: api/Employers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployer(int id)
    {
        var employer = await _context.Employers.FindAsync(id);
        if (employer == null)
        {
            return NotFound();
        }

        _context.Employers.Remove(employer);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EmployerExists(int id)
    {
        return _context.Employers.Any(e => e.EmployerId == id);
    }
}
