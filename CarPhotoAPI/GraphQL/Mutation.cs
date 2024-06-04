using HotChocolate;
using HotChocolate.Data;
using CarPhotoAPI.Data;
using CarPhotoAPI.Models;
using System.Threading.Tasks;

namespace CarPhotoAPI.GraphQL
{
    public class Mutation
    {
        public async Task<Car> CreateCarAsync([Service] CarPhotoContext context, string name, int photoId, bool status){
            var carro = new Car {
                PhotoId = photoId,
                Name = name,
                Status = status
            };

            await context.Cars.AddAsync(carro);
            await context.SaveChangesAsync();
            return carro;
        }

        public async Task<Car> AtualizarCarAsync([Service] CarPhotoContext context, int id, int? photoId, string? name, bool? status)
        {
            var carro = await context.Cars.FindAsync(id);
            if (carro == null)
            {
                throw new GraphQLException(new Error("Car not found.", "CAR_NOT_FOUND"));
            }

            if (!string.IsNullOrEmpty(name))
            {
                carro.Name = name;
            }

            if (photoId.HasValue)
            {
                carro.PhotoId = photoId.Value;
            }

            if (status.HasValue)
            {
                carro.Status = status.Value;
            }

            context.Cars.Update(carro);
            await context.SaveChangesAsync();
            return carro;
        }

        public async Task<bool> ExcluirCarAsync([Service] CarPhotoContext context, int id)
        {
            var carro = await context.Cars.FindAsync(id);
            if (carro == null)
            {
                throw new GraphQLException(new Error("Car not found", "CAR_NOT_FOUND"));
            }

            context.Cars.Remove(carro);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Photo> CreatePhotoAsync([Service] CarPhotoContext context, string base64string){
            var foto = new Photo {
                Base64 = base64string
            };

            await context.Photos.AddAsync(foto);
            await context.SaveChangesAsync();
            return foto;
        }


        public async Task<Photo> AtualizarPhotoAsync([Service] CarPhotoContext context, int id, string base64string)
        {
            var foto = await context.Photos.FindAsync(id);
            if (foto == null)
            {
                throw new GraphQLException(new Error("Photo not found", "PHOTO_NOT_FOUND"));
            }

            foto.Base64 = base64string;

            context.Photos.Update(foto);
            await context.SaveChangesAsync();
            return foto;
        }

        public async Task<bool> ExcluirPhotoAsync([Service] CarPhotoContext context, int id)
        {
            var foto = await context.Photos.FindAsync(id);
            if (foto == null)
            {
                throw new GraphQLException(new Error("Photo not found", "PHOTO_NOT_FOUND"));
            }

            context.Photos.Remove(foto);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
