using AdsAPI.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AdsAPI.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _context;

        public DataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void MigrateData()
        {
            _context.Database.Migrate();
            SeedData();
            _context.SaveChanges();
        }

        private void SeedData()
        {
            if (!_context.Ads.Any(e => e.Id == 1))
            {
                _context.Add(new Ad
                {
                    Title = "Anställningsbar",
                    Author = "Kalk Rikkardson",
                    Description = "Vi på Systementor försöker froma alla våra elever så att de blir anställningsbara.",
                    PublishedDate = DateOnly.FromDateTime(DateTime.Now)
                });
            }
        }
    }
}
