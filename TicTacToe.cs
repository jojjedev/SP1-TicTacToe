
namespace tictactoe;

public class TicTacToe
{
    // Create the constants of the game that are used in the entire class.
    public static int[,] board = new int[3, 3];
    private static int[] columns = { 1, 2, 3 };
    private static string[] rows = { "A", "B", "C" };
    
    // Create the current player variable to keep track on whose turn it is.
    static string player1Name;
    static string player2Name;
    static int currentPlayer = 1;
    
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
                /* If a coordinate in the board has not yet been taken, draw it as empty.
                 If the value of the input coordinate is 1, write out an X, else write out an O. Basically,
                 player 1 writes out X, player 2 writes out O.*/
                if (board[i, j] == 0)
                {
                    Console.Write("   |");
                }
                else if (board[i, j] == 1)
                {
                    Console.Write($" X |");
                }
                else
                {
                    Console.Write($" O |");
                }

            }

            Console.WriteLine();
            Console.Write("  -------------\n");
        }
    }
    
    public static (int rowIndex, int colIndex, int previousPlayer) Round()
    {
        // If currentPlayer == 1, print player1Name, else print player2Name
        Console.Write(currentPlayer == 1 ? $"It's {player1Name}'s turn: " : $"It's {player2Name}'s turn: ");
        string row;
        int col;
        int rowIndex;
        int colIndex;
        
        // While loop that continues until a valid input is given.
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
            // If an invalid input is given, redraw the board with an error message below that prompts another input.
            Draw(); 
            Console.WriteLine("Invalid input, try another coordinate A1-C3.");
            
        }

        rowIndex = rows.IndexOf(row);
        colIndex = columns.IndexOf(col);
        Update(rowIndex, colIndex, currentPlayer);
        int previousPlayer = currentPlayer;
        currentPlayer = currentPlayer % 2 + 1;
        return (rowIndex, colIndex, previousPlayer);
        
    }
    
    /* The Update() function takes the variables generated in Round() by the input of the player and updates the board.
     The updated value of board is then used when Draw() is called again. */
    private static void Update(int row, int col, int currentPlayer)
    {
        board[row, col] = currentPlayer;
        Draw();
    }
    
    /* CheckGameState() is called in Main() at the end of each round to see if the latest input given by a player
     has ended the game by making a line of three in a row. It does this by comparing each valid combination of
     coordinates that makes three in a row with the inputs made by each player. Not an effective method since it
     checks even though the length of player1Used and player2Used is less than 3, meaning it checks before it's
     possible for there to even be a winner.*/
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
            Console.WriteLine($"Game over! {player1Name} Wins!");
            gameEnd = true;
        }

        if (player2Win == 1)
        {
            Console.WriteLine($"Game over! {player2Name} Wins!");
            gameEnd = true;
        }

        return gameEnd;
    }

    /* NewGame() runs at the start of the game, and makes the players set their names. After the names are set, 
     the players have to confirm their names by typing yes. If anything else is given, they get prompted to
     write their names in again. If confirmed by typing "yes", the while loop breaks and the function ends.*/
    public static void NewGame()
    {
        Console.Clear();
        Console.WriteLine("Let's play TicTacToe!\n\nPress Enter to start the game");
        Console.ReadLine();
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Please write your names.");
            player1Name = Console.ReadLine()!;
            player2Name = Console.ReadLine()!;
            Console.Clear();
            Console.WriteLine($"Please confirm that your names are correct.\nPlayer 1: {player1Name}\nPlayer 2: {player2Name}");
            Console.WriteLine("Type 'yes' to confirm, or press Enter to type new names.");
            string response = Console.ReadLine()!.Trim().ToLower();
            if (response == "yes")
            {
                break;
            }
            
        }
    }
    
    /* When a rematch is prompted in the game loop, Rematch() runs. It checks which player lost, by checking who
     was going to take their turn next. So if player 1 wins, currentPlayer would be set to 2, since it was on
     player 1's turn the last input was made. The loser decides which player is going to start the next game
     by typing 1 or 2.*/
    public static void Rematch()
    {
        string response;
        do
        {
            if (currentPlayer == 1)
            {
                Console.WriteLine($"{player1Name}, since you lost, you decide who begins the next game. \nType 1 for {player1Name}\nor\nType 2 for {player2Name} ");
            }
            else
            {
                Console.WriteLine($"{player2Name}, since you lost, you decide who begins the next game. \nType 1 for {player1Name}\nor\nType 2 for {player2Name} ");
                
            }
            response = Console.ReadLine()!.Trim();
            if (response == "1")
            {
                currentPlayer = 1;
            }
            else if (response == "2")
            {
                currentPlayer = 2;
            }
        } while (response != "1" && response != "2");
            
        
    }
}