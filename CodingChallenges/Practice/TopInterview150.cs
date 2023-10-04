
using System.Diagnostics;
using System.Globalization;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualBasic;

public static class TopInterview150
{
  internal static void Merge(int[] nums1, int m, int[] nums2, int n)
  {
    //copy
    int copyIndex = 0;
    for (int i = m; i < nums1.Length; i++)
    {
      nums1[i] = nums2[copyIndex];
      copyIndex++;
    }

    // sort
    for (int i = 0; i < nums1.Length - 1; i++)
    {
      for (int j = 0; j < nums1.Length - i - 1; j++)
      {
        if (nums1[j] > nums1[j + 1])
        {
          // swap temp and arr[i] 
          int temp = nums1[j];
          nums1[j] = nums1[j + 1];
          nums1[j + 1] = temp;
        }
      }
    }
  }

  internal static int RemoveElement(int[] nums, int val)
  {
    int index = 0;
    int result = 0;
    for (int i = 0; i < nums.Length; i++)
    {
      if (nums[i] != val)
      {
        nums[index] = nums[i];
        result++;
        index++;
      }
    }
    return result;
  }

  internal static int RemoveDuplicates(int[] nums)
  {
    int result = 1;
    int index = 1;
    for (int i = 0; i < nums.Length - 1; i++)
    {
      if (nums[i] != nums[i + 1])
      {
        result++;
        nums[index] = nums[i + 1];
        index++;
      }
    }

    return result;
  }

  internal static int RemoveDuplicatesII(int[] nums)
  {

    if (nums.Length <= 2)
      return nums.Length;

    int k = 2; // Maximum allowed duplicates
    int count = 1; // Count of the current element
    int index = 1; // Index to update in the input array

    for (int i = 1; i < nums.Length; i++)
    {
      if (nums[i] == nums[i - 1])
      {
        count++;
      }
      else
      {
        count = 1;
      }

      if (count <= k)
      {
        nums[index] = nums[i];
        index++;
      }
    }

    return index;

  }

  internal static int MajorityElement(int[] nums)
  {
    int max = 0;
    int result = 0;
    var tracker = new Dictionary<int, int>();
    foreach (int item in nums)
    {
      if (!tracker.ContainsKey(item))
      {
        tracker.Add(item, 0);
      }
      tracker[item]++;

      if (tracker[item] > max)
      {
        max = tracker[item];
        result = item;
      }
    }

    return result;


  }

  internal static void RotateArray(int[] nums, int k)
  {
    var lastIndex = nums.Length - 1;
    var _ = new int[nums.Length];

    for (int i = 0; i < nums.Length; i++)
    {
      var newIdx = (i + k) % nums.Length; // Corrected calculation of new index
      _[newIdx] = nums[i];
    }

    Array.Copy(_, nums, nums.Length);

  }

  internal static int MaxProfit(int[] prices)
  {
    int minValue = int.MaxValue;
    int maxProfit = 0;
    for (int i = 0; i < prices.Length; i++)
    {
      if (prices[i] < minValue)
      {
        minValue = prices[i];
      }
      else
      {
        maxProfit = Math.Max(prices[i] - minValue, maxProfit);
      }
    }
    return maxProfit;
  }
}