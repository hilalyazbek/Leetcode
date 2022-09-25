# CodingChallenges
Leetcode and hackerrank coding challenges

[Study Plan](https://leetcode.com/study-plan/leetcode-75/)

[Algo Practice](https://leetcode.com/study-plan/algorithm/)

Each level has its own class file (Level1.cs, Level2.cs)
```
public static int[] RunningSum(int[] nums)
{
    int current = 0;
    int[] result = nums.ToArray();
    for (int i = 0; i < nums.Length; i++)
    {
        current = current + nums[i];
        result[i] = current;
    }

    return result;
}
```

Program.cs calls the static functions with the appropriate arguments.
```
Console.WriteLine("724.Find Pivot Index");
Console.WriteLine("********************");
Console.WriteLine(Level1.PivotIndex(new int[] { 1, 7, 3, 6, 5, 6 }));
```
The problem id and title can be found ontop of each function call.
