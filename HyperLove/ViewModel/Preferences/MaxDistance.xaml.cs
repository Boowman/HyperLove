using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HyperLove.ViewModel.Preferences
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MaxDistance : ModalPage
    {
        public MaxDistance()
        {
            InitializeComponent();
        }

        public MaxDistance(string modalTitle)
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