using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe_de_Prim.classes
{
    public class edge
    {
        private int _value;
        private node _node1, _node2;
        private bool _display = false;


        public edge(node node1, node node2, int value)
        {
            _node1 = node1;
            _node2 = node2;
            _value = value;
        }
    }
}
