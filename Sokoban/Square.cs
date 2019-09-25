using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class Square
    {
        public Moving Moving { get; set; }

        public virtual void Show()
        {
            Console.Write(" ");
        }
    }
}