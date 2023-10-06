public class ReflectingActivity : Activity
{    
    private List<string> _prompts;
    private List<string> _questions;
    //Constructor
    public ReflectingActivity(string name, string description, int duration, List<string> prompts, List<string> questions) : base(name,description,duration)
    {
        _prompts = prompts;
        _questions = questions;
    }
    public ReflectingActivity(int duration, List<string> prompts, List<string> questions) : base("Reflecting Activity","This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",duration)
    {
        _prompts = prompts;
        _questions = questions;
    }
    public ReflectingActivity(List<string> prompts, List<string> questions) : base("Reflecting Activity","This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _prompts = prompts;
        _questions = questions;
    }
    //Methods
    public void Run()
    {
        DisplayStartingMessage();
        Console.WriteLine("Consider the following prompt: ");
        DisplayPrompt();
        Console.WriteLine("When you have something in mind, press enter to continue");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        DisplayQuestions();
        DisplayEndingMessage();
    }

    public string GetRandomPrompt()
    {
        Random random = new();
        int index = random.Next(0,_prompts.Count - 1);
        string prompt = _prompts[index];
        _prompts.RemoveAt(index);

        return prompt;
    }
    public string GetRandomQuestion()
    {
        Random random = new();
        string question = _questions[random.Next(0,_questions.Count -1)];

        return question;
    }
    public void DisplayPrompt()
    {

        Console.WriteLine($"\n ---  {GetRandomPrompt()} ---\n");
    }
    public void DisplayQuestions()
    {
        int questionDuration = 10;
        double amount = Math.Ceiling((double)GetDuration()/(double)questionDuration);
        Console.Clear();
        for(int i=0;i<amount;i++)
        {
            Console.WriteLine(GetRandomQuestion());
            ShowSpinner(questionDuration);
            Console.Clear();
        }
    }
}