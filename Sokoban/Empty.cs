using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban
{
    public class Empty : Square
    {

        public bool Move()
        {
            return false;
        }
    }
}
