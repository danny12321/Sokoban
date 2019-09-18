using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sokoban
{
    public class Floor : Square
    {


        public override void Show()
        {
            Console.Write(".");
        }
    }
}