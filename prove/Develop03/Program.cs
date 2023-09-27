using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new("Proverbs",3,5,6);
        Scripture scripture = new(reference,"Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");
        
        // I added the option to increment or decrement the amount of hidden words by tiping positive or negative integers
        Console.Clear();
        Console.WriteLine("Please, type a positive number of words you want to hide, or a negative number of the amount of words you want to show.\nType 'quit' if you want to exit.");
        Console.WriteLine();

        //The Scripture is displayed in blue
        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"{reference.GetDisplayText()} {scripture.GetDisplayText()}\n");
        Console.ResetColor();
        
        // GetValidInput() keeps asking the user until it enters a positive or negative integer, or "quit"
        string answer = GetValidInput();
        do{
            Console.Clear();
            int number = int.Parse(answer);
            if(number > 0)
            {
                scripture.HideRandomWords(number);
            }
            else
            {
                scripture.ShowLastWords(number*-1);
            }
            
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine($"{reference.GetDisplayText()} {scripture.GetDisplayText()}\n");
            Console.ResetColor();
            
            answer = GetValidInput();
        }while(answer.ToLower() != "quit" && (!scripture.IsCompletelyHidden() || int.Parse(answer) < 0)); //I added the last condition so it allows to show words even if the scripture is completely hidden
    }

    static string GetValidInput()
    //this function is meant to ask the user until it enters positive or negative integer, or "quit". If it's left empty, it will hide 3 words as the core requirements asked
    {
        string input = "";
        int number;
        do
        {
            Console.WriteLine("Please enter how many words you'd like to show or hide, or type 'quit' to exit.");
            input = Console.ReadLine();
        } while(input.ToLower() != "quit" && (!int.TryParse(input,out number) || input == "0") && input.ToLower() != "");
        if(input == "")
        {
            return "3";
        }
        else
        { 
            return input;
        }
    } 
}
