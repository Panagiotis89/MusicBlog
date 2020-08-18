using Moq;
using MyMusic.Core.Models;
using MyMusic.Core.Repositories;
using MyMusic.Services;
using MyMusicBlog.Test.Mocks.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MyMusicBlog.Test.Mocks.Services
{
   public class MusicServiceTests
    {
        [Fact]
        public void MusicService_GetAllByArtistId_ValidArtistId() //when id is valid
        {
            var mockMusic = GetMusics();
            //Arrange
            //var mockUnitOfWork = new MockUnitOfWork();
            //mockUnitOfWork.Musics.MockIsValid(true)
            //                     .MockGetAllWithArtistByArtistId(mockMusic);
            var mockMusicRepo = new MockMusicRepository()
                                    .MockIsValid(true)
                                    .MockGetAllWithArtistByArtistId(mockMusic);

            //var mockUnitOfWork = new Mock<IUnitOfWork>();
            //mockUnitOfWork.Setup(x => x.Musics).Returns(mockMusicRepo.Object);
            var mockUnitOfWork = new MockUnitOfWork();
            mockUnitOfWork.InitializeMusicRepo(mockMusicRepo.Object);

            var musicService = new MusicService(mockUnitOfWork.Object);

            //Act
            var listOfMusic =  musicService.GetAllByArtistId(1).Result;

            //Assert
            Assert.NotEmpty(listOfMusic);
            mockMusicRepo.VerifyIsValid(Times.Once());
            mockMusicRepo.VerifyGetAllWithArtistByArtistId(Times.Once());
        }

        private IReadOnlyList<Music> GetMusics()
        {
            return new List<Music>
            {
                new Music
                {
                    Name = "District Zero",
                    ArtistId = 1
                },
                new Music
                {
                    Name = "Courage of fools",
                    ArtistId = 2
                },
                new Music
                {
                    Name = "Burning bridges",
                    ArtistId = 3 
                }
            };
        }
    }
}
