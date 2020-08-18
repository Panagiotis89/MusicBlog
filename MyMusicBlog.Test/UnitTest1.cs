using MyMusic.Services;
using MyMusicBlog.Test.Mocks.Services;

namespace MyMusicBlog.Test
{
    public class Tests
    {
        private readonly MusicServiceTests _musicServiceTest;
        public Tests(MusicServiceTests musicServiceTest)
        {
            _musicServiceTest = musicServiceTest;
        }

       // [SetUp]
        public void Setup()
        {
        }

        //[Test]
        public void Test1()
        {
            _musicServiceTest.MusicService_GetAllByArtistId_ValidArtistId();
            //Assert.Pass();
        }
    }
}