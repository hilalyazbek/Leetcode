
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
}