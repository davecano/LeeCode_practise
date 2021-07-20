using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utils;

namespace _2021_05
{
    class _20210707:Singleton<_20210707>
    {
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xn1m0i/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int HammingWeight(uint n)
        {
            //转成二进制
            var bNum=new List<bool>();
            while (n>0)
            {
                var t = n % 2;
                n= n / 2;
                bNum.Insert(0, t==0);
            }
            return bNum.Count(t => !t);
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnyode/
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int HammingDistance(int x, int y)
        {
            var temp = x ^ y;
            int count=0;
            while (temp>0)
            {
                temp = temp >> 1;
              if ((temp & 1) == 1)
                {
                    count++;
                }  
            }
            return count;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnc5vg/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public uint reverseBits(uint n)
        {
            uint res = 0;
            for (int i = 0; i < 32; i++)
            {
                //res先往左移一位，把最后一个位置空出来，
                //用来存放n的最后一位数字
                res <<= 1;
                //res加上n的最后一位数字
                res |= ( n & 1);
                //n往右移一位，把最后一位数字去掉
                n >>= 1;
            }
            return res;

        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xncfnv/
        /// </summary>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public IList<IList<int>> Generate(int numRows)
        {
            var res = new List<IList<int>>();
            res.Add(new List<int>() { 1 });
            if (numRows == 1) return res;
         
            for (int i = 1; i < numRows; i++)
            {
                var list = new List<int>(i+1);
                res.Add(list);
                res[i].Add(1);
                for (int j = 1; j < i; j++)
                {
                    res[i].Add(res[i - 1][j-1]+res[i-1][j]);
                }
                res[i].Add(1);
            }

            return res;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnbcaj/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
       private char GetMatchChar(char c)
        {
            if (c == '(') return ')';
            if (c == '[') return ']';
            if (c == '{') return '}';
            return '*';
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnbcaj/
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            foreach (var c in s)
            {
                if (stack.Count > 0 && GetMatchChar(stack.Peek()) == c)
                    stack.Pop();
                else
                    stack.Push(c);
            }
            return stack.Count == 0;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnj4mt/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MissingNumber(int[] nums)
        {
//            a ^ a = 0；自己和自己异或等于0

//a ^ 0 = a；任何数字和0异或还等于他自己

//a ^ b ^ c = a ^ c ^ b；异或运算具有交换律
            //int n = nums.Length;
            //var map = new Dictionary<int, int>();
            //for (int i = 0; i < n; i++)
            //{
            //    map[nums[i]] = map.TryGetValue(nums[i], out var t) ? t + 1 : 1;
            //}
            //for (int i = 0; i <= n; i++)
            //{
            //    if (!map.TryGetValue(i, out var t)) return i;
            //}
            //return -1;
            int xor = 0;
            for (int i = 0; i < nums.Length; i++)
                xor ^= nums[i] ^ (i + 1);
            return xor;

        }
    }
}
