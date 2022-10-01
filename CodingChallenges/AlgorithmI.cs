using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenges;

internal class AlgorithmI
{
    public static int BinarySearch(int[] nums, int target)
    {
        //[-1,0,3,5,9,12], target = 9
        int left = 0;
        int right = nums.Length - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            if (nums[mid] < target)
                left = mid + 1;
            if (nums[mid] > target)
                mid = right - 1;
        }
        return -1;

        /*     var result = -1;
        // [-1,0,3,5,9,12], target = 9

        var low = 0;
        var high = nums.Length - 1;
        var mid = 0;

        while (high - low > 1)
        {
            mid = (high + low) / 2;
            if (nums[mid] < target)
            {
                low = mid + 1;
            }
            else
                high = mid;
        }

        if (nums[low] == target)
        {
            result = low;
        }
        else if (nums[high] == target)
        {
            result = high;
        }

        return result;
        */

    }

    public int FirstBadVersion(int n)
    {
        int low = 0;
        int high = n;

        while (low < high)
        {
            int mid = low + (high - low) / 2;
            if (Level1.IsBadVersion(mid))
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }

    //35. Search Insert Position
    public int SearchInsert(int[] nums, int target)
    {
        if (nums == null || nums.Length == 0)
            return -1;

        int i = 0,
            j = nums.Length - 1;

        while (i <= j)
        {
            int m = j + (i - j) / 2;

            if (nums[m] == target)
                return m;
            else if (nums[m] < target)
                i = m + 1;
            else
                j = m - 1;
        }

        return i;
    }

    //509. Fibonacci Number
    public int Fib(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        return Fib(n - 1) + Fib(n - 2);
    }


    public int ClimbStairs(int n)
    {
        if (n == 1) return 1;
        if (n == 2) return 2;
        int oneStep = 1;
        int twoStep = 2;

        for (int i = 3; i <= n; i++)
        {
            int temp = twoStep;
            twoStep = oneStep + twoStep;
            oneStep = temp;
        }
        return twoStep;
    }

    //977. Squares of a Sorted Array
    public static int[] SortedSquares(int[] nums)
    {
        //[-4,-1,0,3,10]
        int left = 0;
        int index = nums.Length - 1;
        int right = index;
        int[] result = new int[nums.Length];

        while (left <= right)
        {

            var leftSquared = nums[left] * nums[left];
            var rightSquared = nums[right] * nums[right];
            if (leftSquared < rightSquared)
            {
                result[index] = rightSquared;
                right--;
            }
            else
            {
                result[index] = leftSquared;
                left++;
            }
            index--;
        }
        return result;
    }

    //189. Rotate Array
    public void Rotate(int[] nums, int k)
    {
        // Solution 1 -- Time: O(n), Space: O(n)
        int[] output = new int[nums.Length];
        int length = nums.Length;
        for (int i = 0; i < nums.Length; i++)
        {
            output[(i + k) % length] = nums[i];
        }
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = output[i];
        }
    }

    public static void Rotate2(int[] nums, int k)
    {
        // Solution 1 -- Time: O(n), Space: O(n)
        int[] output = new int[nums.Length];
        int length = nums.Length;
        for (int i = 0; i < nums.Length; i++)
        {
            output[(i + k) % length] = nums[i];
        }
        for (int i = 0; i < nums.Length; i++)
        {
            nums[i] = output[i];
        }
    }

    //Intersection of Two Arrays II
    public static int[] Intersect(int[] nums1, int[] nums2)
    {
        return new int[0];
    }

    //2418. Sort the People
    public static string[] SortPeople(string[] names, int[] heights)
    {
        Dictionary<int, string> tracker = new();
        for (int i = 0; i < names.Length; i++)
        {
            tracker.Add(heights[i], names[i]);
        }
        tracker = tracker.OrderByDescending(itm => itm.Key).ToDictionary(itm => itm.Key, value => value.Value);
        List<string> result = new();

        foreach(KeyValuePair<int, string> kvp in tracker)
        {
            result.Add(kvp.Value);
        }
        return result.ToArray();
    }

    //283. Move Zeroes
    public static void MoveZeroes(int[] nums)
    {
        int i = 0; int j = 0;
        for (i = 0; i < nums.Length; i++)
        {
            if (nums[i] != 0)
            {
                nums[j] = nums[i];
                j++;
            }
        }

        for (int k = j; k < nums.Length; k++)
        {
            nums[k] = 0;
        }
    }

    private static void Swap(int left, int right, int[] nums)
    {
        var temp = nums[right];
        nums[right] = nums[left];
        nums[left] = temp;
    }

    //167. Two Sum II - Input Array Is Sorted
    public static int[] TwoSum(int[] numbers, int target)
    {
        //[2,7,11,15], target = 9
        var tracker = new Dictionary<int, int>();

        int rem = 0;
        for(int i = 0; i < numbers.Length; i++)
        {
            rem = target - numbers[i];
            if (!tracker.ContainsKey(rem))
            {
                tracker.TryAdd(numbers[i], i + 1);
                continue;
            }
            else
            {
                return new int[] { tracker[rem], i + 1 };
            }
        }
        return new int[0];
    }


    //344. Reverse String
    public static string ReverseString(char[] s)
    {
        int left = 0;
        int right = s.Length - 1;
        while (left <= right)
        {
            SwapString(s, left, right);
            left++;
            right--;
        }
        return new string(s);
    }

    private static void SwapString(char[] s, int left, int right)
    {
        char temp = s[right];
        s[right] = s[left];
        s[left] = temp;
    }

    //557. Reverse Words in a String III
    public static string ReverseWords(string s)
    {
        StringBuilder sb = new();
        string[] split = s.Split(' ');
        foreach(string word in split)
        {
            sb.Append(ReverseString(word.ToCharArray()) + " ");
        }
        return sb.ToString().TrimEnd() ;
    }
}
