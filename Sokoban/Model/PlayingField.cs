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

        
        public bool CheckWin()
        {
            bool hasWon = true;
            Squares.FindAll(s => s is Destination).ForEach(s =>
            {
                if (!(s.Content is Chest))  
                {
                    hasWon = false;
                }
            });

            return hasWon;
        }
    }
}