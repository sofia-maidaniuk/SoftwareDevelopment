using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionsLibrary
{
    public class PremiumSubscription : ISubscription
    {
        public decimal MonthlyFee { get; } = 20.0m;
        public int MinPeriod { get; } = 2;
        public List<string> Channels { get; } = new List<string> { "All Channels", "Sports+", "Movies+", "Exclusive Content" };
        public List<string> Features { get; } = new List<string> { "4K quality", "Up to 5 devices", "Access to exclusive shows" };

        public string DisplaySubscription()
        {
            StringBuilder info = new StringBuilder("Premium Subscription\n");
            info.AppendLine($"Monthly Fee: {MonthlyFee} USD")
                .AppendLine($"Minimum Period: {MinPeriod} months")
                .Append("Channels: ").Append(string.Join(", ", Channels)).AppendLine()
                .Append("Features: ").Append(string.Join(", ", Features))
                .AppendLine("\nIdeal for those who want everything at the highest quality.");

            return info.ToString();
        }
    }
}
