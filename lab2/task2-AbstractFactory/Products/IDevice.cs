﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device
{
    public interface IDevice
    {
        string Name { get; }
        void DisplayInfo();
    }
}
