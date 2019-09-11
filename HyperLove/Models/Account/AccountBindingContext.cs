using System.Collections.Generic;
using HyperLove.Modules.Account;

namespace HyperLove.Modules
{
    public class AccountBindingContext
    {
        public List<AccountRowList> RowsList { get; set; }

        public AccountBindingContext()
        {
            var bProfileEdit = new AccountRowList()
            {
                new AccountRow { Title = "Add Mobile Number", },
            };
            bProfileEdit.Heading = "MOBILE NUMBER";

            var mProfileEdit = new AccountRowList()
            {
                new AccountRow { Title = "boowman.work@gmail.com", Entry = true, },
            };
            mProfileEdit.Heading = "EMAIL ADDRESS";

            var nProfileEdit = new AccountRowList()
            {
                new AccountRow { Title = "Push Notifications", Switch = true, Switched = true, },
            };
            nProfileEdit.Heading = "NOTIFICATIONS";

            var cProfileEdit = new AccountRowList()
            {
                new AccountRow { Title = "Facebook",   Switch = true, },
                new AccountRow { Title = "Instagram",  Switch = true, Switched = true, },
                new AccountRow { Title = "Spotify",    Switch = true, },
            };
            cProfileEdit.Heading = "CONNECTED ACCOUNTS";

            var lProfileEdit = new AccountRowList()
            {
                new AccountRow { Title = "Privacy Policy",     Link = true, URL = "https://google.com", },
                new AccountRow { Title = "Terms of Service",   Link = true, URL = "https://google.com", },
                new AccountRow { Title = "Cookies Policy",     Link = true, URL = "https://google.com", },
                new AccountRow { Title = "Safe Dating Tips",   Link = true, URL = "https://google.com", },
                new AccountRow { Title = "Licenses",           Link = true, URL = "https://google.com", },
            };
            lProfileEdit.Heading = "LEGAL";

            var list = new List<AccountRowList>()
            {
                bProfileEdit,
                mProfileEdit,
                nProfileEdit,
                cProfileEdit,
                lProfileEdit
            };

            RowsList = list;
        }
    }
}
