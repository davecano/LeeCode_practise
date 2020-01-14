using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Utils;

namespace _2020_01_05
{
    public class _202001 : Singleton<_202001>
    {

        #region 两数之和

        public int[] TwoSum(int[] nums, int target)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (target.Equals(nums[i] + nums[j]))
                    {
                        return new[] { i, j };
                    }
                }
            }

            return null;
        }
        /// <summary>
        /// 算法优化
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum2(int[] nums, int target)
        {
            int[] indexs = new int[2];
            // 建立k-v ，一一对应的哈希表
            IDictionary<int, int> hash = new Dictionary<int, int>();
            for (int i = 0; i < nums.Length; i++)
            {
                if (hash.ContainsKey(nums[i]))
                {
                    indexs[0] = i;
                    indexs[1] = hash[nums[i]];
                    return indexs;
                }
                // 将数据存入 key为补数 ，value为下标
                hash[target - nums[i]] = i;
            }

            return indexs;
        }

        #endregion
        #region 两数相加
        /**
 * Definition for singly-linked list.
 输入：(2 -> 4 -> 3) + (5 -> 6 -> 4)
输出：7 -> 0 -> 8
原因：342 + 465 = 807
 */

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            l1 = new ListNode(1);
            l1.next = new ListNode(8);

            l2 = new ListNode(0);

            bool isAddOne;
            ListNode l;

            int sum = 0;
            //把第一个先捞出来
            if (l1 != null || l2 != null)
            {

                sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val);
                //个位数
                l = new ListNode(sum % 10);
                isAddOne = sum / 10 == 1;
                l1 = l1.next;
                l2 = l2.next;

            }
            else return null;

            ListNode res = l;
            while (l1 != null || l2 != null)
            {

                sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + (isAddOne ? 1 : 0);
                //个位数
                l.next = new ListNode(sum % 10);
                isAddOne = (sum / 10) == 1;
                if (l1 != null) l1 = l1.next;
                if (l2 != null) l2 = l2.next;
                l = l.next;
            }

            if (isAddOne)
            {
                l.next = new ListNode(1);
            }
            return res;
        }

        public ListNode AddTwoNumbers2(ListNode l1, ListNode l2)
        {
            l1 = new ListNode(2);
            l1.next = new ListNode(4);
            l1.next.next = new ListNode(3);
            l2 = new ListNode(5);
            l2.next = new ListNode(6);
            l2.next.next = new ListNode(4);
            if (l1 == null)
            {
                return l2;
            }
            if (l2 == null)
            {
                return l1;
            }
            int jinwei = 0;
            ListNode res = new ListNode(-1);
            ListNode tmp = res;
            while (l1 != null || l2 != null)
            {
                int val1 = l1 == null ? 0 : l1.val;
                int val2 = l2 == null ? 0 : l2.val;
                int sum = val1 + val2 + jinwei;
                res.next = new ListNode(sum % 10);
                res = res.next;
                jinwei = sum / 10;
                if (l1 != null)
                {
                    l1 = l1.next;
                }
                if (l2 != null)
                {
                    l2 = l2.next;
                }
            }

            if (jinwei == 1)
            {
                res.next = new ListNode(1);
            }
            return tmp.next;
        }




        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
        #endregion
        #region 无重复字符的最长子串
        public int LengthOfLongestSubstring(string s)
        {

            int ans = 0;
            int[] index = new int[128]; // current index of character
            // try to extend the range [left, right]
            int left = 0;
            for (int right = 0; right < s.Length; right++)
            {
                //
                left = Math.Max(index[s[right]], left);
                ans = Math.Max(ans, right - left + 1);
                index[s[right]] = right + 1; // set current index of character
            }
            return ans;

        }
        //自己解决  c  pafga 暂时有问题，以后再搞
        //public int LengthOfLongestSubstring(string s)
        //{
        //    //哈希来做 key存储 char的值，value 存储下标索引
        //    IDictionary<char, int> hash = new Dictionary<char, int>();
        //    int max = 0;
        //    if (s.Length == 0) return max;
        //    int left = 0;
        //    for (int right = 0; right < s.Length; right++)
        //    {
        //        if (hash.ContainsKey(s[right]))
        //        {
        //            left = s[right];
        //        }

        //        hash[s[right]] = right;
        //        max = Math.Max(max, right - left + 1);

        //    }

        //    return max;
        //}
        #endregion
        #region 4. 寻找两个有序数组的中位数 https://leetcode-cn.com/problems/median-of-two-sorted-arrays/



        #endregion
        #region 5. 最长回文子串 https://leetcode-cn.com/problems/longest-palindromic-substring/

        public string LongestPalindrome(string s)
        {
            return null;
        }

        #endregion

        #region Z 字形变换 https://leetcode-cn.com/problems/zigzag-conversion/

    
        /// <summary>
        /// x的轨迹   012321 01232 10          4     0121 0121 012                   3
        /// y的轨迹   000012 333345 6         4     0001 2223 4445                  3
        /// 对x y进行移位操作
        /// </summary>
        /// <param name="numRows"></param>
        /// <param name="i"></param>
        /// <returns></returns>
      
        private (int x,int y) change(int numRows,int i)
        {
            var m = i / (2 * (numRows - 1));
            var n = i % (2 * (numRows - 1));
            int[] tempx=new int[2*(numRows - 1)];
            int index = 0;
            for (int j = 0; j < tempx.Length; j++)
            {
             tempx[j] = j < numRows - 1 ? index++ : index--;
            }

            int x = tempx[i % (2 * (numRows - 1))];
            int y;
            if (n < numRows)
            {
                y = m * (numRows - 1);
            }
            else
            {
                y = m * (numRows - 1) + n - numRows+1;
            }

          
            return (x, y);
        }
        public string Convert(string s, int numRows)
        {
            if (numRows == 1) return s;
            int p = 100;
            char[,] arr=new char[numRows,p];
            int x, y;
            for (var i = 0; i < s.Length; i++)
            {
               
                (x, y) = change(numRows, i);
                arr[x,y] = s[i];
              
            }
            var list=new List<char>();
            for (int a = 0; a < numRows; a++)
            {
                for (int b = 0; b <p; b++)
                {
                   if(arr[a,b]!= '\0')  list.Add(arr[a,b]);
                }
            }

            return new string(list.ToArray());
        }

        public void DisPlayConvert()
        {
            Console.WriteLine(this.Convert("A", 1));
          
        }
        #endregion
    }


}
