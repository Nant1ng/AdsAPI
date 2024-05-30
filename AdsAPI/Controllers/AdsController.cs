using AdsAPI.Data;
using AdsAPI.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdsAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ad>>> GetAll()
        {
            var ads = await _context.Ads.ToListAsync();

            return Ok(ads);
        }
    }
}
