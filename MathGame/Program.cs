string? readResult;
string menuSelection = "";
int roundsPlayed = 0;
string[,] games = new string[20, 2];

do
{
    Console.WriteLine("Welcome to the Math Game!");

    Console.WriteLine("Select an option:");
    Console.WriteLine("1 - Play Add");
    Console.WriteLine("2 - Play Subtract");
    Console.WriteLine("3 - Play Multiply");
    Console.WriteLine("4 - Play Divide");
    Console.WriteLine("5 - Previous games");
    Console.WriteLine("6 - Rules");
    Console.WriteLine("7 - Exit");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }

    switch (menuSelection)
    {
        case "1":
            RunAddGame();
            break;
        case "2":
            RunSubtractGame();
            break;
        case "3":
            RunMultiplyGame();
            break;
        case "4":
            RunDivideGame();
            break;
        case "5":
            PrintGames();
            break;
        case "6":
            PrintRules();
            break;
        case "7":
            menuSelection = "exit";
            break;
        default:
            break;
    }
} while (menuSelection != "exit");

void RunAddGame()
{
    bool allCorrect = true;
    int i;

    Console.WriteLine("Add Game");

    for (i = 0; i < 10; i++)
    {
        int num1 = GetRandomNumber();
        int num2 = GetRandomNumber();
        int num3;
        
        Console.WriteLine($"What is the result of {num1} + {num2}?");

        var input = Console.ReadLine();
        num3 = Convert.ToInt32(input);
        if (num3 == (num1 + num2))
        {
            Console.WriteLine("Correct!");
            Console.WriteLine("");
        } else
        {
            Console.WriteLine("Not quite, try again next time!");
            allCorrect = false;
            break;
        }
    }

    Console.WriteLine($"You've got {i} correct answer(s)!");

    if (allCorrect)
    {
        Console.WriteLine("You've beaten the game, such a genius!");
    }

    RegisterGame("Add", i.ToString());

    Console.ReadLine();
    Console.Clear();
}

void RunSubtractGame()
{
    bool allCorrect = true;
    int i;

    Console.WriteLine("Subtract Game");

    for (i = 0; i < 10; i++)
    {
        int num1 = GetRandomNumber();
        int num2 = GetRandomNumber();
        int num3;

        Console.WriteLine($"What is the result of {num1} - {num2}?");

        var input = Console.ReadLine();
        num3 = Convert.ToInt32(input);
        if (num3 == (num1 - num2))
        {
            Console.WriteLine("Correct!");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("Not quite, try again next time!");
            allCorrect = false;
            break;
        }
    }

    Console.WriteLine($"You've got {i} correct answer(s)!");

    if (allCorrect)
    {
        Console.WriteLine("You've beaten the game, such a genius!");
    }

    RegisterGame("Subtract", i.ToString());

    Console.ReadLine();
    Console.Clear();
}

void RunMultiplyGame()
{
    bool allCorrect = true;
    int i;

    Console.WriteLine("Multiply Game");

    for (i = 0; i < 10; i++)
    {
        int num1 = GetRandomNumber();
        int num2 = GetRandomNumber();
        int num3;

        Console.WriteLine($"What is the result of {num1} * {num2}?");

        var input = Console.ReadLine();
        num3 = Convert.ToInt32(input);
        if (num3 == (num1 * num2))
        {
            Console.WriteLine("Correct!");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("Not quite, try again next time!");
            allCorrect = false;
            break;
        }
    }

    Console.WriteLine($"You've got {i} correct answer(s)!");

    if (allCorrect)
    {
        Console.WriteLine("You've beaten the game, such a genius!");
    }

    RegisterGame("Multiply", i.ToString());

    Console.ReadLine();
    Console.Clear();
}

void RunDivideGame()
{
    int i;
    bool allCorrect = true;

    Console.WriteLine("Divide Game");

    for (i = 0; i < 10; i++)
    {
        int num1;
        int num2;
        int num3;

        do
        {
            num1 = GetRandomNumber();
            num2 = GetRandomNumber();
        } while (num1 % 2 != 0 || num1 < num2 || num1 % num2 != 0);

        Console.WriteLine($"What is the result of {num1} / {num2}?");

        var input = Console.ReadLine();
        num3 = Convert.ToInt32(input);
        if (num3 == (num1 / num2))
        {
            Console.WriteLine("Correct!");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("Not quite, try again next time!");
            allCorrect = false;
            break;
        }
    }

    if (allCorrect)
    {
        Console.WriteLine("You've beaten the game, such a genius!");
    }

    RegisterGame("Divide", i.ToString());

    Console.ReadLine();
    Console.Clear();
}

void PrintGames()
{

    Console.Clear();
    Console.WriteLine("Previous Games");

    for (int i = 0; i < games.GetLength(0); i++)
    {
        if (games[i, 0] != null)
        {
            Console.WriteLine($"Game {i + 1}");
            Console.WriteLine($"Operation: {games[i, 0]}");
            Console.WriteLine($"Num. of Correct Answers: {games[i, 1]}");
            Console.WriteLine();
        }
    }

    Console.ReadLine();
    Console.Clear();

}

int GetRandomNumber()
{
    Random random = new Random();
    return random.Next(1, 101);
}

void PrintRules()
{
    Console.WriteLine("Rules");
    Console.WriteLine("The game will offer you the 4 basic operations (add, subtract, multiply and divide");
    Console.WriteLine("After choosing one, you'll be presented with questions involving random numbers");
    Console.WriteLine("If you get 10 answers right in a row, you win!");
    Console.WriteLine("If you get 1 answer wrong, that's the end of the game");
    Console.WriteLine("When on the menu, choose option 7 to leave, or just type 'exit'.");
    Console.WriteLine("Don't forget to have a lot of fun!");

    Console.ReadLine();
}

void RegisterGame(string operation, string correctAnswers)
{
    games[roundsPlayed, 0] = operation;
    games[roundsPlayed, 1] = correctAnswers;
    roundsPlayed++;
}