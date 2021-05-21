/**************************************************************** 
* 作    者 ：ChenXuan
* 创建时间 ：2021/5/13 19:00:15
* 描述说明： 
****************************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace _2021_05
{
    class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

    class _20200513 : Singleton<_20200513>
    { 
        /// <summary>
       /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnarn7/
       /// </summary>
        public void DeleteNode(ListNode node)
        {
            node.val = node.next.val;
            node.next = node.next.next;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xn2925/
        /// </summary>
        /// <param name="head"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            //快慢指针
            var fast = head;
            var slow = head;
            for (int i = 0; i < n; i++)
            {
                fast = fast.next;
            }
            if (fast == null) return head.next;
            while (fast.next != null)
            {
                fast = fast.next;
                slow = slow.next;
            }
            slow.val = slow.next.val;
            slow.next = slow.next.next;
            return head;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnnhm6/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public ListNode ReverseList(ListNode head)
        {
            //var stack = new Stack<ListNode>();
            //while (head != null)
            //{
            //    stack.Push(head);
            //    head = head.next;
            //}
            //if (stack.Count == 0) return null;
            //var resNode = stack.Pop();
            //var p2 = resNode;
            //while (stack.Count > 0)
            //{
            //    p2.next = stack.Pop();
            //    p2 = p2.next;
            //}
            //p2.next = null;
            //return resNode;
            ListNode res =new ListNode(0);
            var rHead = res;
            while (head!=null)
            {
                var temp = head.next;
                head.next = rHead.next;
                rHead.next = head;
                head = temp;
            }
            return res.next;


        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnnbp2/
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            //只要有一个为空，就返回另一个
            if (l1 == null || l2 == null)
                return l2 == null ? l1 : l2;
            //把小的赋值给first
            ListNode first = (l2.val < l1.val) ? l2 : l1;
            first.next = MergeTwoLists(first.next, first == l1 ? l2 : l1);
            return first;

            //下面4行是空判断
            //if (l1 == null)
            //    return l2;
            //if (l2 == null)
            //    return l1;
            //ListNode dummy = new ListNode(0);
            //ListNode curr = dummy;
            //while (l1 != null && l2 != null)
            //{
            //    //比较一下，哪个小就把哪个放到新的链表中
            //    if (l1.val <= l2.val)
            //    {
            //        curr.next = l1;
            //        l1 = l1.next;
            //    }
            //    else
            //    {
            //        curr.next = l2;
            //        l2 = l2.next;
            //    }
            //    curr = curr.next;
            //}
            ////然后把那个不为空的链表挂到新的链表中
            //curr.next = l1 == null ? l2 : l1;
            //return dummy.next;

        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnv1oc/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool IsPalindrome(ListNode head)
        {
            //使用递归做一下
            temp = head;
            return check(head);
        }
        ListNode temp;
        private bool check(ListNode head)
        {
            if (head == null) return true;
            var res = check(head.next) && head.val == temp.val;
                temp = temp.next;
            return res;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnwzei/
        /// </summary>
        /// <param name="head"></param>
        /// <returns></returns>
        public bool HasCycle(ListNode head)
        {
            ListNode slow = head, fast = head;
            while (fast!=null&&fast.next!=null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast) return true;
            }
            return false;
        }
    }
}
