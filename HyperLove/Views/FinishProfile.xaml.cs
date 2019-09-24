using HyperLove.Database;
using System;
using Xamarin.Forms;
using Xamarin.Forms.PancakeView;
using Xamarin.Forms.Xaml;

namespace HyperLove
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinishProfile : ContentPage
    {
        DateTime current_date   = DateTime.Now;
        DateTime selected_date  = new DateTime(1994,1,1);
        string[] date = new string[] { "", "", "" };

        int current_setup = 3; // Min 3 - Max 5

        string gender = "";
        string intrested = "";

        public FinishProfile()
        {
            InitializeComponent();

            SetUserCurrentAge();
            SetUsersName();
            SetupDatePicker();

            ui_pages_setup.Children[current_setup].IsVisible = true;
            ui_current_page.Children[current_setup - 3].BackgroundColor = Color.FromHex("#F5B22C");

            ui_date_picker.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => SetBirthDay(false, false, false, false)), });

            ui_day_pick.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => SetBirthDay(true, false, false)), });
            ui_month_pick.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => SetBirthDay(false, true, false)), });
            ui_year_pick.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => SetBirthDay(false, false, true)), });
        }

        private void SetUsersName()
        {
            ui_display_name.Text    = App.CurrentUser.UserBase.First;
            ui_user_name.Text       = App.CurrentUser.UserBase.First + " " + App.CurrentUser.UserBase.Last;
        }

        private void SetupDatePicker()
        {
            for(int x = 1; x <= 31; x++)
            {
                var button = new Button();
                button.Text = (x < 10) ? ("0" + x.ToString()) : x.ToString();
                button.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button));
                button.TextColor = Color.Black;
                button.BackgroundColor = Color.White;

                button.Clicked          += DaySelected;

                ui_date_day_list.Children.Add(button);
            }

            for (int x = 1; x <= 12; x++)
            {
                var button = new Button();
                button.Text = (x < 10) ? ("0" + x.ToString()) : x.ToString();
                button.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button));
                button.TextColor = Color.Black;
                button.BackgroundColor = Color.White;

                button.Clicked += MonthSelected;

                ui_date_month_list.Children.Add(button);
            }

            var currentYear = 2019;
            for (int x = currentYear; x >= (currentYear - 100); --x)
            {
                var button = new Button();
                button.Text = (x < 10) ? ("0" + x.ToString()) : x.ToString();
                button.FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button));
                button.TextColor = Color.Black;
                button.BackgroundColor = Color.White;

                button.Clicked += YearSelected;

                ui_date_year_list.Children.Add(button);
            }
        }

        private void NameSelected(object sender, System.EventArgs e)
        {
            var textInput = (Label)sender;

            Console.WriteLine("HyperVoid: " + textInput.Text);
        }

        private void GenderSelected(object sender, System.EventArgs e)
        {
            var button = (Button)sender;

            ui_male_selection.BackgroundColor = Color.White;
            ui_male_selection.TextColor = Color.Black;
            ui_male_selection_parent.BackgroundColor = Color.White;

            ui_female_selection.BackgroundColor = Color.White;
            ui_female_selection.TextColor = Color.Black;
            ui_female_selection_parent.BackgroundColor = Color.White;

            switch (button.Text)
            {
                case "Male":
                    ui_male_selection.BackgroundColor = Color.FromHex("#F5B22C");
                    ui_male_selection.TextColor = Color.White;
                    ui_male_selection_parent.BackgroundColor = Color.FromHex("#F5B22C");

                    gender = "Male";
                    App.CurrentUser.Gender = gender.ToLower();
                    break;
                case "Female":
                    ui_female_selection.BackgroundColor = Color.FromHex("#F5B22C");
                    ui_female_selection.TextColor = Color.White;
                    ui_female_selection_parent.BackgroundColor = Color.FromHex("#F5B22C");

                    gender = "Female";
                    App.CurrentUser.Gender = gender.ToLower();
                    break;
            }
        }

        private void IntrestSelected(object sender, System.EventArgs e)
        {
            var button = (Button)sender;

            ui_men_selection.BackgroundColor = Color.White;
            ui_men_selection.TextColor = Color.Black;
            ui_men_selection_parent.BackgroundColor = Color.White;

            ui_women_selection.BackgroundColor = Color.White;
            ui_women_selection.TextColor = Color.Black;
            ui_women_selection_parent.BackgroundColor = Color.White;

            switch (button.Text)
            {
                case "Men":
                    ui_men_selection.BackgroundColor = Color.FromHex("#F5B22C");
                    ui_men_selection.TextColor = Color.White;
                    ui_men_selection_parent.BackgroundColor = Color.FromHex("#F5B22C");

                    intrested = "Men";
                    App.CurrentUser.IntrestedIn = intrested.ToLower();
                    break;
                case "Women":
                    ui_women_selection.BackgroundColor = Color.FromHex("#F5B22C");
                    ui_women_selection.TextColor = Color.White;
                    ui_women_selection_parent.BackgroundColor = Color.FromHex("#F5B22C");

                    intrested = "Women";
                    App.CurrentUser.IntrestedIn = intrested.ToLower();
                    break;
            }
        }

        private void SetBirthDay(bool day, bool month, bool year, bool menu = true)
        {
            ui_date_picker.IsVisible = menu;

            ui_date_day_selection.IsVisible = day;
            ui_date_month_selection.IsVisible = month;
            ui_date_year_selection.IsVisible = year;
        }

        private void SetUserCurrentAge(bool set_age = false)
        {
            if(date[2] == "")
                ui_current_age.Text = (current_date.Year - selected_date.Year).ToString();
            else
                ui_current_age.Text = (current_date.Year - int.Parse(date[2])).ToString();

            if (int.Parse(ui_current_age.Text) < 16)
                ui_current_age.TextColor = Color.Red;
            else
                ui_current_age.TextColor = Color.Black;

            if (date[0] != "" && date[1] != "" && date[2] != "")
            {
                selected_date = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));

                if (set_age == true)
                    App.CurrentUser.UserBase.Birthday = selected_date;
            }
        }

        private void DaySelected(object sender, System.EventArgs e)
        {
            var day = ((Button)sender).Text;
            date[0] = day;

            ui_day_pick.BackgroundColor = Color.FromHex("#F5B22C");
            ui_day_pick_text.TextColor = Color.White;

            ui_day_pick_text.Text = day;

            SetUserCurrentAge(true);
            SetBirthDay(false, false, false, false);
        }

        private void MonthSelected(object sender, System.EventArgs e)
        {
            var month = ((Button)sender).Text;
            date[1] = month;

            ui_month_pick.BackgroundColor = Color.FromHex("#F5B22C");
            ui_month_pick_text.TextColor = Color.White;

            ui_month_pick_text.Text = month;

            SetUserCurrentAge(true);
            SetBirthDay(false, false, false, false);
        }

        private void YearSelected(object sender, System.EventArgs e)
        {
            var year = ((Button)sender).Text;
            date[2] = year;

            ui_year_pick.BackgroundColor = Color.FromHex("#F5B22C");
            ui_year_pick_text.TextColor = Color.White;

            ui_year_pick_text.Text = year;

            if ((date[0] != "" && date[1] != "" && date[2] != "" && int.Parse(ui_current_age.Text) >= 16) && !string.IsNullOrWhiteSpace(ui_user_name.Text) && gender != "" && intrested != "")
                ui_finish_setup.IsVisible = true;
            else
                ui_finish_setup.IsVisible = false;

            SetUserCurrentAge(true);
            SetBirthDay(false, false, false, false);
        }

        private void PreviousSetup(object sender, System.EventArgs e)
        {
            ui_pages_setup.Children[current_setup].IsVisible = false;
            ui_current_page.Children[current_setup - 3].BackgroundColor = Color.FromHex("#C0C0C0");

            if(current_setup - 1 >= 3)
                current_setup--;

            if (current_setup != 3) ui_prev_setup.IsVisible = true;
            else ui_prev_setup.IsVisible = false;

            if (current_setup >= 5)
            {
                ui_next_setup.IsVisible = false;

                if ((date[0] != "" && date[1] != "" && date[2] != "" && int.Parse(ui_current_age.Text) >= 16) && !string.IsNullOrWhiteSpace(ui_user_name.Text) && gender != "" && intrested != "")
                    ui_finish_setup.IsVisible = true;
                else
                    ui_finish_setup.IsVisible = false;
            }
            else
            {
                ui_next_setup.IsVisible = true;
                ui_finish_setup.IsVisible = false;
            }

            ui_pages_setup.Children[current_setup].IsVisible = true;
            ui_current_page.Children[current_setup - 3].BackgroundColor = Color.FromHex("#F5B22C");
        }

        private void ContinueSetup(object sender, System.EventArgs e)
        {
            ui_pages_setup.Children[current_setup].IsVisible = false;
            ui_current_page.Children[current_setup - 3].BackgroundColor = Color.FromHex("#C0C0C0");

            if (current_setup + 1 <= 5)
                current_setup++;

            if (current_setup != 3) ui_prev_setup.IsVisible = true;
            else ui_prev_setup.IsVisible = false;

            if (current_setup >= 5)
            { 
                ui_next_setup.IsVisible = false;

                if ((date[0] != "" && date[1] != "" && date[2] != "" && int.Parse(ui_current_age.Text) >= 16) && !string.IsNullOrWhiteSpace(ui_user_name.Text) && gender != "" && intrested != "")
                    ui_finish_setup.IsVisible = true;
                else
                    ui_finish_setup.IsVisible = false;
            }
            else 
            { 
                ui_next_setup.IsVisible = true;
                ui_finish_setup.IsVisible = false;
            }

            ui_pages_setup.Children[current_setup].IsVisible = true;
            ui_current_page.Children[current_setup - 3].BackgroundColor = Color.FromHex("#F5B22C");
        }

        private void FinishSetup(object sender, System.EventArgs e)
        {
            DependencyService.Get<IUserDatabaseService>().UpdateUser(App.CurrentUser);
            App.Current.MainPage = new NavigationPage(new SearchView());
        }
    }
}