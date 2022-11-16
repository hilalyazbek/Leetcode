public static class LcEasy
{
    #region Class Definitions
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
    //1. Two Sum
    public static int[] TwoSum(int[] nums, int target)
    {
        // nums = [2,7,11,15], target = 9

        if (nums == null || nums.Length == 0) return null;

        Dictionary<int, int> tracker = new();

        for (int i = 0; i < nums.Length; i++)
        {
            int rem = target - nums[i];
            if (tracker.ContainsKey(rem))
            {
                return new int[] { tracker[rem], i };
            }
            else if (!tracker.ContainsKey(nums[i]))
            {
                tracker.Add(nums[i], i);
            }
        }
        return null;
    }

    //20. Valid Parentheses
    public static bool IsValidParentheses(string s)
    {
        //s = "()[]{}"
        if (s[0] == ']' || s[0] == '}' || s[0] == ')') return false;

        Stack<char> tracker = new Stack<char>();
        foreach (char c in s)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                tracker.Push(c);
                continue;
            }
            else if (
            (tracker.Count > 0 && tracker.Peek() == '(' && c == ')') ||
            (tracker.Count > 0 && tracker.Peek() == '[' && c == ']') ||
            (tracker.Count > 0 && tracker.Peek() == '{' && c == '}'))
            {
                tracker.Pop();
            }
            else { return false; }
        }
        return tracker.Count == 0;
    }

    //21. Merge Two Sorted Lists
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        //1-2-4
        //1-3-4
        if (list1 == null) return list2;
        else if (list2 == null) return list1;

        ListNode result = new ListNode();
        ListNode dummy = new ListNode();
        result = dummy;

        if (list1.val <= list2.val)
        {
            dummy.next = list1;
            list1 = list1.next;
        }
        else
        {
            dummy.next = list2;
            list2 = list2.next;
        }
        dummy = dummy.next;

        while (list1 != null && list2 != null)
        {
            if (list1.val <= list2.val)
            {
                dummy.next = list1;
                dummy = list1;
                list1 = list1.next;

            }
            else
            {
                dummy.next = list2;
                dummy = list2;
                list2 = list2.next;
            }
        }
        if (list1 != null)
        {
            dummy.next = list1;
        }
        if (list2 != null)
        {
            dummy.next = list2;
        }
        return result.next;
    }

    //35. Search Insert Position
    public static int SearchInsert(int[] nums, int target)
    {
        //nums = [1,3,5,6], target = 5 -> 2
        //nums = [1,3,5,6], target = 2 -> 1 (where value should be)
        int lo = 0, hi = nums.Length - 1;

        while (lo <= hi)
        {
            int mid = lo + (hi - lo) / 2;

            if (target < nums[mid]) hi = mid - 1;
            else if (target > nums[mid]) lo = mid + 1;
            else return mid;
        }

        return lo;
    }
}