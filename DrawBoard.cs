using System.Security.Cryptography.X509Certificates;

namespace tictactoe;

public class TicTacToe
{
    private static int[,] board = new int[3, 3];
    private static int[] columns = { 1, 2, 3 };
    private static string[] rows = { "A", "B", "C" };
    private static int currentPlayer = 1; 
    public static void Draw()
    {
        Console.Clear();
        Console.Write("\n    1   2   3  \n");
        Console.Write("  -------------\n");

        for (int i = 0; i < 3; i++)
        {
            Console.Write($"{rows[i]} ");
            Console.Write("|");

            for (int j = 0; j < 3; j++)
            {
                if (board[i, j] == 0)
                {
                    Console.Write(" X |");
                }
                else
                {
                    Console.Write($" {board[i, j]} |");
                }

            }

            Console.WriteLine();
            Console.Write("  -------------\n");
        }
    }

    public static void Update(int row, int col, int currentPlayer)
    {
        board[row, col] = currentPlayer;
        TicTacToe.Draw();
    }

    public static void Round()
    {
        Console.Write($"It's {currentPlayer}'s turn: ");
        string row;
        int col;
        int rowIndex;
        int colIndex;
        var player1Squares = new List<string>();
        var player2Squares = new List<string>();
        
        while (true)
        {
            var response = Console.ReadLine().Trim();
            if (response.Length == 2)
            {
                if (char.IsLetter(response[0]) && char.IsDigit(response[1]))
                {
                    row = response[0].ToString().ToUpper();
                    col = response[1] - '0';

                    // Check to see if the response is a valid coordinate
                    if (row is "A" or "B" or "C" && col is 1 or 2 or 3)
                    {
                        rowIndex = rows.IndexOf(row);
                        colIndex = columns.IndexOf(col);


                        if (board[rowIndex, colIndex] == 0)
                        {
                            var coordinate = $"{rowIndex}{colIndex}";
                            if (currentPlayer == 1)
                            {
                                player1Squares.Add(coordinate);
                            
                            }
                            else
                            {
                                player2Squares.Add(coordinate);
                            }
                            break;
                        }
                        
                    } 
                }
            }
            Console.WriteLine("Invalid input, try another.");
            Console.WriteLine($"Used squares\nPlayer 1: ");
            player1Squares.ForEach(i => Console.Write(i + ", "));
            Console.WriteLine($"Player 2: ");
            player2Squares.ForEach(i => Console.Write(i + ", "));
            
        }
//        string row = char.ToString(char.ToUpper(response[0]));

        rowIndex = rows.IndexOf(row);
        colIndex = columns.IndexOf(col);
        Update(rowIndex, colIndex, currentPlayer);
        currentPlayer = currentPlayer % 2 + 1;

    }

    public static void CheckGameState()
    {
        
    }
}