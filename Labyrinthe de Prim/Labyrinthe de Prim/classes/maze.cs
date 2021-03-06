﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe_de_Prim.classes
{
    public class Maze
    {
        private int _hauteur, _largeur;
        private Node[,] arrayNode;
        List<Edge> listOfEdge = new List<Edge>();
        List<Node> listOfNode = new List<Node>();

        public Maze(int hauteur, int largeur)
        {
            _hauteur = hauteur;
            _largeur = largeur;
            arrayNode = new Node[hauteur,largeur];
        }
        public Maze()
        {

        }
        /// <summary>
        /// Fonction qui genere les nodes et les edges (Noeuds et arêtes)
        /// </summary>
        public void Generate()
        {
            Node n;
            Edge e;
            Random r = new Random();

            // Generation des nodes
            for (int a = 0; a< _hauteur; a++)
            {
                for(int b = 0; b < _largeur; b++)
                {
                    n = new Node(a, b);
                    arrayNode[a, b] = n;


                }
            }

            // Generation des edges Est/Ouest
            for (int a = 0; a < _hauteur; a++)
            {
                for (int b = 0; b < _largeur-1; b++)
                {
                    e = new Edge(arrayNode[a, b], arrayNode[a, b+1],r.Next(1,10));
                    arrayNode[a, b]._eastEdge = e;
                    arrayNode[a, b+1]._westEdge = e;

                }
            }

            // Generation des edges Nord/Sud
            for (int a = 0; a < _hauteur-1; a++)
            {
                for (int b = 0; b < _largeur; b++)
                {

                    e = new Edge(arrayNode[a, b], arrayNode[a+1, b],r.Next(1,10));
                    arrayNode[a, b]._southEdge = e;
                    arrayNode[a+1, b]._northEdge = e;

                }
            }

            arrayNode[0, 0]._isEntrance = true;
            arrayNode[0, 0]._isVisited = true;
            arrayNode[_hauteur-1, _largeur-1]._isExit = true;

            primAlgo();
            
        }

        private void primAlgo()
        {


            Edge nextEdge = null;

            int nbNode = (_hauteur ) * (_largeur );    
            Node lastNode = arrayNode[0, 0];
            listOfNode.Add(lastNode);

            while (listOfNode.Count < nbNode)
            {
                primAddEdge(lastNode);
                nextEdge = primVerifNextEdge();
                nextEdge._display = true;

                // MEttre tous les nodes reliés a visited
                foreach (Edge e in listOfEdge)
                {
                    if (e._display == true)
                    {
                        if (!listOfNode.Contains(e._node1))
                        {
                            listOfNode.Add(e._node1);
                            lastNode = e._node1;
                        }

                        if (!listOfNode.Contains(e._node2))
                        {
                            listOfNode.Add(e._node2);
                            lastNode = e._node2;
                        }

                    }
                }

                lastNode._isVisited = true;

            }


        }

        public void primAddEdge(Node n)
        {
            
            if (n._eastEdge != null && !listOfEdge.Contains(n._eastEdge))
            {
                listOfEdge.Add(n._eastEdge);
            }

            if (n._southEdge != null && !listOfEdge.Contains(n._southEdge))
            {
                listOfEdge.Add(n._southEdge);
            }

            if (n._westEdge != null && !listOfEdge.Contains(n._westEdge))
            {
                listOfEdge.Add(n._westEdge);
            }

            if (n._northEdge != null && !listOfEdge.Contains(n._northEdge))
            {
                listOfEdge.Add(n._northEdge);
            }



            
        }

        public Edge primVerifNextEdge()
        {
            int minEdgeValue = 100;
            Edge minEdge = null;

            foreach(Edge e in listOfEdge)
            {
                if (e.getValue() < minEdgeValue && e._display == false && (e._node1._isVisited == false || e._node2._isVisited==false))
                {
                    minEdgeValue = e.getValue();
                    minEdge = e;
                }
            }

            return minEdge;
        }

        public void Show()
        {

            for (int a = 0; a < _hauteur; a++)
            {
                for (int b = 0; b < _largeur; b++)
                {
                    if (arrayNode[a, b]._eastEdge != null)
                    {
                        if (arrayNode[a, b]._eastEdge._display == true)
                            Console.Write("(" + arrayNode[a, b].ToString() + ")" + "-----");
                        else
                            Console.Write("(" + arrayNode[a, b].ToString() + ")" + "     ");
                    }
                    else
                        Console.Write("(" + arrayNode[a, b].ToString() + ")");
                }
                Console.WriteLine();

                for (int b = 0; b < _largeur; b++)
                {
                    if (arrayNode[a, b]._southEdge != null)
                    {
                        if (arrayNode[a, b]._southEdge._display == true)
                            Console.Write(" |      ");
                        else
                            Console.Write("        ");

                    }
                        

                }
                Console.WriteLine();

            }
        }
    }
}
