using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HyperLove.Modules.Preferences;
using HyperLove.ViewModel;
using System;

namespace HyperLove.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Preferences : ContentPage
    {
        private bool constructorCalled = false;

        public Preferences()
        {
            InitializeComponent();

            Console.WriteLine("Preferences Constructor");
            ui_rows_list.ItemsSource = new Modules.PreferenceBindingContext().RowsList;
            ui_rows_list.ItemSelected += OnItemSelected;

            ui_pop_modal.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => PopCurrentModal()), });

            constructorCalled = true;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if(constructorCalled == true)
            {
                Console.WriteLine("Constructor Called");

                ui_rows_list.ItemsSource = null;
                ui_rows_list.ItemsSource = new Modules.PreferenceBindingContext().RowsList;
            }
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (ui_rows_list.SelectedItem != null)
            {
                // Open Modal
                if(e.SelectedItem as PreferenceRow != null)
                {
                    PreferenceRow row = (e.SelectedItem as PreferenceRow);

                    if(row.IsLocked == false)
                    {
                        if (row.Modal != null && row.IsSelected == false && (row.Modal is MainMenu) == false)
                        {
                            row.IsSelected = true;
                            ModalPage modal = (row.Modal as ModalPage);

                            if (modal != null)
                                modal.Button = row;

                            await Navigation.PushModalAsync(row.Modal);
                        }
                    }
                }
            }
        }

        async void PopCurrentModal()
        {
            await Navigation.PopModalAsync();
        }
    }
}