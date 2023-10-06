using System.Globalization;

public class Activity
{
    private string _name;
    private string _description;
    private int _duration;

    //Constructor
    public Activity(string name, string description, int duration)
    {
        _name = name;
        _description = description;
        _duration = duration;
    }
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 60;
    }
    //Setter
    public void SetDuration(int duration)
    {
        _duration = duration;
    }
    //Getters
    public int GetDuration()
    {
        return _duration;
    }
    public string GetName()
    {
        return _name;
    }
    //Methods
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine(_description);
        Console.WriteLine("How long, in seconds, would you like your session? ");
        int duration = int.Parse(Console.ReadLine());
        SetDuration(duration);

        Console.Clear();
        Console.WriteLine("Get Ready...");
        ShowSpinner(5);
        
    }
    public void DisplayEndingMessage()
    {
        Console.WriteLine("\nWell done!!");
        ShowSpinner(3);
        Console.WriteLine($"\nYou have completed another {_duration} seconds of the {_name}.");
        Console.WriteLine("Press Enter to continue.");
        Console.ReadLine();
    }
    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        int latency = 250; //Here I can set how fast or slow it can beshown
        int loops = seconds*latency/1000;

        for (int i = 0; i < loops; i++)
        {
            foreach (string symbol in spinner)
            {
                Console.Write(symbol);
                Thread.Sleep(latency);
                Console.Write("\b");
            }
        }
        Console.Write(" ");
    }
    public void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
          
            Console.Write(i);
            Thread.Sleep(1000);
            foreach(char c in i.ToString()) //Here, I'm deleting all the digits, even if there are more than 1 or 2.
            {
                Console.Write("\b \b");
            }
        }
    }
}

