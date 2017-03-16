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
        static void Main(string[] args)
        {
            maze m = new maze(3, 4);

            m.generate();

            m.show();
          
            Console.ReadLine();
        }
    }
}
