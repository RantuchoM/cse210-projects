using System.Runtime.CompilerServices;

public abstract class Rehearsal: AnyEvent
{
    private string _observations;
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
        
}
