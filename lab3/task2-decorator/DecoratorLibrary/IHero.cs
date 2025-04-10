using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesLibrary
{
    public interface IHero
    {
        string GetDescription();
        int GetAttackPower();
        int GetDefensePower();
        int GetMagicPower();
    }


}
