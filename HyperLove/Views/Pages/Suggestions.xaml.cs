using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HyperLove.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Suggestions : ContentPage
    {
        public Suggestions()
        {
            InitializeComponent();

            ui_pop_modal.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => PopCurrentModal()), });
        }

        async void PopCurrentModal()
        {
            await Navigation.PopModalAsync();
        }
    }
}