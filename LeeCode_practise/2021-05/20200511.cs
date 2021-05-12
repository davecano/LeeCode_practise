/**************************************************************** 
* 作    者 ：ChenXuan
* 创建时间 ：2021/5/11 19:55:48
* 描述说明： 
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace _2021_05
{
    class _20200511 : Singleton<_20200511>
    {
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnhbqj/
        /// </summary>
        /// <param name="s"></param>
        public void ReverseString(char[] s)
        {
            char temp;
            var loop = s.Length / 2;
            for (int i = 0; i < loop; i++)
            {
                temp = s[i];
                s[i] = s[s.Length - i - 1];
                s[s.Length - i - 1] = temp;

            }
    
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnx13t/
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int Reverse(int x)
        {
            //1234=> %10 4 /10 123=> %10 3 /10 12=>%10 2 /10 1=> %10 1 /10=>0 
            var res = 0;
            var s = x;
            while (s !=0)
            {
                var t = s % 10;
                s /= 10;
                var newRes = res * 10 + t;
             
                if ((newRes-t)/10!=res) return 0;
                res = newRes;
            }
            return res;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xn5z8r/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
         
        public int FirstUniqChar(string s)
        {
            var map = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                map[s[i]] = map.TryGetValue(s[i], out var t) ? t + 1 : 1;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (map[s[i]] == 1) return i; 
            }
            return -1;
         
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xn96us/
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length) return false;
            var map = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                map[s[i]] = map.TryGetValue(s[i], out var m) ? m + 1 : 1;
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (!map.ContainsKey(t[i]) || map[t[i]] == 0) return false;
                else map[t[i]]--;
            }
            return true;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xne8id/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsPalindrome(string s)
        {
            int left = 0,right=s.Length-1;
            while (left<right)
            {
                if (!char.IsLetterOrDigit(s[left]))
                {
                    left++;
                    continue;
                }
                if (!char.IsLetterOrDigit(s[right]))
                {
                    right--;
                    continue;
                }
                if (char.ToLower(s[left]) != char.ToLower(s[right])) return false;
                left++;
                right--;
            }
            return true;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnoilh/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int MyAtoi(string s)
        {
            //var str= s.Trim();
            // int index = 0;
            // int res = 0;
            // for (int i = str.Length-1; i >= 0; i--)
            // {
            //     if (char.IsDigit(str[i]))
            //     {
            //         res += index * 10 * str[i];
            //         index++;
            //     }
            //     if(str[i])
            // }
            bool isNagative = false;
            if (string.IsNullOrWhiteSpace(s)) return 0;
            int i = 0;
            int res = 0;
            for (; i < s.Length; i++)
            {
                if (s[i] == ' ') continue;
                if (s[i] == '-')
                {
                    isNagative = true;
                    continue;
                }
                if (s[i] == '+') continue;
                if (char.IsDigit(s[i])) break;
            }
            int index = 0;
            for (int j = i; j < s.Length; j++)
            {
                if (char.IsDigit(s[j]))
                {
                    var newres = res * index * 10 + (s[j]-'0');
                    if (newres - (s[j] - '0') != res * index * 10) return isNagative ? int.MinValue : int.MaxValue;
                    res = newres;
                    index++;
                    continue;
                }
                break;
            }
            return isNagative? res*-1: res;
        }
    }
}
