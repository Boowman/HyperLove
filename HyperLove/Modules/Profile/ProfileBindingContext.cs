using System.Collections.Generic;
using HyperLove.Modules.Profile;

namespace HyperLove.Modules
{
    public class ProfileBindingContext
    {
        public List<ProfileRowList> RowsList { get; set; }

        public ProfileBindingContext()
        {
            var bProfileEdit = new ProfileRowList()
            {
            };
            bProfileEdit.Heading = "";

            var list = new List<ProfileRowList>()
            {
                bProfileEdit
            };

            RowsList = list;
        }
    }
}
