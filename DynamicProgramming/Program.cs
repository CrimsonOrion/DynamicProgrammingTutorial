// memoization
namespace DynamicProgramming;
public class Program
{
    private static void Main(string[] args)
    {
        ShowFibonacciResults();
        //ShowGridTraveler();
        //ShowCanSum();
        //ShowHowSum();
        //howBestSum();

        Console.WriteLine("Done.");
        Console.ReadKey();
    }

    private static void ShowFibonacciResults()
    {
        List<int> numbers = new() { 6, 7, 8, 50 };
        FibonacciProcessor fib = new()
        {
            Numbers = numbers
        };

        fib.Calculate();
    }

    private static void ShowGridTraveler()
    {
        List<Grid> grids = new()
        {
            new(1, 1),
            new(2, 3),
            new(3, 2),
            new(3, 3),
            new(18, 18)
        };
        GridTravelerProcessor traveler = new()
        {
            Grids = grids
        };

        traveler.Calculate();
    }

    private static void ShowCanSum()
    {
        List<SumNumbers> numbers = new()
        {
            new(7, new int[] { 2, 3 }),
            new(7, new int[] { 5, 3, 4, 7 }),
            new(7, new int[] { 2, 4 }),
            new(8, new int[] { 2, 3, 5 }),
            new(300, new int[] { 7, 14 })
        };
        CanSumProcessor canSum = new()
        {
            SumNumbers = numbers
        };

        canSum.Calculate();
    }

    private static void ShowHowSum()
    {
        List<SumNumbers> numbers = new()
        {
            new(7, new int[] { 2, 3 }),
            new(7, new int[] { 5, 3, 4, 7 }),
            new(7, new int[] { 2, 4 }),
            new(8, new int[] { 2, 3, 5 }),
            new(300, new int[] { 7, 14 })
        };
        HowSumProcessor howSum = new()
        {
            SumNumbers = numbers
        };

        howSum.Calculate();
    }

    static void ShowBestSum()
    {
        List<SumNumbers> numbers = new()
        {
            new(7, new int[] { 5, 3, 4, 7 }),
            new(8, new int[] { 2, 3, 5 }),
            new(8, new int[] { 1, 4, 5 }),
            new(100, new int[] { 1, 2, 5, 25 })
        };
        BestSumProcessor bestSum = new()
        {
            SumNumbers = numbers
        };

        bestSum.Calculate();
    }
}