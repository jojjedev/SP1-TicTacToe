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

    public static (int rowIndex, int colIndex, int previousPlayer) Round()
    {
        Console.Write($"It's Player {currentPlayer}'s turn: ");
        string row;
        int col;
        int rowIndex;
        int colIndex;
        
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
                            break;
                        }
                        
                    } 
                }
            }
            Console.WriteLine("Invalid input, try another coordinate A1-C3.");
            
        }
//        string row = char.ToString(char.ToUpper(response[0]));

        rowIndex = rows.IndexOf(row);
        colIndex = columns.IndexOf(col);
        Update(rowIndex, colIndex, currentPlayer);
        var previousPlayer = currentPlayer;
        currentPlayer = currentPlayer % 2 + 1;
        return (rowIndex, colIndex, previousPlayer);
        
    }

    public static (int player1Win, int player2Win) CheckGameState(List<string> player1Used, List<string> player2Used)
    {
        int totalP1A = 0;
        int totalP1B = 0;
        int totalP1C = 0;
        int totalP11 = 0;
        int totalP12 = 0;
        int totalP13 = 0;
        
        int[] totals1 =
        {
            totalP1A, totalP1B, totalP1C, totalP11, totalP12, totalP13
        };
        
        int totalP2A = 0;
        int totalP2B = 0;
        int totalP2C = 0;
        int totalP21 = 0;
        int totalP22 = 0;
        int totalP23 = 0;
        
        int[] totals2 =
        {
            totalP2A, totalP2B, totalP2C, totalP21, totalP22, totalP23
        };
        
        // if any of these values turns to 1, that player wins
        int player1Win = 0;
        int Player2Win = 0;
        
        foreach (var input in player1Used)
        {
            if (input[0] == 0)
            {
                totalP1A++;
            }
            if (input[0] == 1)
            {
                totalP1B++;
            }
            if (input[0] == 2)
            {
                totalP1C++;
            }
        }

        foreach (var input in player1Used)
        {
            if (input[1] == 0)
            {
                totalP11++;
            }
            if (input[1] == 1)
            {
                totalP12++;
            }
            if (input[1] == 2)
            {
                totalP13++;
            }
        }
        foreach (var input in player2Used)
        {
            if (input[0] == 0)
            {
                totalP2A++;
            }
            if (input[0] == 1)
            {
                totalP2B++;
            }
            if (input[0] == 2)
            {
                totalP2C++;
            }
        }
        foreach (var input in player2Used)
        {
            if (input[1] == 0)
            {
                totalP21++;
            }
            if (input[1] == 1)
            {
                totalP22++;
            }
            if (input[1] == 2)
            {
                totalP23++;
            }
        }

        foreach (var total in totals1)
        {
            if (total == 3)
            {
                player1Win = 1;
            }
        }

        foreach (var total in totals2)
        {
            if (total == 3)
            {
                Player2Win = 1;
            }
        }

        return (player1Win, Player2Win);
    }
}