public static class LcEasy
{
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
}