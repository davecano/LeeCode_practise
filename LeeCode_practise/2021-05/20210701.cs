using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace _2021_05
{
   public class _20210701:Singleton<_20210701>
    {
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xngt85/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public IList<string> FizzBuzz(int n)
        {
            var res = new List<string>(n);
            for (int i = 1; i <= n; i++)
            {
                string outStr = i.ToString();
                if (i % 15 == 0) outStr = "FizzBuzz";
                else if (i % 5 == 0) outStr = "Buzz";
                else if (i % 3 == 0) outStr = "Fizz";
                    res.Add(outStr);
            }
            return res;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnzlu6/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int CountPrimes(int n)
        {
            //if (n < 3) return 0;
            //int res = 1;
            //for (int i = 3; i < n; i += 2)
            //{
            //    bool isPrime = true;
            //    for (int j = 3; j <= Math.Sqrt(i); j += 2)
            //    {
            //        if (i % j == 0)
            //        {
            //            isPrime = false;
            //            break;
            //        }
            //    }
            //    if (isPrime) res++;
            //}
            //return res;

            //埃拉托斯特尼筛法
            if (n < 3) return 0;
            //假设改数组放的都是合数，a[0] 无意义
            bool[] notPrimes = new bool[n];
            int count = 0;
            for (int i = 2; i <=Math.Sqrt(n) ; i++)
            {
                if (notPrimes[i]) continue;
                count++;
                for (int j = i; j < n; j*=i)
                {
                    notPrimes[j] = true;
                }
            }
            return count;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnsdi2/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsPowerOfThree(int n)
        {
            return (n > 0 && 1162261467 % n == 0);
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xn4n7c/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private readonly IDictionary<char, int> map = new Dictionary<char, int>()
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000,
        };
        private readonly char[] d = new char[] {'I','V','X','L','C','D','M' };
        private readonly char[] e = new char[] { 'I',  'X',  'C'};
        public int RomanToInt(string s)
        {
            var res = 0;
            char t = '0';
            foreach (char v in s)
            {
                if (e.Contains(v)) {
                    if (t == '0')
                    {
                        t = v;
                        continue;
                    }
                    res = CalcNum(res, t, v);
                    t = '0';
                }
                else
                {
                    if(t=='0')
                    res += map[v];
                    else
                    {
                        res = CalcNum(res, t, v);
                        t = '0';
                    }

                }
            }
            if (t != '0') res += map[t];
            return res;
        }

        private int CalcNum(int res, char t, char v)
        {
            if (map[t] * 5 == map[v]|| map[t] * 10 == map[v])
                res += (map[v] - map[t]);
            else
                res += (map[t] + map[v]);
            return res;
        }
        private readonly IDictionary<string, int> mapNew = new Dictionary<string, int>()
        {
            ["I"] = 1,
            ["V"] = 5,
            ["X"] = 10,
            ["L"] = 50,
            ["C"] = 100,
            ["D"] = 500,
            ["M"] = 1000,

            ["IV"] = 4,
            ["IX"] = 9,
            ["XL"] = 40,
            ["XC"] = 90,
            ["CD"] = 400,
            ["CM"] = 900,
        };
        /// <summary>
        /// 上面的有点问题
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToIntNew(string s)
        {
            var res = 0;
            char t = '0';
            foreach (var c in s)
            {
                if (e.Contains(c))
                {
                    if (t == '0')
                    {
                        t = c;
                        continue;
                    }
                    CalcNum(ref res, ref t, c);
                }

                else
                {
                    if (t == '0')
                        res += mapNew[c.ToString()];
                    else
                    {
                        CalcNum(ref res, ref t, c);
                    }
                }
            }
            if (t != '0') res += mapNew[t.ToString()];
            return res;
        }

        private void CalcNum(ref int res, ref char t, char c)
        {
            var key = t + "" + c;
            if (mapNew.ContainsKey(key))
            {
                res += mapNew[key];
            }
            else
            {
                res += (mapNew[t.ToString()] + mapNew[c.ToString()]);
            }
            t = '0';
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xn4n7c/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public int RomanToIntN(string s)
        {
            int res=0;
            for (int i = 0; i < s.Length;)
            {
                if (i + 1 < s.Length && mapNew.ContainsKey(s.Substring(i, 2)))
                {
                    res += mapNew[s.Substring(i, 2)];
                    i += 2;
                }
                else
                {
                    res += mapNew[s[i].ToString()];
                    i++;
                }
            }
            return res;
        }
    }
  
}
