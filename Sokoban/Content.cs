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

            if (squareTo is Wall) return false;

            if (squareTo.Content is Chest)
            {
                if (!squareTo.Content.Move(direction))
                {
                    return false;
                }
            }

            Square.Content = null;

            Square = squareTo;
            squareTo.Content = this;

            return true;
        }

    }
}