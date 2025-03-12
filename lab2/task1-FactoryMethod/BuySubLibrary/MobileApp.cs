using BuySubLibrary;
using System;
using System.Threading;

namespace SubscriptionsLibrary
{
    public class MobileApp : SubscriptionCreator
    {
        public override ISubscription CreateDomesticSubscription()
        {
            SimulateProcessing("domestic (mobile app)");
            return new DomesticSubscription();
        }

        public override ISubscription CreateEducationalSubscription()
        {
            Console.WriteLine("Verifying student ID...");
            VerifyStudentID();
            SimulateProcessing("educational (mobile app)");
            return new EducationalSubscription();
        }

        public override ISubscription CreatePremiumSubscription()
        {
            SimulateProcessing("premium (mobile app)");
            return new PremiumSubscription();
        }
    }
}
