namespace tictactoe;

public class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Let's play TicTacToe!\n\nPress Enter to start the game");
        Console.ReadLine();
        TicTacToe.Draw();
        int round = 0;
        var player1Used = new List<string>();
        var player2Used = new List<string>();
        while (round < 9)
        {
            
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
            (int player1Status, int player2Status) = TicTacToe.CheckGameState(player1Used, player2Used);
            var (usedRow, usedCol, previousPlayer) = TicTacToe.Round();
            if (player1Status == 1)
            {
                
            }
            if (previousPlayer == 1)
            {
                player1Used.Add($"{usedRow}{usedCol}");
            }
            if (previousPlayer == 2)
            {
                player2Used.Add($"{usedRow}{usedCol}");
            }
            round++;
        }

        Console.WriteLine($"Game Over! Total rounds: {round}");

    }

    static void EndGame()
    {
        
    }
}