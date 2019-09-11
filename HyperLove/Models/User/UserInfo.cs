using System.Collections.Generic;
using Xamarin.Forms.Internals;
using HyperLove.Models.User;

namespace HyperLove.Modules.User
{
    public class PreferencesInfo
    {
        public ERelationship    Relationship    = ERelationship.SomethingCasual;
        public EGenderIntrest   Gender          = EGenderIntrest.Mixed;
        public EChildren        Children        = EChildren.WantSomeday;
        public EEducation       Education       = EEducation.SixthForm;
        public EPets            Pets            = EPets.None;
        public EExercise        Exercise        = EExercise.Active;

        public EDrinking        Drinking        = EDrinking.Never;
        public ESmoking         Smoking         = ESmoking.Never;

        public EEthnicity   Ethnicity           = EEthnicity.Other;
        public EReligion    Religion            = EReligion.Other;
        public EPolitics    Politics            = EPolitics.Liberal;

        //public string Neighborhood;

        // Range
        public int MinAge   = 18;
        public int MaxAge   = 75;

        // Max Distance
        public int Distance = 20;

        // Centimeters
        public float Height = 170.0f;
    }

    [Preserve(AllMembers = true)]
    public class UserInfo
    {
        // Search Preferences
        private PreferencesInfo preferences;

        // Private Info
        private string first;
        private string last;
        private string email;
        private int age;

        private string school;
        private string job;
        private string company;

        // Profile Info
        private Dictionary<int, string> quotes;
        private UserSwipes userSwipes;

        private UserLocation location;

        private List<string> images;
        private bool verified;
        private bool premium;

        // Social Media Connections
        private UserSocialAccount instagram;
        private UserSocialAccount spotify;

        public PreferencesInfo Preferences { get => preferences; set => preferences = value; }

        public string First { get => first; set => first = value; }
        public string Last { get => last; set => last = value; }
        public string Email { get => email; set => email = value; }
        public int Age { get => age; set => age = value; }

        public UserLocation Location { get => location; set => location = value; }

        public string School { get => school; set => school = value; }
        public string Job { get => job; set => job = value; }
        public string Company { get => company; set => company = value; }

        public List<string> Images { get => images; set => images = value; }
        public bool Verified { get => verified; set => verified = value; }
        public bool Premium { get => premium; set => premium = value; }

        public Dictionary<int, string> Quotes { get => quotes; set => quotes = value; }

        public UserSwipes Swipes { get => userSwipes; set => userSwipes = value; }

        public UserSocialAccount Instagram { get => instagram; set => instagram = value; }

        public UserSocialAccount Spotify { get => spotify; set => spotify = value; }

        public UserInfo() 
        {
            preferences = new PreferencesInfo();

            images = new List<string>();
            quotes = new Dictionary<int, string>();

            location = new UserLocation();

            userSwipes          = new UserSwipes();
            userSwipes.Matches  = new List<string>();
            userSwipes.Loves    = new List<string>();
            userSwipes.Likes    = new List<string>();
            userSwipes.Dislikes = new List<string>();


            instagram   = new UserSocialAccount();
            spotify     = new UserSocialAccount();
        }
    }
}
