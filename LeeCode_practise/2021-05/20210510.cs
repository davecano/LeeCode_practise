/**************************************************************** 
* 作    者 ：ChenXuan
* 创建时间 ：2021/5/10 18:50:01
* 描述说明： 
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace _2021_05
{

    public class Solution : Singleton<Solution>
    {/// <summary>
     /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/x2gy9m/
     /// </summary>
     /// <param name="nums"></param>
     /// <returns></returns>
        public int RemoveDuplicates(int[] nums)
        {
            if (nums == null || nums.Length == 0)
            {
                return 0;
            }

            int left = 0;
            for (int right = 1; right < nums.Length; right++)
            {
                if (nums[right] != nums[left])
                {
                    nums[++left] = nums[right];
                }
            }
            return ++left;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/x2zsx1/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            //if (prices == null || prices.Length < 2) return 0;
            //int index = 0; int length = prices.Length;
            //int Profit=0;
            //while (index < length)
            //{
            //    while (index < length-1 && prices[index] > prices[index+1])
            //        index++;
            //    int startRise = index;
            //    while (index < length-1 && prices[index] < prices[index+1])
            //        index++;
            //    Profit += prices[index++] - prices[startRise];

            //}
            //return Profit;
            if (prices == null || prices.Length < 2)
            {
                return 0;
            }

            int total = 0;
            for (int i = 0; i < prices.Length - 1; i++)
            {
                total += Math.Max(prices[i + 1] - prices[i], 0);
            }
            return total;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/x2skh7/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="k"></param>
        public void Rotate(int[] nums, int k)
        {
            if (nums == null || nums.Length == 0 || k < 0) return;
            if (nums == null || nums.Length == 0 || k < 0) return;
            k = k % nums.Length;
            int[] temp = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                temp[i] = nums[i];
            }
            for (int i = 0; i < nums.Length; i++)
            {
                nums[(i + k) % nums.Length] = temp[i];
            }
            //if (nums == null || nums.Length == 0 || k < 0)
            //{
            //    return;
            //}

            //int[] temp = new int[nums.Length];
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    temp[i] = nums[i];
            //}
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    nums[(i + k) % nums.Length] = temp[i];
            //}
            //找到移动后末尾的数字
            //int temp = nums[nums.Length - k - 1];
            //nums[nums.Length - k - 1]=
        }

        public void Rotatenew(int[] nums, int k)
        {
            if (k >= nums.Length)
                Rotate(nums, k % nums.Length);
            else
            {
                int[] temp = new int[nums.Length];
                for (int i = 0; i < nums.Length; i++)
                {
                    temp[i] = nums[i];
                }
                for (int i = 0; i < nums.Length; i++)
                {
                    nums[i] = temp[getNewIndex(nums.Length, k, i)];
                }
            }
        }
        public int getNewIndex(int length, int k, int index)
        {
            return (index + k) % length;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/x248f5/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public bool ContainsDuplicate(int[] nums)
        {
            HashSet<int> set = new HashSet<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                set.Add(nums[i]);
            }
            return set.Count != nums.Length;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/x21ib6/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int SingleNumber(int[] nums)
        {
            int reduce = 0;
            foreach (int num in nums)
            {
                reduce ^= num;
            }
            return reduce;
        }

        public (int a, int b) TwoDifferentNumber(int[] nums) {
            int eor = 0;
            foreach (int num in nums)
            {
                eor ^= num;
            }
            //异或出的结果为 a^b !=0 以为a！=b
            int temp = eor & (~eor + 1);
            int seor = 0;
            foreach (int num in nums)
            {
                if ((num & temp) == 0) {
                    seor ^= num;
                }
            }
            return (seor, eor ^ seor);
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/x2y0c2/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="nums2"></param>
        /// <returns></returns>
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            //Array.Sort(nums1);
            //Array.Sort(nums2); 
            //var res = new List<int>();
            //int point1=0, point2 = 0;

            //while (point1<nums1.Length&&point2<nums2.Length)
            //{
            //    if (nums1[point1] > nums2[point2])
            //        point2++;
            //    else if (nums1[point1] < nums2[point2])
            //        point1++;
            //    else
            //    {
            //        res.Add(nums1[point1]);
            //        point1++;
            //        point2++;
            //    }
            //}
            //return res.ToArray();

            Dictionary<int, int> map = new Dictionary<int, int>();
            List<int> res = new List<int>();
            for (int i = 0; i < nums1.Length; i++)
            {
                map[nums1[i]] = (map.TryGetValue(nums1[i], out int t) ? t : 0) + 1;
            }
            for (int i = 0; i < nums2.Length; i++)
            {
                if (map.TryGetValue(nums2[i], out int t))
                {
                    if (t > 0)
                    {
                        res.Add(nums2[i]);
                        map[nums2[i]] = map[nums2[i]] - 1;
                    }

                }
            }
            return res.ToArray();
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/x2cv1c/
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public int[] PlusOne(int[] digits)
        {
            List<int> list = digits.ToList();
            bool isAdd = false;
            for (int i = list.Count() - 1; i >= 0; i--)
            {
                if (list[i] < 9)
                {
                    list[i]++;
                    isAdd = false;
                    break;
                }
                else
                {
                    list[i] = 0;
                    isAdd = true;
                }
            }
            if (isAdd)
            {
                list.Insert(0, 1);
            }

            return list.ToArray();
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/x2ba4i/
        /// </summary>
        /// <param name="nums"></param>
        public void MoveZeroes(int[] nums)
        {
            //int index = 0;
            //int zeroCount = 0;
            //while (index < nums.Length - zeroCount-1)
            //{

            //    if (nums[index] == 0)
            //    {
            //        int j = index + 1;
            //        for (; j < nums.Length - zeroCount; j++)
            //        {
            //            nums[j - 1] = nums[j];
            //        }
            //        nums[j-1] = 0;
            //        zeroCount++;

            //    }
            //    else
            //    {
            //        index++;
            //    }
            //}
            //int index = 0;
            ////for (int i = 0; i < nums.Length; i++)
            ////{
            ////    if (nums[i] != 0)
            ////        nums[index++] = nums[i];

            ////}
            ////for (int i = index; i < nums.Length; i++)
            ////{
            ////    nums[i] = 0;
            ////}
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    if (nums[i] != 0)
            //    {
            //        int temp = nums[index];
            //        nums[index] = nums[i];
            //        nums[i] = temp;
            //        index++;
            //    }
            //}
            int left = 0;
            for (int right = 0; right < nums.Length; right++)
            {
                if (nums[right] != 0)
                {
                    if (nums[left] == 0){
                nums[left] = nums[right];
                nums[right] = 0;
            }
            left++;
        }
    }
}
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/x2jrse/
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public int[] TwoSum(int[] nums, int target)
        {
            // if (nums != null || nums.Length == 0) return null;
            //for (int i = 0; i < nums.Length-1; i++)
            // {
            //     for (int j =i+1 ; j < nums.Length; j++)
            //     {
            //         if (nums[j] + nums[i] == target)
            //             return new int[] { j, i };
            //     }

            // }
            // return null;
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
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnhhkv/
        /// </summary>
        /// <param name="matrix"></param>
        public void Rotate(int[][] matrix)
        {
            int len = matrix.Length;
            //上下交换
            int p1 = 0;
            int p2 = len - 1;
            while (p1 < p2)
            {
                int[] temp = matrix[p1];
                matrix[p1] = matrix[p2];
                matrix[p2] = temp;
                p1++;
                p2--;
            }

            //对角线交换 永远考虑列》行的
            for (int i = 0; i < len - 1; i++)
            {
                for (int j = 1; j < len; j++)
                {
                    if (i < j)
                    {
                        int temp = matrix[i][j];
                        matrix[i][j] = matrix[j][i];
                        matrix[j][i] = temp;
                    }
                }
            }
        }
    }
}


