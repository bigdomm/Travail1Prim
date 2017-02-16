using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe_de_Prim.classes
{
    public class node
    {
        private int _x,_y;
        public edge _northEdge = null, _southEdge = null, _westEdge = null, _eastEdge = null;
        private bool _isVisited = false, _isEntrance = false, _isExit = false;
        

        public node(int x,int y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            return _x + " , " + _y;
        }
    }
}
