public class Instrument
{
    private int _instrumentId;
    private string _instrumentName;
    private string _family;
    

    public Instrument(int instrumentId,string instrumentName,string family)
    {
        _instrumentId = instrumentId;
        _instrumentName = instrumentName;
        _family = family;
    }
    public int GetInstrumentId()
    {
        return _instrumentId;
    }
    public string GetInstrumentName()
    {
        return _instrumentName;
    }
    public string GetFamily()
    {
        return _family;
    }
}