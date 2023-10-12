using System.Collections;
using System.IO;
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Diagnostics;

public class GoalManager
{
    List<Goal> _goals;
    int _score;
    string _user; //here I store the active username
    
    public GoalManager()
    {
        _goals = new();
        _score = 0;
    }

    public void Start()
    {
        Console.Clear();
        List<String> users = GetUsersTxt(); //finds current users
        if(users.Count() == 0)
        {
            Console.WriteLine("Welcome. Since there are not saved users, please provide your name to create you a new file in where you can save your progress.");
            _user = $"{Console.ReadLine()}.txt";
            File.AppendAllText("users.txt", Environment.NewLine + _user);

        }
        else
        {
            LoadUser();
        }
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }
    public List<Goal> PendingGoals()
    {
        return _goals.Where(n => !n.IsComplete()).ToList();
    }
    public void ListGoalNames()
    {
        List<Goal> _pendingGoals = PendingGoals();
        for(int i = 0;i<_pendingGoals.Count();i++)
        {
            Console.WriteLine($"{i+1}. {_pendingGoals[i].GetName()}");
        }
    }
    public void ListGoalDetails()
    {
        Console.WriteLine("These are the goals:");
        for(int i = 0;i<_goals.Count();i++)
        {
            Console.WriteLine($"   {i+1}. {_goals[i].GetDetailsString()}");
        }
        
    }
    public void CreateGoal()
    {
        string goalType = "";
        while(true)
        {
            Console.WriteLine("The types of Goals are:");
            Console.WriteLine("  1. Simple Goal");
            Console.WriteLine("  2. Eternal Goal");
            Console.WriteLine("  3. Checklist Goal");
            Console.Write("Which type of goal would you like to create? ");
            string goalChoice = Console.ReadLine();
            
            switch(goalChoice) //finds which goal was chosen
            {
                case "1":
                    goalType = "Simple Goal";
                    break;
                case "2":
                    goalType = "Eternal Goal";
                    break;
                case "3":
                    goalType = "Checklist Goal";
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
            }
            break;
        }
        //Finds the first three values, common to each goal
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch(goalType) //creates the type of goal chosen
        {
            case "Simple Goal":
                SimpleGoal simpleGoal = new(name,description,points);
                _goals.Add(simpleGoal);
                break;
            case "Eternal Goal":
                EternalGoal eternalGoal = new(name,description,points);
                _goals.Add(eternalGoal);
                break;
            case "Checklist Goal": //asks for the additional details of this kind of goal
                Console.Write("How many times does this goal need to be accomplished? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write($"What is the bonus for accomplishing it those {target} times? ");
                int bonus = int.Parse(Console.ReadLine());
                ChecklistGoal checklistGoal = new(name,description,points,target,bonus);
                _goals.Add(checklistGoal);
                break;
        }
            
    }

    public void RecordEvent()
    {
        List<Goal> _pendingGoals = PendingGoals(); //finds the goals that weren't already completed
        ListGoalNames();
        
        Console.Write("What goal would you like to record? ");
        int index = int.Parse(Console.ReadLine()) -1;
        int scored = _pendingGoals[index].RecordEvent();
        _score += scored;
        Console.Write($"\nYour goal has been recorded! You won {scored} points! Congratulations!!");
    }
    public void SaveGoals()
    {
        
        string filename = _user;
        using (StreamWriter outputFile = new StreamWriter(filename))
        {
            outputFile.WriteLine(_score);
            
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
        Console.Write($"{_user.Substring(0, _user.Length - 4)}, your progress has been saved successfully!!");
    }
    public void LoadUser()
    {
        List<String> users = GetUsersTxt();
        Console.WriteLine("Welcome to the ETERNAL QUEST!\nPlease choose your username, or select to create a new one");
        Console.WriteLine("0. CREATE A NEW USER");
        for(int u=0;u<users.Count();u++)
        {
            Console.WriteLine($"{u+1}. {users[u].Substring(0, users[u].Length - 4)}");
        }
        string option = Console.ReadLine();
        if(option == "0")
        {
            Console.WriteLine("Welcome. Please provide your name to create your file where you can save your progress.");
            while (true) //loops until you provide a different username
            {
                
                string username = $"{Console.ReadLine()}.txt";

                if (users.Contains(username))
                {
                    Console.WriteLine("The username already exists. Please provide a different one.");
                }
                else
                {
                    // Username doesn't exist, you can create a new file
                    File.AppendAllText("users.txt", Environment.NewLine + username);
                    break; // Exit the loop if a valid username is chosen
                }
            }
        }
        else
        {
            _user = users[int.Parse(option)-1]; 
            ProcessFile(_user);//loads the file with its own method
        }
    }
    public void ProcessFile(string filename)
    {
        _goals.RemoveAll(goal => true); //cleans the goals list
        string[] lines = System.IO.File.ReadAllLines(filename); //processes the file
        int totalPoints = int.Parse(lines[0]);
        _score = totalPoints;

        for (int line = 1;line<lines.Count();line++)
        {
            string[] parts = lines[line].Split("|");
            string goalType = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            switch(goalType)
        {
            case "Simple Goal":
                string isComplete = parts[4];
                
                SimpleGoal simpleGoal = new(name,description,points);
                if(isComplete == "1")
                {
                    simpleGoal.SetCompleted();
                }
                _goals.Add(simpleGoal);
                break;
            case "Eternal Goal":
                EternalGoal eternalGoal = new(name,description,points);
                _goals.Add(eternalGoal);
                break;
            case "Checklist Goal":
                int target = int.Parse(parts[4]);
                int bonus = int.Parse(parts[5]);
                int amountCompleted = int.Parse(parts[6]);
                ChecklistGoal checklistGoal = new(name,description,points,target,bonus);
                checklistGoal.SetAmountCompleted(amountCompleted);
                _goals.Add(checklistGoal);
                break;
        }
        }
        Console.Write($"{_user.Substring(0, _user.Length - 4)}, your progress has been loaded successfully!!");
    
    }
    public List<string> GetUsersTxt()
    {   //Finds all the current users

        string filename = "users.txt";
        List<string> users = new();
        string[] lines = System.IO.File.ReadAllLines(filename);
        
            foreach (string user in lines)
            {
                users.Add(user);
            }
        
        return users;
    }

}