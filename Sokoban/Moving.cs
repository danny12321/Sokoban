using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class Moving
    {
        public Square Square { get; set; }

        public Moving(Square square)
        {
            Square = square;
        }

        public virtual void Show()
        {
            Console.Write(" ");
        }
    }
}