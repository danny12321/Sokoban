using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class PlayingField
    {
        private List<Square> _squareList = new List<Square>();

        public List<Square> SquareList
        {
            get { return _squareList; }
            set { _squareList = value; }
        }

    }
}