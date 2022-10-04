class Board
{
    List<string> spaces = new List<string>();

    public Board()
    {
        for (int i = 1; i <=9; i++)
        {
            spaces.Add(i.ToString());
        }
    }

    public bool containsUnclaimedSpaces()
    {
        int turnNumber = 0;
        for (int i = 0; i < 9; i++)
        {
            if(spaces[i] == "x" || spaces[i] == "o")
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

    public bool IsPlayerWinner(string player)
    {
        for(int i = 0; i < 3; i++)
        {
            if (spaces[0 + (3*i)] == player && spaces[1 + (3*i)] == player && spaces[2 + (3*i)] == player)
            {
                return true;
            }
        }
        for(int i = 0; i < 3; i++)
        {
            if (spaces[0 + i] == player && spaces[3 + i] == player && spaces[6 +i] == player)
            {
                return true;
            }
        }
        if (spaces[0] == player && spaces[4] == player && spaces[8] == player)
        {
            return true;
        }
        if (spaces[2] == player && spaces[4] == player && spaces[6] == player)
        {
            return true;
        }
        
        return false;
    }
}