using System;

namespace MediatorLibrary
{
    public class Runway
    {
        public readonly Guid Id = Guid.NewGuid();
        public Aircraft IsBusyWithAircraft; 

        public bool CheckIsActive()
        {
            return IsBusyWithAircraft != null && IsBusyWithAircraft.IsTakingOff;
        }

        public void HighLightRed()
        {
            Console.WriteLine($"Runway {this.Id} is busy!");
        }

        public void HighLightGreen()
        {
            Console.WriteLine($"Runway {this.Id} is free!");
        }
    }
}
