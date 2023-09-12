using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        Console.Write("Enter number: ");
        int amount = 0;
        string answer = Console.ReadLine();
        while (answer != "0"){
            amount ++;
            numbers.Add(int.Parse(answer));
                        
            Console.Write("Enter number: ");
            answer = Console.ReadLine();}
        int sum = numbers.Sum();
        int average = sum/amount;
        int max = numbers.Max();
        Console.WriteLine($"The sum is {sum}.\nThe average is {average}.\nThe largest number is {max}");

        int minPos = 100000000;
        foreach (int number in numbers){
            if ((minPos > number) && (number > 0)){
                minPos = number;
            }
        }
        Console.WriteLine($"The smallest positive number is {minPos}");
        numbers.Sort();
        Console.WriteLine("\nThe sorted list is:");
        foreach (int number in numbers){
            Console.WriteLine(number);
        }



    }
}