using HyperLove.Modules.User;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HyperLove
{
    public partial class App : Application
    {
        public static UserInfo CurrentUser;
        public static List<UserInfo> SearchingProfiles = new List<UserInfo>();

        public App()
        {
            InitializeComponent();

            CurrentUser = CreateUser();

            for(int x = 0; x < 10; x++)
                SearchingProfiles.Add(CreateUser(x));

            MainPage = new NavigationPage(new SearchView());
        }

        public UserInfo CreateUser(int index = -1)
        {
            UserInfo currentUser = new UserInfo();

            currentUser.First   = "Lenard" + ((index != -1) ? " " + index.ToString() : "");
            currentUser.Last    = "Pop";
            currentUser.Age     = 25 + index;

            currentUser.Email   = "denisz.pop@gmail.com";
            currentUser.School  = "Buckinghamshire New University" + ((index != -1) ? " " + index.ToString() : "");

            // User Location
            currentUser.Location.City       = "Birmingham";
            currentUser.Location.County     = "West Midlands";
            currentUser.Location.Country    = "United Kingdom";

            currentUser.Job     = "Junior Web Developer";
            currentUser.Company = "TonyG";

            currentUser.Premium     = false;
            currentUser.Verified    = false;

            // User Images
            currentUser.Images.Add("http://lenardpop.co.uk/xxx.jpg");
            currentUser.Images.Add("http://lenardpop.co.uk/xxx.jpg");
            currentUser.Images.Add("http://lenardpop.co.uk/xxx.jpg");
            currentUser.Images.Add("http://lenardpop.co.uk/xxx.jpg");
            currentUser.Images.Add("http://lenardpop.co.uk/xxx.jpg");

            // User Quotes
            currentUser.Quotes.Add(0, "Lorem impus");
            currentUser.Quotes.Add(3, "Impus");
            currentUser.Quotes.Add(12, "Lorem impus, lorem");

            // User Swipes
            currentUser.Swipes.Matches.Add("bRcvrygwW9RX4Bof22Ra");
            currentUser.Swipes.Matches.Add("sxNhJQeEZArEH2sMrKw8");
            currentUser.Swipes.Matches.Add("ggsfQr3WYkQ2veyJH1vJ");

            currentUser.Swipes.Loves.Add("f2LwVI55t6iu95OnCGxo");

            currentUser.Swipes.Likes.Add("dssC8sgcWQFGMgYLdYW9");
            currentUser.Swipes.Likes.Add("Vd94G8XWgi22BGaNTuYy");

            currentUser.Swipes.Dislikes.Add("RJxmKM78dsYd6GWyt9gg");
            currentUser.Swipes.Dislikes.Add("NJ0HNp6G1hLzofMKn5lb");
            currentUser.Swipes.Dislikes.Add("373wldls1cj6b5PfDSF9");
            currentUser.Swipes.Dislikes.Add("1FC8M4yzc1FHew1km56k");

            currentUser.Instagram.Verified  = false;

            currentUser.Spotify.Verified    = true;
            currentUser.Spotify.Social_ID   = "2srw5252n5io21qn513";

            return currentUser;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
