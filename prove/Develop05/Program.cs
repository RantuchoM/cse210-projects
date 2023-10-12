using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new();
        goalManager.Start();
        while (true) //while Exit is chosen, it will keep looping the menu
        {
            Console.WriteLine("\n\n");
            goalManager.DisplayPlayerInfo();
            Console.WriteLine("");
            Console.WriteLine("Goal Manager Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. Record Event");
            Console.WriteLine("3. List Goals");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Change User");
            Console.WriteLine("6. Exit");

            Console.Write("\nSelect an option (1-6): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    goalManager.CreateGoal();
                    break;
                case "2":
                    goalManager.RecordEvent();
                    break;
                case "3":
                    goalManager.ListGoalDetails();
                    break;
                case "4":
                    goalManager.SaveGoals();
                    break;
                case "5":
                    goalManager.LoadUser(); //instead of choosing a filename, you choose between existing "users"
                    break;
                case "6":
                    Environment.Exit(0); // Exit the program
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
    
}