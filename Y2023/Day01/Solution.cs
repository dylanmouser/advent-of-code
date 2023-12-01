using System.Text.RegularExpressions;

namespace AdventOfCode.Y2023.Day01;

internal class Solution : AdventOfCode.Solution
{
    public override int Year => 2023;

    public override int Day => 1;

    public override string Name => "Trebuchet?!";

    protected override int SolvePart1(string input)
    {
        var inputLines = input.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        var total = 0;

        foreach (var line in inputLines)
        {
            var lineDigits = line.Where(c => char.IsDigit(c)).ToList();
            var firstDigit = lineDigits.FirstOrDefault().ToString();
            var lastDigit = lineDigits.LastOrDefault().ToString();
            var combinedDigits = firstDigit + lastDigit;

            total += Int32.Parse(combinedDigits);
        }

        return total;
    }

    protected override int SolvePart2(string input)
    {
        var inputLines = input.Split('\n');
        var regex = @"\d|one|two|three|four|five|six|seven|eight|nine";

        var numbers = inputLines.Select(line => {
            var firstDigit = Regex.Match(line, regex).Value;
            var lastDigit = Regex.Match(line, regex, RegexOptions.RightToLeft).Value;

            return Int32.Parse($"{ToDigit(firstDigit)}{ToDigit(lastDigit)}");
        }).ToList();

        return numbers.Sum();
    }

    static string ToDigit(string number)
    {
        // Dictionary to map English-written numbers to digits
        return number.ToLower() switch
        {
            "one" => "1",
            "two" => "2",
            "three" => "3",
            "four" => "4",
            "five" => "5",
            "six" => "6",
            "seven" => "7",
            "eight" => "8",
            "nine" => "9",
            _ => number
        };
    }
}
