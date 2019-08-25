using HyperLove.Modules.User;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace HyperLove
{
    public partial class App : Application
    {
        public static UserInfo CurrentUser;

        public App()
        {
            string temp_user = "{'Avatar': 'http://lenardpop.co.uk/35166515_1772929786132028_1651862336350191616_n.jpg','Premium': true,'Name': 'Lenard Pop','Age': 25,'School': 'Bucks New University','Job': 'Junior Web Developer','Company': 'TonyG','City': 'Birmingham','Country': 'United Kingdom','Description': 'Lorem Opus','Instagram': false,'Instagram_ID': '0x25ni25oin25','Spotify': false,'Spotify_ID': '2srw5252n5io21qn513','Verified': false,'likes': ['vDHjTTuDnU','PKzRuRdnrO','vDHjTTuDnU','XFIjvlAzsE','DWRpSptEzs','qSekBhXaTK'],'dislikes': ['ekORzzDUYP','YGGeamCDWt','urnuxTklTZ'],'loves': ['WuMUtemMfK'],'matches': ['LBZWsrbwdY','wmTICtGJTz','kJjgDCRmFm','vZWzFSyVTz']}";

            AssignCurrentUser(temp_user);
            InitializeComponent();

            MainPage = new NavigationPage(new SearchView());
        }

        public void AssignCurrentUser(string user_info)
        {
            CurrentUser = JsonConvert.DeserializeObject<UserInfo>(user_info);
            CurrentUser.Preferences = new PreferencesInfo();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
