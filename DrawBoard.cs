using System.Security.Cryptography.X509Certificates;

namespace tictactoe;

public class TicTacToe
{
    // Create the constants of the game that are used in the entire class.
    public static int[,] board = new int[3, 3];
    private static int[] columns = { 1, 2, 3 };
    private static string[] rows = { "A", "B", "C" };
    
    // Create the current player variable to keep track on whose turn it is.
    public static int currentPlayer = 1; 
    
    // The Draw function draws the current board into the terminal. It changes each turn based on which value in board is changed.
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
                /* If a coordinate in the board has not yet been taken, draw it as empty,
                 otherwise draw the number of the player that chose it. */
                if (board[i, j] == 0)
                {
                    Console.Write("   |");
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
    
    
    

    public static (int rowIndex, int colIndex, int previousPlayer) Round()
    {
        Console.Write($"It's Player {currentPlayer}'s turn: ");
        string row;
        int col;
        int rowIndex;
        int colIndex;
        
        while (true)
        {
            string response = Console.ReadLine().Trim();
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
    
    /* The Update() function takes the variables generated in Round() by the input of the player and updates the board.
     The updated value of board is then used when Draw() is called again. */
    private static void Update(int row, int col, int currentPlayer)
    {
        board[row, col] = currentPlayer;
        TicTacToe.Draw();
    }
    
    /* CheckGameState() is called in Main() at the end of each round to see if the latest
     */
    public static bool CheckGameState(List<string> player1Used, List<string> player2Used)
    {
        int player1Win = 0;
        int player2Win = 0;
        bool gameEnd = false;
        string[][] winning =
        [
            [ "00", "01", "02" ],
            [ "10", "11", "12" ],
            [ "20", "21", "22" ],
            [ "00", "10", "20" ],
            [ "01", "11", "21" ],
            [ "02", "12", "22" ],
            [ "00", "11", "22" ],
            [ "02", "11", "20" ]
        ];
        foreach (string[] combination in  winning)
        {
            int count1 = 0;
            int count2 = 0;
            foreach (var s in combination)
            {
                if (player1Used.Contains(s))
                {
                    count1++;
                }
                if (player2Used.Contains(s))
                {
                    count2++;
                }
            }
            if (count1 == 3)
            {
                player1Win = 1;
            }
            if (count2 == 3)
            {
                player2Win = 1;
            }
        }
        if (player1Win == 1)
        {
            Console.WriteLine("Game over! Player 1 Wins!");
            gameEnd = true;
        }

        if (player2Win == 1)
        {
            Console.WriteLine("Game over! Player 2 Wins!");
            gameEnd = true;
        }

        return gameEnd;
    }
}