using System.Collections.Generic;

namespace HyperLove.Modules.Account
{
    public class AccountRowList : List<AccountRow>
    {
        public string Heading { get; set; }

        public List<AccountRow> AccountRows => this;
    }
}
