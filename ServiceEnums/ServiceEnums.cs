using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LijonGraph.ServiceEnums
{
    public class ServiceEnums
    {
        public enum AccountEnabled
        {
            EnabledOnly,
            DisabledOnly,
            All
        }

        public enum ShowGuests
        {
            GuestsOnly,
            NoGuests,
            All
        }
    }
}
