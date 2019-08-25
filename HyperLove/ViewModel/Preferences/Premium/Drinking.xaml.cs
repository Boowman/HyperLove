using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HyperLove.ViewModel.Preferences.Premium
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Drinking : ModalPage
    {
        public Drinking()
        {
            InitializeComponent();
        }

        public Drinking(string modalTitle)
        {
            InitializeComponent();

            if (ui_pop_modal != null)
            {
                ui_pop_title.Text = modalTitle;
                ui_pop_modal.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => PopCurrentModal()), });
            }
        }

        private async void PopCurrentModal()
        {
            if (Button != null)
                Button.IsSelected = false;

            await Navigation.PopModalAsync();
        }
    }
}