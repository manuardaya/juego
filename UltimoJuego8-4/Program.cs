using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace UltimoJuego8_4
{
    class Program
    {       
                 
        static int level = 0;
        static void menu()
        {
            Console.WriteLine("                                     MENU\n                            ");
            Console.WriteLine("LEVEL I");
            Console.WriteLine("LEVEL II");
            Console.WriteLine("LEVEL III");
            Console.WriteLine("\n\n\n\n\n\n\nPresionar ENTER para seleccionar");
        }
        static SelectorMenu selector = new SelectorMenu();
        static Jugador jugador1 = new Jugador();
        static void inicializar_jugador()
        {            
            jugador1.color = ConsoleColor.Black;
            Console.ForegroundColor = jugador1.color;


            Console.SetCursorPosition(jugador1.x, jugador1.y);
            Console.Write(" ");

            mover_jugador();

            Console.SetCursorPosition(jugador1.x, jugador1.y);
            Console.Write("D");
        }
        static void mover_jugador()
        { 
            while (Console.KeyAvailable)                   // kbhit()
                {
                    ConsoleKeyInfo tecla = Console.ReadKey();   // getch()
                    if (tecla.Key == ConsoleKey.LeftArrow || tecla.Key == ConsoleKey.A)
                        jugador1.x--;
                    else if (tecla.Key == ConsoleKey.RightArrow || tecla.Key == ConsoleKey.D)
                        jugador1.x++;
                    if (tecla.Key == ConsoleKey.UpArrow || tecla.Key == ConsoleKey.W)
                        jugador1.y--;
                    else if (tecla.Key == ConsoleKey.DownArrow || tecla.Key == ConsoleKey.S)
                        jugador1.y++;
                }
            if (jugador1.x == -1)
                jugador1.x = 0;
            if (jugador1.x == 80)
                jugador1.x = 79;
            if (jugador1.y == -1)
                jugador1.y = 0;
            if (jugador1.y == 25)
                jugador1.y = 24;
        }
        static void mover_selector()
        {
            if (Console.KeyAvailable)                   // kbhit()
            {
                ConsoleKeyInfo tecla = Console.ReadKey();

                if (tecla.Key == ConsoleKey.UpArrow)
                    selector.y--;

                if (tecla.Key == ConsoleKey.DownArrow)
                    selector.y++;
            }

            if (selector.y == 1)
                selector.y = 4;

            if (selector.y == 5)
                selector.y = 2;
        }
        static void inicializar_selector()
        {
            Console.SetCursorPosition(selector.x, selector.y);
            Console.Write("<");

            selector.color = ConsoleColor.Red;
            Console.ForegroundColor = selector.color;
        }
        static void inicializar_nivel()
        {
            jugador1.cont_puntos = 0;
            jugador1.x = 4;
            inicializar_comida();
            inicializar_vida();            
            inicializar_jugador();
        }
        static void seleccionar_nivel()
        {
            while (Console.KeyAvailable)                   // kbhit()
            {
                ConsoleKeyInfo tecla = Console.ReadKey();

                if (tecla.Key == ConsoleKey.Enter && selector.y == 2)
                {
                    inicializar_jugador();
                    level = 1;
                }
                if (tecla.Key == ConsoleKey.Enter && selector.y == 3)
                    level = 2;

                if (tecla.Key == ConsoleKey.Enter && selector.y == 4)
                    level = 3;
                if (tecla.Key != ConsoleKey.UpArrow && tecla.Key != ConsoleKey.DownArrow && tecla.Key != ConsoleKey.Enter)
                {
                    Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n                       Error para seleccionar precione enter");
                    Thread.Sleep(500);
                }
            }        
        }
        static Jugador game_over = new Jugador();
        static Vida vida = new Vida();
        static void inicializar_vida()
        {
            

            Console.SetCursorPosition(vida.x, vida.y);
                Console.Write("VIDA: " + jugador1.cont_vida);
                vida.color = ConsoleColor.Black;
                Console.ForegroundColor = vida.color;

                while (jugador1.cont_vida <= 0)
                {
                    Console.SetCursorPosition(game_over.x, game_over.y);
                    Console.WriteLine("GAME OVER");
                    Console.WriteLine("            puntos sumados: " + jugador1.cont_puntos);
                    Console.WriteLine("         Press Intro To Play Again");
                }
        }
        static Comida comida = new Comida();
        static void inicializar_comida()
        {
            comida.x = 19;
            comida.y = 12;

            Console.Write(" ");

            Console.SetCursorPosition(comida.x, comida.y);
            if (jugador1.cont_puntos != 1)
            {
                comida.color = ConsoleColor.Red;
                Console.ForegroundColor = comida.color;
                Console.Write("#");



                if (jugador1.x == comida.x && jugador1.y == comida.y)
                {
                    jugador1.cont_puntos++;
                }
            }
        }
        static void siguiente_nivel()
        {
                //Console.Clear();
            while (jugador1.cont_puntos == 1 && jugador1.x == 45 && level != 0)
            {
                Console.Clear();
                Console.WriteLine("               LEVEL II");
                Console.WriteLine("           puntos sumados: " + jugador1.cont_puntos);
                Console.WriteLine("              Press Intro");
                if (Console.KeyAvailable)                   // kbhit()
                {
                    ConsoleKeyInfo tecla = Console.ReadKey();
                    if (tecla.Key == ConsoleKey.Enter || tecla.Key == ConsoleKey.Spacebar)
                    {
                        Console.Clear();
                        level = 2;
                        inicializar_jugador();
                        inicializar_vida();
                        jugador1.cont_puntos = 0;
                    }
                    if (tecla.Key == ConsoleKey.Escape)
                    {
                        inicializar_nivel();
                        
                        level = 0;
                    }   
                      
                }
                Thread.Sleep(200);

            }
            
        }


        static int [] enemigo = new int[10];
        static Enemigo enemigo1, enemigo2, enemigo3, enemigo4, enemigo5, enemigo6, enemigo7, enemigo8, enemigo9, enemigo10, enemigo11, enemigo12, enemigo13, enemigo14, enemigo15, enemigo16, enemigo17, enemigo18, enemigo19, enemigo20;
        static int i,k=1;
        static void inicializar_enemigos()
        {
           /* for (i = 1; i <= 20; i++)
            { 
                k *= -1;
                if(k ==-1)
                   enemigo.y=0;
                if(k==1)
                    enemigo.y=24;    
                enemigo[i] = new Enemigo(i+9, enemigo.y);
            }*/
            enemigo1 = new Enemigo(10,0);
            enemigo2 = new Enemigo(11,24);
            enemigo3 = new Enemigo(12,0);   
            enemigo4 = new Enemigo(13,24);
            enemigo5 = new Enemigo(14,0);
            enemigo6 = new Enemigo(15,24);
            enemigo7 = new Enemigo(16,0);
            enemigo8 = new Enemigo(17,24);
            enemigo9 = new Enemigo(18,0);            
            enemigo10 = new Enemigo(19,24);         
            enemigo11 = new Enemigo(20,0);           
            enemigo12 = new Enemigo(21,24);
            enemigo13 = new Enemigo(22,0);
            enemigo14 = new Enemigo(23,24);
            enemigo15 = new Enemigo(24,0);                    
            enemigo16 = new Enemigo(25,24);            
            enemigo17 = new Enemigo(26,0);            
            enemigo18 = new Enemigo(27,24);            
            enemigo19 = new Enemigo(28,0);                
            enemigo20 = new Enemigo(29,24);
        }
        static void Main(string[] args)
        {  
            //VolverMenu
            Jugador game_over;
            Vida vida;
            Comida comida;
            Puntos puntos;
                                 

            game_over = new Jugador();
            game_over.x = 15;
            game_over.y = 10;

            vida = new Vida(); 

            puntos = new Puntos();

            inicializar_enemigos();
            

            Console.BackgroundColor = ConsoleColor.Cyan;
            while (true)
            {
                while (level == 0)
                {
                    menu();
                    inicializar_selector();
                    mover_selector();

                    seleccionar_nivel();
                    Thread.Sleep(150);
                    Console.Clear();
                }



                while (level == 1)
                {
                    //volver_menu();
                    inicializar_comida();
                    inicializar_jugador();
                    /***********************ENEMIGO1*************************/

                    enemigo1.x = 10;
                    Console.SetCursorPosition(enemigo1.x, enemigo1.y);
                    Console.Write(" ");
                    if (enemigo1.bandera == 1)
                    {
                        enemigo1.y++;
                    }
                    if (enemigo1.bandera == 2)
                    {
                        enemigo1.y--;
                    }
                    if (enemigo1.y == 24 && enemigo1.bandera == 1)
                    {
                        enemigo1.bandera = 2;
                    }

                    enemigo1.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo1.color;

                    Console.SetCursorPosition(enemigo1.x, enemigo1.y);
                    Console.Write("o");
                    if (enemigo1.y == 0 && enemigo1.bandera == 2)
                    {
                        enemigo1.bandera = 1;
                    }


                    if (jugador1.x == enemigo1.x && jugador1.y == enemigo1.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;

                    }

                    /***********************ENEMIGO2**************************/

                    enemigo2.x = 11;
                    Console.SetCursorPosition(enemigo2.x, enemigo2.y);
                    Console.Write(" ");
                    if (enemigo2.bandera == 1)
                    {
                        enemigo2.y--;
                    }
                    if (enemigo2.bandera == 2)
                    {
                        enemigo2.y++;
                    }
                    if (enemigo2.y == 0 && enemigo2.bandera == 1)
                    {
                        enemigo2.bandera = 2;
                    }

                    Console.SetCursorPosition(enemigo2.x, enemigo2.y);
                    if (enemigo2.y == 24 && enemigo2.bandera == 2)
                    {
                        enemigo2.bandera = 1;

                    }
                    if (jugador1.x == enemigo2.x && jugador1.y == enemigo2.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }

                    Console.Write("o");

                    /***********************ENEMIGO3**************************/
                    enemigo3.x = 12;
                    Console.SetCursorPosition(enemigo3.x, enemigo3.y);
                    Console.Write(" ");
                    if (enemigo3.bandera == 1)
                    {
                        enemigo3.y++;
                    }
                    if (enemigo3.bandera == 2)
                    {
                        enemigo3.y--;
                    }
                    if (enemigo3.y == 24 && enemigo3.bandera == 1)
                    {
                        enemigo3.bandera = 2;
                    }
                    Console.SetCursorPosition(enemigo3.x, enemigo3.y);
                    Console.Write("o");
                    if (enemigo3.y == 0 && enemigo3.bandera == 2)
                    {
                        enemigo3.bandera = 1;

                    }

                    enemigo3.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo3.color;

                    if (jugador1.x == enemigo3.x && jugador1.y == enemigo3.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }

                    /***********************ENEMIGO4**************************/

                    enemigo4.x = 13;
                    Console.SetCursorPosition(enemigo4.x, enemigo4.y);
                    Console.Write(" ");
                    if (enemigo4.bandera == 1)
                    {
                        enemigo4.y--;
                    }
                    if (enemigo4.bandera == 2)
                    {
                        enemigo4.y++;
                    }
                    if (enemigo4.y == 0 && enemigo4.bandera == 1)
                    {
                        enemigo4.bandera = 2;
                    }
                    Console.SetCursorPosition(enemigo4.x, enemigo4.y);
                    Console.Write("o");
                    if (enemigo4.y == 24 && enemigo4.bandera == 2)
                    {
                        enemigo4.bandera = 1;

                    }

                    enemigo4.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo4.color;

                    if (jugador1.x == enemigo4.x && jugador1.y == enemigo4.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }

                    /***********************ENEMIGO5**************************/
                    enemigo5.x = 14;
                    Console.SetCursorPosition(enemigo5.x, enemigo5.y);
                    Console.Write(" ");
                    if (enemigo5.bandera == 1)
                    {
                        enemigo5.y++;
                    }
                    if (enemigo5.bandera == 2)
                    {
                        enemigo5.y--;
                    }
                    if (enemigo5.y == 24 && enemigo5.bandera == 1)
                    {
                        enemigo5.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo5.x, enemigo5.y);
                    Console.Write("o");
                    if (enemigo5.y == 0 && enemigo5.bandera == 2)
                    {
                        enemigo5.bandera = 1;

                    }

                    enemigo5.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo5.color;

                    if (jugador1.x == enemigo5.x && jugador1.y == enemigo5.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }

                    /***********************ENEMIGO6**************************/
                    enemigo6.x = 15;
                    Console.SetCursorPosition(enemigo6.x, enemigo6.y);
                    Console.Write(" ");
                    if (enemigo6.bandera == 1)
                    {
                        enemigo6.y--;
                    }
                    if (enemigo6.bandera == 2)
                    {
                        enemigo6.y++;
                    }
                    if (enemigo6.y == 0 && enemigo6.bandera == 1)
                    {
                        enemigo6.bandera = 2;
                    }
                    Console.SetCursorPosition(enemigo6.x, enemigo6.y);
                    Console.Write("o");
                    if (enemigo6.y == 24 && enemigo6.bandera == 2)
                    {
                        enemigo6.bandera = 1;

                    }

                    enemigo6.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo6.color;

                    if (jugador1.x == enemigo6.x && jugador1.y == enemigo6.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;

                    }
                    /***********************ENEMIGO7**************************/
                    enemigo7.x = 16;
                    Console.SetCursorPosition(enemigo7.x, enemigo7.y);
                    Console.Write(" ");
                    if (enemigo7.bandera == 1)
                    {
                        enemigo7.y++;
                    }
                    if (enemigo7.bandera == 2)
                    {
                        enemigo7.y--;
                    }
                    if (enemigo7.y == 24 && enemigo7.bandera == 1)
                    {
                        enemigo7.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo7.x, enemigo7.y);
                    Console.Write("o");
                    if (enemigo7.y == 0 && enemigo7.bandera == 2)
                    {
                        enemigo7.bandera = 1;

                    }

                    enemigo7.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo7.color;

                    if (jugador1.x == enemigo7.x && jugador1.y == enemigo7.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }

                    /***********************ENEMIGO8**************************/
                    enemigo8.x = 17;
                    Console.SetCursorPosition(enemigo8.x, enemigo8.y);
                    Console.Write(" ");
                    if (enemigo8.bandera == 1)
                    {
                        enemigo8.y--;
                    }
                    if (enemigo8.bandera == 2)
                    {
                        enemigo8.y++;
                    }
                    if (enemigo8.y == 0 && enemigo8.bandera == 1)
                    {
                        enemigo8.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo8.x, enemigo8.y);
                    Console.Write("o");
                    if (enemigo8.y == 24 && enemigo8.bandera == 2)
                    {
                        enemigo8.bandera = 1;

                    }

                    enemigo8.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo8.color;

                    if (jugador1.x == enemigo8.x && jugador1.y == enemigo8.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }

                    /***********************ENEMIGO9**************************/
                    enemigo9.x = 18;
                    Console.SetCursorPosition(enemigo9.x, enemigo9.y);
                    Console.Write(" ");
                    if (enemigo9.bandera == 1)
                    {
                        enemigo9.y++;
                    }
                    if (enemigo9.bandera == 2)
                    {
                        enemigo9.y--;
                    }
                    if (enemigo9.y == 24 && enemigo9.bandera == 1)
                    {
                        enemigo9.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo9.x, enemigo9.y);
                    Console.Write("o");
                    if (enemigo9.y == 0 && enemigo9.bandera == 2)
                    {
                        enemigo9.bandera = 1;

                    }

                    enemigo9.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo9.color;

                    if (jugador1.x == enemigo9.x && jugador1.y == enemigo9.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }

                    /***********************ENEMIGO10**************************/
                    enemigo10.x = 19;
                    Console.SetCursorPosition(enemigo10.x, enemigo10.y);
                    Console.Write(" ");
                    if (enemigo10.bandera == 1)
                    {
                        enemigo10.y--;
                    }
                    if (enemigo10.bandera == 2)
                    {
                        enemigo10.y++;
                    }
                    if (enemigo10.y == 0 && enemigo10.bandera == 1)
                    {
                        enemigo10.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo10.x, enemigo10.y);
                    Console.Write("o");
                    if (enemigo10.y == 24 && enemigo10.bandera == 2)
                    {
                        enemigo10.bandera = 1;

                    }

                    enemigo10.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo10.color;


                    if (jugador1.x == enemigo10.x && jugador1.y == enemigo10.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }

                    /***********************ENEMIGO11**************************/
                    enemigo11.x = 20;
                    Console.SetCursorPosition(enemigo11.x, enemigo11.y);
                    Console.Write(" ");
                    if (enemigo11.bandera == 1)
                    {
                        enemigo11.y++;
                    }
                    if (enemigo11.bandera == 2)
                    {
                        enemigo11.y--;
                    }
                    if (enemigo11.y == 24 && enemigo11.bandera == 1)
                    {
                        enemigo11.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo11.x, enemigo11.y);
                    Console.Write("o");
                    if (enemigo11.y == 0 && enemigo11.bandera == 2)
                    {
                        enemigo11.bandera = 1;

                    }

                    enemigo11.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo11.color;

                    if (jugador1.x == enemigo11.x && jugador1.y == enemigo11.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }

                    /***********************ENEMIGO12**************************/
                    enemigo12.x = 21;
                    Console.SetCursorPosition(enemigo12.x, enemigo12.y);
                    Console.Write(" ");
                    if (enemigo12.bandera == 1)
                    {
                        enemigo12.y--;
                    }
                    if (enemigo12.bandera == 2)
                    {
                        enemigo12.y++;
                    }
                    if (enemigo12.y == 0 && enemigo12.bandera == 1)
                    {
                        enemigo12.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo12.x, enemigo12.y);
                    Console.Write("o");
                    if (enemigo12.y == 24 && enemigo12.bandera == 2)
                    {
                        enemigo12.bandera = 1;

                    }

                    enemigo12.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo12.color;

                    if (jugador1.x == enemigo12.x && jugador1.y == enemigo1.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }

                    /***********************ENEMIGO13**************************/
                    enemigo13.x = 22;
                    Console.SetCursorPosition(enemigo13.x, enemigo13.y);
                    Console.Write(" ");
                    if (enemigo13.bandera == 1)
                    {
                        enemigo13.y++;
                    }
                    if (enemigo13.bandera == 2)
                    {
                        enemigo13.y--;
                    }
                    if (enemigo13.y == 24 && enemigo13.bandera == 1)
                    {
                        enemigo13.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo13.x, enemigo13.y);
                    Console.Write("o");
                    if (enemigo13.y == 0 && enemigo13.bandera == 2)
                    {
                        enemigo13.bandera = 1;

                    }

                    enemigo13.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo13.color;

                    if (jugador1.x == enemigo13.x && jugador1.y == enemigo13.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }
                    /***********************ENEMIGO14**************************/
                    enemigo14.x = 23;
                    Console.SetCursorPosition(enemigo14.x, enemigo14.y);
                    Console.Write(" ");
                    if (enemigo14.bandera == 1)
                    {
                        enemigo14.y--;
                    }
                    if (enemigo14.bandera == 2)
                    {
                        enemigo14.y++;
                    }
                    if (enemigo14.y == 0 && enemigo14.bandera == 1)
                    {
                        enemigo14.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo14.x, enemigo14.y);
                    Console.Write("o");
                    if (enemigo14.y == 24 && enemigo14.bandera == 2)
                    {
                        enemigo14.bandera = 1;

                    }

                    enemigo14.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo14.color;
                    if (jugador1.x == enemigo14.x && jugador1.y == enemigo14.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }
                    /***********************ENEMIGO15**************************/
                    enemigo15.x = 24;
                    Console.SetCursorPosition(enemigo15.x, enemigo15.y);
                    Console.Write(" ");
                    if (enemigo15.bandera == 1)
                    {
                        enemigo15.y++;
                    }
                    if (enemigo15.bandera == 2)
                    {
                        enemigo15.y--;
                    }
                    if (enemigo15.y == 24 && enemigo15.bandera == 1)
                    {
                        enemigo15.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo15.x, enemigo15.y);
                    Console.Write("o");
                    if (enemigo15.y == 0 && enemigo15.bandera == 2)
                    {
                        enemigo15.bandera = 1;

                    }

                    enemigo15.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo15.color;

                    if (jugador1.x == enemigo15.x && jugador1.y == enemigo15.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }
                    /***********************ENEMIGO16**************************/
                    enemigo16.x = 25;
                    Console.SetCursorPosition(enemigo16.x, enemigo16.y);
                    Console.Write(" ");
                    if (enemigo16.bandera == 1)
                    {
                        enemigo16.y--;
                    }
                    if (enemigo16.bandera == 2)
                    {
                        enemigo16.y++;
                    }
                    if (enemigo16.y == 0 && enemigo16.bandera == 1)
                    {
                        enemigo16.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo16.x, enemigo16.y);
                    Console.Write("o");
                    if (enemigo16.y == 24 && enemigo16.bandera == 2)
                    {
                        enemigo16.bandera = 1;

                    }

                    enemigo16.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo16.color;

                    if (jugador1.x == enemigo16.x && jugador1.y == enemigo16.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }

                    /***********************ENEMIGO17**************************/
                    enemigo17.x = 26;
                    Console.SetCursorPosition(enemigo17.x, enemigo17.y);
                    Console.Write(" ");
                    if (enemigo17.bandera == 1)
                    {
                        enemigo17.y++;
                    }
                    if (enemigo17.bandera == 2)
                    {
                        enemigo17.y--;
                    }
                    if (enemigo17.y == 24 && enemigo17.bandera == 1)
                    {
                        enemigo17.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo17.x, enemigo17.y);
                    Console.Write("o");
                    if (enemigo17.y == 0 && enemigo17.bandera == 2)
                    {
                        enemigo17.bandera = 1;

                    }

                    enemigo17.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo17.color;

                    if (jugador1.x == enemigo17.x && jugador1.y == enemigo17.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }
                    /***********************ENEMIGO18**************************/
                    enemigo18.x = 27;
                    Console.SetCursorPosition(enemigo18.x, enemigo18.y);
                    Console.Write(" ");
                    if (enemigo18.bandera == 1)
                    {
                        enemigo18.y--;
                    }
                    if (enemigo18.bandera == 2)
                    {
                        enemigo18.y++;
                    }
                    if (enemigo18.y == 0 && enemigo18.bandera == 1)
                    {
                        enemigo18.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo18.x, enemigo18.y);
                    Console.Write("o");
                    if (enemigo18.y == 24 && enemigo18.bandera == 2)
                    {
                        enemigo18.bandera = 1;

                    }

                    enemigo18.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo18.color;

                    if (jugador1.x == enemigo18.x && jugador1.y == enemigo18.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }
                    /***********************ENEMIGO19**************************/
                    enemigo19.x = 28;
                    Console.SetCursorPosition(enemigo19.x, enemigo19.y);
                    Console.Write(" ");
                    if (enemigo19.bandera == 1)
                    {
                        enemigo19.y++;
                    }
                    if (enemigo19.bandera == 2)
                    {
                        enemigo19.y--;
                    }
                    if (enemigo19.y == 24 && enemigo19.bandera == 1)
                    {
                        enemigo19.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo19.x, enemigo19.y);
                    Console.Write("o");
                    if (enemigo19.y == 0 && enemigo19.bandera == 2)
                    {
                        enemigo19.bandera = 1;

                    }

                    enemigo19.color = ConsoleColor.Blue;
                    Console.ForegroundColor = enemigo19.color;

                    if (jugador1.x == enemigo19.x && jugador1.y == enemigo19.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }
                    /***********************ENEMIGO20**************************/
                    enemigo20.x = 29;
                    Console.SetCursorPosition(enemigo20.x, enemigo20.y);
                    Console.Write(" ");
                    if (enemigo20.bandera == 1)
                    {
                        enemigo20.y--;
                    }
                    if (enemigo20.bandera == 2)
                    {
                        enemigo20.y++;
                    }
                    if (enemigo20.y == 0 && enemigo20.bandera == 1)
                    {
                        enemigo20.bandera = 2;
                    }
                    //enemigo1.x++;
                    Console.SetCursorPosition(enemigo20.x, enemigo20.y);
                    Console.Write("o");
                    if (enemigo20.y == 24 && enemigo20.bandera == 2)
                    {
                        enemigo20.bandera = 1;

                    }

                    enemigo20.color = ConsoleColor.Black;
                    Console.ForegroundColor = enemigo20.color;

                    if (jugador1.x == enemigo20.x && jugador1.y == enemigo20.y)
                    {
                        jugador1.cont_vida--;
                        jugador1.x = 2;
                        jugador1.y = 12;
                    }
                    /***********************Jugador1**************************/

                    /***********************Vida**************************/
                    inicializar_vida();
                    
                    siguiente_nivel();
                    //level = 2;
                    //} 





                    /***********************Puntaje**************************/
                    puntos.color = ConsoleColor.Black;
                    Console.ForegroundColor = puntos.color;

                    Console.SetCursorPosition(puntos.x, puntos.y);
                    Console.Write("Puntaje: " + jugador1.cont_puntos);

                    Thread.Sleep(80);
                    //Console.Clear();

                }

                while (level == 2)
                {
                    inicializar_jugador();
                    inicializar_vida();
                    mover_jugador();

                    Thread.Sleep(100);
                }
            }
        
        }

    }
}