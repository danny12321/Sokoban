using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class Chest : Content
    {
        public Chest(Square square) : base(square)
        {

        }

        public override bool Move(Direction direction)
        {
            var squareTo = DirectionToSquare(direction);


            if (squareTo.Content is Chest) return false;

            if (!base.Move(direction)) return false;

            if (squareTo is Pitfall)
            {
                if (squareTo.CanFallThrough)
                {
                    Square.Content = null;
                }
            }

            return true;
        }
    }
}