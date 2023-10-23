
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Globalization;
using System.Security.AccessControl;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using CodingChallenges;
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

	internal static int MaxProfitII(int[] prices)
	{

		int maxProfit = 0;
		for (int i = 0; i < prices.Length - 1; i++)
		{
			if (prices[i] < prices[i + 1])
			{
				maxProfit += prices[i + 1] - prices[i];
			}

		}
		return maxProfit;
	}

	internal static bool CanJump(int[] nums)
	{
		int reachable = 0;
		for (int i = 0; i < nums.Length; i++)
		{
			if (i > reachable)
				return false;

			reachable = Math.Max(reachable, i + nums[i]);
		}
		return true;
	}

	public static int Jump(int[] nums)
	{
		//2,3,1,1,4
		int ans = 0, currEnd = 0, currFar = 0;

		for (int i = 0; i < nums.Length - 1; i++)
		{
			currFar = Math.Max(currFar, i + nums[i]);

			if (i == currEnd)
			{
				ans++;
				currEnd = currFar;
			}
		}

		return ans;
	}

	public static int HIndex(int[] citations)
	{
		Array.Sort(citations);
		Array.Reverse(citations);

		int h = 0;

		int position = 1;
		foreach (int citation in citations)
		{
			if (citation >= position)
			{
				h++;
			}
			position++;
		}
		return h;
	}

	public static int[] ProductExceptSelf(int[] nums)
	{
		int[] product = new int[nums.Length];
		int left = 1;
		for (int i = 0; i < nums.Length; i++)
		{
			product[i] = left;
			left *= nums[i];
		}

		int right = 1;
		for (int i = nums.Length - 1; i >= 0; i--)
		{
			product[i] *= right;
			right *= nums[i];
		}

		return product;
	}

	internal static int CanCompleteCircuit(int[] gas, int[] cost)
	{
		if (gas.Sum() < cost.Sum()) { return -1; }

		var start = 0;
		var fuel = 0;
		for (int i = 0; i < gas.Length; i++)
		{
			fuel += (gas[i] - cost[i]);
			if (fuel < 0)
			{
				fuel = 0;
				start = i + 1;
			}
		}

		return start;
	}

	internal static int[] SearchRange(int[] nums, int target)
	{
		var first = -1;
		var last = -1;

		//O(N)
		// for (int i = 0; i < nums.Length; i++)
		// {
		// 	if (nums[i] == target && first == -1)
		// 		first = i;

		// 	if (nums[i] == target)
		// 		last = i;
		// }

		// O(Log N)
		first = findFirst(nums, target);  // Find the first occurrence of the target.
		last = findLast(nums, target);    // Find the last occurrence of the target.
		return new int[] { first, last };        // Return the result as an array.
	}

	// Helper function to find the first occurrence of the target.
	private static int findFirst(int[] nums, int target)
	{
		int left = 0;              // Initialize the left pointer to the beginning of the array.
		int right = nums.Length - 1; // Initialize the right pointer to the end of the array.
		int first = -1;            // Initialize the variable to store the first occurrence.

		while (left <= right)
		{
			int mid = left + (right - left) / 2;  // Calculate the middle index.

			if (nums[mid] == target)
			{
				first = mid;           // Update first occurrence.
				right = mid - 1;       // Move the right pointer to the left to search in the left half.
			}
			else if (nums[mid] < target)
			{
				left = mid + 1;        // If mid element is less than target, move the left pointer to the right.
			}
			else
			{
				right = mid - 1;       // If mid element is greater than target, move the right pointer to the left.
			}
		}

		return first;  // Return the index of the first occurrence.
	}

	// Helper function to find the last occurrence of the target.
	private static int findLast(int[] nums, int target)
	{
		int left = 0;              // Initialize the left pointer to the beginning of the array.
		int right = nums.Length - 1; // Initialize the right pointer to the end of the array.
		int last = -1;             // Initialize the variable to store the last occurrence.

		while (left <= right)
		{
			int mid = left + (right - left) / 2;  // Calculate the middle index.

			if (nums[mid] == target)
			{
				last = mid;            // Update last occurrence.
				left = mid + 1;        // Move the left pointer to the right to search in the right half.
			}
			else if (nums[mid] < target)
			{
				left = mid + 1;        // If mid element is less than target, move the left pointer to the right.
			}
			else
			{
				right = mid - 1;       // If mid element is greater than target, move the right pointer to the left.
			}
		}

		return last;  // Return the index of the last occurrence.
	}

	internal static int RomanToInt(string s)
	{
		var tracker = new Dictionary<char, int>{
			{'I',1},
			{'V',5},
			{'X',10},
			{'L',50},
			{'C',100},
			{'D',500},
			{'M',1000},
		};

		var ans = 0;
		for (int i = 0; i < s.Length; i++)
		{
			if (i != s.Length - 1 && tracker[s[i]] < tracker[s[i + 1]])
				ans -= tracker[s[i]];
			else
			{
				ans += tracker[s[i]];
			}
		}
		return ans;
	}

	public static int MinOperations(int[] nums)
	{
		Array.Sort(nums);
		List<int> list = nums.ToHashSet().ToList();

		int max = 0;

		for (int i = 0; i < list.Count; i++)
		{
			int target = list[i] + nums.Length - 1;
			int index = list.BinarySearch(target);

			if (index < 0)
				index = (~index) - 1;

			max = Math.Max(max, index - i + 1);
		}

		return nums.Length - max;

	}

	public static int LengthOfLastWord(string s)
	{
		return s.TrimEnd().Split(' ').Last().Length;
	}

	public static string LongestCommonPrefix(string[] strs)
	{
		Array.Sort(strs);
		String s1 = strs[0];
		String s2 = strs[strs.Length - 1];
		int idx = 0;
		while (idx < s1.Length && idx < s2.Length)
		{
			if (s1[idx] == s2[idx])
			{
				idx++;
			}
			else
			{
				break;
			}
		}
		return s1.Substring(0, idx);

	}

	public static string ReverseWords(string s)
	{
		var sb = new StringBuilder();
		s = s.Trim();
		var splitString = s.Split(' ').ToList();
		for (int i = splitString.Count - 1; i >= 0; i--)
		{
			if (splitString[i] != string.Empty)
			{
				sb.Append(splitString[i]);
				sb.Append(' ');
			}

		}
		return sb.ToString().Trim();
	}

	public class RandomizedSet
	{

		List<int> tracker;

		public RandomizedSet()
		{
			tracker = new List<int>();
		}

		public bool Insert(int val)
		{
			if (!tracker.Contains(val))
			{
				tracker.Add(val);
				return true;
			}
			return false;
		}

		public bool Remove(int val)
		{
			if (tracker.Contains(val))
			{
				tracker.Remove(val);
				return true;
			}
			return false;
		}

		public int GetRandom()
		{
			int randIndex = new Random().Next(0, tracker.Count);
			return tracker[randIndex];
		}
	}
}