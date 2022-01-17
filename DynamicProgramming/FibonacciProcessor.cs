using System.Diagnostics;

namespace DynamicProgramming;
public class FibonacciProcessor
{
    private static readonly Dictionary<int, long> _memo = new();
    private static int _steps1 = 0;
    private static int _steps2 = 0;

    public List<int> Numbers { get; set; } = new();

    public void Calculate()
    {
        foreach (var n in Numbers)
        {
            Stopwatch stopwatch2 = new();
            stopwatch2.Start();
            var fib2 = Fib2(n);
            stopwatch2.Stop();
            Console.WriteLine($"Memo Answer: {fib2}; Steps: {_steps2}; Time: {stopwatch2.ElapsedMilliseconds}ms");
            Stopwatch stopwatch1 = new();
            stopwatch1.Start();
            var fib = Fib(n);
            stopwatch1.Stop();
            Console.WriteLine($"Non Answer: {fib}; Steps: {_steps1}; Time: {stopwatch1.ElapsedMilliseconds}ms");
            _steps1 = _steps2 = 0;
        }
    }

    private static long Fib(int n)
    {
        _steps1 += 1;
        if (n <= 2)
        {
            return 1;
        }

        return Fib(n - 1) + Fib(n - 2);
    }

    private static long Fib2(int n)
    {
        _steps2++;
        if (n <= 2)
        {
            return 1;
        }

        if (!_memo.ContainsKey(n))
        {
            _memo[n] = Fib2(n - 1) + Fib2(n - 2);
        }

        return _memo[n];
    }
}