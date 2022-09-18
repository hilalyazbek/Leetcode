using System;
namespace CodingChallenges;

public static class Level1
{
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

    public static int PivotIndex(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return -1;
        }
        int len = nums.Length;
        int[] leftSum = new int[len];
        int[] rightSum = new int[len];

        leftSum[0] = nums[0];
        rightSum[len - 1] = nums[len - 1];

        for(int i=1; i < len; i++)
        {
            leftSum[i] = nums[i] + leftSum[i - 1];
            rightSum[len - 1 - i] = nums[len - 1 - i] + rightSum[len - i];
        }

        for(int i = 0; i < len; i++)
        {
            if (leftSum[i] == rightSum[i])
                return i;
        }        
        return -1;
    }
}

