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

            if (base.Move(direction))
            {

                Square.Content = null;

                Square = squareTo;
                squareTo.Content = this;

            }



            return true;
        }
    }
}