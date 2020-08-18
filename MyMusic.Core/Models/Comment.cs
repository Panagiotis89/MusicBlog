using System;
using System.Collections.Generic;
using System.Text;

namespace MyMusic.Core.Models
{
   public class Comment
    {
        public string Id { get; set; }

        public string Content { get; set; }

        public string PostId { get; set; }
        public Post Post { get; set; }
        //we secify a required relationship between the two entities(Post / Comments)
    }
}
