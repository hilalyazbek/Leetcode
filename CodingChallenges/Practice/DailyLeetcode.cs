
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualBasic;

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

  public static int FindDuplicate(int[] nums)
  {
    var tracker = new HashSet<int>();

    foreach (int i in nums)
    {
      if (!tracker.Contains(i))
      {
        tracker.Add(i);
      }
      else
        return i;
    }
    return -1;
  }

  public static double ChampagneTower(int poured, int query_row, int query_glass)
  {
    var currentLevel = 1;
    var tracker = new Dictionary<int, bool>();
    for (int i = 0; i < poured; i++)
    {

      currentLevel++;
    }

    return 0.0;
  }

  internal static char FindTheDifference(string s, string t)
  {
    if (s.Length == 0)
    {
      return t[0];
    }

    var tracker = new Dictionary<char, int>();

    foreach (char c in s)
    {
      if (!tracker.ContainsKey(c))
      {
        tracker.Add(c, 0);
      }
      tracker[c]++;
    }

    foreach (char c in t)
    {
      if (tracker.ContainsKey(c) && tracker[c] > 0)
      {
        tracker[c]--;
      }
      else { return c; }
    }
    return '\0';
  }
  public static string RemoveDuplicateLetters(string s)
  {
    var lastIndex = new int[26];
    var seen = new bool[26];
    var stack = new Stack<int>();

    for (int i = 0; i < s.Length; i++)
    {
      lastIndex[s[i] - 'a'] = i;
    }

    for (int i = 0; i < s.Length; i++)
    {
      var current = s[i] - 'a';
      if (seen[current]) continue;
      while (stack.Count > 0 && stack.Peek() > current && i < lastIndex[stack.Peek()])
      {
        seen[stack.Pop()] = false;
      }
      stack.Push(current);
      seen[current] = true;
    }

    var sb = new StringBuilder();
    while (stack.Count > 0)
    {
      sb.Append((char)(stack.Pop() + 'a'));
    }

    var result = sb.ToString().ToCharArray();
    Array.Reverse(result);
    return new string(result);
  }

  internal static string DecodeAtIndex(string s, int k)
  {
    long length = 0;
        int i = 0;

        while (length < k) {
            if (char.IsDigit(s[i])) {
                length *= s[i] - '0';
            } else {
                length++;
            }
            i++;
        }

        for (int j = i - 1; j >= 0; j--) {
            if (char.IsDigit(s[j])) {
                length /= s[j] - '0';
                k %= (int)length;
            } else {
                if (k == 0 || k == length) {
                    return s[j].ToString();
                }
                length--;
            }
        }

        return "";
  }

  public static bool IsMonotonic(int[] nums) {
      var tracker = new List<string>();
        
        for(int i=1; i< nums.Length ; i++){
            if(nums[i] > nums[i-1]){
              tracker.Add("true");
          }
          else if(nums[i] < nums[i-1]){
              tracker.Add("false");
          }
        }
        return tracker.Contains("true") && tracker.Contains("false")? false:true;
  }

    internal static string ReverseWords(string s)
    {
        var arr = s.Split(" ");
        var sb = new StringBuilder();

        foreach(var str in arr){
          sb.Append(Reverse(str)+" ");
        }

        return sb.ToString().TrimEnd();
    }

    private static string Reverse(string str)
    {
      var word = str.ToCharArray();
        int left = 0;
        int right = word.Length-1;
        while(left<right){
          var temp = word[left];
          word[left] = word[right];
          word[right]= temp;
          left++;
          right--;
        }

        return new string(word);
    }

    internal static bool WinnerOfGame(string colors)
    {
        var tracker = new Dictionary<char,int>();
        tracker.Add('A',0);
        tracker.Add('B',0);
        for(int i=1 ; i<colors.Length -1 ; i++){
          if(colors[i] == colors[i-1] && colors[i] == colors[i+1]){
            tracker[colors[i]]++;
          }
        }
        if(tracker['B']>=tracker['A']){
          return false;
        }
        else{
          return true;
        }
    }
}