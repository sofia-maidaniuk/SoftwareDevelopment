using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderLibrary
{
    public class MyCharacter
    {
        public Character ConstructHero(ICharacterBuilder builder)
        {
            return builder
                .SetName("Katniss Everdeen")
                .SetHeight(170)
                .SetBodyType("Athletic")
                .SetHairColor("Dark Brown")
                .SetEyeColor("Gray")
                .SetOutfit("Hunting gear with Mockingjay pin")
                .SetInventory("Bow and arrows, Healing herbs")
                .AddAction("Won the Hunger Games")
                .AddAction("Led the rebellion against the Capitol")
                .AddAction("Protected her family and friends")
                .GetCharacter();
        }

        public Character ConstructEnemy(ICharacterBuilder builder)
        {
            return builder
                .SetName("President Coriolanus Snow")
                .SetHeight(180)
                .SetBodyType("Slim but authoritative")
                .SetHairColor("White")
                .SetEyeColor("Cold Blue")
                .SetOutfit("Elegant black suit with a red rose")
                .SetInventory("Poisoned drinks, Political influence")
                .AddAction("Ruled Panem with an iron fist")
                .AddAction("Manipulated the Hunger Games to maintain control")
                .AddAction("Executed rebels mercilessly")
                .GetCharacter();
        }

    }
}
