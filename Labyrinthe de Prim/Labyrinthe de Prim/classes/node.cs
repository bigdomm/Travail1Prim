using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe_de_Prim.classes
{
    public class Node
    {
        private int _x,_y;
        public Edge _northEdge = null, _southEdge = null, _westEdge = null, _eastEdge = null;
        public bool _isVisited = false, _isEntrance = false, _isExit = false;
        

        public Node(int x,int y)
        {
            _x = x;
            _y = y;
        }

        public override string ToString()
        {
            if (_isEntrance)
                return "E";
            else if (_isExit)
                return "S";
            else
                return "X";
        }
        
    }
}
