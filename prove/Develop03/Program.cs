using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new("Proverbs",3,5,6);
        Scripture scripture = new(reference,"Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");
        
        Console.Clear();
        Console.WriteLine("Please, type a positive number of words you want to hide, or a negative number of the amount of words you want to show.\nType 'quit' if you want to exit.");
        Console.WriteLine();

        Console.ForegroundColor = ConsoleColor.DarkBlue;
        Console.WriteLine($"{reference.GetDisplayText()} {scripture.GetDisplayText()}\n");
        Console.ResetColor();
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
            //Console.WriteLine(string.Join(", ",scripture._orderOfHidden));
            answer = GetValidInput();
        }while(answer.ToLower() != "quit" && (!scripture.IsCompletelyHidden() || int.Parse(answer) < 0)); //I added the last condition so it allows to show words even if the scripture is completely hidden
    }

    static string GetValidInput()
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
