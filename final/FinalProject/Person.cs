public class Person
{  
    private int _id;
    private string _firstName;
    private string _lastName;
    private DateTime _initialDate;
    private DateTime _endDate;
    private Instrument _instrument; 

    public Person(int id,string first,string last,Instrument instrument)
    {
        _id = id;
        _firstName = first;
        _lastName = last;
        _initialDate =  DateTime.Now;
        _instrument = instrument;
    }
    public Person(int id, string first,string last,Instrument instrument, DateTime date)
    {
        _id = id;
        _firstName = first;
        _lastName = last;
        _initialDate =  date;
        _instrument = instrument;
    }
    public Person(int id, string first,string last,Instrument instrument, DateTime startDate, DateTime endDate)
    {
        _id = id;
        _firstName = first;
        _lastName = last;
        _initialDate =  startDate;
        _endDate = endDate;
        _instrument = instrument;
    }
    public string GetFullName()
    {
        return $"{_lastName}, {_firstName} - {_instrument.GetInstrumentName()} ({_instrument.GetFamily()})";
    }
    public int GetId()
    {
        return _id;
    }
}