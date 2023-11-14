
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualBasic;
using System.Linq;
using System.Data;
using CodingChallenges;
using System.Runtime.CompilerServices;

public static class DailyLeetcode
{
    public static IList<int> AddToArrayForm(int[] num, int k)
    {
        List<int> result = new();
        // int carry = 0;
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

        while (length < k)
        {
            if (char.IsDigit(s[i]))
            {
                length *= s[i] - '0';
            }
            else
            {
                length++;
            }
            i++;
        }

        for (int j = i - 1; j >= 0; j--)
        {
            if (char.IsDigit(s[j]))
            {
                length /= s[j] - '0';
                k %= (int)length;
            }
            else
            {
                if (k == 0 || k == length)
                {
                    return s[j].ToString();
                }
                length--;
            }
        }

        return "";
    }

    public static bool IsMonotonic(int[] nums)
    {
        var tracker = new List<string>();

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                tracker.Add("true");
            }
            else if (nums[i] < nums[i - 1])
            {
                tracker.Add("false");
            }
        }
        return tracker.Contains("true") && tracker.Contains("false") ? false : true;
    }

    internal static string ReverseWords(string s)
    {
        var arr = s.Split(" ");
        var sb = new StringBuilder();

        foreach (var str in arr)
        {
            sb.Append(Reverse(str) + " ");
        }

        return sb.ToString().TrimEnd();
    }

    private static string Reverse(string str)
    {
        var word = str.ToCharArray();
        int left = 0;
        int right = word.Length - 1;
        while (left < right)
        {
            var temp = word[left];
            word[left] = word[right];
            word[right] = temp;
            left++;
            right--;
        }

        return new string(word);
    }

    internal static bool WinnerOfGame(string colors)
    {
        var tracker = new Dictionary<char, int>
    {
        { 'A', 0 },
        { 'B', 0 }
    };
        for (int i = 1; i < colors.Length - 1; i++)
        {
            if (colors[i] == colors[i - 1] && colors[i] == colors[i + 1])
            {
                tracker[colors[i]]++;
            }
        }
        if (tracker['B'] >= tracker['A'])
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    internal static int NumIdenticalPairs(int[] nums)
    {
        int result = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            for (int search = i + 1; search < nums.Length && search != i; search++)
            {
                if (nums[i] == nums[search])
                {
                    result++;
                }
            }
        }
        return result;
    }

    internal static IList<int> MajorityElement(int[] nums)
    {
        var result = new List<int>();
        var tracker = new Dictionary<int, int>();

        foreach (var item in nums)
        {
            if (!tracker.ContainsKey(item))
            {
                tracker.Add(item, 0);
            }
            tracker[item]++;
        }

        result = tracker.Where(itm => itm.Value > nums.Length / 3).Select(x => x.Key).ToList();
        return result;
    }

    public static int MaximumScore(int[] nums, int k)
    {
        int left = k, right = k;
        int min_val = nums[k];
        int max_score = min_val;

        while (left > 0 || right < nums.Length - 1)
        {
            if (left == 0 || (right < nums.Length - 1 && nums[right + 1] > nums[left - 1]))
            {
                right++;
            }
            else
            {
                left--;
            }
            min_val = Math.Min(min_val, Math.Min(nums[left], nums[right]));
            max_score = Math.Max(max_score, min_val * (right - left + 1));
        }

        return max_score;
    }

    public static bool IsPowerOfFour(int n)
    {
        int i = 0;
        while (n != Math.Pow(4, i))
        {
            if (n < Math.Pow(4, i)) return false;
            i++;
        }
        return true;
    }

    public static int CountHomogenous(string s)
    {
        var mod = (int)Math.Pow(10, 9) + 7;
        var result = 0;
        var right = 0;
        var left = 0;
        var currentCount = 1;
        while (left < s.Length)
        {
            if (left == s.Length - 1)
            {
                result += CountPossibilities(currentCount);
                left++;
            }
            else
            {
                right = left + 1;
                if (s[left] == s[right])
                {
                    currentCount++;
                    right++;
                    left++;
                }
                else
                {
                    result += CountPossibilities(currentCount);
                    currentCount = 1;
                    left = right;
                }
            }
        }
        return result % mod;
    }

    private static int CountPossibilities(int currentCount)
    {
        var result = 0;
        for (; currentCount > 0; currentCount--)
        {
            result += currentCount;
        }
        return result;
    }

    public static string SortVowels(string s)
    {
        var vowels = "aeiouAEIOU";
        var currentVowels = new List<char>();
        char[] result = new char[s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            if (vowels.Contains(s[i]))
            {
                currentVowels.Add(s[i]);
            }
        }
        currentVowels.Sort();
        var idx = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (vowels.Contains(s[i]))
            {
                result[i] = currentVowels[idx];
                idx++;
            }
            else
            {
                result[i] = s[i];
            }
        }

        return new string(result);
    }

    public static int CountPalindromicSubsequence(string s)
    {
        var uniqueChars = s.ToHashSet();
        var firstOccurance = new Dictionary<char, int>();
        var lastOccurance = new Dictionary<char, int>();
        var result = 0;

        foreach (var c in uniqueChars)
        {
            if (s.Count(itm => itm == c) > 1)
            {
                firstOccurance.Add(c, s.IndexOf(c));
                lastOccurance.Add(c, s.LastIndexOf(c));
            }
        }

        foreach (var kvp in firstOccurance)
        {

            var count = GetDistinct(s, kvp.Value, lastOccurance[kvp.Key]);
            result += count;
        }
        return result;
    }

    private static int GetDistinct(string s, int start, int end)
    {
        var substring = s.Substring(start + 1, end - start - 1);
        return substring.ToHashSet().Count();

    }
}

public class MyHashMap
{
    public List<int> Keys;
    public List<int> Values;
    public MyHashMap()
    {
        Keys = new List<int>();
        Values = new List<int>();
    }

    public void Put(int key, int value)
    {
        var keyIndex = Keys.IndexOf(key);
        if (keyIndex == -1)
        {
            Keys.Add(key);
            Values.Add(value);
        }
        else
        {
            Values[keyIndex] = value;
        }
    }

    public int Get(int key)
    {
        var value = -1;
        var index = Keys.IndexOf(key);
        if (index != -1)
        {
            value = Values[index];
        }
        return value;
    }

    public void Remove(int key)
    {
        var index = Keys.IndexOf(key);
        if (index != -1)
        {
            Keys.RemoveAt(index);
            Values.RemoveAt(index);
        }
    }


}