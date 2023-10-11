public class ChecklistGoal : Goal
{
    int _amountCompleted;
    int _target;
    int _bonus;
    public ChecklistGoal(string name,string description,int points, int target, int bonus) : base(name,description,points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }
    public override void RecordEvent()
    {
        
    }
    public override bool IsComplete()
    {
        bool isComplete = _amountCompleted == _target;
        return isComplete;
    }
    public override string GetStringRepresentation()
    {
        string stringRepresentation = "";
        return stringRepresentation;
    }
}