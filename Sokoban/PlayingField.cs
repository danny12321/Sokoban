using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class PlayingField
    {
        private List<List<Square>> _squareList = new List<List<Square>>();

        public List<List<Square>> SquareList
        {
            get { return _squareList; }
            set { _squareList = value; }
        }

        public void Show()
        {
            Console.Clear();

            _squareList.ForEach(row =>
            {
                Console.WriteLine();

                row.ForEach(s =>
                {
                    if (s.Moving == null)
                    {
                        s.Show();
                    } else
                    {
                        s.Moving.Show();
                    }
                });
            });
        }

    }
}