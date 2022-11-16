public static class LcEasy
{
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
}