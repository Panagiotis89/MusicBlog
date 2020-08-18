using MyMusic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Core.Repositories
{
   public interface IMusicRepository : IRepository<Music>
    {
        Task<IReadOnlyList<Music>> GetAllMusicWithArtistAsync();
        Task<Music> GetWithArtistByIdAsync(int musicId);
        Task<IReadOnlyList<Music>> GetAllWithArtistByArtistIdAsync(int artistId);
    }
}
