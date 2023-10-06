using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Summary summary = new();
        var menuActions = new Dictionary<string, Action<Summary>> //I created this "launcher", that can execute actions for what I've investigated. 
        //Since I'm passing the Summary Class, it has that 'Action<Summary>' and that arrow function inside.
        {
            { "1", (s) => LaunchBreathing(s) },
            { "2", (s) => LaunchListing(s) },
            { "3", (s) => LaunchReflecting(s) },
            {"4",(s) => LaunchSummary(s) }
        };
        
         while (true)
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("1. Start breathing activity");
            Console.WriteLine("2. Start listing activity");
            Console.WriteLine("3. Start reflecting activity");
            Console.WriteLine("4. See summary of activities in this session.");
            Console.WriteLine("5. Quit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            if (choice.Equals("5", StringComparison.OrdinalIgnoreCase))
                break;

            if (menuActions.TryGetValue(choice, out var action))
            {
                action.Invoke(summary); // Pass the summary object
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
    static void LaunchReflecting(Summary summary)
    {
        List<string> reflectionPrompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };
        
        List<string> reflectionQuestions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        ReflectingActivity reflecting = new(reflectionPrompts,reflectionQuestions);
        reflecting.Run();
        summary.AddActivity(reflecting);

    }

    static void LaunchListing(Summary summary)
    {
        List<string> listingQuestions = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?"
        };
        
        ListingActivity listing = new(listingQuestions);
        listing.Run();
        summary.AddActivity(listing);
    }

    static void LaunchBreathing(Summary summary)
    {
        BreathingActivity breathing = new();
        breathing.Run();
        summary.AddActivity(breathing);
    }
    static void LaunchSummary(Summary summary)
    {
        summary.DisplayActivities();
    }
        
}
