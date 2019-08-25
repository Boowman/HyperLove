using HyperLove.Modules.Preferences;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HyperLove.ViewModel
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPage : ContentPage
    {
        public PreferenceRow Button;

        public ModalPage()
        {
            InitializeComponent();
        }

        private async void PopCurrentModal()
        {
            if(Button != null)
                Button.IsSelected = false;

            await Navigation.PopModalAsync();
        }
    }
}