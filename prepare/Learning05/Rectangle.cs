public class Rectangle : Shape
{
    private double _length;
    private double _width;
    public Rectangle(string color,int length,int width)
    {
        SetColor(color);
        _length = length;
        _width = width;
    }
    public override double GetArea()
    {
        return _length * _width;
    }
}