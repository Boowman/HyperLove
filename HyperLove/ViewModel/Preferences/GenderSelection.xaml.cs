using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.Generic;
using HyperLove.Models.User;

namespace HyperLove.ViewModel.Preferences
{
    public class GenderRow
    {
        public string Title { get; set; }

        public bool IsSelected { get; set; }

        public EGenderIntrest Gender;

        public string IsSelectedImage { get { return (IsSelected) ? "selected.png" : "unselected.png"; } }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GenderSelection : ModalPage
    {
        private List<GenderRow> RowsList;

        public GenderSelection()
        {
            InitializeComponent();
            InitializeItemsSource();
        }

        public GenderSelection(string modalTitle)
        {
            InitializeComponent();
            InitializeItemsSource();

            if(ui_pop_modal != null)
            {
                ui_pop_title.Text = modalTitle;
                ui_pop_modal.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => PopCurrentModal()), });
            }
        }

        private async void PopCurrentModal()
        {
            if(Button != null)
                Button.IsSelected = false;

            await Navigation.PopModalAsync();
        }

        public void InitializeItemsSource()
        {
            RowsList = new List<GenderRow>
            {
                new GenderRow { Title = "Male",   IsSelected = GetSelection(EGenderIntrest.Male),  Gender = EGenderIntrest.Male  },
                new GenderRow { Title = "Women",  IsSelected = GetSelection(EGenderIntrest.Women), Gender = EGenderIntrest.Women },
                new GenderRow { Title = "Mixed",  IsSelected = GetSelection(EGenderIntrest.Mixed), Gender = EGenderIntrest.Mixed },
            };

            ui_rows_list.ItemsSource = RowsList;
        }

        public bool GetSelection(EGenderIntrest selected)
        {
            if (App.CurrentUser != null)
            {
                if (App.CurrentUser.Preferences != null)
                {
                    if (App.CurrentUser.Preferences.Gender.Value == selected)
                        return true;
                }
            }

            return false;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            GenderRow tempRow = (GenderRow)e.SelectedItem;

            ui_rows_list.ItemsSource = null;

            for (int x = 0; x < RowsList.Count; x++)
                RowsList[x].IsSelected = false;

            for (int x = 0; x < RowsList.Count; x++)
            {
                if (RowsList[x].Gender == tempRow.Gender)
                    RowsList[x].IsSelected = true;
            }

            App.CurrentUser.Preferences.Gender.Value = tempRow.Gender;
            ui_rows_list.ItemsSource = RowsList;
        }
    }
}