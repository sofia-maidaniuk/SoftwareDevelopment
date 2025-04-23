using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrary
{
    public class CommandCentre : IMediator
    {
        private readonly List<Runway> runways = new List<Runway>();
        private readonly List<Aircraft> aircrafts = new List<Aircraft>();
        private readonly Dictionary<Runway, bool> runwayStatus = new Dictionary<Runway, bool>();

        public void RegisterRunway(Runway runway)
        {
            runways.Add(runway);
            runwayStatus[runway] = true;
        }

        public void RegisterAircraft(Aircraft aircraft)
        {
            aircrafts.Add(aircraft);
        }

        public bool Notify(Aircraft aircraft, string eventType)
        {
            if (eventType == "Land")
            {
                foreach (var runway in runways)
                {
                    if (runwayStatus[runway])
                    {
                        Console.WriteLine($"Aircraft {aircraft.Name} is landing.");
                        runway.IsBusyWithAircraft = aircraft;
                        aircraft.CurrentRunway = runway;
                        runway.HighLightRed();
                        Console.WriteLine($"Aircraft {aircraft.Name} has landed.");
                        runwayStatus[runway] = false;
                        return true;
                    }
                }
                Console.WriteLine("All runways are busy. Please wait.");
                return false;
            }
            else if (eventType == "TakeOff")
            {
                if (aircraft.CurrentRunway != null)
                {
                    Console.WriteLine($"Aircraft {aircraft.Name} is taking off.");
                    var runway = aircraft.CurrentRunway;
                    runway.IsBusyWithAircraft = null;
                    runwayStatus[runway] = true;
                    aircraft.CurrentRunway = null;
                    runway.HighLightGreen();
                    Console.WriteLine($"Aircraft {aircraft.Name} has taken off.");
                    return true;
                }
            }
            return false;
        }

        public bool Notify(Runway runway, string eventType)
        {
            if (eventType == "RunwayClear")
            {
                runwayStatus[runway] = true;
                Console.WriteLine($"Runway {runway.Id} is now free.");
                return true;
            }
            return false;
        }
    }
}
