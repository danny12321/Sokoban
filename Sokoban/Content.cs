using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public abstract class Content
    {
        public Square Square { get; set; }

        public Content(Square square)
        {
            Square = square;
        }

        public virtual void Show()
        {
            Console.Write(" ");
        }

        protected Square DirectionToSquare(Direction direction)
        {
            switch (direction)
            {
                case Direction.Top:
                    return Square.Top;
                case Direction.Right:
                    return Square.Right;
                case Direction.Bottom:
                    return Square.Bottom;
                case Direction.Left:
                    return Square.Left;
            }

            return null;
        }

        public virtual bool Move(Direction direction)
        {
            Square squareTo = DirectionToSquare(direction);

            // Never go on a wall
            if (squareTo is Wall)
            {
                return false;
            }

            //if (squareTo.Content != null)
            //{
            //
            //    if (!squareTo.Content.Move(direction))
            //    {
            //        return false;
            //    }
            //}

            //if (Square.Content != null)
            //{
            //    Square.Content.Square = squareTo;
            //}
            //
            //squareTo.Content = Square.Content;
            //Square.Content = null;

            return true;
        }
    }
}