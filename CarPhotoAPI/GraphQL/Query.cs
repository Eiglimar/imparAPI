using HotChocolate;
using HotChocolate.Data;
using CarPhotoAPI.Data;
using CarPhotoAPI.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace CarPhotoAPI.GraphQL
{
    public class Query
    {
        public async Task<List<Photo>> AllPhotosAsync([Service] CarPhotoContext context){
            return await context.Photos.ToListAsync();
        }

        public async Task<List<Car>> AllCarsAsync([Service] CarPhotoContext context){
            return await context.Cars.ToListAsync();
        }

        
        public async Task<List<Car>> AllCarsWithPhotosAsync([Service] CarPhotoContext context)
        {
            return await context.Cars
                                .Include(c => c.Photo)
                                .ToListAsync();
        }

        public async Task<Car?> PegaCarPorIdAsync([Service] CarPhotoContext context, int id)
        {
            return await context.Cars
                                .Include(c => c.Photo)
                                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
