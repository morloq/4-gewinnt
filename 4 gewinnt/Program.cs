class Program
{
    static int turns = 1;
    static int player = 2;
    static char[] board = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
    static char playerSignature = 'X';
    private static void Introduction()
    {
        Console.WriteLine("This is a game like tic tac toe, except with in a 4 by 4 dimension. Enter y if you have played before and n if you are new to this.");
        string input1 = " ";
        while (input1 != "y" && input1 != "n")
        {
            input1 = Console.ReadLine();
            switch (input1)
            {
                case "y":
                    Console.WriteLine("Alright, let's get started, you are X, your friend is O.");
                    DrawBoard(board);
                    break;
                case "n":
                    Console.WriteLine("4 gewinnt regeln:");
                    Console.WriteLine("1. The game is played on a grid that's 4 squares by 4 squares.");
                    Console.WriteLine("2. You are X, your friend is O. Players take turns putting their marks in empty squares.");
                    Console.WriteLine("3. The first player to get 4 of their marks in a row (up, down, across, or diagonally) is the winner.");
                    Console.WriteLine("4. When all 16 squares are full, the game is over.");
                    Console.WriteLine("If you have read the rules, press any key to continue.");
                    Console.ReadKey();
                    Console.Clear();
                    DrawBoard(board);
                    break;
                default:
                    Console.WriteLine("Please enter y/n.");
                    break;
            }
        }
    }
    private static void DrawBoard(char[] board)
    {

        string row = "| {0} | {1} | {2} | {3} |";
        string sep = "|___|___|___|___|";
        Console.WriteLine(" ___ ___ ___ ___ ");
        Console.WriteLine(row, board[0], board[1], board[2], board[3]);
        Console.WriteLine(sep);
        Console.WriteLine(row, board[4], board[5], board[6], board[7]);
        Console.WriteLine(sep);
        Console.WriteLine(row, board[8], board[9], board[10], board[11]);
        Console.WriteLine(sep);
        Console.WriteLine(row, board[12], board[13], board[14], board[15]);
        Console.WriteLine(sep);
    }
    private static void Reset()
    {
        char[] reset = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        board = reset;
        DrawBoard(board);
    }
    private static void Draw()
    {
        Console.WriteLine("It's a draw!\n" +
                            "Press any key to play again or click or close the window to exit the game.");
        Console.ReadKey();
        Reset();
    }
    public static void Main()
    {
        Introduction();
        while (true)
        {
            bool isrow = false;
            bool iscol = false;
            int row = 0;
            int col = 0;
            while (!isrow)
            {
                Console.WriteLine("Choose a row (1-4): ");
                try
                {
                    row = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {

                    Console.WriteLine("Please enter a number between 1 and 4.");
                }
                if (row == 1 || row == 2 || row == 3 || row == 4)
                {
                    isrow = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid row!");
                }
            }
            while (!iscol)
            {
                Console.WriteLine("Choose a column (1-4): ");
                try
                {
                    col = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please enter a number between 1 and 4.");
                }
                if (col == 1 || col == 2 || col == 3 || col == 4)
                {
                    iscol = true;
                }
                else
                {
                    Console.WriteLine("\nInvalid column!");
                }
            }
            int[] input = { row, col };
            if (player == 2)
            {
                player = 1;
                XorO(player, input);
            }
            else
            {
                player = 2;
                XorO(player, input);
            }
            DrawBoard(board);
            Win();
            turns++;
            if (turns == 10 && (board[0] == playerSignature && board[1] == playerSignature && board[2] == playerSignature && board[3] == playerSignature &&
                board[4] == playerSignature && board[5] == playerSignature && board[6] == playerSignature && board[7] == playerSignature && board[8] == playerSignature
                && board[9] == playerSignature && board[10] == playerSignature && board[11] == playerSignature && board[12] == playerSignature && board[13] == playerSignature
                && board[14] == playerSignature && board[15] == playerSignature))
            {
                Draw();
            }
        }
    }
    private static void XorO(int player, int[] input)
    {
        playerSignature = (player == 1) ? 'X' : 'O';//if player == 1 dann ps = 'X', else 'O'
        int index = ((input[0] - 1) * 4) + (input[1] - 1);//3 - 1 = 2 , 2*3 = 6 + 2 = 8 für 3 3 | compact layout
        if (board[index] == ' ')
        {
            board[index] = playerSignature;
        }
        else
        {
            Console.WriteLine("That spot is already taken! Try again!");
        }
    }
    private static void Win()
    {
        if ((board[3] == playerSignature && board[7] == playerSignature && board[11] == playerSignature && board[15] == playerSignature ||
            board[2] == playerSignature && board[6] == playerSignature && board[10] == playerSignature && board[14] == playerSignature ||
            board[1] == playerSignature && board[5] == playerSignature && board[9] == playerSignature && board[13] == playerSignature ||
            board[0] == playerSignature && board[4] == playerSignature && board[8] == playerSignature && board[12] == playerSignature)||
            
            (board[0] == playerSignature && board[1] == playerSignature && board[2] == playerSignature && board[3] == playerSignature||
             board[4] == playerSignature && board[5] == playerSignature && board[6] == playerSignature && board[7] == playerSignature||
             board[8] == playerSignature && board[9] == playerSignature && board[10] == playerSignature && board[11] == playerSignature ||
             board[12] == playerSignature && board[13] == playerSignature && board[14] == playerSignature && board[15] == playerSignature) ||

            (board[0] == playerSignature && board[5] == playerSignature && board[10] == playerSignature && board[15] == playerSignature ||
             board[12] == playerSignature && board[9] == playerSignature && board[6] == playerSignature && board[3] == playerSignature))
        {
            if (player == 1)
            {
                Console.WriteLine("Congratulations Player 1, you win!\n");
                Console.WriteLine("Play again? y/n.");
                Playagain();
            }
            else if (player == 2)
            {
                Console.WriteLine("Congratulations Player 2, you win!\n");
                Console.WriteLine("Play again y/n?");
                Playagain();
            }
        }
    }
    private static void Playagain()
    {
        string input2 = " ";
        input2 = Console.ReadLine();
        if (input2 == "y")
        {
            Reset();
            Console.Clear();
        }
        else if (input2 == "n")
        {
            Console.Clear();
            Console.WriteLine("Close the window to exit the game.");
            Console.ReadKey();
        }
        else
        {
            Console.WriteLine("Please enter y/n.");
        }
    }
}