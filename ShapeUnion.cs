namespace CleanCodePerformanceComparison;

public class ShapeUnion
{
    public ShapeUnion(ShapeType type_, double width_, double height_)
    {
        type = type_;
        Width = width_;
        Height = height_;
    }

    public ShapeType type { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
}