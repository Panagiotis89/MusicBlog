using MyMusic.Core.Repositories;
using MyMusic.Data.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyMusicDbContext _mymusicDbContext;
        //δεν τα ορίζουμε με dependency injection γτ θα αρχικοποιούνταν το καθε service
        //με ένα ξεχωριστό αντικείμενο βάσης.
        //Με αυτόν τον τρόπο πετυχαίνουμε να αρχικοποιούνται με το ίδιο dbcontext 
        private MusicRepository _musicReposotiry;
        private ArtistRepository _artistRepository;
        public IMusicRepository Musics => _musicReposotiry ?? new MusicRepository(_mymusicDbContext);

        public IArtistRepository Artists => _artistRepository ?? new ArtistRepository(_mymusicDbContext);


        public async Task<int> CommitAsync()
        {
            return await _mymusicDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _mymusicDbContext.Dispose();
        }
    }
}
