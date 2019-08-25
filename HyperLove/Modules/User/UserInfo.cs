using System.Collections.Generic;
using Xamarin.Forms.Internals;

namespace HyperLove.Modules.User
{
    public enum EGenderIntrest
    {
        Male = 0,
        Women = 1,
        Mixed = 2
    }

    public enum ERelationship
    {
        Relationship = 0,
        SomethingCasual = 1,
        DontKnowYet = 2,
        Marriage = 3
    }

    public enum EEducation
    {
        SixthForm = 0,
        TechnicalCollege = 1,
        Undergraduate = 2,
        UndergraduateDegree = 3,
        Postgraduate = 4,
        PostgraduateDegree = 4,
    }

    public enum EChildren
    {
        WantSomeday = 0,
        DontWant = 1,
        HaveWantMore = 2,
        HaveDontWantMore = 3
    }

    public enum EPets
    {
        Dogs = 0,
        Cats = 1,
        None = 2,
        DontWant = 3,
        Lots = 4
    }

    public enum EExercise
    {
        Active = 0,
        Sometimes = 1,
        AlmostNever = 2
    }

    public enum EDrinking
    {
        Socially = 0,
        Never = 1,
        Frequently = 2
    }

    public enum ESmoking
    {
        Socially = 0,
        Never = 1,
        Frequently = 2
    }

    public enum EMarijuana
    {
        Socially = 0,
        Never = 1,
        Frequently = 2
    }

    public enum EDrugs
    {
        Socially = 0,
        Never = 1,
        Frequently = 2
    }

    public enum EStarSign
    {
        Aquarius = 0,
        Pisces = 1,
        Aries = 2,
        Taurus = 3,
        Gemini = 4,
        Cancer = 5,
        Leo = 6,
        Virgo = 7,
        Libra = 8,
        Scorpio = 9,
        Sagittarius = 10,
        Capricorn = 11
    }

    public enum EEthnicity
    {
        AmericanIndian = 0,
        BlackAfricanDescent = 1,
        EastAsian = 2,
        HispanicLatino = 3,
        MiddleEastern = 4,
        PacificIslander = 5,
        SouthAsian = 6,
        WhiteCaucasian = 7,
        Other = 8,
        OpenToAll = 9
    }

    public enum EReligion
    {
        Atheist = 0,
        Agnostic = 1,
        Buddhist = 2,
        Catholic = 3,
        Christian = 4,
        Hindu = 5,
        Jewish = 6,
        Muslim = 7,
        Spiritual = 8,
        Other = 9,
        OpenToAll = 10
    }

    public enum EPolitics
    {
        Apolitical = 0,
        Moderate = 1,
        Liberal = 2,
        Conservative = 3
    }

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
        public EMarijuana       Marijuana       = EMarijuana.Never;
        public EDrugs           Drugs           = EDrugs.Never;

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
        private string name;
        private int age;

        private string school;
        private string country;
        private string city;

        private string job;
        private string company;

        // Profile Info
        private string avatar;
        private string description;
        private bool verified;
        private bool premium;

        // Social Media Connections
        private bool instagram;
        private string instagram_id;

        private bool spotify;
        private string spotify_id;

        // App Info
        private List<string> likes;
        private List<string> dislikes;
        private List<string> loves;
        private List<string> matches;

        public PreferencesInfo Preferences { get => preferences; set => preferences = value; }

        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public string School { get => school; set => school = value; }
        public string Country { get => country; set => country = value; }
        public string City { get => city; set => city = value; }
        public string Job { get => job; set => job = value; }
        public string Company { get => company; set => company = value; }

        public string Description { get => description; set => description = value; }
        public string Avatar { get => avatar; set => avatar = value; }
        public bool Verified { get => verified; set => verified = value; }
        public bool Premium { get => premium; set => premium = value; }

        public List<string> Likes { get => likes; set => likes = value; }
        public List<string> Dislikes { get => dislikes; set => dislikes = value; }
        public List<string> Loves { get => loves; set => loves = value; }
        public List<string> Matches { get => loves; set => matches = value; }

        public bool Instagram { get => instagram; set => instagram = value; }
        public string Instagram_id { set => instagram_id = value; }

        public bool Spotify { get => spotify; set => spotify = value; }
        public string Spotify_id { set => spotify_id = value; }

        UserInfo() { }
        UserInfo(string empty_json) { }
    }
}
