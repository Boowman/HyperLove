using Xamarin.Forms;

namespace HyperLove.Modules.Account
{
    public class AccountRow
    {
        public string Title { get; set; }

        public string URL { get; set; }
        public bool Link { get; set; }

        public bool Switch { get; set; }
        public bool Switched { get; set; }
        public bool Connect { get; set; }
        public bool Entry { get; set; }

        public ContentPage Modal { get; set; }

        public bool IsSelected { get; set; }
    }
}
