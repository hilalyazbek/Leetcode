// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using CodingChallenges;

Console.WriteLine("LEETCODE CODING CHALLENGES");
Console.WriteLine("__________________________");

Console.WriteLine("\n\n1480. Running Sum of 1d Array");
Console.WriteLine("*****************************");
Console.WriteLine(Level1.RunningSum(new int[] { 1, 5, 2, 6, 7, 4 }));

Console.WriteLine("\n724.Find Pivot Index");
Console.WriteLine("********************");
Console.WriteLine(Level1.PivotIndex(new int[] { 1, 7, 3, 6, 5, 6 }));

Console.WriteLine("\n205.Isomorphic Strings");
Console.WriteLine("**********************");
Console.WriteLine(Level1.IsIsomorphic("bbbaaaba", "aaabbbba"));

Console.WriteLine("\n392. Is Subsequence");
Console.WriteLine("**********************");
Console.WriteLine(Level1.IsSubsequence("ab", "baab"));

Console.WriteLine("\n21.Merge Two Sorted Lists");
Console.WriteLine("***************************");

Console.WriteLine("\n206. Reverse Linked List");
Console.WriteLine("**************************");

Console.WriteLine("\n876.Middle of the Linked List");
Console.WriteLine("*******************************");
Level1.MiddleNode(new Level1.ListNode(0, null));

Console.WriteLine("\n142.Linked List Cycle II");
Console.WriteLine("**************************");

Console.WriteLine("\n121.Best Time to Buy and Sell Stock");
Console.WriteLine("*************************************");
Console.WriteLine(Level1.MaxProfit(new int[] { 7, 1, 5, 3, 6, 4 }));

Console.WriteLine("\n409.Longest Palindrome");
Console.WriteLine("************************");
Console.WriteLine(Level1.LongestPalindrome("abccccdd"));

Console.WriteLine("\n589.N - ary Tree Preorder Traversal");
Console.WriteLine("*************************************");

Console.WriteLine("\n102.Binary Tree Level Order Traversal");
Console.WriteLine("***************************************");

Console.WriteLine("\n704.Binary Search");
Console.WriteLine("*******************");
Console.WriteLine(Level1.BinarySearch(new[] { -1, 0, 3, 5, 9, 12 }, 9));

Console.WriteLine("\n704.Binary Search Recursive");
Console.WriteLine("*******************");
Console.WriteLine(Level1.BinarySearchRecursive(new[] { -1, 0, 3, 5, 9, 12 }, 9));

Console.WriteLine("\n278. First Bad Version");
Console.WriteLine("*******************");
Console.WriteLine(Level1.FirstBadVersion(5));

Console.WriteLine("\n98. Validate Binary Search Tree");
Console.WriteLine("*********************************");

Console.WriteLine("\n733. Flood Fill");
Console.WriteLine("*****************");

Console.WriteLine("\n200. Number of Islands");
Console.WriteLine("************************");

Console.WriteLine("\n977.Squares of a Sorted Array");
Console.WriteLine("*******************************");
Console.WriteLine(AlgorithmI.SortedSquares(new int[] { -4, -1, 0, 3, 10 }));

Console.WriteLine("\n189. Rotate Array");
Console.WriteLine("*******************");

Console.WriteLine("\nSort People");
Console.WriteLine("*************");
AlgorithmI.SortPeople(new string[] { "Mary", "John", "Emma" }, new int[] { 180, 165, 170 });

Console.WriteLine("\n438. Find All Anagrams in a String");
Console.WriteLine("************************************");
Console.WriteLine(Level1.FindAnagrams("cbaebabacd", "abc"));

Console.WriteLine("\n424. Longest Repeating Character Replacement");
Console.WriteLine("**********************************************");
Console.WriteLine(Level1.CharacterReplacement("AABABBA", 1));

Console.WriteLine("\n1. Two Sum");
Console.WriteLine("************");
Console.WriteLine(Level1.TwoSum(new int[] { 1, 1, 1, 1, 1, 4, 1, 1, 1, 1, 1, 7, 1, 1, 1, 1, 1 }, 11));

Console.WriteLine("\n283. Move Zeroes");
Console.WriteLine("******************");
AlgorithmI.MoveZeroes(new int[] { 1, 0, 1 });

Console.WriteLine("\n167.Two Sum II - Input Array Is Sorted");
Console.WriteLine("****************************************");
AlgorithmI.TwoSum(new int[] {2, 7, 11, 15 }, 9);

Console.WriteLine("\n344. Reverse String");
Console.WriteLine("*********************");
AlgorithmI.ReverseString("hello".ToCharArray());

Console.WriteLine("\n557. Reverse Words in a String III");
Console.WriteLine("************************************");
Console.WriteLine(AlgorithmI.ReverseWords("Let's take LeetCode contest"));

Console.WriteLine("\n876. Middle of the Linked List");
Console.WriteLine("********************************");

Console.WriteLine("\n19.Remove Nth Node From End of List");
Console.WriteLine("********************************");

Console.WriteLine("\n3. Longest Substring Without Repeating Characters");
Console.WriteLine("***************************************************");
Console.WriteLine(AlgorithmI.LengthOfLongestSubstring("pwwkew"));

Console.WriteLine("\n567.Permutation in String");
Console.WriteLine("***************************");
AlgorithmI.CheckInclusion("adc", "dcda");

Console.WriteLine("\n299. Bulls and Cows");
Console.WriteLine("***************************");
Console.WriteLine(Level1.GetHint("1807", "7810"));

Console.WriteLine("\n844.Backspace String Compare");
Console.WriteLine("***************************");
Level1.BackspaceCompare("abcd","bbcd");

Console.WriteLine("\n394. Decode String");
Console.WriteLine("*********************");
Level1.DecodeString("3[a]2[bc]");
