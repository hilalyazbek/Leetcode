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
        IList<int> result = new List<int>();

        if (matrix == null || matrix.Length == 0)
            return result;

        int maxRow = matrix.Length;
        int maxCol = matrix[0].Length;
        int i = 0, row = 0, col = 0;

        while (row < maxRow && col < maxCol)
        {
            // #Move Left to Right and #Remove row from Top
            for (i = col; i < maxCol; i++)
                result.Add(matrix[row][i]);
            row++;

            // #Move Top to Down and #Remove col from Right
            for (i = row; i < maxRow; i++)
                result.Add(matrix[i][maxCol - 1]);
            maxCol--;

            // #Move Right to Left and #Remove row from Bottom
            if (row < maxRow)
            {
                for (i = maxCol - 1; i >= col; i--)
                    result.Add(matrix[maxRow - 1][i]);
                maxRow--;
            }

            // #Move Down to Top and #Remove col from Left
            if (col < maxCol)
            {
                for (i = maxRow - 1; i >= row; i--)
                    result.Add(matrix[i][col]);
                col++;
            }
        }

        return result;
    }
}

