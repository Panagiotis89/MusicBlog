using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyMusic.Core.Models
{
  public class Post
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public string MusicId { get; set; }
        //we put a navigation for Music to obtain the corellated Music object
        //when we get a Post. Otherwise we would need to make an extra query to 
        //get the Music entity using the MusicId. If we not use the MusicId property
        //and use only the Music navigation property, entity framework will create the MusicId
        //column in database table
        public Music Music { get; set; }
        public ICollection<Comment> Comments { get; set; }
        //we dont put virtual keyword to the navigation property because 
        //we dont want to enable lazy loading

        public Post() => Comments = new Collection<Comment>();
    }
}
