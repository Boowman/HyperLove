using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Firebase.Firestore;
using Firebase;
using Java.Util;
using HyperLove.Modules.User;

namespace HyperLove.Droid
{
    [Activity(Label = "HyperLove", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private static FirebaseFirestore database;

        public static FirebaseFirestore Database { get => database; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            //uiOptions |= (int)SystemUiFlags.LowProfile;
            //uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;

            database = GetDatabase();

            HashMap map = new HashMap();
            map.Put("first", "Denisz");
            map.Put("last", "Pop");
            map.Put("age", 25);

            DocumentReference reference = database.Collection("users").Document();
            reference.Set(map);

            LoadApplication(new App());
        }

        protected override void OnStart()
        {
            base.OnStart();

            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            //uiOptions |= (int)SystemUiFlags.LowProfile;
            //uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
        }

        protected override void OnResume()
        {
            base.OnResume();

            int uiOptions = (int)Window.DecorView.SystemUiVisibility;

            //uiOptions |= (int)SystemUiFlags.LowProfile;
            //uiOptions |= (int)SystemUiFlags.Fullscreen;
            uiOptions |= (int)SystemUiFlags.HideNavigation;
            uiOptions |= (int)SystemUiFlags.ImmersiveSticky;

            Window.DecorView.SystemUiVisibility = (StatusBarVisibility)uiOptions;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private FirebaseFirestore GetDatabase()
        {
            FirebaseFirestore database;

            var options = new FirebaseOptions.Builder()
                .SetProjectId("datingapp-f9b91")
                .SetApplicationId("datingapp-f9b91")
                .SetApiKey("AIzaSyAI1FqTtwwCJXyoP_TB5ktdnayaA76hBgY")
                .SetDatabaseUrl("https://datingapp-f9b91.firebaseio.com")
                .SetStorageBucket("datingapp-f9b91.appspot.com")
                .Build();

            var app = FirebaseApp.InitializeApp(this, options);
            database = FirebaseFirestore.GetInstance(app);

            return database;
        }
    }
}