namespace AoC2021.Core.Day1;

public class SonarSweep
{    
    //zorg voor een "cleane" input
    public static int[] Parse(string input) =>
        input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
             .Select(s => int.Parse(s.Trim()))
             .ToArray();

    //Als de volgende in lijst hoger is: ++
    public static int CountIncreases(IReadOnlyList<int> a)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        int count = 0;
        for (int i = 1; i < a.Count; i++)
            if (a[i] > a[i - 1]) count++;
        return count;
    }

    //neem totalen van drie hoogtes en vergelijk deze met de hoogtes van opvolgende drie
    //dus index 0,1,2 vergelijken met 1,2,3. Index 1,2,3 vergelijken met 2,3,4. Etc...
    public static int CountPlusThreeIncreases(IReadOnlyList<int> a)
    {
        if (a is null) throw new ArgumentNullException(nameof(a));
        int count = 0;
        for (int i = 0; i + 3 < a.Count; i++)
            if (a[i + 3] > a[i]) count++;
        return count;
    }
}
