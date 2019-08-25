using System.Collections.Generic;
using HyperLove.Modules.Preferences;
using HyperLove.ViewModel.Preferences;
using HyperLove.ViewModel.Preferences.Premium;

namespace HyperLove.Modules
{
    public class PreferenceBindingContext
    {
        public List<PreferenceRowList> RowsList { get; set; }

        public PreferenceBindingContext()
        {
            var bPreference = new PreferenceRowList()
            {
                new PreferenceRow { Title = "I'm intrested in", Selection = App.CurrentUser.Preferences.Gender.ToString(),  Modal = new GenderSelection("Gender Selection")},
                new PreferenceRow { Title = "My neighborhood",  Selection = "Harborne",                                     Modal = new Neighborhood("Neighborhood")},
            };
            bPreference.Heading = "BASIC PREFERENCE";

            var mPreference = new PreferenceRowList()
            {
                new PreferenceRow {Title = "Age Range",         Selection = "21 to 27",                     Modal = new AgeRange("Age Range"), DealBreaker = true,},
                new PreferenceRow {Title = "Maximum distance",  Selection = "21 miles",                     Modal = new MaxDistance("Max Distance")},
                new PreferenceRow {Title = "Height",            Selection = "5'0 (152cm) to 6'0 (183cm)",   Modal = new HeightRange("Height Range"), DealBreaker = true,},
                new PreferenceRow {Title = "Ethnicity",         Selection = "Open to All",                  Modal = new EthnicitySelection("Ethnicity")},
                new PreferenceRow {Title = "Religion",          Selection = "Open to All",                  Modal = new ReligionSelection("Religion")},
            };
            mPreference.Heading = "MEMBER PREFERENCE";

            var pPreference = new PreferenceRowList()
            {
                new PreferenceRow { Title = "Children",     Selection = "Want Someday",         Premium = true, Modal = new Children("Children")},
                new PreferenceRow { Title = "Relationship", Selection = "Relationship",         Premium = true, Modal = new Relationship("Relationship")},
                new PreferenceRow { Title = "Pets",         Selection = "None",                 Premium = true, Modal = new Relationship("Pets")},
                new PreferenceRow { Title = "Exercise",     Selection = "Sometimes",            Premium = true, Modal = new Relationship("Exercise")},
                new PreferenceRow { Title = "Education",    Selection = "Undergraduate degree", Premium = true, Modal = new Education("Education")},
                new PreferenceRow { Title = "Politics",     Selection = "",                     Premium = true, Modal = new Politics("Politics")},
                new PreferenceRow { Title = "Drinking",     Selection = "Socially",             Premium = true, Modal = new Drinking("Drinking")},
                new PreferenceRow { Title = "Smoking",      Selection = "Never",                Premium = true, Modal = new Smoking("Smoking")},
                new PreferenceRow { Title = "Marijuana",    Selection = "Never",                Premium = true, Modal = new Marijuana("Marijuana")},
                new PreferenceRow { Title = "Drugs",        Selection = "Never",                Premium = true, Modal = new Drugs("Drugs")},
            };
            pPreference.Heading = "PREFERRED PREFERENCES";
            pPreference.Premium = true;

            var list = new List<PreferenceRowList>()
            {
                bPreference,
                mPreference,
                pPreference
            };

            RowsList = list;
        }
    }
}
