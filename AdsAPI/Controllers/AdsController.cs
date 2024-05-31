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

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Ad>> GetOne(int id)
        {
            var ad = await _context.Ads.FindAsync(id);

            if (ad == null)
                return NotFound($"Ad with id: {id} was not found");

            return Ok(ad);
        }

        [HttpPost]
        public async Task<ActionResult<Ad>> PostAd(Ad ad)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Ads.Add(ad);
            await _context.SaveChangesAsync();

            return Ok(ad);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Ad>> UpdateAd(int id, [FromBody] Ad updatedAd)
        {
            var adToUpdate = await _context.Ads.FindAsync(id);
            DateTime date = DateTime.Now;

            if (adToUpdate == null)
                return NotFound($"Ad with id: {id} was not found!");

            adToUpdate.Title = adToUpdate.Title;
            adToUpdate.Description = adToUpdate.Description;
            adToUpdate.Author = adToUpdate.Author;
            adToUpdate.PublishedDate = adToUpdate.PublishedDate;

            await _context.SaveChangesAsync();

            return Ok(adToUpdate);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Ad>> DeleteAd(int id)
        {
            var deleteAd = await _context.Ads.FindAsync(id);

            if (deleteAd == null)
                return NotFound($"Ad with id: {id} was not found!");

            _context.Ads.Remove(deleteAd);
            await _context.SaveChangesAsync();
            return Ok(deleteAd);
        }
    }
}
