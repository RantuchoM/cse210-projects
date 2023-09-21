using System;
using System.Collections.Generic;

public class PromptGenerator{
    //creating list
    public List<string> _prompts = new()
    {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            // Additional prompts
            "What new thing did I learn today?",
            "What made me laugh today?",
            "What is a goal I want to accomplish in the near future?",
            "What is something I'm grateful for today?",
            "What small act of kindness did I perform or witness today?"
        };
        
    public string GetRandomPrompt(){

        // Create a Random instance
        Random random = new Random();
        // Generate a random index within the range of valid indices
        int randomIndex = random.Next(0, _prompts.Count);
        // Get the random prompt from the list
        string randomPrompt = _prompts[randomIndex];
        //Console.WriteLine(randomPrompt);
        
        return randomPrompt;
    }
}