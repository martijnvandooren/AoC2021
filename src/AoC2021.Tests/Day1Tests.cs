using AoC2021.Core.Day1;

namespace AoC2021.Tests;

public class Day1Tests
{
    // tweede nummer is hoger dan eerste nummer
    [Fact]
    public void CheckIfNextNumberIsHigher()
    {
        var a = new[] { 100, 101 };
        Assert.Equal(1, SonarSweep.CountIncreases(a));
    }

    // tweede nummer is lager dan eerste nummer
    [Fact]
    public void CheckIfNextNumberIsLower()
    {
        var a = new[] { 101, 100 };
        Assert.Equal(0, SonarSweep.CountIncreases(a));
    }

    // som van drie vergelijken met volgende som van drie (toename)
    [Fact]
    public void CheckIfSumOfThreeNumbersIsHigher()
    {
        var a = new[] { 1, 2, 3, 4 };
        Assert.Equal(1, SonarSweep.CountPlusThreeIncreases(a));
    }

    // som van drie gelijk of lager => geen toename
    [Fact]
    public void PlusThreeNoIncreaseWhenEqualOrLower()
    {
        Assert.Equal(0, SonarSweep.CountPlusThreeIncreases(new[] { 1, 1, 1, 1 }));
        Assert.Equal(0, SonarSweep.CountPlusThreeIncreases(new[] { 4, 3, 2, 1 }));
    }

    // Nul, null en leeg
    [Fact]
    public void CheckIfNullBreaks()
    {
        Assert.Throws<ArgumentNullException>(() => SonarSweep.CountIncreases(null!));
        Assert.Throws<ArgumentNullException>(() => SonarSweep.CountPlusThreeIncreases(null!));
    }

    //kleine inputs worden niet in aanmerking genomen
    [Fact]
    public void EmptyAndSmallInputsYieldZero()
    {
        Assert.Equal(0, SonarSweep.CountIncreases(Array.Empty<int>()));
        Assert.Equal(0, SonarSweep.CountIncreases(new[] { 42 }));

        Assert.Equal(0, SonarSweep.CountPlusThreeIncreases(Array.Empty<int>()));
        Assert.Equal(0, SonarSweep.CountPlusThreeIncreases(new[] { 1 }));
        Assert.Equal(0, SonarSweep.CountPlusThreeIncreases(new[] { 1, 2 }));
        Assert.Equal(0, SonarSweep.CountPlusThreeIncreases(new[] { 1, 2, 3 }));
    }

    //Sample van AoC gepakt (check, check, dubbelcheck)
    [Fact]
    public void SampleInputMatchesExpected()
    {
        const string sample = @"
199
200
208
210
200
207
240
269
260
263
";
        var nums = SonarSweep.Parse(sample);
        Assert.Equal(7, SonarSweep.CountIncreases(nums));
        Assert.Equal(5, SonarSweep.CountPlusThreeIncreases(nums));
    }

    // Negatieve nummers?
    [Fact]
    public void NegativeNumbersAreHandled()
    {
        var nums = new[] { -5, -3, -4, -1, -1, 0 };
        Assert.Equal(3, SonarSweep.CountIncreases(nums));
        Assert.Equal(3, SonarSweep.CountPlusThreeIncreases(nums));
    }
}
