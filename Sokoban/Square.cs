using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class Square
    {
        public Moving Moving { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
    }
}