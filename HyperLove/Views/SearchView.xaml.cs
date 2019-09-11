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

        private List<string> images;
        private int current_image = 0;

        private DisplayInfo deviceSize = DeviceDisplay.MainDisplayInfo;
        private float ySize = 0.0f;
        private float yPos  = 0.105f;

        public SearchView()
        {
            InitializeComponent();

            SpotifyAlbums = new List<SpotifyAlbum>();

            SpotifyAlbums.Add(new SpotifyAlbum { Label = "Travis Scott",        Image = "travis_scott" });
            SpotifyAlbums.Add(new SpotifyAlbum { Label = "The Weekend",         Image = "the_weekend" });
            SpotifyAlbums.Add(new SpotifyAlbum { Label = "Chance The Rapper",   Image = "chance_the_rapper" });
            SpotifyAlbums.Add(new SpotifyAlbum { Label = "Sweet Sexy Jaslage",  Image = "sweet_sexy_jaslage" });
            SpotifyAlbums.Add(new SpotifyAlbum { Label = "Kanye West",          Image = "kanye_west" });
            SpotifyAlbums.Add(new SpotifyAlbum { Label = "Queen The Miracle",   Image = "queen_the_miracle" });

            InstagramImages = new List<InstagramPicture>();

            InstagramImages.Add(new InstagramPicture { Label = "Test 1", Image = "insta_1" });
            InstagramImages.Add(new InstagramPicture { Label = "Test 2", Image = "insta_2" });
            InstagramImages.Add(new InstagramPicture { Label = "Test 3", Image = "insta_3" });
            InstagramImages.Add(new InstagramPicture { Label = "Test 4", Image = "insta_4" });
            InstagramImages.Add(new InstagramPicture { Label = "Test 5", Image = "insta_5" });
            InstagramImages.Add(new InstagramPicture { Label = "Test 6", Image = "insta_6" });
            InstagramImages.Add(new InstagramPicture { Label = "Test 7", Image = "insta_7" });
            InstagramImages.Add(new InstagramPicture { Label = "Test 8", Image = "insta_8" });

            images = new List<string>();
            images.Add("image_1");
            images.Add("image_2");
            images.Add("image_3");
            images.Add("image_4");

            foreach(string s in images)
            {
                PancakeView tempView = new PancakeView();
                tempView.WidthRequest = 7.5f;
                tempView.HeightRequest = 7.5f;
                tempView.CornerRadius = 7.5f;
                tempView.BackgroundColor = Color.FromRgb(255, 255, 255);
                tempView.Opacity = 0.5f;

                ui_image_selection.Children.Add(tempView);
            }

            SpotifyAlbumsSetup();
            InstagramImagesSetup();

            //ui_profile_image.Source = images[current_image];
            ui_image_selection.Children[current_image].Opacity = 1.0f;

            ui_user_info.Margin = new Thickness(0, deviceSize.Height / deviceSize.Density, 0, 0);
        }

        private void SpotifyAlbumsSetup()
        {
            foreach(SpotifyAlbum album in SpotifyAlbums)
                ui_spotify_albums.Children.Add(SpotifyAlbumTemplate(album));
        }

        private StackLayout SpotifyAlbumTemplate(SpotifyAlbum album)
        {
            var layout = new StackLayout();
            layout.Orientation      = StackOrientation.Vertical;
            layout.VerticalOptions  = LayoutOptions.Fill;
            layout.Spacing = 0;

            var pancakeView = new PancakeView();
            pancakeView.CornerRadius = 5;
            pancakeView.HasShadow = true;
            pancakeView.IsClippedToBounds = true;
            pancakeView.HorizontalOptions = LayoutOptions.FillAndExpand;
            pancakeView.WidthRequest = 95;
            pancakeView.HeightRequest = 95;

            var image = new Image();
            image.Source = ImageSource.FromFile(album.Image + ".jpg");
            image.HorizontalOptions = LayoutOptions.FillAndExpand;
            image.VerticalOptions = LayoutOptions.FillAndExpand;
            image.Aspect = Aspect.AspectFill;

            var label = new Label();
            label.Text = album.Label;
            label.FontSize = 18;
            label.TextColor = Color.Black;
            label.LineBreakMode = LineBreakMode.TailTruncation;
            label.HorizontalOptions = LayoutOptions.FillAndExpand;
            label.VerticalOptions = LayoutOptions.StartAndExpand;
            label.WidthRequest = 75;

            //layout.Children.Add(pancakeView);
            layout.Children.Add(image);
            layout.Children.Add(label);

            return layout;
        }

        private void InstagramImagesSetup()
        {
            List<InstagramPicture> tempImgs = new List<InstagramPicture>();

            for (int index = (InstagramImages.Count - 1); index >= 0; --index)
            {
                tempImgs.Add(InstagramImages[index]);

                if(index % 6 == 0)
                {
                    Grid tempGrid = InstagramGroupTemplate(tempImgs);

                    ui_instagram_images.Children.Add(tempGrid);
                    ui_instagram_images.LowerChild(tempGrid);

                    tempImgs.Clear();
                }
            }
        }

        private Grid InstagramGroupTemplate(List<InstagramPicture> images)
        {
            var itemSize = 127;

            var grid = new Grid();
            grid.HorizontalOptions  = LayoutOptions.FillAndExpand;
            grid.VerticalOptions    = LayoutOptions.Start;
            grid.Margin             = new Thickness(10, 0, 10, 10);

            grid.RowDefinitions.Add(new RowDefinition()         { Height = itemSize });
            grid.RowDefinitions.Add(new RowDefinition()         { Height = itemSize });
            grid.ColumnDefinitions.Add(new ColumnDefinition()   { Width  = itemSize });
            grid.ColumnDefinitions.Add(new ColumnDefinition()   { Width  = itemSize });
            grid.ColumnDefinitions.Add(new ColumnDefinition()   { Width  = itemSize });

            for (int index = 0; index < images.Count; index++)
            { 
                var image = new Image();
                image.Source = ImageSource.FromFile(images[index].Image + ".jpg");
                image.Aspect = Aspect.AspectFill;

                grid.Children.Add(image);

                image.SetValue(Grid.RowProperty, index % 2);
                image.SetValue(Grid.ColumnProperty, index / 2);

                Console.WriteLine("Grid: " + images[index].Image + " - " + index % 2 + " - " + index / 2);
            }

            return grid;
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

        public void SetupProfileData(UserInfo user)
        {

        }

        private async void ViewProfile(object sender, EventArgs e)
        {
            await Task.WhenAll(
                //ui_user_name.TranslateTo(           -350, 0, 2000, Easing.BounceOut),
                //ui_user_quote_title.TranslateTo(    -350, 0, 2000, Easing.BounceOut),
                //ui_user_quote_desc.TranslateTo(     -350, 0, 2000, Easing.BounceOut),
                //ui_user_view_btn.TranslateTo(        350, 0, 2000, Easing.BounceOut)
            );

            ui_profile_root.IsVisible = true;
            await ui_user_info.TranslateTo(0, -230, 2000, Easing.Linear);
        }

        private void Disliked_Profile(object sender, SwipedEventArgs e)
        {

        }

        private void Liked_Profile(object sender, SwipedEventArgs e)
        {

        }

        private void ViewPreviousImage(object sender, SwipedEventArgs e)
        {
            ui_image_selection.Children[current_image].Opacity = 0.5f;
            current_image = ((current_image - 1) < 0) ? images.Count - 1 : current_image - 1;
            //ui_profile_image.Source = images[current_image];
            ui_image_selection.Children[current_image].Opacity = 1.0f;
        }

        private void ViewNextImage(object sender, SwipedEventArgs e)
        {
            ui_image_selection.Children[current_image].Opacity = 0.5f;
            current_image = ((current_image + 1) > images.Count - 1) ? 0 : current_image + 1;
            //ui_profile_image.Source = images[current_image];

            ui_image_selection.Children[current_image].Opacity = 1.0f;
        }
    }
}