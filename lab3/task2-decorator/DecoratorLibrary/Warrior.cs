using HeroesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesLibrary
{
    public class Warrior : IHero
    {
        public string GetDescription() => "Warrior";
        public int GetAttackPower() => 45;
        public int GetDefensePower() => 20;
        public int GetMagicPower() => 2;
    }
}
