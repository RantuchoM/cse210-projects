public class Fraction
{
    private int _top;
    private int _bottom;
    
//constructors
    public Fraction()
    {
        _top = 1;
        _bottom = 1;

    }

    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
        
    }

    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }
//getters and setters
    public int GetTop()
    {
        return _top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetTop(int top)
    {
        _top = top;
    }
    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

//representations
    public string GetFractionString()
    {
        string str = $"{_top}/{_bottom}";
        return  str;
    }
    public double GetDecimalValue()
    {
        double fr = (double)_top / (double)_bottom; //I had to parse the values as doubles, because as integers, the result would also return as integer
        return fr;
    }

}