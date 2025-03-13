using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuilderLibrary;

namespace ConsoleApp5
{
    using System;
    using System.Reflection.Emit;
    using BuilderLibrary;

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ICharacterBuilder heroBuilder = new HeroBuilder();
            ICharacterBuilder enemyBuilder = new EnemyBuilder();
            MyCharacter director = new MyCharacter();

            Character hero = director.ConstructHero(heroBuilder);
            Character enemy = director.ConstructEnemy(enemyBuilder);

            Console.WriteLine("Hero:");
            Console.WriteLine(hero.GetCharacterInfo());

            Console.WriteLine("Enemy:");
            Console.WriteLine(enemy.GetCharacterInfo());
        }
    }

}
