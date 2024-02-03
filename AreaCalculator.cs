using BenchmarkDotNet.Attributes;

namespace CleanCodePerformanceComparison;

public class AreaCalculator
{
    [Params(1, 1000, 5000)]
    public int numberOfRepetitions { get; set; }

    [Benchmark(Baseline = true)]
    public double CalculateAreaUsingPolymorphism()
    {
        var totalAreaAccumulator = 0.0;

        for (int i = 0; i < numberOfRepetitions; i++)
        {
            totalAreaAccumulator += new Square { Side = 5 }.Area();
            totalAreaAccumulator += new Rectangle { Width = 6, Height = 4 }.Area();
            totalAreaAccumulator += new Triangle { Base = 3, Height = 8 }.Area();
            totalAreaAccumulator += new Circle { Radius = 2.5 }.Area();
        }

        return totalAreaAccumulator;
    }

    [Benchmark]
    public double CalculateAreaUsingSwitch()
    {
        var totalAreaAccumulator = 0.0;
        for (int i = 0; i < numberOfRepetitions; i++)
        {
            totalAreaAccumulator += CalculateArea(new ShapeUnion(ShapeType.Square, 5, 0));
            totalAreaAccumulator += CalculateArea(new ShapeUnion(ShapeType.Rectangle, 6, 4));
            totalAreaAccumulator += CalculateArea(new ShapeUnion(ShapeType.Triangle, 3, 8));
            totalAreaAccumulator += CalculateArea(new ShapeUnion(ShapeType.Circle, 2.5, 0));
        }

        return totalAreaAccumulator;
    }

    private double CalculateArea(ShapeUnion shape)
    {
        switch (shape.type)
        {
            case ShapeType.Square: return shape.Width * shape.Width;
            case ShapeType.Rectangle: return shape.Width * shape.Height;
            case ShapeType.Triangle: return 0.5 * shape.Width * shape.Height;
            case ShapeType.Circle: return Math.PI * shape.Width * shape.Width;
            default: return 0;
        }
    }
}