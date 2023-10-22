public class SymphonicConcert : Concert
{
    private string _title;
    public SymphonicConcert(DateTime date, string location, string conductor, string description, string title) : base(date,location,conductor,description)
    {
        _title = title;
    }
    public SymphonicConcert(int id,DateTime date, string location, string conductor, string description, string title) : base(id,date,location,conductor,description)
    {
        _title = title;
    }
    public override string GetEventDetails()
    {
        return $"Symphonic Concert: {_dateTime}: {_location}. Conductor: {_conductor}.";
    }
    public override string GetString()
    {
        
        return $"{base.GetString()}♪Symphonic♪{_title}";

    }
}