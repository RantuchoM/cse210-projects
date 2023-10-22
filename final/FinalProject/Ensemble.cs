public class Ensemble
{
    private int _ensembleId;
    private string _ensembleName;
    private string _description;
    private List<Person> _integrants;
    private string _location;

    public Ensemble(int ensembleId, string ensembleName, string description, List<Person> integrants, string location)
    {
        _ensembleId = ensembleId;
        _ensembleName = ensembleName;
        _description = description;
        _integrants = integrants;
        _location = location;
    }
    public int GetId()
    {
        return _ensembleId;
    }
    public List<Person> GetPeople()
    {
        return _integrants;
    }
    public string GetName()
    {
        return _ensembleName;
    }
    public string GetDescription()
    {
        return _description;
    }
    public string GetLocation()
    {
        return _location;
    }
}