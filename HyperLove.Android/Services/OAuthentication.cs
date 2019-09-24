using System;
using System.Threading.Tasks;
using HyperLove.Droid;
using HyperLove.Models.User;
using HyperLove.Services;
using Newtonsoft.Json.Linq;
using Xamarin.Auth;
using Xamarin.Forms;

[assembly: Dependency(typeof(OAuthentication))]
namespace HyperLove.Droid
{
    public class OAuthentication : IOAuthentication
    {
        public void FacebookLogin()
        {
            var auth = new OAuth2Authenticator(
                clientId: "400271123861358",
                scope: "",
                authorizeUrl: new System.Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new System.Uri("https://www.facebook.com/connect/login_success.html"));

            auth.Completed += FacebookAuth_Completed;
            MainActivity.Instance.OAuthStartActivity(auth);
        }

        private async void FacebookAuth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            if (e.IsAuthenticated)
            {
                Console.WriteLine("Facebook Authentication");

                var request = new OAuth2Request(
                    "GET",
                    new System.Uri("https://graph.facebook.com/me?fields=id,first_name,last_name,albums{photos{images},name,picture{url}}"),
                    null,
                    e.Account);

                var fbResponse = await request.GetResponseAsync();
                var fbUser = JObject.Parse(fbResponse.GetResponseText());

                UserBase user = new UserBase();
                user.ID = fbUser["id"].ToString();
                user.First = fbUser["first_name"].ToString();
                user.Last = fbUser["last_name"].ToString();
                //user.Avatar = fbUser["pictures"]["data"]["url"].ToString();

                Console.WriteLine("Get Facebook Data");
                Console.WriteLine(fbUser);
                
                App.AuthenticationSuccessful(user);
            }
        }

        public void InstagramLogin()
        {
            var auth = new OAuth2Authenticator(
                clientId: "400271123861358",
                scope: "",
                authorizeUrl: new System.Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new System.Uri("https://www.facebook.com/connect/login_success.html"));

            auth.Completed += InstagramAuth_Completed;
            MainActivity.Instance.OAuthStartActivity(auth);
        }

        public void InstagramAuth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void GoogleAuthntication()
        {
            var auth = new OAuth2Authenticator(
                clientId: "400271123861358",
                scope: "",
                authorizeUrl: new System.Uri("https://m.facebook.com/dialog/oauth/"),
                redirectUrl: new System.Uri("https://www.facebook.com/connect/login_success.html"));

            auth.Completed += GoogleAuth_Completed;
            MainActivity.Instance.OAuthStartActivity(auth);
        }

        public void GoogleAuth_Completed(object sender, AuthenticatorCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}