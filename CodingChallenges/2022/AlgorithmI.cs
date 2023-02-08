using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CodingChallenges.Level1;

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

        foreach (KeyValuePair<int, string> kvp in tracker)
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
        for (int i = 0; i < numbers.Length; i++)
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
        foreach (string word in split)
        {
            sb.Append(ReverseString(word.ToCharArray()) + " ");
        }
        return sb.ToString().TrimEnd();
    }

    //876. Middle of the Linked List
    public ListNode MiddleNode(ListNode head)
    {
        // 1 - 2 - 3 - 4 - 5
        // 3 - 4 - 5
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }

    //19. Remove Nth Node From End of List
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        //1-2-3-4-5, 2
        //1-2-3-5
        ListNode dummy = new ListNode(0, head);
        ListNode left = dummy;
        ListNode right = head;
        while (n > 0 && right != null)
        {
            right = right.next;
            n--;
        }
        while (right != null)
        {
            left = left.next;
            right = right.next;
        }
        left.next = left.next.next;

        return dummy.next;
    }

    //3. Longest Substring Without Repeating Characters
    public static int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0) return 0;
        if (s.Length == 1) return 1;
        int result = 0;
        //"abcabcbb"
        var tracker = new HashSet<char>();
        int left = 0;
        int right = 0;

        while (right < s.Length)
        {
            if (!tracker.Contains(s[right]))
            {
                tracker.Add(s[right]);
                right++;
                result = Math.Max(result, right - left);
            }
            else
            {

                tracker.Remove(s[left]);
                left++;
            }
        }
        return result;
    }

    //567. Permutation in String
    public static bool CheckInclusion(string s1, string s2)
    {
        int[] s1Tracker = new int[26];


        foreach (char c in s1)
        {
            s1Tracker[c - 'a']++;
        }

        int left = 0;

        while (left + s1.Length - 1 < s2.Length) {
            bool result = CompareArrays(s1Tracker, s2.Substring(left, s1.Length));
            if (result)
            {
                return result;
            }
            left++;
        }
        return false;
    }

    private static bool CompareArrays(int[] s1Tracker, string v)
    {
        int[] s2Tracker = new int[26];

        foreach (char c in v)
        {
            s2Tracker[c - 'a']++;
        }

        if (Enumerable.SequenceEqual(s1Tracker, s2Tracker))
        {
            return true;
        }
        return false;
    }

    //733. Flood Fill
    public static int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        var oldColor = image[sr][sc];
        if (oldColor != color)
        {
            image = DFS(image, sr, sc, oldColor, color);
        }
        return image;
    }

    private static int[][] DFS(int[][] image, int sr, int sc, int oldColor, int color)
    {
        if (sr < 0 || sr >= image.Length || sc < 0 || sc >= image[sr].Length || image[sr][sc] != oldColor)
        {
            return null;
        }
        image[sr][sc] = color;
        DFS(image, sr + 1, sc, oldColor, color);
        DFS(image, sr - 1, sc, oldColor, color);
        DFS(image, sr, sc + 1, oldColor, color);
        DFS(image, sr, sc - 1, oldColor, color);
        return image;
    }


    //695. Max Area of Island
    public static int MaxAreaOfIsland(int[][] grid)
    {
        int result = 0;
        int size = 0;
        for(int i = 0; i < grid.Length; i++)
        {
            for(int j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == 1)
                {
                    size = MaxAreaDFS(grid, i, j);
                    result = Math.Max(size, result);
                }
            }
        }

        return result;
    }

    private static int MaxAreaDFS(int[][] grid, int row, int col)
    {
        if (row < 0 || row > grid.Length - 1 || col < 0 || col > grid[row].Length - 1 || grid[row][col] == 0)
            return 0;

        grid[row][col] = 0;

        int val = MaxAreaDFS(grid, row + 1, col) +
        MaxAreaDFS(grid, row - 1, col) +
        MaxAreaDFS(grid, row, col + 1) +
        MaxAreaDFS(grid, row, col - 1);

        return val + 1;
    }

    //617. Merge Two Binary Trees
    public static TreeNode MergeTrees(TreeNode root1, TreeNode root2)
    {
        if (root1 is null) return root2;
        if (root2 is null) return root1;

        TreeNode node = new TreeNode(root1.val + root2.val);
        node.left = MergeTrees(root1.left, root2.left);
        node.right = MergeTrees(root1.right, root2.right);

        return node;
    }
}
