using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Utils;

namespace _2020_01_05
{
  public  class _202001:Singleton<_202001>
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

 */
        public class Solution
        {
            public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
            {
                return null;
            }
        }

         public class ListNode
        {
                public int val;
                public ListNode next;
                public ListNode(int x) { val = x; }
         }
        #endregion
    }

 
}
