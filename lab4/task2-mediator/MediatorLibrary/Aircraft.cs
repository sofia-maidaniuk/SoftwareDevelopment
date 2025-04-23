using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorLibrary
{
    public class Aircraft
    {
        private readonly IMediator _mediator;
        public string Name { get; }
        public Runway CurrentRunway { get; set; } 
        public bool IsTakingOff { get; set; }

        public Aircraft(string name, IMediator mediator)
        {
            Name = name;
            _mediator = mediator;
            _mediator.RegisterAircraft(this);
        }

        public void Land()
        {
            _mediator.Notify(this, "Land");
        }

        public void TakeOff()
        {
            _mediator.Notify(this, "TakeOff");
        }
    }
}
