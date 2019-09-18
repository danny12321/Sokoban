﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class LevelParser
    {
        public LevelParser()
        {
            

        }

        public PlayingField getPlayingField()
        {
            PlayingField playingField = new PlayingField();
            string[] lines = System.IO.File.ReadAllLines(@"../../Levels/level1.txt");

            for (int y = 0; y < lines.Length; y++)
            {
                for (int x = 0; x < lines[y].Length; x++)
                {
                    switch(lines[y][x])
                    {
                        case '#':
                            var wall = new Wall();
                            wall.PosX = x;
                            wall.PosY = y;
                            playingField.SquareList.Add(new Wall());
                            break;

                        case '.':
                            var floor = new Floor();
                            playingField.SquareList.Add(floor);
                            break;

                        case 'o':
                            var chest = new Floor();
                            chest.PosX = x;
                            chest.PosY = y;
                            chest.Moving = new Chest();
                            playingField.SquareList.Add(chest);
                            break;

                        case 'x':
                            var destination = new Destination();
                            destination.PosX = x;
                            destination.PosY = y;
                            playingField.SquareList.Add(destination);
                            break;

                        case '@':
                            var player = new Floor();
                            player.PosX = x;
                            player.PosY = y;
                            player.Moving = new Player();
                            playingField.SquareList.Add(player);
                            break;
                    }
                }
            }

            return playingField;
        }
    }
}
