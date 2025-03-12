using SubscriptionsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BuySubLibrary
{
    public class WebSite : SubscriptionCreator
    {
        public override ISubscription CreateDomesticSubscription()
        {
            SimulateProcessing("domestic (website)");
            return new DomesticSubscription();
        }

        public override ISubscription CreateEducationalSubscription()
        {
            Console.WriteLine("Processing of educational documents...");
            VerifyStudentID();
            SimulateProcessing("educational (website)");
            return new EducationalSubscription();
        }

        public override ISubscription CreatePremiumSubscription()
        {
            SimulateProcessing("premium (website)");
            return new PremiumSubscription();
        }
    }
}
