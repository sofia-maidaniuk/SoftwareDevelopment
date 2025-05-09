﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositeLibrary.Command
{
    public interface ICommand
    {
        void Execute();
        void Undo();
        string Description { get; }
    }
}
