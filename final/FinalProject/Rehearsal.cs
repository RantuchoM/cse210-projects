using System.Runtime.CompilerServices;

public abstract class Rehearsal: AnyEvent
{
    protected string _observations;
    private int _id;
    
    public Rehearsal(DateTime date, string location, string conductor, string observations) : base(date,location,conductor)
    {
        _observations = observations;
        Random random = new();
        _id = random.Next(100000000);
    }
    public Rehearsal(int id,DateTime date, string location, string conductor, string observations) : base(date,location,conductor)
    {
        _observations = observations;
        _id = id;
    }
    public virtual string GetRehearsalString()
    {
        string repr = $"{_dateTime}♪{_location}♪{_conductor}♪{_observations}♪{_id}";
        return repr;
    }
    public int GetId()
    {
        return _id;
    }

        
}
