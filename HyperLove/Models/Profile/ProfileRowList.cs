using System.Collections.Generic;

namespace HyperLove.Modules.Profile
{
    public class ProfileRowList : List<ProfileRow>
    {
        public string Heading { get; set; }

        public List<ProfileRow> ProfileRows => this;
    }
}
