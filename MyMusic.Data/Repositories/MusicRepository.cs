using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Models;
using MyMusic.Core.Repositories;
using MyMusic.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Data.Repositories
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {

        private MyMusicDbContext _musicDbContext => _dbContext as MyMusicDbContext; 


        public MusicRepository(MyMusicDbContext musicDbContext) : base(musicDbContext) { }
        public async Task<IReadOnlyList<Music>> GetAllMusicWithArtistAsync()
        {
            return await _musicDbContext.Musics
                                        .Include(x => x.Artist)
                                        .ToListAsync();
        }

        public async Task<IReadOnlyList<Music>> GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await _musicDbContext.Musics.Include(x => x.Artist)
                                               .Where(a => a.ArtistId == artistId)
                                               .ToListAsync();
        }

        public async Task<Music> GetWithArtistByIdAsync(int musicId)
        {
            return await _musicDbContext.Musics
                                        .Include(x => x.Artist)
                                        .SingleOrDefaultAsync(m => m.Id == musicId);
        }
    }
}
