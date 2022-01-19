namespace DynamicProgramming.Models;
public class ConstructString
{
    public string TargetString { get; set; }
    public string[] WordBank { get; set; } = Array.Empty<string>();

    public ConstructString(string targetString, string[] strings)
    {
        TargetString = targetString;
        WordBank = strings;
    }
}