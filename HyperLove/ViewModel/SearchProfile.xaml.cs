using HyperLove.Database;
using HyperLove.Models;
using HyperLove.Models.User;
using System;
using System.Linq;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HyperLove.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchProfile : ContentView
    {
        private UserProfile userAssigned;

        private int currentImage = 0;
        private StackLayout stackImageDots;
        private SearchView searchView;

        public UserProfile UserAssigned { get => userAssigned; }

        public SearchProfile()
        {
            InitializeComponent();
        }

        public SearchProfile(UserProfile user, SearchView searchView, StackLayout stackImageDots)
        {
            InitializeComponent();

            if (user != null)
            {
                userAssigned = user;

                Random rdm = new Random();
                int tempIndx = rdm.Next(0, 3);

                ui_current_image.Source = user.Images[tempIndx].URL;
                ui_info_name.Text       = (user.UserBase.First + " " + user.UserBase.Last + ", " + user.GetAge().ToString());

                ui_info_quote_title.Text = Functions.QuotesTitles(user.Quotes.Keys.ElementAt(0));
                ui_info_quote_desc.Text  = user.Quotes[user.Quotes.Keys.ElementAt(0)];
            }
            else
                throw new System.ArgumentException("The `user` parameter value cannot be NULL", "user");

            if (searchView != null)
            {
                this.searchView = searchView;
            }
            else
                throw new System.ArgumentException("The `stackImageDots` parameter value cannot be NULL", "stackImageDots");

            if (stackImageDots != null)
            {
                this.stackImageDots = stackImageDots;
            }
            else
                throw new System.ArgumentException("The `stackImageDots` parameter value cannot be NULL", "stackImageDots");
        }

        private void DislikedProfile(object sender, SwipedEventArgs e)
        {
            if(App.CurrentUser != null)
            {
                App.CurrentUser.Swipes.Dislikes.Add(userAssigned.UserBase.ID);
                DependencyService.Get<IUserDatabaseService>().DislikedPerson(UserAssigned.UserBase.ID, "");

                this.searchView.ViewingNewUser();

                Console.WriteLine("Profile Disliked");
            }
            else
                throw new System.ArgumentException("`App.CurrentUser` cannot be NULL", "CurrentUser");
        }

        private void LikedProfile(object sender, SwipedEventArgs e)
        {
            if (App.CurrentUser != null)
            {
                App.CurrentUser.Swipes.Likes.Add(userAssigned.UserBase.ID);
                DependencyService.Get<IUserDatabaseService>().LikedPerson(UserAssigned.UserBase.ID, "");


                this.searchView.ViewingNewUser();

                /*
                    If userAssigned.Swipes.Likes Contains App.CurrentUser.UserID
                        match was found display menu on the screen to start chatting or continue
                 */
                Console.WriteLine("Profile Liked");
            }
            else
                throw new System.ArgumentException("`App.CurrentUser` cannot be NULL", "CurrentUser");
        }

        private void LovedProfile(object sender, SwipedEventArgs e)
        {
            if (App.CurrentUser != null)
            {
                App.CurrentUser.Swipes.Loves.Add(userAssigned.UserBase.ID);
                DependencyService.Get<IUserDatabaseService>().LovedPerson(UserAssigned.UserBase.ID, "");

                this.searchView.ViewingNewUser();

                /*
                    If userAssigned.Swipes.Likes Contains App.CurrentUser.UserID
                        match was found display menu on the screen to start chatting or continue
                 */
                Console.WriteLine("Profile Loved");
            }
            else
                throw new System.ArgumentException("`App.CurrentUser` cannot be NULL", "CurrentUser");
        }

        private void ViewPreviousImage(object sender, EventArgs e)
        {
            if (stackImageDots != null)
            {
                stackImageDots.Children[currentImage].Opacity = 0.5f;

                currentImage            = ((currentImage - 1) < 0) ? UserAssigned.Images.Count - 1 : currentImage - 1;
                ui_current_image.Source = UserAssigned.Images[currentImage].URL;

                stackImageDots.Children[currentImage].Opacity = 1.0f;

                Console.WriteLine("Previous Image");
            }
            else
                throw new System.ArgumentException("`StackImageDots` cannot be NULL", "stackImageDots");
        }

        private void ViewNextImage(object sender, EventArgs e)
        {
            if (stackImageDots != null)
            {
                stackImageDots.Children[currentImage].Opacity = 0.5f;

                currentImage            = ((currentImage + 1) > UserAssigned.Images.Count - 1) ? 0 : currentImage + 1;
                ui_current_image.Source = UserAssigned.Images[currentImage].URL;

                stackImageDots.Children[currentImage].Opacity = 1.0f;

                Console.WriteLine("Next Image");
            }
            else
                throw new System.ArgumentException("`StackImageDots` cannot be NULL", "stackImageDots");
        }

        private void ViewProfile(object sender, EventArgs e)
        {
            //await Task.WhenAll(
            //    ui_user_name.TranslateTo(-350, 0, 2000, Easing.BounceOut),
            //    ui_user_quote_title.TranslateTo(-350, 0, 2000, Easing.BounceOut),
            //    ui_user_quote_desc.TranslateTo(-350, 0, 2000, Easing.BounceOut),
            //    ui_user_view_btn.TranslateTo(350, 0, 2000, Easing.BounceOut)
            //);

            //ui_profile_root.IsVisible = true;
            //await ui_user_info.TranslateTo(0, -230, 2000, Easing.Linear);

            this.searchView.ViewProfile();
            Console.Write("SearchProfile ViewProfile");
        }
    }
}