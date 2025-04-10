using HeroesLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesLibrary
{
    public class Mage : IHero
    {
        public string GetDescription() => "Mage";
        public int GetAttackPower() => 9;
        public int GetDefensePower() => 16;
        public int GetMagicPower() => 32;
    }
}
