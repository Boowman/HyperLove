using System.Collections.Generic;

namespace HyperLove.Models.User
{
    public class UserSwipes
    {
        public List<string> Matches { get; set; }
        public List<string> Loves { get; set; }
        public List<string> Likes { get; set; }
        public List<string> Dislikes { get; set; }
    }
}
