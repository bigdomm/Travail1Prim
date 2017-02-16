﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe_de_Prim.classes
{
    public class maze
    {
        private int _hauteur, _largeur;
        private node[,] arrayNode;
        public maze(int hauteur, int largeur)
        {
            _hauteur = hauteur;
            _largeur = largeur;
            arrayNode = new node[hauteur,largeur];
        }

        /// <summary>
        /// Fonction qui genere les nodes et les edges (Noeuds et arêtes)
        /// </summary>
        public void generate()
        {
            node n;
            edge e;

            // Generation des nodes
            for (int a = 0; a< _hauteur; a++)
            {
                for(int b = 0; b < _largeur; b++)
                {
                    n = new node(a, b);
                    arrayNode[a, b] = n;


                }
            }

            // Generation des edges Est/Ouest
            for (int a = 0; a < _hauteur; a++)
            {
                for (int b = 0; b < _largeur-1; b++)
                {
                    e = new edge(arrayNode[a, b], arrayNode[a, b+1], 1);
                    arrayNode[a, b]._eastEdge = e;
                    arrayNode[a, b+1]._westEdge = e;

                }
            }

            // Generation des edges Nord/Sud
            for (int a = 0; a < _hauteur-1; a++)
            {
                for (int b = 0; b < _largeur; b++)
                {
                    e = new edge(arrayNode[a, b], arrayNode[a+1, b], 1);
                    arrayNode[a, b]._southEdge = e;
                    arrayNode[a+1, b]._northEdge = e;

                }
            }

        }

        public void show()
        {

            for (int a = 0; a < _largeur; a++)
            {
                for (int b = 0; b < _hauteur; b++)
                {
                    Console.Write(arrayNode[a, b].ToString() + " ");
                    
                }

                Console.WriteLine();
            }

        }
    }
}