using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UltimoJuego8_4
{
    class Enemigo 
    {
        public Enemigo()
        {
        }

        public Enemigo (int X, int Y)
        {
            this.x = X;
            this.y = Y;
        }

        public int x, y;
        public int bandera=1;
        public ConsoleColor color;       
    }
}
