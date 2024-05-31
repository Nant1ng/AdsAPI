using AdsAPI.Data;
using AdsAPI.Data.Models;
using Microsoft.AspNetCore.JsonPatch;
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

        /// <summary>
        /// Retrieves all ads.
        /// </summary>
        /// <returns>A list of ads.</returns>
        /// <response code="200">Returns the list of ads.</response>
        [HttpGet]
        public async Task<ActionResult<List<Ad>>> GetAll()
        {
            var ads = await _context.Ads.ToListAsync();

            return Ok(ads);
        }

        /// <summary>
        /// Retrieves a specific ad by unique id.
        /// </summary>
        /// <param name="id">The id of the ad.</param>
        /// <returns>The ad with the specified id.</returns>
        /// <response code="200">Returns the ad with the specified id.</response>
        /// <response code="404">If the ad is not found.</response>
        [HttpGet("{id}")]
        public async Task<ActionResult<Ad>> GetOne(int id)
        {
            var ad = await _context.Ads.FindAsync(id);

            if (ad == null)
                return NotFound($"Ad with id: {id} was not found!");

            return Ok(ad);
        }

        /// <summary>
        /// Creates a new ad.
        /// </summary>
        /// <param name="ad">The ad to create.</param>
        /// <returns>The created ad.</returns>
        /// <response code="200">Returns the created ad.</response>
        /// <response code="400">If the ad is invalid.</response>
        [HttpPost]
        public async Task<ActionResult<Ad>> PostAd(Ad ad)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _context.Ads.Add(ad);
            await _context.SaveChangesAsync();

            return Ok(ad);
        }

        /// <summary>
        /// Updates an ad.
        /// </summary>
        /// <param name="id">The id of the ad to update.</param>
        /// <param name="updatedAd">The updated ad.</param>
        /// <returns>The updated ad.</returns>
        /// <response code="200">Returns the updated ad.</response>
        /// <response code="404">If the ad is not found.</response>
        [HttpPut("{id}")]
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

        /// <summary>
        /// Applies a JSON patch to an existing ad.
        /// </summary>
        /// <param name="id">The id of the ad to update.</param>
        /// <param name="ad">The JSON patch document containing the changes to apply.</param>
        /// <returns>The updated ad.</returns>
        /// <response code="200">Returns the updated ad.</response>
        /// <response code="404">If the ad is not found.</response>
        [HttpPatch("{id}")]
        public async Task<ActionResult<Ad>> PatchAd(int id, JsonPatchDocument ad)
        {
            var adToUpdate = await _context.Ads.FindAsync(id);

            if (adToUpdate == null)
                return NotFound($"Ad with id: {id} was not found!");

            ad.ApplyTo(adToUpdate);
            await _context.SaveChangesAsync();

            return Ok(ad);
        }

        /// <summary>
        /// Deletes an ad.
        /// </summary>
        /// <param name="id">The id of the ad to delete.</param>
        /// <returns>The deleted ad.</returns>
        /// <response code="200">Returns the deleted ad.</response>
        /// <response code="404">If the ad is not found.</response>
        [HttpDelete("{id}")]
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
