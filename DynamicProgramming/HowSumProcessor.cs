using System.Diagnostics;

namespace DynamicProgramming;
public class HowSumProcessor
{
    private static Dictionary<long, List<int>?> _memo = new();
    private static int _steps1 = 0;
    private static int _steps2 = 0;

    public List<SumNumbers> SumNumbers { get; set; } = new();

    public void Calculate()
    {
        foreach (SumNumbers n in SumNumbers)
        {
            _memo = new();
            Stopwatch stopwatch2 = new();
            stopwatch2.Start();
            var howSum2 = HowSum2(n);
            stopwatch2.Stop();
            var arrayString = howSum2 is not null && howSum2.Any() ? $"[{string.Join(',', howSum2)}]" : "null";
            Console.WriteLine($"Memo Answer: {arrayString}; Steps: {_steps2}; Time: {stopwatch2.ElapsedMilliseconds}ms");
            Stopwatch stopwatch1 = new();
            stopwatch1.Start();
            var howSum = HowSum(n);
            stopwatch1.Stop();
            arrayString = howSum is not null && howSum.Any() ? $"[{string.Join(',', howSum)}]" : "null";
            Console.WriteLine($"Non Answer: {arrayString}; Steps: {_steps1}; Time: {stopwatch1.ElapsedMilliseconds}ms");
            _steps1 = _steps2 = 0;
        }
    }

    private static List<int>? HowSum(SumNumbers n)
    {
        _steps1++;
        if (n.TargetSum == 0)
        {
            return new();
        }

        if (n.TargetSum < 0)
        {
            return null;
        }

        foreach (var num in n.Numbers)
        {
            var remainder = n.TargetSum - num;
            var remainderResult = HowSum(new(remainder, n.Numbers));
            if (remainderResult is not null)
            {
                remainderResult.Add(num);
                return remainderResult;
            }
        }

        return null;
    }

    private static List<int>? HowSum2(SumNumbers n)
    {
        _steps2++;
        if (_memo.ContainsKey(n.TargetSum))
        {
            return _memo[n.TargetSum];
        }

        if (n.TargetSum == 0)
        {
            return new();
        }

        if (n.TargetSum < 0)
        {
            return null;
        }

        foreach (var num in n.Numbers)
        {
            var remainder = n.TargetSum - num;
            var remainderResult = HowSum2(new(remainder, n.Numbers));
            if (remainderResult is not null)
            {
                remainderResult.Add(num);
                _memo[n.TargetSum] = remainderResult;
                return remainderResult;
            }
        }

        _memo[n.TargetSum] = null;
        return null;
    }
}