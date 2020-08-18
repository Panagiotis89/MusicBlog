using MyMusic.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Core.Services
{
   public interface IMusicService
    {
        Task<IReadOnlyList<Music>> GetAllWithArtists();
        Task<Music> GetMusicById(int Id);
        Task<IReadOnlyList<Music>> GetAllByArtistId(int artistid);
        Task<Music> CreateMusic(Music newMusic);
        Task UpdateMusic(Music musicToBeUpdated, Music music);
        Task DeleteMusic(Music music);
    }
}
