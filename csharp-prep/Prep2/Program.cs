using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Which is your percentage? ");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        string letterGrade;
        string letterSign = "";
        

        if (number >= 90)
            {letterGrade = "A";}
        else if (number >= 80)
            {letterGrade = "B";}
        else if (number >= 70)
            {letterGrade = "C";}
        else if (number >= 60)
            {letterGrade = "D";}
        else
            {letterGrade = "F";}

        if (number < 90 && number >=60)
            {
                int remainder = number % 10;
                if (remainder <= 3)
                    {letterSign = "-";}
                else if (remainder >= 7)
                    {letterSign = "+";}
            }
        
        Console.WriteLine($"Your grade is {letterGrade}{letterSign}");
        if(number >= 70)
            {Console.WriteLine("Congratulations! You passed!");}
        else
            {Console.WriteLine("Unfortunately, you haven't passed.");}
        
        
    }
}