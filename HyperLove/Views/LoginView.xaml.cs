using HyperLove.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HyperLove
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void FacebookLogin_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Facebook Login");
            DependencyService.Get<IOAuthentication>().FacebookLogin();
            Console.WriteLine("Facebook Login Successful");
        }

        private void InstagramLogin_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Instagram Login");
            DependencyService.Get<IOAuthentication>().InstagramLogin();
            Console.WriteLine("Instagram Login Successful");
        }
    }
}