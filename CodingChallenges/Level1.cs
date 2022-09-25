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

    // TreeNode Class
    public class Node
    {
        public int val;
        public IList<Node> children;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, IList<Node> _children)
        {
            val = _val;
            children = _children;
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

    public static ListNode MiddleNode(ListNode head)
    {
        // 1 - 2 - 3 - 4 - 5
        // 3 - 4 - 5
        ListNode fast = head;
        ListNode slow = head;

        while(fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }
        return slow;
    }

    public static ListNode DetectCycle(ListNode head)
    {
        ListNode slow = head;
        ListNode fast = head;

        while(fast is not null && fast.next is not null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if(slow == fast)
            {
                slow = head;
                while(slow != fast)
                {
                    slow = slow.next;
                    fast = fast.next;
                }
                return slow;
            }
        }
        return null;
    }

    public static int MaxProfit(int[] prices)
    {
        //[7,1,5,3,6,4]
        var profit = 0;
        var min = int.MaxValue;

        for(int i = 0; i < prices.Length; i++)
        {
            if (prices[i] < min)
            {
                min = prices[i];
            }
            else
            {
                profit = Math.Max(prices[i] - min, profit);
            }
        }
        return profit;
    }

    public static int LongestPalindrome(string s)
    {
        Dictionary<char, int> tracker = new Dictionary<char, int>();

        foreach (char c in s)
        {
            if (tracker.ContainsKey(c))
            {
                tracker[c]++;
            }
            else
            {
                tracker.Add(c, 1);
            }
        }

        int result = 0;

        foreach (var key in tracker.Keys)
        {
            var count = tracker[key];
            if (count % 2 == 0)
            {
                result += count;
                tracker.Remove(key);
            }
            else if (count % 2 != 0)
            {
                result += count - 1;
                tracker[key] = 1;
            }

        }
        result = tracker.Count > 0 ? result += 1 : result;

        return result;
    }

    public static IList<int> Preorder(Node root)
    {
        List<int> result = new List<int>();
        if(root is null)
        {
            return result;
        }
        if(root != null)
        {
            helper(root, result);
        }
        return result;
    }
    public static void helper(Node node, List<int> result)
    {
        if(node.children == null)
        {
            return;
        }
        result.Add(node.val);
        foreach(var nde in node.children)
        {
            helper(nde, result);
        }
    }

}

