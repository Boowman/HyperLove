using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HyperLove.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileView : ContentView
    {
        private DisplayInfo deviceSize = DeviceDisplay.MainDisplayInfo;
        private float ySize = 0.0f;
        private float yPos = 0.08f;

        public ProfileView()
        {
            InitializeComponent();
            ui_user_info.Margin         = new Thickness(0, deviceSize.Height / deviceSize.Density, 0, 0);
        }

        private void Ui_scroll_menu_Scrolled(object sender, ScrolledEventArgs e)
        {
            ScrollView scrollView = sender as ScrollView;

            ySize = ((float)(scrollView.ScrollY / 1030) * 0.2f);
            yPos = (float)Math.Round(((float)(scrollView.ScrollY / 1030) * 0.022f), 3);

            AbsoluteLayout.SetLayoutBounds(ui_scroll_bar, new Rectangle(0.97, 0.078f + yPos, 0.01, ySize));
        }
    }
}