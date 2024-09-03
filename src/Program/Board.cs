namespace Ucu.Poo.GameOfLife;

public class Board //Clase creada con el objetivo de actualizar el tablero mediante el cumpimiento de las reglas
{
    public Board(string url) //Constructor
    {
        BoardGenerator boardGenerator = new BoardGenerator(); //Utilizando una instancia de BoardGenerator
        gameBoard = boardGenerator.generateBoardByTxt(url);
        boardWidth = gameBoard.GetLength(0);
        boardHeight = gameBoard.GetLength(1);
    }
    
    private bool[,] gameBoard;  //Atributos
    public bool[,] GameBoard
    {
        get { return gameBoard; }
    }
    
    private int boardWidth;
    public int BoardWith
    {
        get { return boardWidth; }
    }
    
    private int boardHeight;
    public int BoardHeight
    {
        get { return boardHeight; } //Fin de atributos
    }
    
    public void nextGeneration()
    {
        bool[,] cloneboard = new bool[boardWidth, boardHeight];
        for (int x = 0; x < boardWidth; x++)
        {
            for (int y = 0; y < boardHeight; y++)
            {
                int aliveNeighbors = 0;
                for (int i = x-1; i<=x+1;i++)
                {
                    for (int j = y-1;j<=y+1;j++)
                    {
                        if(i>=0 && i<boardWidth && j>=0 && j < boardHeight && gameBoard[i,j])
                        {
                            aliveNeighbors++;
                        }
                    }
                }
                if(gameBoard[x,y])
                {
                    aliveNeighbors--;
                }
                if (gameBoard[x,y] && aliveNeighbors < 2)
                {
                    //Celula muere por baja población
                    cloneboard[x,y] = false;
                }
                else if (gameBoard[x,y] && aliveNeighbors > 3)
                {
                    //Celula muere por sobrepoblación
                    cloneboard[x,y] = false;
                }
                else if (!gameBoard[x,y] && aliveNeighbors == 3)
                {
                    //Celula nace por reproducción
                    cloneboard[x,y] = true;
                }
                else
                {
                    //Celula mantiene el estado que tenía
                    cloneboard[x,y] = gameBoard[x,y];
                }
            }
        }
        gameBoard = cloneboard;
    }
}