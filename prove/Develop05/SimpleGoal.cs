using System.Security.Cryptography.X509Certificates;

public class SimpleGoal : Goal
{
    private bool _isComplete;
    public SimpleGoal(string name,string description,int points) : base(name,description,points)
    {
        _isComplete = false;
    }
    public void SetCompleted()
    {
        _isComplete = true;
    }
    public override int RecordEvent()
    {
        _isComplete = true;
        return GetPoints();
    }
    public override bool IsComplete()
    {
        bool isComplete = _isComplete;
        return isComplete;
    }
    public override string GetStringRepresentation()
    {
        int isComplete;
        if(IsComplete())
        {
            isComplete = 1;
        }
        else
        {
            isComplete = 0;
        }
        string stringRepresentation = $"Simple Goal|{GetInitialStringRepresentation()}|{isComplete}";
        return stringRepresentation;
    }
}