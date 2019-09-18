using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Chest : Moving
    {
        public Chest(Square square) : base(square)
        {
            
        }

        public override void Show()
        {
            Console.Write("o");
        }
    }
}