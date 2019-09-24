using HyperLove.Database;
using HyperLove.Models.User;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HyperLove
{
    public partial class App : Application
    {
        public static UserProfile CurrentUser { get; private set; }
        public static List<UserProfile> SearchingProfiles = new List<UserProfile>();

        public App()
        {
            InitializeComponent();
            CurrentUser = new UserProfile();
            MainPage    = new SplashScreen();
        }
    
        public static void UserSetupProfile(UserProfile user)
        {
            CurrentUser = user;
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

        public static void CheckStorageInfo()
        {
            // Look up for a file inside the cache/user/ folder that has the name of user_xxxxxx (explode the string and get the xxxxx)
            string user_id_file = "";

            if (user_id_file != "")
            {
                // Get user id from the devices' storage file
                DependencyService.Get<IUserDatabaseService>().LookingForUser(user_id_file);
                Console.WriteLine("User File Found");
            }
            else
            {
                LoginSuccessful(false);
                Console.WriteLine("User File Not Found");
            }
        }
        
        /// <summary>
        /// This will determine where will the user go next based on the informations found
        /// Setting it to false will go to the LoginView Page
        /// </summary>
        /// <param name="success">If a user was found or not</param>
        /// <param name="profileCompleted">Has the user finished setting up their profile</param>
        public static void LoginSuccessful(bool success, bool profileCompleted = false, bool createUser = false)
        {
            if (success == true)
            {
                if (profileCompleted == true)
                {
                    App.Current.MainPage = new NavigationPage(new SearchView());
                    Console.WriteLine("View SearchView");
                }
                else
                {
                    Console.WriteLine("Finish Profile");
                    App.Current.MainPage = new FinishProfile();
                }
            }
            else
            {
                App.Current.MainPage = new LoginView();
                Console.WriteLine("User Not Found Login");
            }
        }

        /// <summary>
        /// Called whenever a user has logged in via a social media account
        /// </summary>
        /// <param name="user">Get informations found from the social media</param>
        /// <param name="userFound"></param>
        public static void AuthenticationSuccessful(UserBase user)
        {
            if(user != null && user.ID != "")
            {
                CurrentUser.UserBase = user;
                DependencyService.Get<IUserDatabaseService>().LookingForUser(user.ID);
                Console.WriteLine("Authentication Successful Look Up User");
            }
            else
            {
                Console.WriteLine("Display a toast to the user");
            }
        }
    }
}
