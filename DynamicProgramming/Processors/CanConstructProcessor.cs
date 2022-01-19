using DynamicProgramming.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming.Processors;
public class CanConstructProcessor
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
            var canConstructMemo = CanConstructMemo(s, new());
            Console.WriteLine($"Memo Answer: {canConstructMemo}; Steps: {_stepsMemo}; Time: {stopwatchMemo.ElapsedMilliseconds}ms");
            stopwatchMemo.Stop();
            Stopwatch stopwatch = new();
            stopwatch.Start();
            var canConstruct = CanConstruct(s);
            Console.WriteLine($"Non Answer: {canConstruct}; Steps: {_steps}; Time: {stopwatch.ElapsedMilliseconds}ms");
            stopwatch.Stop();
            _steps = _stepsMemo = 0;
        }
    }

    private static bool CanConstruct(ConstructString s)
    {
        if (s.TargetString == string.Empty)
        {
            return true;
        }
        _steps++;
        foreach (var word in s.WordBank)
        {
            
            if (s.TargetString.IndexOf(word) == 0)
            {
                var suffix = s.TargetString[word.Length..];
                if (CanConstruct(new(suffix, s.WordBank)))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool CanConstructMemo(ConstructString s, Dictionary<string, bool> memo)
    {   
        memo ??= new();
        if (memo.ContainsKey(s.TargetString))
        {
            return memo[s.TargetString];
        }
        
        if (s.TargetString == string.Empty)
        {
            return true;
        }
        _stepsMemo++;
        foreach (var word in s.WordBank)
        {
            
            if (s.TargetString.IndexOf(word) == 0)
            {
                var suffix = s.TargetString[word.Length..];
                if (CanConstructMemo(new(suffix, s.WordBank), memo))
                {
                    memo[s.TargetString] = true;
                    return true;
                }
            }
        }

        memo[s.TargetString] = false;
        return false;
    }
}