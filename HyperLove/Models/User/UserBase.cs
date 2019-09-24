using System;

namespace HyperLove.Models.User
{
    public class UserBase
    {
        public string ID { get; set; }

        public string First { get; set; }

        public string Last { get; set; }

        public string Avatar { get; set; }

        public DateTime Birthday { get; set; } 
    }
}
