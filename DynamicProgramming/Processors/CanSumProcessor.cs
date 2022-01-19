using DynamicProgramming.Models;

using System.Diagnostics;

namespace DynamicProgramming.Processors;
public class CanSumProcessor
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
            var canSum2 = CanSum2(n, new());
            stopwatch2.Stop();
            Console.WriteLine($"Memo Answer: {canSum2}; Steps: {_steps2}; Time: {stopwatch2.ElapsedMilliseconds}ms");
            Stopwatch stopwatch1 = new();
            stopwatch1.Start();
            var canSum = CanSum(n);
            stopwatch1.Stop();
            Console.WriteLine($"Non Answer: {canSum}; Steps: {_steps1}; Time: {stopwatch1.ElapsedMilliseconds}ms");
            _steps1 = _steps2 = 0;
        }
    }

    private static bool CanSum(SumNumbers n)
    {
        if (n.TargetSum == 0)
        {
            return true;
        }

        if (n.TargetSum < 0)
        {
            return false;
        }

        foreach (var num in n.Numbers)
        {
            var remainder = n.TargetSum - num;
            _steps1++;
            if (CanSum(new(remainder, n.Numbers)))
            {
                return true;
            }
        }
        return false;
    }

    private static bool CanSum2(SumNumbers n, Dictionary<long, bool> memo)
    {
        if (memo.ContainsKey(n.TargetSum))
        {
            return memo[n.TargetSum];
        }

        if (n.TargetSum == 0)
        {
            return true;
        }

        if (n.TargetSum < 0)
        {
            return false;
        }

        foreach (var num in n.Numbers)
        {
            var remainder = n.TargetSum - num;
            _steps2++;
            if (CanSum2(new(remainder, n.Numbers), memo))
            {
                memo[n.TargetSum] = true;
                return true;
            }
        }
        memo[n.TargetSum] = false;
        return false;
    }
}