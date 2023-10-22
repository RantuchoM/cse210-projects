public class EnsembleConcert : Concert
{
    private Ensemble _ensemble;
    public EnsembleConcert(DateTime date, string location, string conductor, string description, Ensemble ensemble) : base(date,location,conductor,description)
    {
        _ensemble = ensemble;
    }
    public EnsembleConcert(int id,DateTime date, string location, string conductor, string description, Ensemble ensemble) : base(id,date,location,conductor,description)
    {
        _ensemble = ensemble;
    }
    public override string GetEventDetails()
    {
        
        return $"Ensemble Concert: {_dateTime}: {_location}. Conductor: {_conductor}. Ensemble: {_ensemble}";
    }
    public void SetEnsemble(Ensemble ensemble)
    {
        _ensemble = ensemble;
    }
    public override string GetString()
    {
        return $"{base.GetString()}♪Ensemble♪{_ensemble.GetId()}";
    }
}