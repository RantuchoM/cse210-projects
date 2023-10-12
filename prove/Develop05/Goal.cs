using System.ComponentModel;

public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;

    public Goal(string name,string description,int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public string GetName()
    {
        return _shortName;
    }
    public string GetDescription()
    {
        return _description;
    }
    public virtual string GetDetailsString()
    {
        string completed;
        if(IsComplete())
        {
            completed = "X";
        }
        else
        {
            completed = " ";
        }
        string detailsString = $"[{completed}] {_shortName} ({_description})";
        return detailsString;
    }
    public abstract string GetStringRepresentation(); 
    public string GetInitialStringRepresentation() //this method was created because the middle part of the string was common to all of the variables
    //Instead of having "Getters" for each variable, I just get this "initial string representation"
    {
        return $"{_shortName}|{_description}|{_points}"; 
    }
    public int GetPoints()
    {
        return _points;
    }
}