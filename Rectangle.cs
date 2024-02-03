namespace CleanCodePerformanceComparison;

public class Rectangle : ShapeBase
{
    public double Height { get; set; }
    public double Width { get; set; }

    public override double Area()
    {
        return Height * Width;
    }
}