using Microsoft.EntityFrameworkCore;
using MyMusic.Core.Models;
using MyMusic.Core.Repositories;
using MyMusic.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Data.Repositories
{
   public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        private MyMusicDbContext _artistDbContext => _dbContext as MyMusicDbContext;
        public ArtistRepository(MyMusicDbContext artistDbContext) : base(artistDbContext) { }
        public async Task<IReadOnlyList<Artist>> GetAllWithMusicsAsync()
        {
            return await _artistDbContext.Artists
                                         .Include(a => a.Musics)
                                         .ToListAsync();
        }

        public async Task<Artist> GetWithMusicsByIdAsync(int artistId)
        {
            return await _artistDbContext.Artists
                                         .Include(a => a.Musics)
                                         .SingleOrDefaultAsync(m => m.Id == artistId);
        }
    }
}
