using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayMessage();
        
        string name = PromptUserName();
        int number = PromptUserNumber();
        double squared = SquareNumber(number);

        DisplayResult(name,squared);
        
    }

    static void DisplayMessage()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());
        return number;
    }
    
    static double SquareNumber(int number)
    {
        double squared = Math.Pow(double.Parse(number.ToString()),2);
        return squared;
    }

    static void DisplayResult(string name,double square)
    {
        Console.Write($"{name}, the square of your number is {square}.");
    }
}