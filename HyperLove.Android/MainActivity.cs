using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.OS;
using Firebase.Firestore;
using Xamarin.Auth;

namespace HyperLove.Droid
{
    [Activity(Label = "HyperLove", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static MainActivity Instance;
        public FirebaseFirestore database;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            if (Instance == null)
                Instance = this;

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

            database = new DatabaseService().GetDatabase(this);
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
    
        public void OAuthStartActivity(OAuth2Authenticator auth)
        {
            var gui = auth.GetUI(this);
            StartActivity(gui);
        }

        public void OAuthStartActivity(OAuth1Authenticator auth)
        {
            var gui = auth.GetUI(this);
            StartActivity(gui);
        }
    }
}