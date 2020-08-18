using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyMusic.Core.Models
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Music> Musics { get; set; }

        public Artist()
        {
            Musics = new Collection<Music>();
        }

    }
}