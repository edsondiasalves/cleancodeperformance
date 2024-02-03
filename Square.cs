namespace CleanCodePerformanceComparison;

public class Square : ShapeBase
{
    public double Side { get; set; }

    public override double Area()
    {
        return Side * Side;
    }
}
