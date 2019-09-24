using System.Collections.Generic;

namespace HyperLove.Services.Facebook
{
    public class FacebookAlbum
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public Dictionary<string, string> Images { get; set; }
        public Dictionary<string, string> Thumbnails { get; set; }
    }
}
