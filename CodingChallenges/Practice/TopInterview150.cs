
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
    var tracker = new Dictionary<int, int>();
    int index = 0;
    for (int i = 0; i < nums.Length - 1; i++)
    {
      if (!tracker.ContainsKey(nums[i]))
      {
        tracker.Add(nums[i], 0);
      }
      tracker[nums[i]]++;

      if (nums[i] == nums[i + 1])
      {
        if (tracker[nums[i]] >= 2)
        {
          index = i;
        }
        else
        {
          continue;
        }
      }
      else
      {
        nums[index] = nums[i];
        index++;
      }

    }
    return index;
  }
}