using AoC2021.Core.Day25;

namespace AoC2021.Tests;

public class Day25Tests
{
    private static SeaCucumber Sim(params string[] lines) => new(lines);
    private static void AssertGrid(SeaCucumber sim, params string[] expected)
        => Assert.Equal(expected, sim.ToLines());

    //komkommers naar rechts
    [Fact]
    public void CheckIfCucumberGoesRight()
    {
        var sim = Sim(">.");
        var moved = sim.Step();
        Assert.True(moved);
        AssertGrid(sim, ".>");
    }

    //komkommers naar beneden
    [Fact]
    public void CheckIfCucumberGoesDown() 
    {
        var sim = Sim("v", ".");       // height 2, one column
        var moved = sim.Step();
        Assert.True(moved);
        AssertGrid(sim, ".", "v");
    }

    //rechts komkommer stopt wanner beneden komkommer er is
    [Fact]
    public void CheckIfRightCucumberStopsWhenDownCucumberIsThere() 
    {
        var sim = Sim(".>v.");
        var moved = sim.Step();
        Assert.False(moved);
        AssertGrid(sim, ".>v.");
    }

    //beneden komkommer stopt wanneer rechts komkommer er is
    [Fact]
    public void CheckIfDownCucumberStopsWhenRightCucumberIsThere()
    {
        var sim = Sim(">", "v");
        var moved = sim.Step();
        Assert.False(moved);
        AssertGrid(sim, ">", "v");
    }

    //RechtsKomkommer verschijnt links wanneer eind van de rij is bereikt
    [Fact]
    public void CheckIfRightCucumberSwitchesToLeft()
    {
        var sim = Sim("..>");
        var moved = sim.Step();
        Assert.True(moved);
        AssertGrid(sim, ">..");
    }

    //Benedenkomkommer verschijnt boven wanneer eind van de kolom is bereikt
    [Fact]
    public void CheckIfDownCucumberSwitchesToTop()
    {
        var sim = Sim(".", "v");       // height 2, 'v' at bottom wraps to top
        var moved = sim.Step();
        Assert.True(moved);
        AssertGrid(sim, "v", ".");
    }

    //Benedenkomkommer kan plaats innemen van rechtskomkommer (want die beurt is al geweest)
    [Fact]
    public void SouthMovesIntoCellVacatedByEast()
    {
        // Step 1: '>' from (0,0) -> (0,1); then 'v' from (1,0) -> (0,0) (wrap)
        var sim = Sim(">.", "v.");
        var moved = sim.Step();
        Assert.True(moved);
        AssertGrid(sim, "v>", "..");
    }

    [Fact]
    public void StableGridReturnsNoMoveAndStopsAtStep1()
    {
        var sim = Sim(">", "v");
        var moved = sim.Step();
        Assert.False(moved);
        //tweede optie, RunUntilStable aanroepen en kijken of stap 1 is
        Assert.Equal(1, sim.RunUntilStable());
    }

    //sample van AoC website, kijken of die stopt bij stap 58
    [Fact]
    public void SampleStabilizesAt58()
    {
        var sample = new[]
        {
            "v...>>.vv>",
            ".vv>>.vv..",
            ">>.>v>...v",
            ">>v>>.>.v.",
            "v>v.vv.v..",
            ">.>>..v...",
            ".vv..>.>v.",
            "v.v..>>v.v",
            "....v..v.>"
        };
        var sim = Sim(sample);
        Assert.Equal(58, sim.RunUntilStable());
    }
}
