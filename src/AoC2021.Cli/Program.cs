using System;
using System.IO;
using AoC2021.Core.Day1;
using AoC2021.Core.Day25;

if (args.Length < 2)
{
    Console.WriteLine("Gebruik voor dagen:");
    Console.WriteLine("  dotnet run -- day1 <Day1.txt>");
    Console.WriteLine("  dotnet run -- day25 <Day25.txt>");
    return;
}

var day = args[0].ToLowerInvariant();
var path = args[1];
if (!File.Exists(path))
{
    Console.Error.WriteLine($"Filepath is fout: {path}");
    Environment.Exit(1);
}

switch (day)
{
    case "day25":
        {
            var lines = File.ReadAllLines(path);
            var sim = new SeaCucumber(lines);
            var steps = sim.RunUntilStable();
            Console.WriteLine($"Aantal stappen waarna alle komkommers stabiel zijn: {steps}");
            break;
        }
    default:
        Console.Error.WriteLine($"Deze dag is nog niet opgelost: {day}");
        Environment.Exit(2);
        break;
}