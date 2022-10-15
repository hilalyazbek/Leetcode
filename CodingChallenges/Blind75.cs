using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges;

internal class Blind75
{

    //53. Maximum Subarray
    public int MaxSubArrayDP(int[] nums)
    {
        //nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4]
        int[] dynamic = new int[nums.Length];
        int sum = nums[0];
        dynamic[0] = sum;
        for (int i = 1; i < nums.Length; i++)
        {
            sum = Math.Max(nums[i], dynamic[i - 1] + nums[i]);
            dynamic[i] = sum;
        }

        return dynamic.Max();

    }
    //53. Maximum Subarray
    public int MaxSubArray(int[] nums)
    {
        //nums = [-2, 1, -3, 4, -1, 2, 1, -5, 4]

        int sum = 0;
        int maxSum = nums[0];
        for (int i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            if (nums[i] > sum)
            {
                sum = nums[i];
            }
            if (sum > maxSum)
            {
                maxSum = sum;
            }
        }
        return maxSum;
    }

    //152. Maximum Product Subarray
    public int MaxProduct(int[] nums)
    {
        int[] product = new int[nums.Length];
        int prod = nums[0];
        product[0] = prod;

        for (int i = 1; i < nums.Length; i++)
        {
            product[i] = product[i - 1] * nums[i];
        }

        return product.Max();
    }

    //153. Find Minimum in Rotated Sorted Array
    public int FindMin(int[] nums)
    {
        int min = nums[0];
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] < min)
            {
                min = Math.Min(nums[i], min);
            }
        }
        return min;
    }

    //33. Search in Rotated Sorted Array
    public int Search(int[] nums, int target)
    {
        //TODO: Revisit Search Rotated Sorted Array
        // must be written in O(log n) time
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = right - left / 2;
            if (target == nums[mid])
            {
                return mid;
            }
            if (nums[left] <= nums[mid])
            {
                if (target < nums[mid] && target >= nums[left])
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            if (nums[mid] <= nums[right])
            {
                if (target > nums[mid] && target <= nums[right])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
        }
        return -1;
    }
}
