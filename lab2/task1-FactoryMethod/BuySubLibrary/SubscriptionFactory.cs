using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SubscriptionsLibrary;

namespace BuySubLibrary
{
    public abstract class SubscriptionCreator
    {
        public abstract ISubscription CreateDomesticSubscription();
        public abstract ISubscription CreateEducationalSubscription();
        public abstract ISubscription CreatePremiumSubscription();

        protected void SimulateProcessing(string type)
        {
            Console.WriteLine($"Creating a {type} subscription...");
            Thread.Sleep(1500);
            Console.WriteLine("Entering details and making payment...");
            Thread.Sleep(1500);
            Console.WriteLine("Subscription created successfully!");
        }

        protected void VerifyStudentID()
        {
            Console.Write("Enter your student ID: ");
            string studentID = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(studentID) && studentID.Length >= 6)
            {
                Console.WriteLine("Student ID verified successfully.");
            }
            else
            {
                Console.WriteLine("Invalid student ID. Verification failed.");
                throw new InvalidOperationException("Subscription cannot be processed without student verification.");
            }
        }
    }
}
