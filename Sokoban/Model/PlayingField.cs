using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban.Model
{
    public class PlayingField
    {
        public List<Square> Squares { get; set; } = new List<Square>();
        public Player Player;
        public Worker Worker;

        

    }
}