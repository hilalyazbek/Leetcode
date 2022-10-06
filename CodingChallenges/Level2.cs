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

    //54. Spiral Matrix
    public static IList<int> SpiralOrder(int[][] matrix)
    {
        List<int> res = new();

        int left = 0;
        int right = matrix[0].Length;

        int top = 0;
        int bottom = matrix.Length;

        while(left < right && top < bottom)
        {
            // go right
            for(int i = left; i < right; i++)
            {
                res.Add(matrix[top][i]);
            }
            top++;

            // go down

        }

        return res;
    }
}

