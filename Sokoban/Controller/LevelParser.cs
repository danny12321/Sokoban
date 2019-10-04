using Sokoban.Model;
using System;
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

        public PlayingField getPlayingField(int level)
        {
            List<List<Square>> tempSquareList = new List<List<Square>>();
            Player player = null;
            Worker worker = null;

            string[] lines = System.IO.File.ReadAllLines($@"../../Levels/level{level}.txt");

            for (int y = 0; y < lines.Length; y++)
            {
                var row = new List<Square>();

                for (int x = 0; x < lines[y].Length; x++)
                {
                    switch (lines[y][x])
                    {
                        case '#':
                            row.Add(new Wall());
                            break;

                        case '.':
                            row.Add(new Floor());
                            break;

                        case 'o':
                            var chest = new Floor();
                            chest.Content = new Chest(chest);
                            row.Add(chest);
                            break;

                        case 'x':
                            row.Add(new Destination());
                            break;

                        case '@':
                            var floor = new Floor();
                            player = new Player(floor);
                            floor.Content = player;
                            row.Add(floor);
                            break;
                        case '~':
                            row.Add(new Pitfall());
                            break;
                        case '$':
                            var floor2 = new Floor();
                            worker = new Worker(floor2);
                            floor2.Content = worker;
                            row.Add(floor2);
                            break;
                        case ' ':
                            var empty = new Empty();
                            row.Add(empty);
                            break;
                    }
                }

                tempSquareList.Add(row);
            }

            PlayingField playingField = new PlayingField() { Player = player, Worker = worker };

            for (int i = 0; i < tempSquareList.Count; i++)
            {
                for (int j = 0; j < tempSquareList[i].Count; j++)
                {
                    // TOP
                    if (i > 0)
                    {
                        tempSquareList[i][j].Top = tempSquareList[i - 1][j];
                    }

                    // Bottom
                    if (i < tempSquareList.Count - 1)
                    {
                        tempSquareList[i][j].Bottom = tempSquareList[i + 1][j];
                    }

                    // Left
                    if (j > 0)
                    {
                        tempSquareList[i][j].Left = tempSquareList[i][j - 1];
                    }

                    // Right
                    if (j < tempSquareList[i].Count - 1)
                    {
                        tempSquareList[i][j].Right = tempSquareList[i][j + 1];
                    }

                    playingField.Squares.Add(tempSquareList[i][j]);
                }
            }

            return playingField;
        }
    }
}
