﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe_de_Prim.classes
{
    public class Edge
    {
        private int _value;
        public Node _node1, _node2;
        public bool _display = false;

        public Edge(Node node1, Node node2,int value)
        {
            _node1 = node1;
            _node2 = node2;
            _value = value;
        }

        internal int getValue()
        {
            return _value;
        }
    }
}
