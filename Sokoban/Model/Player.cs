using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class Player : Content
    {
        public Player(Square square) : base(square)
        {

        }

        public override bool Move(Direction direction)
        {
            Square squareTo = DirectionToSquare(direction);

            if (squareTo.Content is Worker)
            {
                var worker = (Worker)squareTo.Content;
                worker.IsSleeping = false;
                return false;
            }

            if (!base.Move(direction))
            {
                return false;
            }

            return true;
        }
    }
}