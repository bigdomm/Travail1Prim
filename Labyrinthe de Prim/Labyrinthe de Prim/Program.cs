using Labyrinthe_de_Prim.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinthe_de_Prim
{
    class Program
    {
        private static int choix;

        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenue dans le magnifique labyrinthe");
            Console.WriteLine();
            Random _rdn = new Random();
            Maze m = new Maze();
            string hauteur = "", largeur = "";


            do
            {
                choix = DisplayMenu();

                Console.Clear();

                switch (choix)
                {
                    case 1:

                        m = gen(_rdn.Next(1, 5), _rdn.Next(1, 5));
                        m.Generate();
                        m.Show();
                        break;
                    case 2:

                        Console.WriteLine("Veuillez entrer la hauteur du labyrinthe : ");
                        hauteur = Console.ReadLine();
                        Console.WriteLine("Veuillez entrer la largeur du labyrinthe : ");
                        largeur = Console.ReadLine();
                        m = gen(Convert.ToInt32(hauteur), Convert.ToInt32(largeur));
                        m.Generate();
                        m.Show();

                        break;
                    case 3:
                        if (hauteur == "")
                        {
                            choix = 2;
                            break;
                        }
                        else
                        {
                            m = gen(Convert.ToInt32(hauteur), Convert.ToInt32(largeur));
                            m.Generate();
                            m.Show();
                        }

                        break;

                }
               
            }while (choix != 4);
          
        }

        public static Maze gen(int h,int l)
        {
            return new Maze(h, l);

        }

        static public int DisplayMenu()
        {
            Console.WriteLine("Choix disponible");
            Console.WriteLine();
            Console.WriteLine("1. Générer un labyrinthe aléatoirement");
            Console.WriteLine("2. Générer un labyrinthe avec vos choix");
            Console.WriteLine("3. Génération rapide (dernier paramètre)");
            Console.WriteLine("4. Exit");
            var result = Console.ReadLine();

                return Convert.ToInt32(result);

        }
    }
}
