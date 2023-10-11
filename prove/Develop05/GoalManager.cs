public class GoalManager
{
    List<Goal> _goals;
    int _score;
    
    public GoalManager()
    {
        _goals = new();
        _score = 0;
    }

    public void Start()
    {

    }
    public void DisplayPlayerInfo()
    {

    }
    public void ListGoalNames()
    {
        for(int i = 0;i<_goals.Count();i++)
        {
            Console.WriteLine($"{i+1}. {_goals[i].GetName()}");
        }
    }
    public void ListGoalDetails()
    {
        for(int i = 0;i<_goals.Count();i++)
        {
            Console.WriteLine($"{i+1}. {_goals[i].GetDetailsString()}");
        }
    }
    public void CreateGoal()
    {
        
    }
    public void RecordEvent()
    {

    }
    public void SaveGoals()
    {

    }
    public void LoadGoals()
    {

    }

}