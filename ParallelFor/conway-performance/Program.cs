using System;
using System.Diagnostics;
using System.Threading.Tasks;
using conway_library;

namespace conway_performance
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var grid = new LifeGrid(75, 25);

            int iterations = 10000;

            Console.Clear();
            Console.WriteLine($"Number of iterations: {iterations}");

            grid.Randomize();
            var stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
                await grid.UpdateState();
            Console.WriteLine($"Nested for: {stopWatch.ElapsedMilliseconds}ms");

            grid.Randomize();
            stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
                await grid.ParallelTaskUpdateState();
            Console.WriteLine($"Parallel Tasks: {stopWatch.ElapsedMilliseconds}ms");

            grid.Randomize();
            stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
                await grid.ParallelForUpdateState();
            Console.WriteLine($"Parallel.For: {stopWatch.ElapsedMilliseconds}ms");

            grid.Randomize();
            stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
                await grid.OveryParallelTaskUpdateState();
            Console.WriteLine($"Overly Parallel Tasks: {stopWatch.ElapsedMilliseconds}ms");

            grid.Randomize();
            stopWatch = Stopwatch.StartNew();
            for (int i = 0; i < iterations; i++)
                await grid.OverlyParallelForUpdateState();
            Console.WriteLine($"Overly Parallel.For: {stopWatch.ElapsedMilliseconds}ms");

            Console.WriteLine("Complete");
        }
    }
}
