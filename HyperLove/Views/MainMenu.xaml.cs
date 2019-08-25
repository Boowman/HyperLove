using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HyperLove.Views;
using HyperLove.Modules.User;

namespace HyperLove
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
            AssignCurrentUser();

            ui_settings.GestureRecognizers.Add(new TapGestureRecognizer     { Command = new Command(() => ViewSettings()), });
            ui_account.GestureRecognizers.Add(new TapGestureRecognizer      { Command = new Command(() => ViewAccount()), });
            ui_help.GestureRecognizers.Add(new TapGestureRecognizer         { Command = new Command(() => ViewHelp()), });
            ui_support.GestureRecognizers.Add(new TapGestureRecognizer      { Command = new Command(() => ViewSupport()), });
            ui_suggestions.GestureRecognizers.Add(new TapGestureRecognizer  { Command = new Command(() => ViewSuggestions()), });
        }

        public void AssignCurrentUser()
        {
            //ui_avatar.Source = App.CurrentUser.Avatar;
            ui_personal_info.Text   = App.CurrentUser.Name      + ", "      + App.CurrentUser.Age;
            ui_profession.Text      = App.CurrentUser.Job       + " at "    + App.CurrentUser.Company;
            ui_education.Text       = App.CurrentUser.School;
        }

        async void ViewSettings()
        {
            Console.WriteLine("View Settings");
            await Navigation.PushModalAsync(new Settings(), true);
        }

        async void ViewAccount()
        {
            Console.WriteLine("View Account");
            await Navigation.PushModalAsync(new Account(), true);
        }

        async void ViewHelp()
        {
            Console.WriteLine("View Help");
            await Navigation.PushModalAsync(new Help(), true);
        }

        async void ViewSupport()
        {
            Console.WriteLine("View Support");
            await Navigation.PushModalAsync(new Support(), true);
        }

        async void ViewSuggestions()
        {
            Console.WriteLine("View Suggestions");
            await Navigation.PushModalAsync(new Suggestions(), true);
        }


        async void Btn_ViewPreferences(object sender, System.EventArgs e)
        {
            Console.WriteLine("Before Preferences");
            await Navigation.PushModalAsync(new Preferences(), true);
        }

        private void Btn_GetPremium(object sender, System.EventArgs e)
        {
            Console.WriteLine("Get Premium");
        }

        async void Btn_EditProfile(object sender, System.EventArgs e)
        {
            Console.WriteLine("Edit Profiles");
            await Navigation.PushModalAsync(new EditProfile(), true);
        }
    }
}