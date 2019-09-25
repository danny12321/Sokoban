using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Player : Content
    {
        public Player(Square square) : base (square)
        {

        }

        public override void Show()
        {
            Console.Write("@");
        }

        public override bool Move(Direction direction)
        {
            Square squareTo = DirectionToSquare(direction);

            bool canMove = true;

            if(squareTo.Content is Chest)
            {
                if(!squareTo.Content.Move(direction))
                {
                    canMove = false;
                }
            }

            if (canMove)
            {

                if (!base.Move(direction))
                {
                    canMove = false;
                }
            }
            return canMove;
        }

    }
}