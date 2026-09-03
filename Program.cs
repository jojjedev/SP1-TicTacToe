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
            //Start next round. Round() returns the input into the used row and column variables according to which player just went.
            var (usedRow, usedCol, previousPlayer) = TicTacToe.Round();
            if (previousPlayer == 1)
            {
                player1Used.Add($"{usedRow}{usedCol}");
            }

            if (previousPlayer == 2)
            {
                player2Used.Add($"{usedRow}{usedCol}");
            }
            
            // Check game state. If any player has three in a row, end the loop early with a victory message.
            var isGameEnded = TicTacToe.CheckGameState(player1Used, player2Used);
            if (isGameEnded == true)
            {
                break;
            }
            // Increase round amount.
            round++;
            // When round == 9, the board is full. If neither player has won by then, the game ends in a draw.
            if (round == 9 && !isGameEnded)
            {
                Console.WriteLine("Game over! It's a draw!");
                break;
            }
        }

    }
}