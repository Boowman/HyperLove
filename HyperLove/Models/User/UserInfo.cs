using System.Collections.Generic;
using Xamarin.Forms.Internals;
using HyperLove.Models.User;
using System;

namespace HyperLove.Modules.User
{
    public class PreferencesInfo
    {
        public Relationship Relationship    = new Relationship()    { Enabled = true, Icon = "f004", Value = ERelationship.Relationship  };
        public GenderIntrest Gender         = new GenderIntrest()   { Enabled = true, Icon = "f228", Value = EGenderIntrest.Mixed        };
        public Children Children            = new Children()        { Enabled = true, Icon = "f77c", Value = EChildren.WantSomeday       };
        public Education Education          = new Education()       { Enabled = true, Icon = "f19d", Value = EEducation.Postgraduate     };
        public Pets Pets                    = new Pets()            { Enabled = true, Icon = "f1b0", Value = EPets.DontWant              };
        public Exercise Exercise            = new Exercise()        { Enabled = true, Icon = "f44b", Value = EExercise.Sometimes         };

        public Drinking Drinking    = new Drinking()    { Enabled = true, Icon = "f5ce", Value = EDrinking.Socially  };
        public Smoking Smoking      = new Smoking()     { Enabled = true, Icon = "f48d", Value = ESmoking.Never      };

        public Ethnicity Ethnicity  = new Ethnicity()   { Enabled = true, Icon = "f0c0", Value = EEthnicity.EastAsian    };
        public Religion Religion    = new Religion()    { Enabled = true, Icon = "f683", Value = EReligion.Atheist       };
        public Politics Politics    = new Politics()    { Enabled = true, Icon = "f66f", Value = EPolitics.Apolitical    };

        //public string Neighborhood;

        // Range
        public int MinAge   = 18;
        public int MaxAge   = 75;

        // Max Distance
        public int Distance = 20;

        // Centimeters
        public float Height = 170.0f;

        public bool Available()
        {
            if (Relationship.Enabled || Gender.Enabled || Children.Enabled || Education.Enabled || Pets.Enabled || Exercise.Enabled || Drinking.Enabled || Smoking.Enabled || Ethnicity.Enabled || Religion.Enabled || Politics.Enabled)
                return true;

            return false;
        }
    }

    [Preserve(AllMembers = true)]
    public class UserInfo
    {
        private string userID;

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

        public string UserID { get => userID; set => userID = value; }

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

            instagram = new UserSocialAccount();
            spotify     = new UserSocialAccount();
        }

        public List<SpotifyAlbum> GetSpotifyAlbums()
        {
            /*
                Get App.SearchingProfiles[currentUser].Spotify.Social_ID
                    Connect to spotify's API and retrieve info regarding the Social_ID
                        Get 10 Most Listened to songs
                            Get the label and image of the album
            */
            Console.WriteLine("Spotify: " + UserID + "Social ID: " + Spotify.Social_ID);

            List<SpotifyAlbum> temp = new List<SpotifyAlbum>();
            temp.Add(new SpotifyAlbum() { Label = "Travis Scott",   Image = "travis_scott" });
            temp.Add(new SpotifyAlbum() { Label = "The Weekend",    Image = "the_weekend" });
            temp.Add(new SpotifyAlbum() { Label = "Kanye West",     Image = "kanye_west" });

            return temp;
        }

        public List<InstagramPicture> GetInstagramImages()
        {                    
            /*
                Get App.SearchingProfiles[currentUser].Instagram.Social_ID
                    Connect to instagram's API and retrieve the newest images
                        Get any title of the image and the image url
            */
            Console.WriteLine("Instagram: " + UserID + "Social ID: " + Instagram.Social_ID);

            List<InstagramPicture> temp = new List<InstagramPicture>();
            temp.Add(new InstagramPicture() { Label = "Selfie",     Image = "insta_1" });
            temp.Add(new InstagramPicture() { Label = "Holiday",    Image = "insta_4" });
            temp.Add(new InstagramPicture() { Label = "Summer",     Image = "insta_5" });
            temp.Add(new InstagramPicture() { Label = "Fuck off",   Image = "insta_3" });

            return temp;
        }
    }
}
