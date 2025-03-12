using System;
using BuySubLibrary;
using SubscriptionsLibrary;

namespace ConsoleApp_task1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\nChoose a subscription purchase method:");
                Console.WriteLine("1 - WebSite");
                Console.WriteLine("2 - Mobile App");
                Console.WriteLine("3 - Manager Call");
                Console.WriteLine("0 - Exit");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();
                SubscriptionCreator creator;

                switch (input)
                {
                    case "1":
                        creator = new WebSite();
                        break;
                    case "2":
                        creator = new MobileApp();
                        break;
                    case "3":
                        creator = new ManagerCall();
                        break;
                    case "0":
                        Console.WriteLine("Exiting the program...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Please enter 1, 2, or 3.");
                        continue;
                }

                Console.WriteLine("\nChoose a subscription type:");
                Console.WriteLine("1 - Domestic Subscription");
                Console.WriteLine("2 - Educational Subscription");
                Console.WriteLine("3 - Premium Subscription");
                Console.Write("Enter your choice: ");

                string subscriptionType = Console.ReadLine();
                ISubscription subscription;

                switch (subscriptionType)
                {
                    case "1":
                        subscription = creator.CreateDomesticSubscription();
                        break;
                    case "2":
                        subscription = creator.CreateEducationalSubscription();
                        break;
                    case "3":
                        subscription = creator.CreatePremiumSubscription();
                        break;
                    default:
                        Console.WriteLine("Invalid subscription type! Please enter 1, 2, or 3.");
                        continue;
                }

                Console.WriteLine("\n" + subscription.DisplaySubscription());
            }
        }
    }
}
