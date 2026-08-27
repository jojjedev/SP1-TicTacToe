namespace tictactoe;

public class TicTacToe
{
    public void Draw(string[] args)
    {
        int[,] board = new int[3, 3];
        int[] columns = { 1, 2, 3 };
        string[] rows = { "A", "B", "C" };
        board[1, 1] = 2;
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

    public void Update(string[] args)
    {
        
    }
}