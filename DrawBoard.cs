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
        Console.WriteLine("Let's play TicTacToe!");
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
        string response = Console.ReadLine().Trim();
        string row = char.ToString(char.ToUpper(response[0]));
        int col = response[1] - '0';
            
        int rowIndex = rows.IndexOf(row);
        int colIndex = columns.IndexOf(col);
        TicTacToe.Update(rowIndex, colIndex, currentPlayer);
        if (currentPlayer == 1)
        {
            currentPlayer = 2;
        }
        else
        {
            currentPlayer = 1;
        }
        
    }
}