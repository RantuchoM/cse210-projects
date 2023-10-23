public class GeneralRehearsal : Rehearsal
{
    private List<Ensemble> _ensembles;
    public GeneralRehearsal(DateTime date, string location, string conductor, string observations, List<Ensemble> ensembles) : base(date,location,conductor,observations)
    {
        _ensembles = ensembles;
    }
    public GeneralRehearsal(int id, DateTime date, string location, string conductor, string observations, List<Ensemble> ensembles) : base(id,date,location,conductor,observations)
    {
        _ensembles = ensembles;
        }
    public List<Ensemble> GetEnsemble()
    {
        return _ensembles;
    }
    public override string GetEventDetails()
    {
        string ensembles = string.Join(", ",_ensembles.Select(x => x.GetName()));
        return $"General Rehearsal: {_dateTime.ToString("dd MMM yyyy HH:mm")} at {_location}. Conductor: {_conductor}. Observations: {_observations}. Ensembles: {ensembles}";
    }
    public override string GetRehearsalString()
    {

        string ensembles = string.Join("♫",_ensembles.Select(x => x.GetId()));
        return $"{base.GetRehearsalString()}♪General♪{ensembles}";
    }
}