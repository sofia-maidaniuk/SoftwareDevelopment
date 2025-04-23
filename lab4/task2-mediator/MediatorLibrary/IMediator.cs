using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrary
{
    public interface IMediator
    {
        void RegisterRunway(Runway runway);
        void RegisterAircraft(Aircraft aircraft);
        bool Notify(Aircraft aircraft, string eventType);
        bool Notify(Runway runway, string eventType);
    }
}
