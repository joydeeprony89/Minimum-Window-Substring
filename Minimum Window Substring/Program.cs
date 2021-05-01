using System;

namespace Minimum_Window_Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "babbcabba";
            string t = "abc";
            Console.WriteLine(MinWindow(s, t));
        }

        static string MinWindow(string s, string t)
        {
            int[] map = new int[128];
            foreach (char c in t) map[c]++;
            int left = 0, right = 0, minleft = 0, minlen = int.MaxValue, count = t.Length;
            while (right < s.Length)
            {
                char c = s[right];
                int hashValue = map[c]; // reference variable during debugging
                if (map[c] > 0) count--;
                right++;map[c]--;
                while(count == 0)
                {
                    if(right - left < minlen)
                    {
                        minlen = right - left;
                        minleft = left;
                    }
                    char cc = s[left];
                    hashValue = map[cc]; // reference variable during debugging
                    map[cc]++;
                    if (map[cc] > 0) count++;
                    left++;
                }
            }

            return minlen == int.MaxValue ? "" : s.Substring(minleft, minlen);
        }
    }
}
