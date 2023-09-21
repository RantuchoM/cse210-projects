using System;
using System.Formats.Asn1;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new();

        string answer ="";
        do
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1.Write \n2.Display \n3.Load \n4.Save \n5.Edit Last Entry \n6.Quit");
            answer = Console.ReadLine();
            if(answer  == "1"){
                journal.AddEntry();
            }
            else if(answer == "2"){
                journal.DisplayAll();
            }
            else if(answer == "3"){
                Console.Write("What is the filename? ");
                string filePath = Console.ReadLine();
                journal.LoadFromFile(filePath);
            }
            else if(answer == "4"){
                Console.Write("What is the filename? ");
                string filePath = Console.ReadLine();
                journal.SaveToFile(filePath);
            }
            else if(answer == "5"){journal.EditLastEntry();}
            else if(answer == "6"){
                continue;}
            else {
                Console.WriteLine("\nPlease choose a valid option.");
            }

        } while (answer != "6");

        Console.WriteLine("\nThank you for using this program.");
    }
}
