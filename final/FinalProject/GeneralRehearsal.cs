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
        string details = "";
        return details;
    }
}