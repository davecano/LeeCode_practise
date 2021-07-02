/**************************************************************** 
* 作    者 ：ChenXuan
* 创建时间 ：2021/5/24 10:38:38
* 描述说明： 
****************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using Utils;

namespace _2021_05
{
    #region tree
    //Definition for a binary tree node.
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }

    internal class _20210524 : Singleton<_20210524>
    {
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnd69e/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public int MaxDepth(TreeNode root)
        {
            return root == null ? 0 : Math.Max(MaxDepth(root.left), MaxDepth(root.right)) + 1;

        }

        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xn08xg/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        private TreeNode prev;
        public bool IsValidBST(TreeNode root)
        {
            // return IsValidBST(root, long.MinValue, long.MaxValue);
            //中序遍历试一下呢
            if (root == null)
            {
                return true;
            }

            if (!IsValidBST(root.left))
            {
                return false;
            }

            if (prev != null && prev.val >= root.val)
            {
                return false;
            }

            prev = root;
            if (!IsValidBST(root.right))
            {
                return false;
            }

            return true;
        }

        private bool IsValidBST(TreeNode root, long minValue, long maxValue)
        {
            if (root == null)
            {
                return true;
            }

            return minValue < root.val && root.val < maxValue &&
            IsValidBST(root.left, minValue, root.val)
            && IsValidBST(root.right, root.val, maxValue);
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xn7ihv/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public bool IsSymmetric(TreeNode root)
        {
            //if (root == null) return true;
            //return IsSymmetricHelper(root.left, root.right);  
            if (root == null)
            {
                return true;
            }

            Queue<TreeNode> quene = new Queue<TreeNode>();
            quene.Enqueue(root.left);
            quene.Enqueue(root.right);
            while (quene.Count > 0)
            {
                TreeNode left = quene.Dequeue();
                TreeNode right = quene.Dequeue();
                if (left == null && right == null)
                {
                    continue;
                }

                if (left == null || right == null)
                {
                    return false;
                }

                if (left.val != right.val)
                {
                    return false;
                }

                quene.Enqueue(left.left);
                quene.Enqueue(right.right);
                quene.Enqueue(left.right);
                quene.Enqueue(right.left);

            }
            return true;
        }

        private bool IsSymmetricHelper(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
            {
                return true;
            }

            if (left?.val != right?.val)
            {
                return false;
            }

            return IsSymmetricHelper(left.left, right.right) && IsSymmetricHelper(left.right, right.left);
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnldjj/
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            //BFS
            //var resList = new List<IList<int>>();
            //if (root == null) return resList;
            //var quene = new Queue<TreeNode>();
            //quene.Enqueue(root);
            //while (quene.Count > 0)
            //{
            //    var list = new List<TreeNode>();
            //    var storage = new List<int>();
            //    while (quene.Count > 0)
            //    {
            //        list.Add(quene.Dequeue());
            //    }
            //    foreach (var node in list)
            //    {
            //        if (node != null)
            //        {
            //            storage.Add(node.val);
            //            quene.Enqueue(node.left);
            //            quene.Enqueue(node.right);
            //        }

            //    }
            //    if (storage.Count > 0)
            //        resList.Add(storage);
            //}
            //return resList;
            //DFS
            List<IList<int>> resList = new List<IList<int>>();
            if (root == null)
            {
                return resList;
            }

            LevelOrderHelper(ref resList, root, 0);
            return resList;
        }

        private void LevelOrderHelper(ref List<IList<int>> resList, TreeNode root, int v)
        {
            if (root == null)
            {
                return;
            }

            if (resList.Count < v)
            {
                resList.Add(new List<int>());
            }

            resList[v].Add(root.val);
            LevelOrderHelper(ref resList, root.left, v + 1);
            LevelOrderHelper(ref resList, root.right, v + 1);
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xninbt/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums.Length == 0)
            {
                return null;
            }

            int half = nums.Length / 2;
            TreeNode resNode = new TreeNode(nums[half]);

            if (nums.Length == 2)
            {
                resNode.left = new TreeNode(nums[half - 1]);
            }
            else if (nums.Length != 1)
            {
                resNode.left = SortedArrayToBST(nums.Take(half).ToArray());
                resNode.right = SortedArrayToBST(nums.Skip(half + 1).Take(nums.Length - half - 1).ToArray());
            }
            return resNode;


        }
    }
    #endregion
    #region 排序和搜索
    public class _20210525 : Singleton<_20210525>
    {
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnumcr/
        /// </summary>
        /// <param name="nums1"></param>
        /// <param name="m"></param>
        /// <param name="nums2"></param>
        /// <param name="n"></param>
        public void Merge(int[] nums1, int m, int[] nums2, int n)
        {
            if (nums2.Length == 0)
            {
                return;
            }

            int i = 0, j = 0;
            while (i < m + n && j < n)
            {
                if (nums2[j] < nums1[i])
                {
                    for (int k = m + j - 1; k >= i; k--)
                    {
                        nums1[k + 1] = nums1[k];
                    }
                    nums1[i] = nums2[j++];
                }
                else if (i == m + j)
                {
                    nums1[i] = nums2[j++];
                }
                i++;
            }

        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnto1s/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int FirstBadVersion(int n)
        {
            int left = 1, right = n;
            int index;
            while (left < right)
            {
                index = left + (right - left) / 2;
                if (IsBadVersion(index))
                {
                    right = index;
                }
                else
                {
                    left = index + 1;
                }
            }
            return left;
        }

        private bool IsBadVersion(int version)
        {
            return false;
        }
    }
    #endregion
    #region 动态规划
    internal class _20210526 : Singleton<_20210526>
    {
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xn854d/
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public int ClimbStairs(int n)
        {
            int result = 0;
            if (n == 1)
            {
                return 1;
            }

            if (n == 2)
            {
                return 2;
            }

            int n1 = 1, n2 = 2;
            for (int i = 2; i < n; i++)
            {
                result = n1 + n2;
                n1 = n2;
                n2 = result;
            }
            return result;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xn8fsh/
        /// </summary>
        /// <param name="prices"></param>
        /// <returns></returns>
        public int MaxProfit(int[] prices)
        {
            //可以利用下面的思路來實現一下
            int len = prices.Length;
            int minIndex = 0;
            int max = 0;
            for (int i = 0; i < len; i++)
            {
                if (prices[i] < prices[minIndex])
                {
                    minIndex = i;
                }
                if (prices[i] - prices[minIndex] > max)
                {
                    max = prices[i] - prices[minIndex];
                }
            }
            return max;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xn3cg3/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int MaxSubArray(int[] nums)
        {
            int max = 0;
            int sum = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                sum = Math.Max(nums[i], sum + nums[i]);
                if (sum > max)
                    max = sum;
            }
            return max;
        }
        /// <summary>
        /// https://leetcode-cn.com/leetbook/read/top-interview-questions-easy/xnq4km/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        public int Rob(int[] nums)
        {
            int len = nums.Length;
            if (len == 1) return nums[0];
            if (len == 2) return nums[0] > nums[1] ? nums[0] : nums[1];
            int[] T  = new int[len];
            T[0] = nums[0];
            T[1] = nums[0] > nums[1] ? nums[0] : nums[1];
            for (int i = 2; i < len; i++)
            {
                T[i] = T[i-2] + nums[i] > T[i - 1] ? T[i-2] + nums[i] : T[i - 1];
            }
            return T.Max();
        }
        public int MaxChildArrayOrder(int[] a)
        {
            int n = a.Length;
            int[] temp = new int[n];//temp[i]代表0...i上最长递增子序列
            for (int i = 0; i < n; i++)
            {
                temp[i] = 1;//初始值都为1
            }
            for (int i = 1; i < n; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (a[i] > a[j] && temp[j] + 1 > temp[i])
                    {
                        //如果有a[i]比它前面所有的数都大，则temp[i]为它前面的比它小的数的那一个temp+1取得的最大值
                        temp[i] = temp[j] + 1;
                    }
                }
            }
            int max = temp[0];
            //从temp数组里取出最大的值
            for (int i = 1; i < n; i++)
            {
                if (temp[i] > max)
                {
                    max = temp[i];
                }
            }
            return max;
        }

        public int MaxContinueArraySum(int[] a)
        {
            var len = a.Length;
            int sum = a[0];
            //这个最大连续数字和必须要包含当前遍历的值，之前对题意一直有误区
            for (int i = 1; i < len; i++)
            {
                var max = Math.Max(sum + a[i], a[i]);
                if (sum < max)
                    sum = max;
            }
            return sum;
        }
        public int minNumberInRotateArray(int[][] n)
        {

            //从上往下看
            int len = n.Length;
            //int[][] T = new int[len][];
            //T[0][0] = n[0][0];
            //for (int i = 1; i < len; i++)
            //{
            //    for (int j = 0; j < i+1; j++)
            //    {
            //        if (j == 0) T[i][j] = T[i - 1][j] + n[i][j];
            //        else if(j==i) T[i][j] = T[i - 1][j-1] + n[i][j];
            //        else T[i][j] = Math.Max(T[i - 1][j] + n[i][j], T[i - 1][j - 1] + n[i][j]);

            //    }
            //}
            //return T[len].Max();
            //从下往上看
            int[] T = new int[len];
            for (int i = 0; i < len; i++)
            {
                T[i] = n[len-1][i];
            }
            for (int i = len-2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    T[j] = Math.Max(T[j], T[j + 1]) + n[i][j];
                }
            }
            return T[0];
        }
        /// <summary>
        /// https://blog.csdn.net/zw6161080123/article/details/80639932
        /// </summary>
        public int MaxTwoArraySameOrderMethod(String str1, String str2)
        {
            int len1 = str1.Length;
            int len2 = str2.Length;
            int[,] T = new int[len1+1,len2+1];
            for (int i = 0; i <= len1; i++)
            {
                T[i,0] = 0;
            }
            for (int i = 0; i <= len2; i++)
            {
                T[0, i] = 0;
            }
            for (int i = 1; i <=len1; i++)
            {
                for (int j = 1; j <=len2 ; j++)
                {
                    if (str1[i - 1] == str2[j - 1]) T[i, j] = T[i - 1, j - 1] + 1;
                    else T[i,j] = Math.Max(T[i - 1, j], T[i, j - 1]);
                }
            }
            return T[len1, len2];
        }

        /// <summary>
        /// 背包问题
        /// 在N件物品取出若干件放在容量为W的背包里，每件物品的体积为W1，W2……Wn（Wi为整数），与之相对应的价值为P1,P2……Pn（Pi为整数），求背包能够容纳的最大价值。
        /// </summary>
        /// <param name="n"></param>
        /// <param name="w"></param>
        /// <param name="p"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        //public int PackageHelper(int n, int[] w, int[] p, int v)
        //{
        //    int[,] T = new int[]

        //}

    }
    #endregion
}
