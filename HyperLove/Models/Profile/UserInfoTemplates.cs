using HyperLove.Models.User;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HyperLove.Models.Profile
{
    public class UserInfoTemplates
    {
        /*
         * Instagram images template that gets displayed when viewing more
         * info about a certain profile
         */
        public void InstagramImagesSetup(List<InstagramPicture> list, StackLayout parent)
        {
            List<InstagramPicture> tempImgs = new List<InstagramPicture>();

            for (int index = (list.Count - 1); index >= 0; --index)
            {
                tempImgs.Add(list[index]);

                if (index % 6 == 0)
                {
                    Grid tempGrid = InstagramGroupTemplate(tempImgs);

                    parent.Children.Add(tempGrid);
                    parent.LowerChild(tempGrid);

                    tempImgs.Clear();
                }
            }
        }

        private Grid InstagramGroupTemplate(List<InstagramPicture> images)
        {
            /* Open ScrollView
             *      Open Grid xN
             *          Image
             *          ...
             *          Image x6
             *      Close Grid
             * Close ScrollView
             */

            var itemSize = 127;

            var grid = new Grid();
            grid.HorizontalOptions = LayoutOptions.FillAndExpand;
            grid.VerticalOptions = LayoutOptions.Start;
            grid.Margin = new Thickness(10, 0, 10, 10);

            grid.RowDefinitions.Add(new RowDefinition() { Height = itemSize });
            grid.RowDefinitions.Add(new RowDefinition() { Height = itemSize });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = itemSize });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = itemSize });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = itemSize });

            for (int index = 0; index < images.Count; index++)
            {
                var image = new Image();
                image.Source = ImageSource.FromFile(images[index].Image + ".jpg"); // Change it to URL later on
                image.Aspect = Aspect.AspectFill;

                grid.Children.Add(image);

                image.SetValue(Grid.RowProperty, index % 2);
                image.SetValue(Grid.ColumnProperty, index / 2);
            }

            return grid;
        }

        /*
         * Spotify albums template that gets displayed when viewing more
         * info about a certain profile
         */
        public void SpotifyAlbumsSetup(List<SpotifyAlbum> list, StackLayout parent)
        {
            foreach (SpotifyAlbum album in list)
                parent.Children.Add(SpotifyAlbumTemplate(album));
        }

        private StackLayout SpotifyAlbumTemplate(SpotifyAlbum album)
        {
            /* Open ScrollView
             *      Open Layout xN
             *          Image
             *          Label
             *      Close Layout
             * Close ScrollView
             */
            var layout = new StackLayout();
            layout.Orientation = StackOrientation.Vertical;
            layout.VerticalOptions = LayoutOptions.Fill;
            layout.Spacing = 0;

            //var pancakeView = new PancakeView();
            //pancakeView.CornerRadius = 5;
            //pancakeView.HasShadow = true;
            //pancakeView.IsClippedToBounds = true;
            //pancakeView.HorizontalOptions = LayoutOptions.FillAndExpand;
            //pancakeView.WidthRequest = 95;
            //pancakeView.HeightRequest = 95;

            var image = new Image();
            image.Source = ImageSource.FromFile(album.Image + ".jpg");
            image.HorizontalOptions = LayoutOptions.FillAndExpand;
            image.VerticalOptions = LayoutOptions.FillAndExpand;
            image.Aspect = Aspect.AspectFill;

            var label = new Label();
            label.Text = album.Label;
            label.FontSize = Device.GetNamedSize(NamedSize.Subtitle, typeof(Label));
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

        /*
         * Quotes template that will get displayed when viewing more
         * info about a certain profile
         */
        public void QuotesSetup(Dictionary<int, string> list, StackLayout parent)
        {
            foreach(KeyValuePair<int, string> item in list)
            {
                parent.Children.Add(QuotesTemplate(item.Key, item.Value));
            }
        }

        private StackLayout QuotesTemplate(int title_idx, string desc)
        {
            /* Open StackLayout
             *      Open Layout x3
             *          Label
             *          Label
             *      Close Layout
             * Close StackLayout
             */
            StackLayout layout = new StackLayout();
            layout.BackgroundColor = Color.FromHex("#93c2d2");
            layout.Spacing = 0;
            layout.Padding = 15;

            Label title = new Label();
            title.FontSize          = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            title.TextColor         = Color.White;
            title.FontAttributes    = FontAttributes.Bold;
            title.HorizontalOptions = LayoutOptions.FillAndExpand;
            title.VerticalOptions   = LayoutOptions.FillAndExpand;

            title.Text = Functions.QuotesTitles(title_idx);

            Label description = new Label();
            description.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            description.TextColor = Color.White;
            description.HorizontalOptions = LayoutOptions.FillAndExpand;
            description.VerticalOptions = LayoutOptions.FillAndExpand;
            description.Margin = new Thickness(10, 0, 0, 0);

            description.Text = desc;

            layout.Children.Add(title);
            layout.Children.Add(description);

            return layout;
        }

        /*
         * Preferences template that will get displayed when viewing more
         * info about a certain profile
         */
        public void PreferencesSetup(PreferencesInfo preferences, FlexLayout parent)
        {
            if (preferences.Relationship.Enabled)
            {
                string children = preferences.Relationship.Value.ToString();
                parent.Children.Add(PreferencesTemplate(preferences.Relationship.Icon, Functions.AddSpace(ref children)));
            }

            if (preferences.Children.Enabled)
            {
                string children = preferences.Children.Value.ToString();
                parent.Children.Add(PreferencesTemplate(preferences.Children.Icon, Functions.AddSpace(ref children)));
            }

            if (preferences.Gender.Enabled)
            {
                string children = preferences.Gender.Value.ToString();
                parent.Children.Add(PreferencesTemplate(preferences.Gender.Icon, Functions.AddSpace(ref children)));
            }

            if (preferences.Pets.Enabled)
            {
                string children = preferences.Pets.Value.ToString();
                parent.Children.Add(PreferencesTemplate(preferences.Pets.Icon, Functions.AddSpace(ref children)));
            }

            if (preferences.Education.Enabled)
            {
                string children = preferences.Education.Value.ToString();
                parent.Children.Add(PreferencesTemplate(preferences.Education.Icon, Functions.AddSpace(ref children)));
            }

            if (preferences.Exercise.Enabled)
            {
                string children = preferences.Exercise.Value.ToString();
                parent.Children.Add(PreferencesTemplate(preferences.Exercise.Icon, Functions.AddSpace(ref children)));
            }

            if (preferences.Drinking.Enabled)
            {
                string children = preferences.Drinking.Value.ToString();
                parent.Children.Add(PreferencesTemplate(preferences.Drinking.Icon, Functions.AddSpace(ref children)));
            }

            if (preferences.Smoking.Enabled)
            {
                string children = preferences.Smoking.Value.ToString();
                parent.Children.Add(PreferencesTemplate(preferences.Smoking.Icon, Functions.AddSpace(ref children)));
            }

            if (preferences.Ethnicity.Enabled)
            {
                string children = preferences.Ethnicity.Value.ToString();
                parent.Children.Add(PreferencesTemplate(preferences.Ethnicity.Icon, Functions.AddSpace(ref children)));
            }

            if (preferences.Religion.Enabled)
            {
                string children = preferences.Religion.Value.ToString();
                parent.Children.Add(PreferencesTemplate(preferences.Religion.Icon, Functions.AddSpace(ref children)));
            }

            if (preferences.Politics.Enabled)
            {
                string children = preferences.Politics.Value.ToString();
                parent.Children.Add(PreferencesTemplate(preferences.Politics.Icon, Functions.AddSpace(ref children)));
            }
        }

        private StackLayout PreferencesTemplate(string preferenceIcon, string preferenceText)
    {
            //Label icon = new Label();
            //icon.Text       = "&#xf085;";
            //icon.FontSize   = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            //icon.FontFamily = Device.RuntimePlatform == Device.Android ? "FontAwesomeSolid.ttf#Regular" : "FontAwesomeSolid";
            //icon.TextColor  = Color.Black;

            //icon.LineBreakMode  = LineBreakMode.NoWrap;
            //icon.Margin         = new Thickness(0.0f, 7.0f, 7.5f, 0.0f);

            Label text      = new Label();
            text.Text       = preferenceText;
            text.FontSize   = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            text.TextColor  = Color.Black;

            text.LineBreakMode              = LineBreakMode.NoWrap;
            text.HorizontalTextAlignment    = TextAlignment.Center;
            text.VerticalTextAlignment      = TextAlignment.Center;

            StackLayout stackLayout = new StackLayout();
            stackLayout.Orientation = StackOrientation.Horizontal;
            stackLayout.Spacing = 0.0f;
            stackLayout.HeightRequest = 35;

            stackLayout.Padding = new Thickness(7.5f, 0.0f);
            stackLayout.Margin = new Thickness(5, 5);
            stackLayout.BackgroundColor = Color.FromHex("#EFD194");

            stackLayout.Children.Add(text);
            //stackLayout.Children.Add(icon);

            return stackLayout;     
        }
    }
}
