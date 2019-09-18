using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    class Program
    {
        static void Main(string[] args)
        {
            var LevelParser = new LevelParser();

            LevelParser.getPlayingField();




            Console.ReadKey();
        }
    }
}
