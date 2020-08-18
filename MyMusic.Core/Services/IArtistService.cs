using MyMusic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Core.Services
{
   public interface IArtistService
    {
        Task<IReadOnlyList<Artist>> GetAllArtist();
        Task<Artist> GetArtistById(int Id);
        Task<Artist> CreateArtist(Artist artist);
        Task UpdateArtist(Artist artistToBeUpdated, Artist artist);
        Task DeleteArtist(Artist artist);

    }
}
