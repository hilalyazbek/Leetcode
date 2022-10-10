using System;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using static CodingChallenges.Level1;

namespace CodingChallenges;

public class Level2
{
    //202. Happy Number
    public static bool IsHappy(int n)
    {
        HashSet<int> tracker = new();
        return CheckHappiness(n, tracker);
    }
    private static bool CheckHappiness(int number, HashSet<int> tracker)
    {

        if (number == 1)
        {
            return true;
        }
        int result = 0;
        int index = 0;
        string numb = number.ToString();
        while (index < numb.Length)
        {
            int num = numb[index] - '0';

            num *= num;

            result += num;
            index++;
        }
        if (tracker.Contains(result))
        {
            return false;
        }
        tracker.Add(result);
        return CheckHappiness(result, tracker);
    }

    //54. Spiral Matrix
    public static IList<int> SpiralOrder(int[][] matrix)
    {
        IList<int> result = new List<int>();

        if (matrix == null || matrix.Length == 0)
            return result;

        int maxRow = matrix.Length;
        int maxCol = matrix[0].Length;
        int i = 0, row = 0, col = 0;

        while (row < maxRow && col < maxCol)
        {
            // #Move Left to Right and #Remove row from Top
            for (i = col; i < maxCol; i++)
                result.Add(matrix[row][i]);
            row++;

            // #Move Top to Down and #Remove col from Right
            for (i = row; i < maxRow; i++)
                result.Add(matrix[i][maxCol - 1]);
            maxCol--;

            // #Move Right to Left and #Remove row from Bottom
            if (row < maxRow)
            {
                for (i = maxCol - 1; i >= col; i--)
                    result.Add(matrix[maxRow - 1][i]);
                maxRow--;
            }

            // #Move Down to Top and #Remove col from Left
            if (col < maxCol)
            {
                for (i = maxRow - 1; i >= row; i--)
                    result.Add(matrix[i][col]);
                col++;
            }
        }

        return result;
    }

    //14. Longest Common Prefix
    public static string LongestCommonPrefix(string[] strs)
    {
        if (strs == null || strs.Length == 0)
        { return String.Empty; }

        StringBuilder sb = new StringBuilder();
        List<char> tracker = new List<char>();
        foreach (char c in strs[0])
        {
            tracker.Add(c);
        }

        for (int i = 1; i < strs.Length; i++)
        {
            tracker = GetPrefix(strs[i], tracker);
        }

        foreach (char c in tracker)
        {
            sb.Append(c);
        }
        return sb.ToString();
    }

    private static List<char> GetPrefix(string s, List<char> tracker)
    {
        if (s.Length < tracker.Count)
        {
            tracker.RemoveRange(s.Length, tracker.Count - s.Length);
        }
        for (int i = 0; i < tracker.Count; i++)
        {
            if (s[i] != tracker[i])
            {
                tracker.RemoveRange(i, tracker.Count - i);
            }
        }
        return tracker;
    }

    public static int[] FindBall(int[][] grid)
    {
        return new int[0];
    }

    //43. Multiply Strings
    public static string Multiply(string num1, string num2)
    {
        if (num1 == "0" || num2 == "0")
        {
            return "0";
        }
        return string.Empty;
    }

    private static int ConvertToInt(string num)
    {
        int numb = 0;
        foreach (char c in num)
        {
            numb += numb * 10 + c - '0';
        }
        return numb;
    }

    //19. Remove Nth Node From End of List
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        //1-2-3-4-5, 2
        //1-2-3-5
        ListNode right = head;
        ListNode left = head;

        int i = 0;
        while (i < n)
        {
            right = right.next;
            i++;
        }
        if (right == null) return head.next;
        while (right.next != null)
        {
            right = right.next;

            left = left.next;
        }
        left.next = left.next.next;

        return head;
    }

    //234. Palindrome Linked List
    public bool IsPalindrome(ListNode head)
    {
        List<int> tracker = new();

        ListNode curr = head;
        while (curr != null)
        {
            tracker.Add(curr.val);
            curr = curr.next;
        }
        int count = tracker.Count();
        Console.WriteLine(count);
        for (int i = 0; i < count / 2; i++)
        {
            if (tracker[i] != tracker[count - i - 1])
            {
                return false;
            }
        }
        return true;
    }

    //328. Odd Even Linked List
    public ListNode OddEvenList(ListNode head)
    {
        if (head is null) return null;
        ListNode odd = head;
        ListNode even = head.next;
        ListNode evenHead = even;

        while (even != null && even.next != null)
        {
            odd.next = odd.next.next;
            even.next = even.next.next;
            odd = odd.next;
            even = even.next;
        }
        odd.next = evenHead;

        return head;
    }
    // TODO: Reverse linked list
    private ListNode Reverse(ListNode head)
    {
        ListNode prev = null;
        ListNode next = null;
        ListNode curr = head;
        while (curr != null)
        {
            next = curr.next;
            curr.next = prev;
            prev = curr;
            curr = next;
        }

        return prev;
    }

    //226. Invert Binary Tree
    public TreeNode InvertTree(TreeNode root)
    {
        if (root == null)
            return root;

        TreeNode temp = root.right;
        root.right = root.left;
        root.left = temp;

        InvertTree(root.left);
        InvertTree(root.right);

        return root;
    }


    //148. Sort List
    public ListNode SortList(ListNode head)
    {
        return new ListNode();
    }

    //2131. Longest Palindrome by Concatenating Two Letter Words
    public int LongestPalindrome(string[] words)
    {
        return 0;
    }

    //110. Balanced Binary Tree
    public bool isBalanced = true;
    public bool IsBalanced(TreeNode root)
    {
        if (root == null)
            return true;

        GetDepth(root);
        return isBalanced;
    }
    public int GetDepth(TreeNode root)
    {
        if (root == null)
            return 0;

        int left = GetDepth(root.left);   // depth of left subtree of current root
        int right = GetDepth(root.right); // depth of right subtree of current root

        if (Math.Abs(left - right) > 1)   // check whether the current (sub)tree is balanced or not
            isBalanced = false;

        return Math.Max(left, right) + 1; // depth of current root node
    }

    //543. Diameter of Binary Tree
    public int DiameterOfBinaryTree(TreeNode root)
    {
        return 1;
    }
}

