using System;
public class Entry
{
    public string _date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
    public string _promptText = new PromptGenerator().GetRandomPrompt();
    public string _entryText;

        public void Display(){
            Console.WriteLine($"{_date} - {_promptText} \n {_entryText}");
        }
}
