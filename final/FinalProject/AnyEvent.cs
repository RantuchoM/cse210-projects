using System.Dynamic;

public abstract class AnyEvent
{
    protected DateTime _dateTime;
    protected string _location;
    protected string _conductor;

    public AnyEvent(DateTime dateTime, string location, string conductor)
    {
        _dateTime = dateTime;
        _location = location;
        _conductor = conductor;
    }
    public AnyEvent(DateTime dateTime, string location)
    {
        _dateTime = dateTime;
        _location = location;
        _conductor = "";
    }
    public DateTime GetDateTime()
    {
        return _dateTime;
    }
    public void SetTime(DateTime dateTime)
    {
        _dateTime = dateTime;
    }
    public void SetLocation (string location)
    {
        _location = location;
    }
    public void SetConductor (string conductor)
    {
        _conductor = conductor;
    }
    public abstract string GetEventDetails();

}