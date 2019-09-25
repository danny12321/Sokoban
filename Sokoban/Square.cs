using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class Square
    {
        public Content Content { get; set; }
        public Square Top { get; set; }
        public Square Right { get; set; }
        public Square Bottom { get; set; }
        public Square Left { get; set; }

        public virtual void Show()
        {
            Console.Write(" ");
        }
    }
}