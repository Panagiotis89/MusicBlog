using MyMusic.Core.Models;
using MyMusic.Core.Repositories;
using MyMusic.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArtistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Artist> CreateArtist(Artist artist)
        {
            await _unitOfWork.Artists.AddAsync(artist);
            await _unitOfWork.CommitAsync();
            return artist;
        }

        public async Task DeleteArtist(Artist artist)
        {
            _unitOfWork.Artists.Remove(artist);
            await _unitOfWork.CommitAsync();

        }

        public async Task<IReadOnlyList<Artist>> GetAllArtist()
        {
            return await _unitOfWork.Artists.GetAllAsync();
        }

        public async Task<Artist> GetArtistById(int Id)
        {
            return await _unitOfWork.Artists.GetByIdAsync(Id);
        }

        public async Task UpdateArtist(Artist artistToBeUpdated, Artist artist)
        {
            artistToBeUpdated.Name = artist.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
