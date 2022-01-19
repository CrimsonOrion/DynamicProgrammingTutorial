
using System.Diagnostics;

namespace DynamicProgramming.Processors;
public class GridTravelerProcessor
{
    private static int _steps1 = 0;
    private static int _steps2 = 0;

    public List<Grid> Grids { get; set; } = new();

    public void Calculate()
    {
        foreach (Grid n in Grids)
        {
            Console.WriteLine($"Target Grid: {n.X}, {n.Y}");
            Stopwatch stopwatch2 = new();
            stopwatch2.Start();
            var gridTraveler2 = Travel2(n, new());
            stopwatch2.Stop();
            Console.WriteLine($"Memo Answer: {gridTraveler2}; Steps: {_steps2}; Time: {stopwatch2.ElapsedMilliseconds}ms");
            Stopwatch stopwatch1 = new();
            stopwatch1.Start();
            var gridTraveler = Travel(n);
            stopwatch1.Stop();
            Console.WriteLine($"Non Answer: {gridTraveler}; Steps: {_steps1}; Time: {stopwatch1.ElapsedMilliseconds}ms");
            _steps1 = _steps2 = 0;
        }
    }

    private static long Travel(Grid grid)
    {
        _steps1++;
        if (grid.X == 1 && grid.Y == 1)
        {
            return 1;
        }

        if (grid.X == 0 || grid.Y == 0)
        {
            return 0;
        }

        return Travel(new(grid.X - 1, grid.Y)) + Travel(new(grid.X, grid.Y - 1));
    }

    private static long Travel2(Grid grid, Dictionary<string, long> memo)
    {
        var key = $"{grid.X},{grid.Y}";
        if (grid.X == 1 && grid.Y == 1)
        {
            return 1;
        }

        if (grid.X == 0 || grid.Y == 0)
        {
            return 0;
        }

        if (!memo.ContainsKey(key))
        {
            _steps2++;
            memo[key] = Travel2(new(grid.X - 1, grid.Y), memo) + Travel2(new(grid.X, grid.Y - 1), memo);
        }

        return memo[key];
    }
}


public class Grid
{
    public int X { get; set; }
    public int Y { get; set; }
    public Grid(int x, int y)
    {
        X = x;
        Y = y;
    }
}