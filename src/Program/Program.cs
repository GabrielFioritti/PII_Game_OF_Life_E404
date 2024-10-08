﻿using System;
using System.Text;      //librerias
using System.Threading;

namespace Ucu.Poo.GameOfLife
{
    class Program  //Clase creada con el objetivo de ejecutar el programa
    {
        static void Main(string[] args)
        {
            Board board = new Board("..\\..\\..\\..\\..\\assets\\board.txt");

            bool[,] b = board.GameBoard; //variable que representa el tablero
            int width = board.BoardWith;//variabe que representa el ancho del tablero
            int height = board.BoardHeight; //variabe que representa altura del tablero
            
            while (true)
            {
                Console.Clear();
                StringBuilder s = new StringBuilder();
                for (int y = 0; y<height;y++)
                {
                    for (int x = 0; x<width; x++)
                    {
                        if(b[x,y])
                        {
                            s.Append("|X|");
                        }
                        else
                        {
                            s.Append("___");
                        }
                    }
                    s.Append("\n");
                }
                Console.WriteLine(s.ToString());
                //=================================================
                //Invocar método para calcular siguiente generación
                //=================================================
                board.nextGeneration();
                b = board.GameBoard;
                Thread.Sleep(300);
            }
        }
    }
}
