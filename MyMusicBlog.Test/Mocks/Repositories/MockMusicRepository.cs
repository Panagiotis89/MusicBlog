using Moq;
using MyMusic.Core.Models;
using MyMusic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyMusicBlog.Test.Mocks.Repositories
{
   public class MockMusicRepository : Mock<IMusicRepository>
    {
        public MockMusicRepository MockGetWithArtistById(Music result)
        {
            Setup(x => x.GetWithArtistByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(result);

            return this;
        }

        public MockMusicRepository MockIsValid(bool result)
        {
            Setup(x => x.IsValid(It.IsAny<Expression<Func<Music, bool>>>()))
                .ReturnsAsync(result);

            return this;
        }

        public MockMusicRepository VerifyIsValid(Times times)
        {
            Verify(x => x.IsValid(It.IsAny<Expression<Func<Music, bool>>>()), times);

            return this;
        }

        public MockMusicRepository MockGetAllWithArtistByArtistId(IReadOnlyList<Music> result)
        {
            Setup(x => x.GetAllWithArtistByArtistIdAsync(It.IsAny<int>()))
                .ReturnsAsync(result);

            return this;
        }

        public MockMusicRepository VerifyGetAllWithArtistByArtistId(Times times)
        {
            Verify(x => x.GetAllWithArtistByArtistIdAsync(It.IsAny<int>()), times);

            return this;
        }
    }
}
