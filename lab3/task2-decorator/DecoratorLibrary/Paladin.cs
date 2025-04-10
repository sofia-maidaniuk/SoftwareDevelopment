using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesLibrary
{
    public class Paladin : IHero
    {
        public string GetDescription() => "Paladin";
        public int GetAttackPower() => 20;
        public int GetDefensePower() => 22;
        public int GetMagicPower() => 18;
    }
}
