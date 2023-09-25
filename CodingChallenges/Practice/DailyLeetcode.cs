
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

    public static double ChampagneTower(int poured, int query_row, int query_glass) {
      var currentLevel = 1;
      var tracker = new Dictionary<int, bool>();
      for(int i=0; i < poured; i++){
        
        currentLevel++;
      }

      return 0.0;
    }

    internal static char FindTheDifference(string s, string t)
    {
        if(s.Length == 0){
          return t[0];
        }

        var tracker = new Dictionary<char, int>();

        foreach(char c in s){
          if(!tracker.ContainsKey(c)){
            tracker.Add(c,0);
          }
          tracker[c]++;
        }

        foreach(char c in t){
          if(tracker.ContainsKey(c) && tracker[c]>0){
            tracker[c]--;
          }
          else{return c;}
        }
        return '\0';
    }
}