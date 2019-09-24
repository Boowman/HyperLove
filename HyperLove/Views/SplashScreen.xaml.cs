using HyperLove.Database;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HyperLove
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SplashScreen : ContentPage
    {
        public static SplashScreen Instance;

        public SplashScreen()
        {
            if (Instance == null)
                Instance = this;

            InitializeComponent();
            LoadingContent();
        }
        
        public async void LoadingContent()
        {
            await ui_loading_logo.RotateTo(360, 2500, Easing.Linear);
            ui_loading_logo.Rotation = 0;

            App.CheckStorageInfo();

            await ui_loading_logo.RotateTo(360, 2500, Easing.Linear);
            ui_loading_logo.Rotation = 0;
            await ui_loading_logo.RotateTo(360, 2500, Easing.Linear);
            ui_loading_logo.Rotation = 0;
        }


    }
}