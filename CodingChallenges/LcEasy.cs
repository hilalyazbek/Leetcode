using static CodingChallenges.Level1;

public static class LcEasy
{
    #region Class Definitions

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

    //94. Binary Tree Inorder Traversal
    public static IList<int> InorderTraversal(TreeNode root)
    {
        List<int> result = new List<int>();
        InOrderUtil(root, result);
        return result;
    }
    private static void InOrderUtil(TreeNode node, List<int> result)
    {
        if (node == null) { return; }
        InOrderUtil(node.left, result);
        result.Add(node.val);
        InOrderUtil(node.right, result);
    }

    //70. Climbing Stairs
    public static int ClimbStairs(int n)
    {
        int result = 0;
        //TODO: implementation
        return result;
    }

    //101. Symmetric Tree
    public static bool IsSymmetric(TreeNode root)
    {
        if (root == null) return true;

        return IsSymmetric(root.left, root.right);
    }
    private static bool IsSymmetric(TreeNode left, TreeNode right)
    {
        if (left == null || right == null)
        {
            return left == right;
        }
        if (left.val != right.val)
        {
            return false;
        }
        return IsSymmetric(left.left, right.right) && IsSymmetric(left.right, right.left);
    }

    //104. Maximum Depth of Binary Tree
    public static int MaxDepth(TreeNode root)
    {
        int height = 0;
        if (root == null) return height;
        height = LevelOrderTraversal(root);

        return height;
    }
    public static int LevelOrderTraversal(TreeNode node)
    {
        int result = 0;
        Queue<TreeNode> queue = new();
        queue.Enqueue(node);

        while (queue.Count != 0)
        {
            int size = queue.Count;
            for (int i = 0; i < size; i++)
            {
                TreeNode temp = queue.Dequeue();
                if (temp.left != null)
                    queue.Enqueue(temp.left);
                if (temp.right != null)
                    queue.Enqueue(temp.right);
            }

            result++;
        }

        return result;
    }

    //104. Maximum Depth of Binary Tree
    public static int MaxDepthRecursive(TreeNode root)
    {
        if (root == null) return 0;

        int left = MaxDepthRecursive(root.left);
        int right = MaxDepthRecursive(root.right);

        return Math.Max(left, right) + 1;
    }
}