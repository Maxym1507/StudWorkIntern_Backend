using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudWorkIntern_Backend.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class InternshipsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public InternshipsController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/Internships
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Internship>>> GetAllInternships()
    {
        return await _context.Internships.ToListAsync();
    }

    // GET: api/Internships/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Internship>> GetInternshipById(int id)
    {
        var internship = await _context.Internships.FindAsync(id);

        if (internship == null)
        {
            return NotFound();
        }

        return internship;
    }

    // PUT: api/Internships/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateInternship(int id, Internship internship)
    {
        if (id != internship.InternshipId)
        {
            return BadRequest();
        }

        _context.Entry(internship).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!InternshipExists(id))
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

    // POST: api/Internships
    [HttpPost]
    public async Task<ActionResult<Internship>> CreateInternship(Internship internship)
    {
        _context.Internships.Add(internship);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetInternshipById", new { id = internship.InternshipId }, internship);
    }

    // DELETE: api/Internships/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInternship(int id)
    {
        var internship = await _context.Internships.FindAsync(id);
        if (internship == null)
        {
            return NotFound();
        }

        _context.Internships.Remove(internship);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool InternshipExists(int id)
    {
        return _context.Internships.Any(e => e.InternshipId == id);
    }
}
