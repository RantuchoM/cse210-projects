public class Square : Shape
{
    private double _side;
    public Square(string color,int side)
    {
        SetColor(color);
        _side = side;
    }
    public override double GetArea()
    {
        return _side * _side;
    }
}