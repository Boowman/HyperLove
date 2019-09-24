using System;
using System.Collections.Generic;

using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.PancakeView;

using HyperLove.ViewModel;
using HyperLove.Models.Profile;
using HyperLove.Models.User;

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

        private DisplayInfo deviceSize = DeviceDisplay.MainDisplayInfo;
        private float ySize = 0.0f;
        private float yPos  = 0.105f;

        private UserInfoTemplates templates;
        private UserProfile currentUserProfile;

        public SearchView()
        {
            InitializeComponent();
            templates = new UserInfoTemplates();

            //ui_profiles_display.Children.Insert(0, new SearchProfile(App.SearchingProfiles[0], this, ui_image_selection));
            //currentUserProfile = App.SearchingProfiles[0];

            ViewingNewUser();

            ui_user_info.Margin = new Thickness(0, deviceSize.Height / deviceSize.Density, 0, 0);
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

                ui_user_name.Text = currentUserProfile.UserBase.First + " " + currentUserProfile.UserBase.Last + ", " + currentUserProfile.GetAge().ToString();
                ui_user_location.Text = currentUserProfile.Location.City + ", " + currentUserProfile.Location.Country;
                ui_user_job.Text = currentUserProfile.Carrer.Title;

                /* Preferences */
                if (currentUserProfile.Preferences.Available())
                {
                    templates.PreferencesSetup(currentUserProfile.Preferences, ui_user_preferences_list);
                }
                else
                {
                    ui_user_preferences_list.IsVisible = false;
                }

                /* Spotify */
                if (currentUserProfile.Spotify.Verified)
                {
                    ui_user_spotify_albums.Children.Clear();

                    SpotifyAlbums = currentUserProfile.GetSpotifyAlbums();
                    templates.SpotifyAlbumsSetup(SpotifyAlbums, ui_user_spotify_albums);

                    ui_spotify_menu.IsVisible = true;
                }
                else
                {
                    ui_spotify_menu.IsVisible = false;
                }

                /* Instagram */
                if (currentUserProfile.Instagram.Verified)
                {
                    ui_user_instagram_images.Children.Clear();

                    InstagramImages = currentUserProfile.GetInstagramImages();
                    templates.InstagramImagesSetup(InstagramImages, ui_user_instagram_images);

                    ui_instagram_menu.IsVisible = true;
                }
                else
                {
                    ui_instagram_menu.IsVisible = false;
                }

                /* Quotes */
                if (currentUserProfile.Quotes.Count != 0)
                {
                    ui_user_quotes_list.Children.Clear();
                    templates.QuotesSetup(currentUserProfile.Quotes, ui_user_quotes_list);

                    ui_user_quotes_list.IsVisible = true;
                }
                else
                    ui_user_quotes_list.IsVisible = false;

                /* Hide All Other Profiles */
                //for (int x = ui_profiles_display.Children.Count - 2; x >= 0; --x)
                //{
                //    ui_profiles_display.Children[x].IsVisible = false;
                //}

                /* Show The Profiles Menu */
                ui_profile_root.IsVisible = true;
            }    
        }

        public void ViewingNewUser()
        {
            if(currentUserProfile != null)
            {
                int count = ui_image_selection.Children.Count - currentUserProfile.Images.Count;
                count = Math.Abs((count == 0) ? 0 : count);

                foreach (View item in ui_image_selection.Children)
                    item.Opacity = 0.5f;

                for (int x = 0; x < count; x++)
                {
                    PancakeView tempView = new PancakeView();
                    tempView.WidthRequest = 18;
                    tempView.HeightRequest = 7.5;
                    tempView.CornerRadius = 15;
                    tempView.Opacity = 0.5f;

                    tempView.BackgroundColor = Color.FromRgb(255, 255, 255);

                    ui_image_selection.Children.Insert(0, tempView);
                }

                ui_image_selection.Children[0].Opacity = 1.0f;
            }
        }

        private void LovedUser(object sender, EventArgs e)
        {
            App.SearchingProfiles.RemoveAt(0);
            ui_profiles_display.Children.RemoveAt(0);

            if (App.SearchingProfiles.Count > 0)
            {
                ui_profiles_display.Children.Insert(0, new SearchProfile(App.SearchingProfiles[0], this, ui_image_selection));
                currentUserProfile = App.SearchingProfiles[0];
                ViewingNewUser();
            }
            else
            {
                // Add Loading New Users Animation
            };

            ui_profile_root.IsVisible = false;
        }

        private void DislikedUser(object sender, EventArgs e)
        {
            App.SearchingProfiles.RemoveAt(0);
            ui_profiles_display.Children.RemoveAt(0);

            if (App.SearchingProfiles.Count > 0)
            {
                ui_profiles_display.Children.Insert(0, new SearchProfile(App.SearchingProfiles[0], this, ui_image_selection));
                currentUserProfile = App.SearchingProfiles[0];
                ViewingNewUser();
            }
            else
            {
                // Add Loading New Users Animation
            }


            ui_profile_root.IsVisible = false;
        }

        private void LikedUser(object sender, EventArgs e)
        {
            App.SearchingProfiles.RemoveAt(0);
            ui_profiles_display.Children.RemoveAt(0);

            if (App.SearchingProfiles.Count > 0)
            {
                ui_profiles_display.Children.Insert(0, new SearchProfile(App.SearchingProfiles[0], this, ui_image_selection));
                currentUserProfile = App.SearchingProfiles[0];
                ViewingNewUser();
            }
            else
            {
                // Add Loading New Users Animation
            }

            ui_profile_root.IsVisible = false;
        }
    }
}