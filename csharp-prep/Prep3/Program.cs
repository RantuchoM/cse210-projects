using System;

class Program
{
    static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int magicNumber;
        string response = "yes";
        string answer;
        int answerNumber;
        int guesses;
        do{
            magicNumber = randomGenerator.Next(1,100);
            guesses = 0;

            Console.Write("What is your guess? ");
            answer = Console.ReadLine();
            answerNumber = int.Parse(answer);

            do{
                if(answerNumber > magicNumber){
                    Console.WriteLine("Lower");
                }
                else{
                    Console.WriteLine("Higher");
                }
                Console.Write("What is your guess? ");
                answer = Console.ReadLine();
                answerNumber = int.Parse(answer);
                guesses ++;
            } while (answerNumber != magicNumber);
            Console.WriteLine($"Congratulations! The magic number is {magicNumber}! You guessed after {guesses} attempts!");

            Console.Write("Do you want to continue playing? ");
            response = Console.ReadLine().ToLower();
        } while (response == "yes");

        Console.WriteLine("Thank you for playing!");
    }
}