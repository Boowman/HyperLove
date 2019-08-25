using System.Collections.Generic;

namespace HyperLove.Modules.Preferences
{
    public class PreferenceRowList : List<PreferenceRow>
    {
        public string Heading { get; set; }
        public bool Premium { get; set; }

        public bool CheckPremium { get { return (Premium) ? ((App.CurrentUser.Premium) ? false : true) : false; } }

        public List<PreferenceRow> Preferences => this;
    }
}
