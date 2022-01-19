namespace DynamicProgramming.Models;

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