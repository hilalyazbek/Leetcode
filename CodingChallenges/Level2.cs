using System;
using System.Linq;

namespace CodingChallenges;

public class Level2
{
    //202. Happy Number
    public static bool IsHappy(int n)
    {
        HashSet<int> tracker = new();
        return CheckHappiness(n,tracker);
    }
    private static bool CheckHappiness(int number, HashSet<int> tracker)
    {
        
        if(number == 1)
        {
            return true;
        }
        int result = 0;
        int index = 0;
        string numb = number.ToString();
        while(index < numb.Length)
        {
            int num = numb[index] - '0';

            num *= num;
               
            result += num;
            index++;
        }
        if (tracker.Contains(result))
        {
            return false;
        }
        tracker.Add(result);
        return CheckHappiness(result, tracker);
    }
}

