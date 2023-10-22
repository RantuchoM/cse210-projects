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
        string details = "";
        return details;
    }
}