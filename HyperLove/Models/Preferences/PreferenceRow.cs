using Xamarin.Forms;

namespace HyperLove.Modules.Preferences
{
    public class PreferenceRow
    {
        public string Title { get; set; }
        public string Selection { get; set; }

        public bool DealBreaker { get; set; }
        public bool Premium { get; set; }

        public ContentPage Modal { get; set; }

        public bool IsSelected { get; set; }

        public bool CheckPremium {  get { return (Premium) ? ((App.CurrentUser.Premium) ? true : false) : true; } }

        public bool IsLocked     {  get { return (Premium) ? ((App.CurrentUser.Premium) ? false : true) : false; } }
    }
}
