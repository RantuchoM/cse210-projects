public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts;
    //Constructor
    public ListingActivity(string name, string description, int duration, List<string> prompts) : base(name,description,duration)
    {
        _count = 0;
        _prompts = prompts;
    }
    
    public ListingActivity(List<string> prompts) : base("Listing Activity","This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _count = 0;
        _prompts = prompts;
    }
    //Methods
    public void Run()
    {
        DisplayStartingMessage();
        GetRandomPrompt();
        Console.Write("\nGet ready to start typing: ");
        ShowCountDown(5);
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            Console.ReadLine();
            _count++;
        }
        Console.WriteLine($"Congratulations! You could write {_count} sentences!");
        DisplayEndingMessage();
    }

    public void GetRandomPrompt()
    {
        Random random = new();
        int index = random.Next(0,_prompts.Count - 1);
        Console.WriteLine(_prompts[index]);
    }
    public List<string> GetListFromUser()
    {
        List<string> list = new();


        return list;
    }
}