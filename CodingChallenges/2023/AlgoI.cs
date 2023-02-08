public static class AlgoI
{
    //704. Binary Search
    public static int Search(int[] nums, int target)
    {
        int len = nums.Length;
        int left = 0;
        int right = len - 1;

        while (left <= right)
        {
            int m = right - left / 2;
            if (nums[m] == target)
            {
                return m;
            }
            if (nums[m] < target)
            {
                left = m + 1;
            }
            if (nums[m] > target)
            {
                right = m - 1;
            }
        }
        return -1;
    }

    //278. First Bad Version
    public static int FirstBadVersion(int n)
    {

        while (IsBadVersion(n))
        {
            n--;
        }
        return n + 1;
    }
    private static bool IsBadVersion(int n)
    {
        throw new NotImplementedException();
    }
}
