using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static CodingChallenges.Level1;

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

    //15. 3Sum
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        //TODO: Revisit 3SUM
        List<IList<int>> result = new();
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }
            int left = i + 1;
            int right = nums.Length - 1;
            while (left < right)
            {
                int threeSum = nums[i] + nums[left] + nums[right];
                if (threeSum > 0)
                {
                    right--;
                }
                else if (threeSum < 0)
                {
                    left++;
                }
                else if (threeSum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });
                    left++;
                    while (nums[left] == nums[left - 1] && left < right)
                    {
                        left++;
                    }
                }
            }

        }

        return result;
    }

    //11. Container With Most Water
    public int MaxArea(int[] height)
    {
        //TODO: to be revisited.
        int left = 0;
        int right = height.Length - 1;
        int max = 0;
        while (left < right)
        {
            int width = right - left;
            int minHeight = Math.Min(height[right], height[left]);
            int currentWater = width * minHeight;
            max = Math.Max(max, currentWater);
            if (height[left] <= height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return max;
    }

    //206. Reverse Linked List
    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;

        while (head != null)
        {
            ListNode next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }

        return prev;
    }

    //141. Linked List Cycle
    public bool HasCycle(ListNode head)
    {
        if (head == null) return false;
        ListNode slow = head;
        ListNode fast = head;
        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
            if (slow == fast) return true;
        }
        return false;
    }

    //21. Merge Two Sorted Lists
    public ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        if (list1 == null) return list2;
        if (list2 == null) return list1;
        ListNode dummy = new ListNode(0);
        ListNode curr = dummy;
        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                curr.next = list1;
                list1 = list1.next;
            }
            else
            {
                curr.next = list2;
                list2 = list2.next;
            }
            curr = curr.next;
        }

        if (list1 == null)
        {
            curr.next = list2;
        }
        if (list2 == null)
        {
            curr.next = list1;
        }
        return dummy.next;
    }

    //23. Merge k Sorted Lists
    public ListNode MergeKLists(ListNode[] lists)
    {
        HashSet<ListNode> tracker = new();

        foreach (ListNode node in lists)
        {
            ListNode item = node;
            while (item != null)
            {
                tracker.Add(item);
                item = item.next;
            }
        }

        ListNode head = new ListNode(0);
        ListNode curr = head;

        tracker = tracker.OrderBy(itm => itm.val).ToHashSet<ListNode>();
        foreach (ListNode node in tracker)
        {
            curr.next = node;
            curr = curr.next;
        }

        return head.next;
    }

    //143. Reorder List
    public void ReorderList(ListNode head1)
    {
        //1-2-3-4-5
        //1-5-2-4-3
        if (head1 == null || head1.next == null) { return; }
        // find middle of the list
        ListNode fast = head1;
        ListNode slow = head1;
        ListNode tail = null;

        while (fast != null && fast.next != null)
        {
            fast = fast.next.next;
            tail = slow;
            slow = slow.next;

        }

        tail.next = null;

        ListNode prev = null;

        while (slow != null)
        {
            ListNode next = slow.next;
            slow.next = prev;
            prev = slow;
            slow = next;
        }
        ListNode l2 = prev;
        ListNode l1 = head1;

        while (l1 != null)
        {
            ListNode n1 = l1.next;
            ListNode n2 = l2.next;
            l1.next = l2;
            if (n1 == null)
            {
                break;
            }
            l2.next = n1;
            l1 = n1;
            l2 = n2;
        }


    }

    HashSet<(int, int)> tracker = new HashSet<(int, int)>();
    //73. Set Matrix Zeroes
    public void SetZeroes(int[][] matrix)
    {
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[i].Length; j++)
            {
                if (matrix[i][j] == 0 && !tracker.Contains((i, j)))
                {
                    SetZeroesToColAndRow(matrix, i, j);
                }
            }
        }
    }

    private void SetZeroesToColAndRow(int[][] matrix, int i, int j)
    {
        // replace col with 0
        for (int c = 0; c < matrix[0].Length; c++)
        {
            if (matrix[i][c] != 0)
            {
                matrix[i][c] = 0;
                tracker.Add((i, c));
            }
        }

        // replace row with 0
        for (int r = 0; r < matrix.Length; r++)
        {
            if (matrix[r][j] != 0)
            {
                matrix[r][j] = 0;
                tracker.Add((r, j));
            }
        }
    }
    //54. Spiral Matrix
    public IList<int> SpiralOrder(int[][] matrix)
    {
        List<int> result = new List<int>();

        if (matrix == null || matrix.Length == 0)
            return result;

        int maxRow = matrix.Length;
        int maxCol = matrix[0].Length;
        int i = 0, row = 0, col = 0;

        while (row < maxRow && col < maxCol)
        {
            //move to the left
            for (i = col; i < maxCol; i++)
            {
                result.Add(matrix[row][i]);
            }
            row++;
            //move down
            for (i = row; i < maxRow; i++)
            {
                result.Add(matrix[i][maxCol - 1]);

            }
            maxCol--;

            if (row < maxRow)
            {
                //move left
                for (i = maxCol - 1; i >= col; i--)
                {
                    result.Add(matrix[maxRow - 1][i]);
                }
                maxRow--;
            }

            if (col < maxCol)
            {
                //move up
                for (i = maxRow - 1; i >= row; i--)
                {
                    result.Add(matrix[i][col]);
                }
                col++;
            }
        }

        return result;
    }

    //48. Rotate Image
    public void Rotate(int[][] matrix)
    {
        int n = matrix.Length;

        //turn rows into columns
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j < n; j++)
            {
                int temp = matrix[i][j];
                matrix[i][j] = matrix[j][i];
                matrix[j][i] = temp;
            }
        }

        //swap reach row
        for (int i = 0; i < n; i++)
        {
            int left = 0;
            int right = n - 1;
            while (left < right)
            {
                int temp = matrix[i][left];
                matrix[i][left] = matrix[i][right];
                matrix[i][right] = temp;
                left++;
                right--;
            }
        }

    }

    //79. Word Search
    public bool Exist(char[][] board, string word)
    {
        if (board == null || board[0].Length == 0)
            return false;
        if (word == "")
            return true;

        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (WordSearch(board, word, i, j, 0))
                    return true;
            }
        }

        return false;
    }

    private bool WordSearch(char[][] board, string word, int i, int j, int idx)
    {
        if (idx == word.Length)
            return true;
        if (i < 0 || i >= board.Length || j < 0 || j >= board[0].Length || word[idx] != board[i][j])
            return false;

        board[i][j] = '#'; // visted

        bool find = WordSearch(board, word, i - 1, j, idx + 1)
            || WordSearch(board, word, i + 1, j, idx + 1)
            || WordSearch(board, word, i, j - 1, idx + 1)
            || WordSearch(board, word, i, j + 1, idx + 1);

        board[i][j] = word[idx]; // backtracking

        return find;
    }

    //424. Longest Repeating Character Replacement
    public int CharacterReplacement(string s, int k)
    {
        int left = 0;
        int result = 0;
        int[] tracker = new int[26];
        int currentMax = 0;
        for (int right = 0; right < s.Length; right++)
        {
            char c = s[right];
            tracker[c - 'A']++;
            currentMax = Math.Max(currentMax, tracker[c - 'A']);


            while (right - left + 1 - currentMax > k)
            {
                tracker[s[left] - 'A']--;
                left++;
            }
            result = Math.Max(result, right - left + 1);
        }

        return result;
    }

    //76. Minimum Window Substring
    public int MinWindow(string s, string t)
    {

    }
}
