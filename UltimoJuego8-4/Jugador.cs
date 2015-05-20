using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UltimoJuego8_4
{
    class Jugador
    {
        public Jugador()
        {
        }
        public Jugador (double X, double Y)
        {
           X=x;
           Y=y;
        }

        public int x=4, y=12;
        public ConsoleColor color;
        public int cont_vida = 5;
        public int cont_puntos = 0;
    }
}
