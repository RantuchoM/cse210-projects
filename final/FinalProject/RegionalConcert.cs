public class RegionalConcert : Concert
{
    List<Ensemble> _ensembles;
    public RegionalConcert(DateTime date, string location, string conductor, string description) : base(date,location,conductor,description)
    {
        _ensembles = new();
    }
    public RegionalConcert(int id, DateTime date, string location, string conductor, string description) : base(id,date,location,conductor,description)
    {
        _ensembles = new();
    }
    
    public override string GetEventDetails()
    {
        string ensembles = string.Join(", ", _ensembles.Select(x => x.GetName()));
        return $"Regional Concert: {_dateTime.ToString("dd MMM yyyy HH:mm")} at {_location}. Conductor: {_conductor}. Ensembles: {ensembles}";
    }
    public void AddEnsemble(Ensemble ensemble)
    {
        _ensembles.Add(ensemble);
    }
    public override string GetString()
    {
        string ensembles = string.Join("♫", _ensembles.Select(x => x.GetId()));
        return $"{base.GetString()}♪Regional♪{ensembles}";

    }
}