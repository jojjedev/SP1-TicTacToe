namespace tictactoe;

public class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Let's play TicTacToe!\n\nPress Enter to start the game");
        Console.ReadLine();
        int round = 0;
        while (round < 9)
        {
            
            TicTacToe.Draw();
            /*int[,] board = new int[3, 3];
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
            */
            TicTacToe.Round();
            round++;
            
        
        Console.Write($"Game Over! Total rounds: {round}");
        }
        

    }
}