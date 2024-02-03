using System;
using BenchmarkDotNet.Running;

namespace CleanCodePerformanceComparison;

class Program
{
    static void Main(string[] args)
    {
        var benchmarkMode = true;
        if (benchmarkMode)
        {
            var summary = BenchmarkRunner.Run<AreaCalculator>();
        }
        else
        {
            CalculateAndPrintResults(1);
            CalculateAndPrintResults(1000);
            CalculateAndPrintResults(5000);
        }

        Console.WriteLine("Finish");
    }

    static void CalculateAndPrintResults(int numberOfRepetitions)
    {
        var areaCalculator = new AreaCalculator();
        areaCalculator.numberOfRepetitions = numberOfRepetitions;

        var totalAreaPoly = areaCalculator.CalculateAreaUsingPolymorphism();
        var totalAreaSimple = areaCalculator.CalculateAreaUsingSwitch();

        Console.WriteLine($"Repetitions = {numberOfRepetitions}, Total Poly Area = {totalAreaPoly}, Total Simple Area = {totalAreaSimple}");
    }
}
