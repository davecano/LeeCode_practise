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
        //public ListNode ReverseList(ListNode head)
        //{
        //    //var stack = new Stack<ListNode>();
        //    // while (head != null)
        //    // {
        //    //     stack.Push(head);
        //    //     head = head.next;
        //    // }
        //    // if (stack.Count == 0) return null;
        //    // var resNode =stack.Pop();
        //    // var p2 = resNode;
        //    // while (stack.Count>0)
        //    // {
        //    //     p2.next= stack.Pop();
        //    //     p2 = p2.next;
        //    // }
        //    // p2.next = null;
        //    // return resNode;

        //    ListNode resListNode = null;
        //    while (head != null)
        //    {
        //        //先保存访问的节点的下一个节点，保存起来
        //        //留着下一步访问的
        //        ListNode temp = head.next;
        //        //每次访问的原链表节点都会成为新链表的头结点，
        //        //其实就是把新链表挂到访问的原链表节点的
        //        //后面就行了
        //        head.next = resListNode;
        //        //更新新链表
        //        resListNode = head;
        //        //重新赋值，继续访问
        //        head = temp;


        //    }
        //}
    }
}
