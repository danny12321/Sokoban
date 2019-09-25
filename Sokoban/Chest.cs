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
            var squareTo = DirectionToSquare(direction);

            bool canMove = true;

            if (squareTo.Content is Chest) canMove = false;

            if(canMove)
            {
                if (!base.Move(direction)) canMove = false;
            }

            if (squareTo is Pitfall)
            {
                if (squareTo.CanFallThrough)
                {
                    Square.Content = null;
                }
            }

            return canMove;
        }
    }
}