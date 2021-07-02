using System;
using System.Collections.Generic;
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

        }
    }
}
