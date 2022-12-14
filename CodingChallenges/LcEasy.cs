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

    //328. Odd Even Linked List
    public static ListNode OddEvenList(ListNode head)
    {
        ListNode dummyOdd = head;
        ListNode dummyEven = head.next;
        ListNode odd = head;
        ListNode even = head.next;

        while (odd.next.next != null || even.next.next != null)
        {
            ListNode oddNext = odd.next.next;
            odd.next = oddNext;
            odd = oddNext;
            if (even.next.next != null)
            {
                ListNode evenNext = even.next.next;
                even.next = evenNext;
                even = evenNext;
            }
        }
        odd.next = dummyEven;
        return dummyOdd;
    }

    //3. Longest Substring Without Repeating Characters
    public static int LengthOfLongestSubstring(string s)
    {
        int result = 0;
        int left = 0;
        int right = 0;
        HashSet<char> map = new HashSet<char>();

        while (right < s.Length)
        {
            if (!map.Contains(s[right]))
            {
                map.Add(s[right]);
                right++;
                result = Math.Max(map.Count, result);
            }
            else
            {
                map.Remove(s[left]);
                left++;
            }
        }
        return result;
    }

    //938. Range Sum of BST
    public static int RangeSumBST(TreeNode node, int low, int high)
    {
        int sum = 0;
        Queue<TreeNode> q = new();

        q.Enqueue(node);

        while (q.Count > 0)
        {
            TreeNode temp = q.Dequeue();
            if (temp.val >= low && temp.val <= high)
            {
                sum += temp.val;
            }
            if (temp.left != null && temp.val > low)
                q.Enqueue(temp.left);
            if (temp.right != null && temp.val < high)
            {
                q.Enqueue(temp.right);
            }
        }

        return sum;
    }

    //11. Container With Most Water
    public static int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int max = 0;

        while (left < right)
        {
            max = Math.Max(Math.Min(height[left], height[right]) * (right - left), max);

            if (height[left] > height[right])
            {
                right--;
            }
            else
            {
                left++;
            }
        }
        return max;
    }

    //872. Leaf-Similar Trees
    public static bool LeafSimilar(TreeNode root1, TreeNode root2)
    {
        List<int> tree1 = new();
        TraverseTree(root1, tree1);
        List<int> tree2 = new();
        TraverseTree(root2, tree2);

        Console.Write(tree1.Count + "|" + tree2.Count);
        if (tree1.Count != tree2.Count)
        {
            return false;
        }

        return tree1.SequenceEqual(tree2);
    }

    private static void TraverseTree(TreeNode root, List<int> tree)
    {
        if (root == null) return;

        if (root.left == null && root.right == null)
        {
            tree.Add(root.val);
            return;
        }
        if (root.left != null)
            TraverseTree(root.left, tree);

        if (root.right != null)
            TraverseTree(root.right, tree);
    }

    //19. Remove Nth Node From End of List
    public static ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        ListNode start = new ListNode(0);
        ListNode slow = start, fast = start;
        start.next = head;

        for (int i = 1; i <= n + 1; i++)
        {
            fast = fast.next;
        }

        while (fast != null)
        {
            slow = slow.next;
            fast = fast.next;
        }

        slow.next = slow.next.next;
        return start.next;
    }

    //15. 3Sum
    public static List<List<int>> ThreeSum(int[] nums)
    {
        List<List<int>> result = new();
        Array.Sort(nums);
        for (int i = 0; i < nums.Length - 2; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }
            int left = i + 1;
            int right = nums.Length - 1;
            int target = 0 - nums[i];
            while (left < right)
            {
                if (nums[i] + nums[left] + nums[right] == 0)
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });
                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;
                    left++;
                    right--;
                }
                else if (nums[left] + nums[right] > target)
                {
                    right--;
                }
                else
                {
                    left++;
                }
            }
        }

        return result;
    }

    //167. Two Sum II - Input Array Is Sorted
    public static int[] TwoSumII(int[] nums, int target)
    {
        int left = 0;
        int right = nums.Length - 1;

        while (nums[left] + nums[right] != target)
        {
            if (nums[left] + nums[right] > target)
            {
                right--;
            }
            else
            {
                left++;
            }
        }
        return new int[] { left + 1, right + 1 };
    }

    //24. Swap Nodes in Pairs
    //TODO: SwapPairs: To be revisited
    public static ListNode SwapPairs(ListNode head)
    {
        if (head == null) return null;
        ListNode dummy = new ListNode(0, head);
        ListNode current = dummy;

        while (current.next != null && current.next.next != null)
        {
            ListNode first = current.next;
            ListNode second = current.next.next;
            first.next = second.next;
            current.next = second;

            current.next.next = first;
            current = current.next.next;
        }

        return dummy.next;
    }

    //931. Minimum Falling Path Sum
    //TODO: MinFallingPathSum: Dynamic Programming
    public static int MinFallingPathSum(int[][] matrix)
    {
        int sum = 0;
        for (int i = 0; i < matrix.Length; i++)
        {
            for (int j = 0; j < matrix[0].Length; j++)
            {
                sum = Math.Min(sum, Fall(matrix, i, j, sum));
            }
        }

        return sum;
    }

    private static int Fall(int[][] matrix, int i, int j, int sum)
    {
        if (i < 0 || i >= matrix.Length || j < 0 || j >= matrix[0].Length)
            return sum;

        sum += matrix[i][j];
        Fall(matrix, i + 1, j, sum);
        Fall(matrix, i + 1, j - 1, sum);
        Fall(matrix, i + 1, j + 1, sum);

        return sum;
    }

    //33. Search in Rotated Sorted Array
    public static int Search(int[] nums, int target)
    {

        int left = 0;
        int right = nums.Length - 1;
        while (left <= right)
        {
            int mid = right + left / 2;
            if (target == nums[mid])
            {
                return mid;
            }
            if (nums[left] <= nums[mid])
            {
                if (target < nums[mid] && target >= nums[left])
                {
                    right = mid - 1;
                }
                else
                {
                    left = mid + 1;
                }
            }
            if (nums[mid] <= nums[right])
            {
                if (target > nums[mid] && target <= nums[right])
                {
                    left = mid + 1;
                }
                else
                {
                    right = mid - 1;
                }
            }
        }
        return -1;
    }
    //198. House Robber
    //TODO: House Robber: DP
    public static int Rob(int[] nums)
    {
        int first = 0;
        int second = 0;
        int index = 0;
        while (index <= nums.Length - 1)
        {
            first += nums[index];
            index = index + 2;
            Console.WriteLine(index);
            Console.WriteLine(first);
        }
        Console.WriteLine(first);
        index = 1;
        while (index <= nums.Length - 1)
        {
            second += nums[index];
            index = index + 2;
        }

        return Math.Max(first, second);
    }
}