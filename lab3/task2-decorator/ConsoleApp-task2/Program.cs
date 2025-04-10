using HeroesLibrary;
using InventoryLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_task2
{
    class Program
    {
        static void Main()
        {
            // Base hero1 Warrior
            IHero hero1 = new Warrior();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Base Hero:");
            Console.ResetColor();
            PrintStats(hero1);

            // Add sword
            hero1 = new Sword(hero1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAfter adding a sword:");
            Console.ResetColor();
            PrintStats(hero1);

            // Add shield
            hero1 = new Shield(hero1);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAfter adding a shield:");
            Console.ResetColor();
            PrintStats(hero1);

            IHero hero2 = new Mage();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nBase Hero:");
            Console.ResetColor();
            PrintStats(hero2);
            // Add amulet
            hero2 = new Amulet(hero2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nAfter adding an amulet:");
            Console.ResetColor();
            PrintStats(hero2);
        }

        static void PrintStats(IHero hero)
        {
            Console.WriteLine($"Description: {hero.GetDescription()}");
            Console.WriteLine($"Attack Power: {hero.GetAttackPower()}");
            Console.WriteLine($"Defense Power: {hero.GetDefensePower()}");
            Console.WriteLine($"Magic Power: {hero.GetMagicPower()}");
        }
    }
}
