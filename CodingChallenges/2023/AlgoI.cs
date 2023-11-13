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
        int left = 0;
        int right = n;

        while (left < right)
        {
            int m = left + (right - left) / 2;
            if (IsBadVersion(m))
            {
                right = m;
            }
            else
            {
                left = m + 1;
            }
        }
        return left;
    }
    private static bool IsBadVersion(int n)
    {
        throw new NotImplementedException();
    }

    //35. Search Insert Position
    public static int SearchInsert(int[] nums, int target)
    {
        int low = 0;
        int high = nums.Length - 1;

        while (low < high)
        {
            int mid = low + (high - low) / 2;
            if (nums[mid] == target)
            {
                return mid;
            }
            else if (nums[mid] < target)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }
        return high + 1;
    }

    public static List<string> processLogs(List<string> logs, int threshold)
    {
        var tracker = new Dictionary<int, int>();

        foreach (var log in logs)
        {
            var details = log.Split(' ');

            if (details.Length != 3)
            {
                continue;
            }

            var sender = details[0];
            var receiver = details[1];

        }
        return new List<string>();
    }
}
