using System;
using System.Collections.Generic;
using System.Text;

namespace SubscriptionsLibrary
{
    public class DomesticSubscription : ISubscription
    {
        public decimal MonthlyFee { get; } = 10.0m;
        public int MinPeriod { get; } = 3;
        public List<string> Channels { get; } = new List<string> { "1+1", "ICTV", "Novyi Channnel", "STB" };
        public List<string> Features { get; } = new List<string> { "Pause an online broadcast", "View recordings of online broadcasts" };

        public string DisplaySubscription()
        {
            StringBuilder info = new StringBuilder("Domestic Subscription\n");
            info.AppendLine($"Monthly Fee: {MonthlyFee} USD")
                .AppendLine($"Minimum Period: {MinPeriod} months")
                .Append("Channels: ").Append(string.Join(", ", Channels)).AppendLine()
                .Append("Features: ").Append(string.Join(", ", Features))
                .AppendLine("\nIdeal for home viewing of popular channels.");

            return info.ToString();
        }
    }
}
