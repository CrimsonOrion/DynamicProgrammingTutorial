using DynamicProgramming.Models;

using System.Diagnostics;

namespace DynamicProgramming.Processors;
public class BestSumProcessor
{
    private static int _steps1 = 0;
    private static int _steps2 = 0;

    public List<SumNumbers> SumNumbers { get; set; } = new();

    public void Calculate()
    {
        foreach (SumNumbers n in SumNumbers)
        {
            Console.WriteLine($"Target Sum: {n.TargetSum}");
            Stopwatch stopwatch2 = new();
            stopwatch2.Start();
            List<int>? bestSum2 = BestSum2(n, new());
            stopwatch2.Stop();
            var arrayString = bestSum2 is not null && bestSum2.Any() ? $"[{string.Join(',', bestSum2)}]" : "null";
            Console.WriteLine($"Memo Answer: {arrayString}; Steps: {_steps2}; Time: {stopwatch2.ElapsedMilliseconds}ms");
            Stopwatch stopwatch1 = new();
            stopwatch1.Start();
            var bestSum = BestSum(n);
            stopwatch1.Stop();
            arrayString = bestSum is not null && bestSum.Any() ? $"[{string.Join(',', bestSum)}]" : "null";
            Console.WriteLine($"Non Answer: {arrayString}; Steps: {_steps1}; Time: {stopwatch1.ElapsedMilliseconds}ms");
            _steps1 = _steps2 = 0;
        }
    }

    private List<int>? BestSum(SumNumbers n)
    {
        if (n.TargetSum == 0)
        {
            return new();
        }

        if (n.TargetSum < 0)
        {
            return null;
        }

        List<int>? shortestCombination = null;

        foreach (var num in n.Numbers)
        {
            var remainder = n.TargetSum - num;
            _steps1++;
            List<int>? remainderCombination = BestSum(new(remainder, n.Numbers));
            if (remainderCombination is not null)
            {
                // List variant of const combination = [ ...remainederCombination, num];
                List<int>? combination = new(remainderCombination) { num };
                // if combination is shorter than current "shortest", update it
                if (shortestCombination is null || combination.Count < shortestCombination.Count)
                {
                    shortestCombination = combination;
                }
            }
        }

        return shortestCombination;
    }

    private List<int>? BestSum2(SumNumbers n, Dictionary<long, List<int>?> memo)
    {
        memo ??= new();
        if (memo.ContainsKey(n.TargetSum))
        {
            return memo[n.TargetSum];
        }

        if (n.TargetSum == 0)
        {
            return new();
        }

        if (n.TargetSum < 0)
        {
            return null;
        }

        List<int>? shortestCombination = null;

        foreach (var num in n.Numbers)
        {
            var remainder = n.TargetSum - num;
            _steps2++;
            List<int>? remainderCombination = BestSum2(new(remainder, n.Numbers), memo);
            if (remainderCombination is not null)
            {
                // List variant of const combination = [ ...remainederCombination, num];
                List<int>? combination = new(remainderCombination) { num };
                // if combination is shorter than current "shortest", update it
                if (shortestCombination is null || combination.Count < shortestCombination.Count)
                {
                    shortestCombination = combination;
                }
            }
        }
        memo[n.TargetSum] = shortestCombination;
        return shortestCombination;
    }
}