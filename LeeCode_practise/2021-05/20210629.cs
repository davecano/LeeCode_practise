/**************************************************************** 
* 作    者 ：ChenXuan
* 创建时间 ：2021/6/29 18:57:11
* 描述说明： 
****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace _2021_05
{
   public class _20210629 : Singleton<_20210629>
    {
        public class Solution
        {
            private readonly int[] nums;
            /// <summary>
            /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xn6gq1/
            /// </summary>
            /// <param name="nums"></param>
            public Solution(int[] nums)
            {
                this.nums = nums;
            }

            /** Resets the array to its original configuration and return it. */
            public int[] Reset()
            {
                return nums;
            }

            /** Returns a random shuffling of the array. */
            public int[] Shuffle()
            {
                var length = nums.Length;
                int[] arrNumber = new int[length];
                Array.Copy(nums, arrNumber, length);
                Random rand = new Random();
                for (int i = 0; i < length; i++)
                {
                    int randIndex = rand.Next(i, length);
                    // 交换两个数字
                    int temp = arrNumber[i];
                    arrNumber[i] = arrNumber[randIndex];
                    arrNumber[randIndex] = temp;
                }
                return arrNumber;
            }
        }
        public class MinStack
        {
           public class ListNode
            {
                public ListNode(int val, int min, ListNode next)
                {
                    Val = val;
                    Min = min;
                    Next = next;
                }

                public int Val { get; set; }
                public int Min { get; set; }
                public ListNode Next { get; set; }
            }
            private ListNode head;
           
            /// <summary>
            /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnkq37/
            /// </summary>
            /** initialize your data structure here. */
            public MinStack()
            {
              
             
            }

            public void Push(int val)
            {
                if (Empty()) head = new ListNode(val, val, null);
                else head = new ListNode(val, Math.Min(val, head.Min), head);
                
            }

            private bool Empty()
            {
                return head == null;
            }

            public void Pop()
            {
                if (head.Next == null) head = null;
                else head = head.Next;
            }

            public int Top()
            {
                return head.Val;
            }

            public int GetMin()
            {
                return head.Min;
            }
        }

        /**
         * Your MinStack object will be instantiated and called as such:
         * MinStack obj = new MinStack();
         * obj.Push(val);
         * obj.Pop();
         * int param_3 = obj.Top();
         * int param_4 = obj.GetMin();
         */
    }
}
