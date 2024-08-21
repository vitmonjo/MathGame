using System.Diagnostics;
using System.Linq.Expressions;

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
            RunGame('+');
            break;
        case "2":
            RunGame('-');
            break;
        case "3":
            RunGame('*');
            break;
        case "4":
            RunGame('/');
            break;
        case "5":
            RunGame('!');
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

void RunGame(char operation)
{
    SetupParameters();

    Stopwatch sw = new Stopwatch();
    sw.Start();
    bool allCorrect = true;
    bool random = false;
    int i = 0;

    if (operation == '!')
        random = true;

    Console.WriteLine($"{GetNameOfGame(operation, random)} Game");

    for (i = 0; i < numOfQuestions; i++)
    {
        int num1;
        int num2;
        int num3;
        int num4;

        if (random) 
            operation = GetRandomOperation();
        do
        {   
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

    Console.WriteLine($"You've got {i} correct answer(s)!");

    if (allCorrect)
    {
        Console.WriteLine("You've beaten the game, such a genius!");
    }

    sw.Stop();
    Console.WriteLine($"Time taken: {sw.Elapsed.Seconds}s");
    RegisterGame(GetNameOfGame(operation, random), i.ToString(), sw.Elapsed.Seconds.ToString());

    Console.ReadLine();
    Console.Clear();

}

void SetupParameters()
{
    DefineNumOfQuestions();
    DefineDifficulty();
}

string GetNameOfGame(char operation, bool random)
{
    if (random)
        return "Random";

    switch (operation)
    {
        case '+':
            return "Adding";
        case '-':
            return "Subtracting";
        case '*':
            return "Multiplying";
        case '/':
            return "Dividing";
        default:
            return "Invalid operation";
    }
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