using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionsLibrary
{
    public interface ISubscription
    {
        decimal MonthlyFee { get; }
        int MinPeriod { get; }
        List<string> Channels { get; }
        List<string> Features { get; }

        string DisplaySubscription();
    }
}

