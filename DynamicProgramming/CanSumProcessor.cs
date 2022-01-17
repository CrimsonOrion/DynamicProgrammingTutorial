using System.Diagnostics;

namespace DynamicProgramming;
public class CanSumProcessor
{
    private static Dictionary<long, bool> _memo = new();
    private static int _steps1 = 0;
    private static int _steps2 = 0;

    public List<SumNumbers> SumNumbers { get; set; } = new();

    public void Calculate()
    {
        foreach (SumNumbers? n in SumNumbers)
        {
            _memo = new();
            Stopwatch stopwatch2 = new();
            stopwatch2.Start();
            var canSum2 = CanSum2(n);
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
        _steps1++;
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
            if (CanSum(new(remainder, n.Numbers)))
            {
                return true;
            }
        }
        return false;
    }

    private static bool CanSum2(SumNumbers n)
    {
        _steps2++;
        if (_memo.ContainsKey(n.TargetSum))
        {
            return _memo[n.TargetSum];
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
            if (CanSum2(new(remainder, n.Numbers)))
            {
                _memo[n.TargetSum] = true;
                return true;
            }
        }
        _memo[n.TargetSum] = false;
        return false;
    }
}

public class SumNumbers
{
    public int TargetSum { get; set; }
    public int[] Numbers { get; set; } = Array.Empty<int>();

    public SumNumbers(int targetSum, int[] numbers)
    {
        TargetSum = targetSum;
        Numbers = numbers;
    }
}