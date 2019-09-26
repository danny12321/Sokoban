﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class PlayingField
    {
        public List<Square> Squares { get; set; } = new List<Square>();
        public Player Player;
        public Worker Worker;

        public void Show()
        {
            // Console.Clear();
            var vertical = Squares[0];

            while (vertical != null)
            {

                var horizontal = vertical;

                while (horizontal != null)
                {
                    if (horizontal.Content != null)
                    {
                        horizontal.Content.Show();
                    }
                    else
                    {
                        horizontal.Show();
                    }
                    horizontal = horizontal.Right;
                }


                Console.WriteLine();
                vertical = vertical.Bottom;

            }
        }

    }
}