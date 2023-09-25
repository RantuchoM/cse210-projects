using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction _fraction1 = new();
        Console.WriteLine(_fraction1.GetFractionString());
        Console.WriteLine();
        
        Fraction _fraction2 = new(4);
        Console.WriteLine(_fraction2.GetFractionString());
        Console.WriteLine();

        Fraction _fraction3 = new(4,7);
        Console.WriteLine(_fraction3.GetFractionString());
        Console.WriteLine();

        Fraction _fraction4 = new();
        _fraction4.SetTop(4);
        _fraction4.SetBottom(8);
        Console.WriteLine(_fraction4.GetTop());
        Console.WriteLine(_fraction4.GetBottom());
        Console.WriteLine(_fraction4.GetFractionString());
        Console.WriteLine(_fraction4.GetDecimalValue());
    }
}