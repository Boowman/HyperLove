using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HyperLove.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Account : ContentPage
    {
        public Account()
        {
            InitializeComponent();

            ui_rows_list.ItemsSource = new Modules.AccountBindingContext().RowsList;
            ui_rows_list.ItemSelected += OnItemSelected;

            ui_pop_modal.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => PopCurrentModal()), });
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (ui_rows_list.SelectedItem != null)
            {
                // Open Modal
                await Navigation.PushModalAsync(new MainMenu());
            }
        }

        async void PopCurrentModal()
        {
            await Navigation.PopModalAsync();
        }
    }
}