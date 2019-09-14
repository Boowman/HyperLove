using System;
using System.Collections.Generic;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PancakeView;

using HyperLove.Modules.User;
using HyperLove.Views;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HyperLove.ViewModel;
using HyperLove.Models.Profile;

namespace HyperLove
{
    [System.Serializable]
    public class SpotifyAlbum
    {
        public string Label { get; set; }
        public string Image { get; set; }
    }

    [System.Serializable]
    public class InstagramPicture
    {
        public string Label { get; set; }
        public string Image { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchView : ContentPage
    {
        public List<SpotifyAlbum> SpotifyAlbums { get; set; }

        private List<InstagramPicture> InstagramImages { get; set; }

        private int current_image = 0;

        private DisplayInfo deviceSize = DeviceDisplay.MainDisplayInfo;
        private float ySize = 0.0f;
        private float yPos  = 0.105f;

        private UserInfoTemplates templates;

        public SearchView()
        {
            InitializeComponent();
            templates = new UserInfoTemplates();

            for(int x = 0; x < 5; x++)
            {
                if(x < App.SearchingProfiles.Count)
                    ui_profiles_display.Children.Add(new SearchProfile(App.SearchingProfiles[x], this, ui_image_selection));
            }

            ViewingNewUser();

            ui_user_info.Margin = new Thickness(0, deviceSize.Height / deviceSize.Density - 220, 0, 0);
        }

        private void Ui_scroll_menu_Scrolled(object sender, ScrolledEventArgs e)
        {
            ScrollView scrollView = sender as ScrollView;

            ySize = ((float)(scrollView.ScrollY / 1030) * 0.2f);
            yPos = (float)Math.Round(((float)(scrollView.ScrollY / 1030) * 0.025f), 3);

            AbsoluteLayout.SetLayoutBounds(ui_scroll_bar, new Rectangle(0.97, 0.105f + yPos, 0.018f, ySize));
        }

        private void UIOpenChatMessage(object sender, EventArgs e)
        {
            Console.WriteLine("View Chat Messages Menu");
        }

        private void UIOpenSettingsMenu(object sender, EventArgs e)
        {
            Console.WriteLine("View Settings Menu");
        }

        public void ViewProfile()
        {
            if(App.SearchingProfiles.Count > 0)
            {
                if (templates == null)
                    throw new System.ArgumentException("The `Templates` variable cannot be NULL", "templates");

                ui_user_name.Text       = App.SearchingProfiles[0].First + " " + App.SearchingProfiles[0].Last + ", " + App.SearchingProfiles[0].Age.ToString();
                ui_user_location.Text   = App.SearchingProfiles[0].Location.City + ", " + App.SearchingProfiles[0].Location.Country;  
                ui_user_job.Text        = App.SearchingProfiles[0].Job;

                /* Preferences */
                if(App.SearchingProfiles[0].Preferences.Available())
                {
                    templates.PreferencesSetup(App.SearchingProfiles[0].Preferences, ui_user_preferences_list);
                }
                else
                {
                    ui_user_preferences_list.IsVisible = false;
                }

                /* Spotify */
                if (App.SearchingProfiles[0].Spotify.Verified)
                {
                    ui_user_spotify_albums.Children.Clear();

                    SpotifyAlbums = App.SearchingProfiles[0].GetSpotifyAlbums();
                    templates.SpotifyAlbumsSetup(SpotifyAlbums, ui_user_spotify_albums);

                    ui_spotify_menu.IsVisible = true;
                }
                else
                {
                    ui_spotify_menu.IsVisible = false;
                }

                /* Instagram */
                if (App.SearchingProfiles[0].Instagram.Verified)
                {
                    ui_user_instagram_images.Children.Clear();

                    InstagramImages = App.SearchingProfiles[0].GetInstagramImages();
                    templates.InstagramImagesSetup(InstagramImages, ui_user_instagram_images);

                    ui_instagram_menu.IsVisible = true;
                }
                else
                {
                    ui_instagram_menu.IsVisible = false;
                }

                /* Quotes */
                if (App.SearchingProfiles[0].Quotes.Count != 0)
                {
                    ui_user_quotes_list.Children.Clear();
                    templates.QuotesSetup(App.SearchingProfiles[0].Quotes, ui_user_quotes_list);

                    ui_user_quotes_list.IsVisible = true;
                }
                else
                    ui_user_quotes_list.IsVisible = false;

                /* Hide All Other Profiles */
                for (int x = 2; x < ui_profiles_display.Children.Count; x++)
                {
                    ui_profiles_display.Children[x].IsVisible = false;
                }

                /* Show The Profiles Menu */
                ui_profile_root.IsVisible = true;
                Console.Write("SearchView ViewProfile");
            }    
        }

        public void ViewingNewUser()
        {
            ui_image_selection.Children.Clear();

            foreach (string s in App.SearchingProfiles[0].Images)
            {
                PancakeView tempView    = new PancakeView();
                tempView.WidthRequest   = 13;
                tempView.HeightRequest  = 13;
                tempView.CornerRadius   = 13;
                tempView.Opacity        = 0.5f;

                tempView.BackgroundColor = Color.FromRgb(255, 255, 255);

                ui_image_selection.Children.Add(tempView);
            }

            ui_image_selection.Children[0].Opacity = 1.0f;
        }

        private void LovedUser(object sender, EventArgs e)
        {
            App.SearchingProfiles.RemoveAt(0);
            ui_profiles_display.Children.RemoveAt(0);

            for (int x = 2; x < ui_profiles_display.Children.Count; x++)
            {
                ui_profiles_display.Children[x].IsVisible = true;
            }

            if (App.SearchingProfiles.Count > 4)
                ui_profiles_display.Children.Add(new SearchProfile(App.SearchingProfiles[5], this, ui_image_selection));
            else
            {
                if(App.SearchingProfiles.Count - 1 >= 0)
                    ui_profiles_display.Children.Add(new SearchProfile(App.SearchingProfiles[App.SearchingProfiles.Count - 1], this, ui_image_selection));
                else
                    ui_profiles_display.Children.Add(new SearchProfile(App.SearchingProfiles[0], this, ui_image_selection));
            }

            ui_profile_root.IsVisible = false;
        }

        private void DislikedUser(object sender, EventArgs e)
        {
            App.SearchingProfiles.RemoveAt(0);
            ui_profiles_display.Children.RemoveAt(0);

            for (int x = 2; x < ui_profiles_display.Children.Count; x++)
            {
                ui_profiles_display.Children[x].IsVisible = true;
            }

            if (App.SearchingProfiles.Count > 4)
                ui_profiles_display.Children.Add(new SearchProfile(App.SearchingProfiles[5], this, ui_image_selection));
            else
            {
                if (App.SearchingProfiles.Count - 1 >= 0)
                    ui_profiles_display.Children.Add(new SearchProfile(App.SearchingProfiles[App.SearchingProfiles.Count - 1], this, ui_image_selection));
                else
                    ui_profiles_display.Children.Add(new SearchProfile(App.SearchingProfiles[0], this, ui_image_selection));
            }

            ui_profile_root.IsVisible = false;
        }

        private void LikedUser(object sender, EventArgs e)
        {
            App.SearchingProfiles.RemoveAt(0);
            ui_profiles_display.Children.RemoveAt(0);

            for (int x = 2; x < ui_profiles_display.Children.Count; x++)
            {
                ui_profiles_display.Children[x].IsVisible = true;
            }

            if (App.SearchingProfiles.Count > 4)
                ui_profiles_display.Children.Add(new SearchProfile(App.SearchingProfiles[5], this, ui_image_selection));
            else
            {
                if (App.SearchingProfiles.Count - 1 >= 0)
                    ui_profiles_display.Children.Add(new SearchProfile(App.SearchingProfiles[App.SearchingProfiles.Count - 1], this, ui_image_selection));
                else
                    ui_profiles_display.Children.Add(new SearchProfile(App.SearchingProfiles[0], this, ui_image_selection));
            }

            ui_profile_root.IsVisible = false;
        }
    }
}