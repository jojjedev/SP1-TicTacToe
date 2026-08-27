namespace tictactoe;

public class Program
{
    static void Main(string[] args)
    {
        int round = 0;
        var currentPlayer = 1;
        while (round < 9)
        {
            Console.WriteLine("Let's play TicTacToe!");
            //Board creation
            int[,] board = new int[3, 3];
            int[] columns = { 1, 2, 3 };
            string[] rows = { "A", "B", "C" };
            Console.Clear();
            Console.Write("\n    1   2   3  \n");
            Console.Write("  -------------\n");

            for (int i = 0; i < 3; i++) {
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
            // End board creation
            Console.Write($"It's {currentPlayer}'s turn: ");
            string response = Console.ReadLine().Trim();
            string row = char.ToString(char.ToUpper(response[0]));
            int col = response[1] - '0';
            
            int rowIndex = rows.IndexOf(row);
            int colIndex = columns.IndexOf(col);
            
            if (currentPlayer == 1)
            {
                currentPlayer = 2;
                round++;
            }
            else
            {
                currentPlayer = 1;
                round++;
            }
        
        Console.Write($"Game Over! Total rounds: {round}");
        }
        

    }
}