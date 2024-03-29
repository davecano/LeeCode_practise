﻿/**************************************************************** 
* 作    者 ：ChenXuan
* 创建时间 ：2021/5/11 19:55:48
* 描述说明： 
****************************************************************/
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace _2021_05
{
    internal class _20200511 : Singleton<_20200511>
    {
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnhbqj/
        /// </summary>
        /// <param name="s"></param>
        public void ReverseString(char[] s)
        {
            char temp;
            int loop = s.Length / 2;
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
            int res = 0;
            int s = x;
            while (s != 0)
            {
                int t = s % 10;
                s /= 10;
                int newRes = res * 10 + t;

                if ((newRes - t) / 10 != res)
                {
                    return 0;
                }

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
            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                map[s[i]] = map.TryGetValue(s[i], out int t) ? t + 1 : 1;
            }
            for (int i = 0; i < s.Length; i++)
            {
                if (map[s[i]] == 1)
                {
                    return i;
                }
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
            if (s.Length != t.Length)
            {
                return false;
            }

            Dictionary<char, int> map = new Dictionary<char, int>();
            for (int i = 0; i < s.Length; i++)
            {
                map[s[i]] = map.TryGetValue(s[i], out int m) ? m + 1 : 1;
            }
            for (int i = 0; i < t.Length; i++)
            {
                if (!map.ContainsKey(t[i]) || map[t[i]] == 0)
                {
                    return false;
                }
                else
                {
                    map[t[i]]--;
                }
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
            int left = 0, right = s.Length - 1;
            while (left < right)
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
                if (char.ToLower(s[left]) != char.ToLower(s[right]))
                {
                    return false;
                }

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
            if (string.IsNullOrWhiteSpace(s))
            {
                return 0;
            }

            int i = 0;
            int res = 0;
            for (; i < s.Length; i++)
            {
                if (s[i] == ' ')
                {
                    continue;
                }

                if (s[i] == '-')
                {
                    isNagative = true;
                    i++;
                    break;
                }
                if (s[i] == '+')
                {
                    i++;
                    break;
                }
                if (char.IsDigit(s[i]))
                {
                    break;
                }
                else
                {
                    return 0;
                }
            }

            for (int j = i; j < s.Length; j++)
            {
                if (char.IsDigit(s[j]))
                {
                    int newres = res * 10 + (s[j] - '0');
                    if (newres / 10 != res)
                    {
                        return isNagative ? int.MinValue : int.MaxValue;
                    }

                    res = newres;
                    continue;
                }
                break;
            }
            return isNagative ? res * -1 : res;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnr003/
        /// </summary>
        /// <param name="haystack"></param>
        /// <param name="needle"></param>
        /// <returns></returns>
        public int StrStr(string haystack, string needle)
        {
            if (needle == string.Empty)
            {
                return 0;
            }

            if (haystack == string.Empty)
            {
                return -1;
            }

            int index = 0;
            for (int i = 0; i < haystack.Length; i++)
            {
                if (haystack[i] == needle[index])
                {
                    if (index == needle.Length - 1)
                    {
                        return i - needle.Length + 1;
                    }

                    index++;
                    continue;
                }
                i -= index;
                index = 0;
            }
            return -1;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnpvdm/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public string CountAndSay(int n)
        {

            if (n == 1)
            {
                return "1";
            }

            string num = CountAndSay(n - 1);
            int index = 0;
            List<char> resList = new List<char>();
            int numCount = 1;
            int i = 0;
            for (; i < num.Length - 1; i++)
            {
                if (num[i] == num[++index])
                {
                    numCount++;
                    continue;
                }
                resList.Add((char)(numCount + '0'));
                resList.Add(num[i]);
                numCount = 1;
            }
            resList.Add((char)(numCount + '0'));
            resList.Add(num[i]);
            return new string(resList.ToArray());
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnmav1/
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public string LongestCommonPrefix(string[] strs)
        {

            //List<char> resList = new List<char>();
            //int i = 0;
            //for (; i < strs.Select(x => x.Length).Min(); i++)
            //{
            //    int index = 0;
            //    bool predicate = true;
            //    for (int j = 0; j < strs.Length - 1; j++)
            //    {
            //        if (strs[j][i] != strs[++index][i])
            //        {
            //            predicate = false;
            //            break;
            //        }
            //    }

            //    if (!predicate)
            //    {
            //        break;
            //    }
            //}

            //return strs[0].Substring(0, i);

            string pre = strs[0];
            foreach (var str in strs)
            {
                while (pre.Length > 0)
                {
                    if (str.IndexOf(pre)!=0)
                        pre = pre.Substring(0, pre.Length - 1);
                    else break;
                }
            
            }
            return pre;
        }
    }
}
