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
    public partial class EditProfile : ContentPage
    {
        public EditProfile()
        {
            InitializeComponent();

            ui_rows_list.ItemSelected += OnItemSelected;
            ui_pop_modal.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => PopCurrentModal()), });
        }
        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (ui_rows_list.SelectedItem != null)
            {
                // Open Modal
                await Navigation.PushModalAsync(new SearchView());
            }
        }

        async void PopCurrentModal()
        {
            await Navigation.PopModalAsync();
        }
    }
}