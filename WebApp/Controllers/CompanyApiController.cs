using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Filters;
using WebApp.Model.Movies;

namespace WebApp.Controllers;
[ApiController]
[Route("api/companies")]

[RequireLogin]
public class CompanyApiController : ControllerBase
{
    private MoviesDbContext _context;

    public CompanyApiController(MoviesDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    public async Task<IActionResult> GetFitered(string fragment)
    {
        return Ok(
            _context.ProductionCompanies
                .Where(m => m.CompanyName != null && m.CompanyName.ToLower().Contains(fragment.ToLower()))
                .AsTracking()
                .AsEnumerable()
            );
    }
}