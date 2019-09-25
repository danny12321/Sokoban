using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Chest : Content
    {
        public Chest(Square square) : base(square)
        {
            
        }

        public override void Show()
        {
            var e = Square;

            if(Square is Destination)
            {
                Console.Write("O");
            }
            else
            {
                Console.Write("o");
            }
        }

        public override bool Move(Direction direction)
        {
            Square squareTo = DirectionToSquare(direction);
            if (squareTo.Content is Chest) return false;

            return base.Move(direction);
        }
    }
}