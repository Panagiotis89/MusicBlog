using MyMusic.Core.Models;
using MyMusic.Core.Repositories;
using MyMusic.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Services
{
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MusicService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Music> CreateMusic(Music newMusic)
        {
            await _unitOfWork.Musics.AddAsync(newMusic);
            await _unitOfWork.CommitAsync();
            return newMusic;
        }

        public async Task DeleteMusic(Music music)
        {
            _unitOfWork.Musics.Remove(music);
            await _unitOfWork.CommitAsync();
        }

        public async Task<IReadOnlyList<Music>> GetAllByArtistId(int artistId)
        {
            var isValid = await _unitOfWork.Musics.IsValid(x => x.ArtistId == artistId);

            return isValid ? await _unitOfWork.Musics.GetAllWithArtistByArtistIdAsync(artistId) : new List<Music>().AsReadOnly();
        }

        public async Task<IReadOnlyList<Music>> GetAllWithArtists()
        {
            return await _unitOfWork.Musics.GetAllMusicWithArtistAsync();
        }

        public async Task<Music> GetMusicById(int Id)
        {
            return await _unitOfWork.Musics.GetByIdAsync(Id);
        }

        public async Task UpdateMusic(Music musicToBeUpdated, Music music)
        {
            musicToBeUpdated.Name = music.Name;
            musicToBeUpdated.ArtistId = music.ArtistId;
            await _unitOfWork.CommitAsync();
        }
    }
}
