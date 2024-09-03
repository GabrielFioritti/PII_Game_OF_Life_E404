

using System.IO;        //Librerias

namespace Ucu.Poo.GameOfLife;

public class BoardGenerator     //Esta clase fue creada con el objetivo de crear el tablero por el hecho de tener esa
{                               //unica responsabilidad cumple, el SRP
    public bool[,] generateBoardByTxt(string url) //Genera el tablero dependiendo del .txt adjunto
    {
        string content = File.ReadAllText(url);
        string[] contentLines = content.Split('\n');
        bool[,] board = new bool[contentLines.Length, contentLines[0].Length];
        for (int y = 0; y < contentLines.Length; y++)
        {
            for (int x = 0; x < contentLines[y].Length; x++)
            {
                if(contentLines[y][x]=='1')
                {
                    board[x, y] = true;
                }
            }
        }
        return board;
    }
}