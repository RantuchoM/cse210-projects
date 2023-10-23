public abstract class Concert: AnyEvent
{
    private int _id;
    private string _description;
    protected List<Rehearsal> _rehearsals;
    public Concert(DateTime date, string location, string conductor, string description) : base(date,location,conductor)
    {
        Random random = new();
        _id = random.Next(100000000);
        _description = description;
        _rehearsals = new();
    }
    public Concert(int id, DateTime date, string location, string conductor, string description) : base(date,location,conductor)
    {
        
        _id = id;
        _description = description;
        _rehearsals = new();
    }
    public int GetId()
    {
        return _id;
    }
    public List<Rehearsal> GetRehearsals()
    {
        return _rehearsals;
    }
    public virtual string GetString()
    {
        string rehearsals = "";
        if(_rehearsals.Count()>0)
        {
            rehearsals = string.Join("♫",_rehearsals.Select(r => r.GetId()));
        }

        return $"{_id}♪{_dateTime}♪{_location}♪{_conductor}♪{_description}♪{rehearsals}";
    }
    public void AddRehearsal(Rehearsal rehearsal)
    {
        _rehearsals.Add(rehearsal);
    }
    public void RemoveRehearsal(Rehearsal rehearsal)
    {
        _rehearsals.Remove(rehearsal);
    }
    
}