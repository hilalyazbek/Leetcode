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
        //TODO: Climb Stairs
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

    //118. Pascal's Triangle
    public static IList<IList<int>> Generate(int numRows)
    {
        List<IList<int>> result = new List<IList<int>>();

        List<int> list = new List<int>();
        list.Add(1);
        result.Add(list);

        for (int i = 1; i < numRows; i++)
        {
            IList<int> prev = result[i - 1];
            List<int> newList = new();
            newList.Add(1);
            for (int j = 0; j < prev.Count - 1; j++)
            {
                newList.Add(prev[j] + prev[j + 1]);
            }
            newList.Add(1);
            result.Add(newList);

        }

        return result;
    }

    //121. Best Time to Buy and Sell Stock
    public static int MaxProfit(int[] prices)
    {
        int maxProfit = 0;
        int min = int.MaxValue;
        //[7,1,5,3,6,4]
        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] < min) min = prices[i];
            maxProfit = Math.Max(prices[i] - min, maxProfit);
        }
        return maxProfit;
    }

    //136. Single Number
    public static int SingleNumber(int[] nums)
    {
        HashSet<int> tracker = new();
        foreach (int i in nums)
        {
            if (tracker.Contains(i))
            {
                tracker.Remove(i);
            }
            else
            {
                tracker.Add(i);
            }
        }
        return tracker.Single();
    }

    //141. Linked List Cycle
    public static bool HasCycle(ListNode head)
    {
        if (head == null) return false;
        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast) return true;
        }
        return false;
    }

    //160. Intersection of Two Linked Lists
    public static ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        ListNode a = headA;
        ListNode b = headB;

        while (a != b)
        {
            if (a == null)
            {
                a = headB;
            }
            else
                a = a.next;

            if (b == null)
            {
                b = headA;
            }
            else
                b = b.next;

        }
        return a;
    }

    //169. Majority Element
    public static int MajorityElement(int[] nums)
    {
        Dictionary<int, int> tracker = new();
        foreach (int i in nums)
        {
            if (!tracker.ContainsKey(i))
                tracker.Add(i, 0);
            tracker[i]++;
        }

        int val = tracker.OrderByDescending(itm => itm.Value).ToList()[0].Key;
        return val;
    }

    //206. Reverse Linked List
    public static ListNode ReverseList(ListNode head)
    {
        if (head == null) return null;
        ListNode prev = null;
        ListNode next = head.next;

        while (next != null)
        {
            head.next = prev;
            prev = head;

            head = next;
            next = next.next;
        }
        head.next = prev;
        return head;
    }
    //226. Invert Binary Tree
    public static TreeNode InvertTree(TreeNode root)
    {
        if (root == null) return null;
        TreeNode temp = root.left;
        root.left = root.right;
        root.right = temp;

        InvertTree(root.left);
        InvertTree(root.right);

        return root;
    }

    //234. Palindrome Linked List
    public static bool IsPalindromeLinkedList(ListNode head)
    {
        if (head == null || head.next == null) return true;
        ListNode fast = head;
        ListNode slow = head;

        while (fast.next != null && fast.next.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        slow = slow.next;

        ListNode reversed = ReverseList(slow);

        while (reversed != null)
        {
            if (head.val != reversed.val)
            {
                return false;
            }
            head = head.next;
            reversed = reversed.next;
        }
        return true;
    }

    //283. Move Zeroes
    public static void MoveZeroes(int[] nums)
    {
        int left = 0;

        for (int right = 0; right < nums.Length; right++)
        {
            if (nums[right] != 0)
            {
                int temp = nums[right];
                nums[right] = nums[left];
                nums[left] = temp;
                left++;
            }
        }
    }

    //108. Convert Sorted Array to Binary Search Tree
    public static TreeNode SortedArrayToBST(int[] nums)
    {
        if (nums == null || nums.Length == 0)
        {
            return null;
        }

        return CreateBST(nums, 0, nums.Length - 1);
    }
    private static TreeNode CreateBST(int[] nums, int left, int right)
    {
        if (left > right)
        {
            return null;
        }
        int mid = (right + left) / 2;
        TreeNode current = new TreeNode(nums[mid]);
        current.left = CreateBST(nums, left, mid - 1);
        current.right = CreateBST(nums, mid + 1, right);

        return current;
    }

}