public class EnsembleRehearsal : Rehearsal
{
    private Ensemble _ensemble;
    public EnsembleRehearsal(DateTime date, string location, string conductor, string observations, Ensemble ensemble) : base(date,location,conductor,observations)
    {
        _ensemble = ensemble;
    }
    public EnsembleRehearsal(int id, DateTime date, string location, string conductor, string observations, Ensemble ensemble) : base(id,date,location,conductor,observations)
    {
        _ensemble = ensemble;
    }
    public Ensemble GetEnsemble()
    {
        return _ensemble;
    }
    public override string GetEventDetails()
    {
        
        return $"Ensemble Rehearsal: {_dateTime.ToString("dd MMM yyyy HH:mm")} at {_location}. Conductor: {_conductor}. Observations: {_observations}. Ensemble: {_ensemble}";
    }
    public override string GetRehearsalString()
    {
        
        return $"{base.GetRehearsalString()}♪Ensemble♪{_ensemble.GetId()}";
    }
}