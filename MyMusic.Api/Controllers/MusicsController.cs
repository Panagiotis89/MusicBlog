using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyMusic.Core.Models;
using MyMusic.Core.Services;

namespace MyMusic.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicsController : ControllerBase
    {
        private readonly IMusicService _musicService;

        public MusicsController(IMusicService musicService)
        {
            _musicService = musicService;
        }


        //api/musics
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Music>>> GetAllMusics()
        {
            var musics = _musicService.GetAllWithArtists();
            return Ok(musics);
        }

        //api/updatemusic
    }
}