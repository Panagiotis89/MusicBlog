using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Moq;
using MyMusic.Core.Models;
using MyMusic.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MyMusicBlog.Test.Mocks.Repositories
{
   public class MockArtistRepository : Mock<IArtistRepository>
    {
        public MockArtistRepository MockGetWithMusicsById(Artist result)
        {
            Setup(x => x.GetWithMusicsByIdAsync(It.IsAny<int>()))
                .ReturnsAsync(result);

            return this;
        }

        public MockArtistRepository MockIsValid(bool result)
        {
            //for any type Expression<Func<Artist,bool>> return the result
            //In Service function wherever isValid() is called, the mocked MockIsValid
            //will be called
            Setup(x => x.IsValid(It.IsAny<Expression<Func<Artist, bool>>>()))
                .ReturnsAsync(result);

            return this;
        }
    }
}
