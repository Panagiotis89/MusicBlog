using Moq;
using MyMusic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusicBlog.Test.Mocks.Repositories
{
   public class MockUnitOfWork : Mock<IUnitOfWork>
    {
       public MockUnitOfWork InitializeMusicRepo(IMusicRepository musicRepo)
       {
            Setup(x => x.Musics).Returns(musicRepo);
            return this;
       }

        public MockUnitOfWork InitializeArtistRepo(IArtistRepository artistRepo)
        {
            Setup(x => x.Artists).Returns(artistRepo);
            return this;
        }
    }
}
