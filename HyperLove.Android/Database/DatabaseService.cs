using System;
using Xamarin.Forms;
using HyperLove.Database;
using HyperLove.Droid;
using Firebase.Firestore;
using Firebase;
using Java.Util;
using HyperLove.Models.User;
using System.Collections.Generic;
using System.Threading.Tasks;

[assembly: Dependency(typeof(DatabaseService))]
namespace HyperLove.Droid
{
    class DatabaseService : Java.Lang.Object, IUserDatabaseService, Firebase.Firestore.IEventListener
    {
        public FirebaseFirestore GetDatabase(Android.Content.Context activity)
        {
            FirebaseFirestore database;

            var options = new FirebaseOptions.Builder()
                .SetProjectId("datingapp-f9b91")
                .SetApplicationId("datingapp-f9b91")
                .SetApiKey("AIzaSyAI1FqTtwwCJXyoP_TB5ktdnayaA76hBgY")
                .SetDatabaseUrl("https://datingapp-f9b91.firebaseio.com")
                .SetStorageBucket("datingapp-f9b91.appspot.com")
                .Build();

            var app = FirebaseApp.InitializeApp(activity, options);
            database = FirebaseFirestore.GetInstance(app);

            return database;
        }

        public void CreateDatabase()
        {
            Console.WriteLine("Create Database From Android");
        }

        /* IUserDatabaseService
         */
        public void LookingForUser(string user_id)
        {
            if (user_id != "")
            {
                MainActivity.Instance.database.Collection("users").Document(user_id).AddSnapshotListener(this);
            }
        }

        public void CreateUser(UserProfile user)
        {
            HashMap carrer = new HashMap();
            carrer.Put("title", user.Carrer.Title);
            carrer.Put("company", user.Carrer.Company);

            HashMap location = new HashMap();
            location.Put("city", user.Location.City);
            location.Put("county", user.Location.County);
            location.Put("country", user.Location.Country);

            HashMap images = new HashMap();
            for (int x = 0; x < user.Images.Count; x++)
                images.Put(user.Images[x].Title, user.Images[x].URL);

            HashMap quotes = new HashMap();
            foreach (KeyValuePair<int, string> quote in user.Quotes)
                quotes.Put(quote.Key, quote.Value);

            HashMap login = new HashMap();
            login.Put("phone", "");
            login.Put("password", "");

            HashMap user_map = new HashMap();
            user_map.Put("first",    user.UserBase.First);
            user_map.Put("last",     user.UserBase.Last);
            user_map.Put("birthday", user.UserBase.Birthday.ToString());

            user_map.Put("email",       user.Email);
            user_map.Put("gender",      user.Gender);
            user_map.Put("intrestedIn", user.IntrestedIn);
            user_map.Put("school",      user.School);

            user_map.Put("verified",    user.Verified);
            user_map.Put("premium",     user.Premium);

            user_map.Put("carrer",      carrer);
            user_map.Put("images",      images);
            user_map.Put("location",    location);
            user_map.Put("quotes",      quotes);

            user_map.Put("phoneLogin",  login);

            DocumentReference reference = MainActivity.Instance.database.Collection("users").Document(user.UserBase.ID);
            reference.Set(user_map);
        }

        public void UpdateUser(UserProfile user)
        {
            CreateUser(user);
        }

        public void DeleteUser(UserBase userBase)
        {
            throw new NotImplementedException();
        }

        public void DisableUser(UserBase userBase)
        {
            throw new NotImplementedException();
        }

        public void LikedPerson(string userID, string likedPersonID)
        {
            Console.WriteLine("Liked Person");
        }

        public void LovedPerson(string userID, string lovedPersonID)
        {
            Console.WriteLine("Loved Person");
        }

        public void DislikedPerson(string userID, string dislikedPersonID)
        {
            Console.WriteLine("Disliked Person");
        }

        public void MatchedPerson(string userID, string matchedPersonID)
        {
            Console.WriteLine("Matched Person");
        }

        private UserProfile ConstructUserProfile(DocumentSnapshot snapshot)
        {
            UserProfile user = new UserProfile();

            user.UserBase.ID    = snapshot.Id.ToString();
            user.UserBase.First = (snapshot.Get("first")    != null) ? snapshot.Get("first").ToString()   : "Jane";
            user.UserBase.Last  = (snapshot.Get("last")     != null) ? snapshot.Get("last").ToString()    : "Doe";
            user.UserBase.Birthday = (snapshot.Get("birthday") != null) ? Convert.ToDateTime(snapshot.Get("birthday").ToString()) : Convert.ToDateTime("");

            user.Email  = (snapshot.Get("email")    != null) ? snapshot.Get("email").ToString()           : "";
            user.Gender = (snapshot.Get("gender")   != null) ? snapshot.Get("gender").ToString()          : "";

            user.School = (snapshot.Get("school") != null) ? snapshot.Get("school").ToString() : "";

            user.Verified   = (snapshot.Get("verified").ToString()  == "true") ? true : false;
            user.Premium    = (snapshot.Get("premium").ToString()   == "true") ? true : false;

            if (snapshot.Get("carrer") != null)
            {
                var job_dic = new Android.Runtime.JavaDictionary<string, string>(snapshot.Get("carrer").Handle, Android.Runtime.JniHandleOwnership.DoNotRegister);
                SProfileCarrer carrer = new SProfileCarrer();

                foreach (KeyValuePair<string, string> info in job_dic)
                {
                    if (info.Key == "title")        carrer.Title = info.Value;
                    else if (info.Key == "company") carrer.Company = info.Value;
                }

                user.Carrer = carrer;
            }

            if (snapshot.Get("quotes") != null)
            {
                var quotes_dic = new Android.Runtime.JavaDictionary<string, string>(snapshot.Get("quotes").Handle, Android.Runtime.JniHandleOwnership.DoNotRegister);

                foreach (KeyValuePair<string, string> info in quotes_dic)
                    user.Quotes.Add(int.Parse(info.Key), info.Value);
            }

            if (snapshot.Get("images") != null)
            {
                var images_dic = new Android.Runtime.JavaDictionary<string, string>(snapshot.Get("images").Handle, Android.Runtime.JniHandleOwnership.DoNotRegister);

                foreach(KeyValuePair<string, string> image in images_dic)
                {
                    user.Images.Add(new SProfileImage() { Title = image.Key, URL = image.Value });
                }
            }

            if (snapshot.Get("location") != null)
            {
                var location_dic = new Android.Runtime.JavaDictionary<string, string>(snapshot.Get("location").Handle, Android.Runtime.JniHandleOwnership.DoNotRegister);

                foreach (KeyValuePair<string, string> location in location_dic)
                {
                    if (location.Key == "city")         user.Location.City      = location.Value;
                    else if (location.Key == "county")  user.Location.County    = location.Value;
                    else if (location.Key == "country") user.Location.Country   = location.Value;
                }
            }
            
            if (snapshot.Get("phoneLogin") != null)
            {
                var login_disc = new Android.Runtime.JavaDictionary<string, string>(snapshot.Get("phoneLogin").Handle, Android.Runtime.JniHandleOwnership.DoNotRegister);
            }

            return user;
        }

        public void OnEvent(Java.Lang.Object value, FirebaseFirestoreException error)
        {
            var snapshot = (DocumentSnapshot)value;
            var profileCompleted = false;

            if(snapshot.Exists())
            {
                UserProfile user = ConstructUserProfile(snapshot);
                App.UserSetupProfile(user);

                profileCompleted = (user.UserBase.First != "" && user.UserBase.Last != "" && user.UserBase.Birthday.ToString() != "" && user.Gender != "");
            }
            else
            {
                Console.WriteLine("Creating User");

                CreateUser(App.CurrentUser);
                LookingForUser(App.CurrentUser.UserBase.ID);

                return;
            }

            Console.WriteLine("Calling This: " + profileCompleted);
            App.LoginSuccessful(snapshot.Exists(), profileCompleted);
        }
    }
}