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
            return 0;
        }
        #endregion

    }


}
