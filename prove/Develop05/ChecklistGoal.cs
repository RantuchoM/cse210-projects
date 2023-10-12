public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    public ChecklistGoal(string name,string description,int points, int target, int bonus) : base(name,description,points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }
    public void SetAmountCompleted(int amount)
    {
        _amountCompleted = amount;
    }
    public override int RecordEvent()
    {
        _amountCompleted ++;
        if(IsComplete())
        {
            Console.Write($"YEAH! You won a bonus of {_bonus} for completing your checklist goal!!\n");
            return GetPoints()+_bonus;
            
        }
        else
        {
            return GetPoints();
        }
    }
    
    public override string GetDetailsString()
    {
        string completed;
        if(_target  > _amountCompleted)
        {
            completed = " ";
        }
        else
        {
            completed = "X";
        }
        string detailsString = $"[{completed}] {GetName()} ({GetDescription()}) -- Currently Completed: {_amountCompleted}/{_target}";
        return detailsString;
    }
    public override bool IsComplete()
    {
        bool isComplete =  _target <= _amountCompleted;
        return isComplete;
    }
    public override string GetStringRepresentation()
    {
        string stringRepresentation = $"Checklist Goal|{GetInitialStringRepresentation()}|{_target}|{_bonus}|{_amountCompleted}";
        return stringRepresentation;
    }
}   