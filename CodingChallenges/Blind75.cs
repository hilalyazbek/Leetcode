using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges;

internal class Blind75
{

    //53. Maximum Subarray
    public int MaxSubArray(int[] nums)
    {
        //nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4]
        int[] dynamic = new int[nums.Length];
        int sum = nums[0];
        dynamic[0] = sum;
        for(int i=1;i< nums.Length; i++)
        {
            sum =  Math.Max(nums[i], dynamic[i - 1] + nums[i]);
            dynamic[i] = sum;
        }

        return dynamic.Max();

    }
}
