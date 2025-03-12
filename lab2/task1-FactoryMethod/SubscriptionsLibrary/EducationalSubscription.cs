using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubscriptionsLibrary
{
    public class EducationalSubscription : ISubscription
    {
        public decimal MonthlyFee { get; } = 15.0m;
        public int MinPeriod { get; } = 3;
        public List<string> Channels { get; } = new List<string> { "Discovery", "National Geographic", "History Channel" };
        public List<string> Features { get; } = new List<string> { "No Ads", "Access to educational content" };

        public string DisplaySubscription()
        {
            StringBuilder info = new StringBuilder("Educational Subscription\n");
            info.AppendLine($"Monthly Fee: {MonthlyFee} USD")
                .AppendLine($"Minimum Period: {MinPeriod} months")
                .Append("Channels: ").Append(string.Join(", ", Channels)).AppendLine()
                .Append("Features: ").Append(string.Join(", ", Features))
                .AppendLine("\nA great choice for learning without ads.");

            return info.ToString();
        }
    }

}
