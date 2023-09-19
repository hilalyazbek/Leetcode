public static class DailyLeetcode
{
    public static IList<int> AddToArrayForm(int[] num, int k)
    {
        List<int> result = new();
        int carry = 0;
        int i = num.Length - 1;



        result.Reverse();
        return result;
    }

    public static int FindDuplicate(int[] nums) {
        var tracker = new HashSet<int>();
        
        foreach(int i in nums)
        {
          if(!tracker.Contains(i)){
            tracker.Add(i);
          }
          else
            return i;
        }
        return -1;
    }
}