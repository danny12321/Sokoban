using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class Moving
    {
        public virtual void Show()
        {
            Console.Write(" ");
        }
    }
}