using System;
namespace CodingChallenges;

public static class Level1
{
    #region ListNode, TreeNode Class
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }
    #endregion

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

        for (int i = 1; i < len; i++)
        {
            leftSum[i] = nums[i] + leftSum[i - 1];
            rightSum[len - 1 - i] = nums[len - 1 - i] + rightSum[len - i];
        }

        for (int i = 0; i < len; i++)
        {
            if (leftSum[i] == rightSum[i])
                return i;
        }
        return -1;
    }

    public static bool IsIsomorphic(string s, string t)
    {
        if (s.Length != t.Length)
            return false;
        Dictionary<char, char> tracker = new Dictionary<char, char>();
        
        for (int i = 0; i < s.Length; i++)
        {
            if (tracker.ContainsKey(s[i])){
                if (tracker[s[i]] != t[i])
                    return false;
            }
            else
            {
                if (tracker.ContainsValue(t[i]))
                    return false;
                tracker.Add(s[i], t[i]);
            }
        }
        
        return true;
    }

    public static bool IsSubsequence(string s, string t)
    {
        if (s.Length == 0)
            return true;
        int j = 0;
        for (int i = 0; i < t.Length; ++i)
        {
            if (t[i] == s[j])
                j++;
            if (j == s.Length)
                return true;
        }
        return false;
    }

    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        // 1 - 2 - 4
        // 1 - 3 - 4

        if (list1 == null)
            return list2;
        if (list2 == null)
            return list1;
        if (list1 == null && list2 == null)
            return null;

        
        ListNode result = new ListNode();
        ListNode current = result;

        while(list1 != null && list2 != null)
        {
            if (list1.val < list2.val)
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }
            current = current.next;
        }

        if (list1 != null)
            current.next = list1;
        if (list2 != null)
            current.next = list2;

        return result.next;
    }

    public static ListNode ReverseList(ListNode head)
    {
        if (head == null)
            return null;
        //1 - 2 - 3 - 4 - 5

        ListNode prev = null;
        while(head != null)
        {
            ListNode next = head.next;
            head.next = prev;
            prev = head;
            head = next;
        }
        return prev;
    }

}

