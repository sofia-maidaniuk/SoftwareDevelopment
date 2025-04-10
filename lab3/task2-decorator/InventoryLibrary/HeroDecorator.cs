using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesLibrary;

namespace InventoryLibrary
{
    public abstract class HeroDecorator : IHero
    {
        protected IHero _baseHero;

        protected HeroDecorator(IHero hero)
        {
            _baseHero = hero;
        }

        public virtual string GetDescription() => _baseHero.GetDescription();
        public virtual int GetAttackPower() => _baseHero.GetAttackPower();
        public virtual int GetDefensePower() => _baseHero.GetDefensePower();
        public virtual int GetMagicPower() => _baseHero.GetMagicPower();
    }
}
