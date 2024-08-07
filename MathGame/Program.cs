using System.Diagnostics;

string? readResult;
string menuSelection = "";
string difficulty = "";
int numOfQuestions = 5;
int roundsPlayed = 0;
string[,] games = new string[20, 3];

do
{
    Console.WriteLine("Welcome to the Math Game!");

    Console.WriteLine("Select an option:");
    Console.WriteLine("1 - Play Add");
    Console.WriteLine("2 - Play Subtract");
    Console.WriteLine("3 - Play Multiply");
    Console.WriteLine("4 - Play Divide");
    Console.WriteLine("5 - Play Random");
    Console.WriteLine("6 - Previous games");
    Console.WriteLine("7 - Rules");
    Console.WriteLine("8 - Exit");

    readResult = Console.ReadLine();
    if (readResult != null)
    {
        menuSelection = readResult.ToLower();
    }   

    switch (menuSelection)
    {
        case "1":
            DefineDifficulty();
            DefineNumOfQuestions();
            RunAddGame();
            break;
        case "2":
            DefineDifficulty();
            DefineNumOfQuestions();
            RunSubtractGame();
            break;
        case "3":
            DefineDifficulty();
            DefineNumOfQuestions();
            RunMultiplyGame();
            break;
        case "4":
            DefineDifficulty();
            DefineNumOfQuestions();
            RunDivideGame();
            break;
        case "5":
            DefineDifficulty();
            DefineNumOfQuestions();
            RunRandomGame();
            break;
        case "6":
            PrintGames();
            break;
        case "7":
            PrintRules();
            break;
        case "8":
            menuSelection = "exit";
            break;
        default:
            break;
    }
} while (menuSelection != "exit");

void RunAddGame()
{
    Stopwatch sw = new Stopwatch();
    sw.Start();

    bool allCorrect = true;
    int i;

    Console.WriteLine("Add Game");

    for (i = 0; i < numOfQuestions; i++)
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

    sw.Stop();
    Console.WriteLine($"Time taken: {sw.Elapsed.Seconds}s");
    RegisterGame("Add", i.ToString(), sw.Elapsed.Seconds.ToString());

    Console.ReadLine();
    Console.Clear();
}

void RunSubtractGame()
{
    Stopwatch sw = new Stopwatch();
    sw.Start();

    bool allCorrect = true;
    int i;

    Console.WriteLine("Subtract Game");

    for (i = 0; i < numOfQuestions; i++)
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

    sw.Stop();
    Console.WriteLine($"Time taken: {sw.Elapsed.Seconds}s");
    RegisterGame("Subtract", i.ToString(), sw.Elapsed.Seconds.ToString());

    Console.ReadLine();
    Console.Clear();
}

void RunMultiplyGame()
{
    Stopwatch sw = new Stopwatch();
    sw.Start();

    bool allCorrect = true;
    int i;

    Console.WriteLine("Multiply Game");

    for (i = 0; i < numOfQuestions; i++)
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

    sw.Stop();
    Console.WriteLine($"Time taken: {sw.Elapsed.Seconds}s");
    RegisterGame("Multiply", i.ToString(), sw.Elapsed.Seconds.ToString());

    Console.ReadLine();
    Console.Clear();
}

void RunDivideGame()
{
    Stopwatch sw = new Stopwatch();
    sw.Start();

    int i;
    bool allCorrect = true;

    Console.WriteLine("Divide Game");

    for (i = 0; i < numOfQuestions; i++)
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

    sw.Stop();
    Console.WriteLine($"Time taken: {sw.Elapsed.Seconds}s");
    RegisterGame("Divide", i.ToString(), sw.Elapsed.Seconds.ToString());

    Console.ReadLine();
    Console.Clear();
}

void RunRandomGame()
{
    Stopwatch sw = new Stopwatch();
    sw.Start();

    int i;
    bool allCorrect = true;

    Console.WriteLine("Random Game");

    for (i = 0; i < numOfQuestions; i++)
    {
        int num1;
        int num2;
        int num3;
        int num4;
        char operation;

        do
        {
            operation = GetRandomOperation();
            num1 = GetRandomNumber();
            num2 = GetRandomNumber();
        } while (num1 % 2 != 0 || num1 < num2 || num1 % num2 != 0);

        Console.WriteLine($"What is the result of {num1} {operation} {num2}?");

        var input = Console.ReadLine();
        num3 = Convert.ToInt32(input);

        if (operation == '+')
            num4 = num1 + num2;
        else if (operation == '-')
            num4 = num1 - num2;
        else if (operation == '*')
            num4 = num1 * num2;
        else
            num4 = num1 / num2;

        if (num3 == num4)
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

    sw.Stop();
    Console.WriteLine($"Time taken: {sw.Elapsed.Seconds}s");
    RegisterGame("Random", i.ToString(), sw.Elapsed.Seconds.ToString());

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
            Console.WriteLine($"Time Taken: {games[i, 2]}s");
            Console.WriteLine();
        }
    }

    Console.ReadLine();
    Console.Clear();

}

int GetRandomNumber()
{
    Random random = new Random();

    if (difficulty == "1")
        return random.Next(1, 30);
    else if (difficulty == "2")
        return random.Next(1, 60);
    else
        return random.Next(1, 151);
}

char GetRandomOperation()
{
    Random _random = new Random();
    char[] operations = { '+', '-', '*', '/' };
    int index = _random.Next(operations.Length);
    return operations[index];
}

void PrintRules()
{
    Console.WriteLine("Rules");
    Console.WriteLine("The game will offer you the 4 basic operations (add, subtract, multiply and divide");
    Console.WriteLine("After choosing one, you'll be presented with questions involving random numbers");
    Console.WriteLine("If you get 10 answers right in a row, you win!");
    Console.WriteLine("If you get 1 answer wrong, that's the end of the game");
    Console.WriteLine("When on the menu, choose option 8 to leave, or just type 'exit'.");
    Console.WriteLine("Don't forget to have a lot of fun!");

    Console.ReadLine();
}

void RegisterGame(string operation, string correctAnswers, string seconds)
{
    games[roundsPlayed, 0] = operation;
    games[roundsPlayed, 1] = correctAnswers;
    games[roundsPlayed, 2] = seconds;
    roundsPlayed++;
}

void DefineDifficulty()
{
    Console.WriteLine("Select a difficulty:");
    Console.WriteLine("1 - Easy");
    Console.WriteLine("2 - Medium");
    Console.WriteLine("3 - Hard");

    difficulty = Console.ReadLine();
}

void DefineNumOfQuestions()
{
    Console.WriteLine("Enter the number of questions you want to play:");
    numOfQuestions = Convert.ToInt32(Console.ReadLine());
}