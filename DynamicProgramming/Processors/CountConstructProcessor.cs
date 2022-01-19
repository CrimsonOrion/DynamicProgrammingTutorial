using DynamicProgramming.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Processors;
public class CountConstructProcessor
{
    private static int _steps = 0;
    private static int _stepsMemo = 0;

    public List<ConstructString> ConstructStrings { get; set; } = new();

    public void Calculate()
    {
        foreach (ConstructString s in ConstructStrings)
        {
            Console.WriteLine($"Target String: {s.TargetString}");
            Stopwatch stopwatchMemo = new();
            stopwatchMemo.Start();
            var countConstructMemo = CountConstructMemo(s, new());
            Console.WriteLine($"Memo Answer: {countConstructMemo}; Steps: {_stepsMemo}; Time: {stopwatchMemo.ElapsedMilliseconds}ms");
            stopwatchMemo.Stop();
            Stopwatch stopwatch = new();
            stopwatch.Start();
            var countConstruct = CountConstruct(s);
            Console.WriteLine($"Non Answer: {countConstruct}; Steps: {_steps}; Time: {stopwatch.ElapsedMilliseconds}ms");
            stopwatch.Stop();
            _steps = _stepsMemo = 0;
        }
    }

    private static int CountConstruct(ConstructString s)
    {
        if (s.TargetString == string.Empty)
        {
            return 1;
        }
        _steps++;

        var totalCount = 0;

        foreach (var word in s.WordBank)
        {
            if (s.TargetString.IndexOf(word) == 0)
            {
                var suffix = s.TargetString[word.Length..];
                totalCount += CountConstruct(new(suffix, s.WordBank));
            }
        }

        return totalCount;
    }

    private static int CountConstructMemo(ConstructString s, Dictionary<string, int> memo)
    {
        memo ??= new();
        if (memo.ContainsKey(s.TargetString))
        {
            return memo[s.TargetString];
        }

        if (s.TargetString == string.Empty)
        {
            return 1;
        }
        _stepsMemo++;

        var totalCount = 0;

        foreach (var word in s.WordBank)
        {

            if (s.TargetString.IndexOf(word) == 0)
            {
                var suffix = s.TargetString[word.Length..];
                totalCount += CountConstructMemo(new(suffix, s.WordBank), memo);
            }
        }

        memo[s.TargetString] = totalCount;
        return totalCount;
    }
}