class TicTacToe
{
    static void Main(string[] args)
    {

        List<string> board = GetNewBoard();
        string currentPlayer = "x";

        while (!IsGameOver(board))
        {
            DisplayBoard(board);

            int choice = GetMoveChoice(currentPlayer);
            MakeMove(board, choice, currentPlayer);

            currentPlayer = GetNextPlayer(currentPlayer);
        }

        DisplayBoard(board);
        Console.WriteLine("Good game. Thanks for playing!");
    }

    /// <summary>Gets a new instance of the board with the numbers 1-9 in place. </summary>
    /// <returns>A list of 9 strings representing each square.</returns>
    static List<string> GetNewBoard()
    {
        List<string> board = new List<string>();

        for (int i = 1; i <=9; i++)
        {
            board.Add(i.ToString());
        }
        
        return board;
    }

    /// <summary>Displays the board in a 3x3 grid.</summary>
    /// <param name="board">The board</param>
    static void DisplayBoard(List<string> board)
    {
        for (int i = 0; i < 9; i++)
        {
            if (i == 2 || i == 5)
            {
                Console.WriteLine($"{board[i]} \n-+-+-\n");
            }
            else if(i == 8)
            {
                Console.WriteLine(board[i]);
            }
            else
            {
                Console.WriteLine($"{board[i]} | ");
            }
        }
    }

    /// <summary>
    /// Determines if the game is over because of a win or a tie.
    /// </summary>
    /// <param name="board">The current board.</param>
    /// <returns>True if the game is over</returns>
    static bool IsGameOver(List<string> board)
    {
        if (IsWinner(board,"x") || IsWinner(board, "o") || IsTie(board))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>Determines if the provided player has a tic tac toe.</summary>
    /// <param name="board">The current board</param>
    /// <param name="player">The player to check for a win</param>
    /// <returns></returns>
    static bool IsWinner(List<string> board, string player)
    {
        for(int i = 0; i < 3; i++)
        {
            if (board[0 + i] == player && board[1 + i] == player && board[2 + i] == player)
            {
                return true;
            }
        }
        if (board[0] == player && board[4] == player && board[8] == player)
        {
            return true;
        }
        if (board[2] == player && board[4] == player && board[6] == player)
        {
            return true;
        }
        
        return false;
    }

    /// <summary>Determines if the board is full with no more moves possible.</summary>
    /// <param name="board">The current board.</param>
    /// <returns>True if the board is full.</returns>
    static bool IsTie(List<string> board)
    {
        int turnNumber = 0;
        for (int i = 0; i <9; i++)
        {
            if(board[i] == "x" || board[i] == "o")
            {
                turnNumber += 1;
            }
        }
        if (turnNumber == 9)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
 
    /// <summary>Cycles through the players (from x to o and o to x)</summary>
    /// <param name="currentPlayer">The current players sign (x or o)</param>
    /// <returns>The next players sign (x or o)</returns>
    static string GetNextPlayer(string currentPlayer)
    {
        if(currentPlayer == "x")
        {
            return "o";
        }
        else
        {
            return "x";
        }
    }

    /// <summary>Gets the 1-based spot number associated with the user's choice.</summary>
    /// <param name="currentPlayer">The sign (x or o) of the current player.</param>
    /// <returns>A 1-based spot number (not a 0-based index)</returns>
    static int GetMoveChoice(string currentPlayer)
    {  
        int choice = 0;
        Console.WriteLine("What space do you want to choose?");
        string input = Console.ReadLine();
        choice = Convert.ToInt32(input);
        choice = choice - 1;
        return choice;
    }

    /// <summary>
    /// Places the current players mark on the board at the desired spot.
    /// This method does NOT check to ensure the spot is available.
    /// </summary>
    /// <param name="board">The current board</param>
    /// <param name="choice">The 1-based spot number (not a 0-based index).</param>
    /// <param name="currentPlayer">The current player's sign (x or o)</param>
    static void MakeMove(List<string> board, int choice, string currentPlayer)
    {
        board[choice] = currentPlayer;
    }
}
