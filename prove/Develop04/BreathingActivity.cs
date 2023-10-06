using System.Runtime;

public class BreathingActivity : Activity
{
    //Constructord
    public BreathingActivity(string name, string description, int duration) : base(name,description,duration)
    {
        
    }
    public BreathingActivity() : base("Breathing Activity","This activity will help you relax by walking your through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {

    }
    //Methods
    public void Run()
    {
        DisplayStartingMessage();
        double duration = (double)GetDuration();
        double amount = Math.Ceiling(duration/10);
        for (int i=0;i<amount;i++)
        {
            Console.Write("\n\nBreath in... ");
            ShowCountDown(4);
            Console.Write("\nBreath out... ");
            ShowCountDown(6);
        }
        DisplayEndingMessage();
    }
}