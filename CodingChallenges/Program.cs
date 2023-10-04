// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;

Console.WriteLine("LEETCODE CODING CHALLENGES");
Console.WriteLine("__________________________");

Console.WriteLine("September 19, 2023");
Console.WriteLine("Answer > " + DailyLeetcode.FindDuplicate(new int[] { 1, 3, 4, 2, 2 }));

Console.WriteLine("September 24, 2023 - 799. Champagne Tower");
Console.WriteLine("Failed");

Console.WriteLine("September 25, 2023 - 389. Find the Difference");
Console.WriteLine("Answer > " + DailyLeetcode.FindTheDifference("abcd", "abcde"));

Console.WriteLine("September 26, 2023 - RemoveDuplicateLetters");
Console.WriteLine("Answer > " + DailyLeetcode.RemoveDuplicateLetters("cbacdcbc"));

Console.WriteLine("September 27, 2023 - 880. Decoded String at Index");
Console.WriteLine("Answer > " + DailyLeetcode.DecodeAtIndex("a2345678999999999999999", 1));

Console.WriteLine("September 29, 2023 - 896. Monotonic Array");
Console.WriteLine(DailyLeetcode.IsMonotonic(new int[] { 6, 5, 4, 4 }));

Console.WriteLine("September 30,2023 - 557. Reverse Words in a String III");
Console.WriteLine(DailyLeetcode.ReverseWords("Let's take LeetCode contest"));

Console.WriteLine("October 02,2023 - 2038. Remove Colored Pieces if Both Neighbors are the Same Color");
Console.WriteLine(DailyLeetcode.WinnerOfGame("AA"));

Console.WriteLine("Octobe 03,2023 - 1512. Number of Good Pairs");
Console.WriteLine(DailyLeetcode.NumIdenticalPairs(new int[] { 1, 2, 3, 1, 1, 3 }));

Console.WriteLine("88. Merge Sorted Array");
TopInterview150.Merge(new int[] { 4, 5, 6, 0, 0, 0 }, 3, new int[] { 1, 2, 3 }, 3);

Console.WriteLine("27.Remove Element");
Console.WriteLine(TopInterview150.RemoveElement(new int[] { 3, 2, 2, 3 }, 3));

Console.WriteLine("26. Remove Duplicates from Sorted Array");
Console.WriteLine(TopInterview150.RemoveDuplicates(new int[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 }));

Console.WriteLine("26. Remove Duplicates from Sorted Array II");
Console.WriteLine(TopInterview150.RemoveDuplicatesII(new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 }));

Console.WriteLine("Octobe 04,2023 - 706. Design HashMap");
var x = new MyHashMap();
x.Put(1, 10);
x.Put(1, 11);
x.Put(2, 2);
x.Get(1);
x.Remove(1);

Console.WriteLine("169. Majority Element");
Console.WriteLine(TopInterview150.MajorityElement(new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 }));

Console.WriteLine("189. Rotate Array");
TopInterview150.RotateArray(new int[] { 1, 2, 3, 4, 5, 6, 7 }, 3);

Console.WriteLine("121. Best Time to Buy and Sell Stock");
Console.WriteLine(TopInterview150.MaxProfit(new int[] { 1, 2 }));

Console.WriteLine("122. Best Time to Buy and Sell Stock II");
Console.WriteLine(TopInterview150.MaxProfitII(new int[] { 7, 1, 5, 3, 6, 4 }));

Console.WriteLine("55. Jump Game");
Console.WriteLine(TopInterview150.CanJump(new int[] { 2, 3, 1, 1, 4 }));