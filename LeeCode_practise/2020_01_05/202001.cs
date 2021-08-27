using System;
using System.Collections.Generic;
using System.Linq;
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
            else
            {
                return null;
            }

            ListNode res = l;
            while (l1 != null || l2 != null)
            {

                sum = (l1 == null ? 0 : l1.val) + (l2 == null ? 0 : l2.val) + (isAddOne ? 1 : 0);
                //个位数
                l.next = new ListNode(sum % 10);
                isAddOne = (sum / 10) == 1;
                if (l1 != null)
                {
                    l1 = l1.next;
                }

                if (l2 != null)
                {
                    l2 = l2.next;
                }

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
        public double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            int p1 = 0;
            int p2 = 0;
            double res = 0;
            int count = 0;
            while (p1 < nums1.Length || p2 < nums2.Length)
            {
                int curval = 0;
                if (p1 < nums1.Length && p2 < nums2.Length)
                {
                    if (nums1[p1] < nums2[p2])
                    {
                        curval = nums1[p1];
                        p1++;
                    }
                    else
                    {
                        curval = nums2[p2];
                        p2++;
                    }
                }

                else if (p1 < nums1.Length)
                {
                    curval = nums1[p1];
                    p1++;
                }
                else if (p2 < nums2.Length)
                {
                    curval = nums2[p2];
                    p2++;
                }

                //even
                if ((nums1.Length + nums2.Length) % 2 == 0)
                {
                    if (count == (nums1.Length + nums2.Length) / 2 - 1)
                        res = curval;
                    else if (count == (nums1.Length + nums2.Length) / 2)
                    {
                        res += (curval - res) / 2;
                        return res;
                    }

                }
                else
                {
                    if (count == (nums1.Length + nums2.Length) / 2)
                    {
                        res = curval;
                        return res;
                    }


                }

                count++;
            }
            return res;
        }


        #endregion
        #region 5. 最长回文子串 https://leetcode-cn.com/problems/longest-palindromic-substring/

        public string LongestPalindrome(string s)
        {
            if (s.Length == 0) return string.Empty;
            var res = s[0].ToString();
            for (int i = 1; i < s.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (s[i] == s[j])
                    {
                        int count = i - j + 1;
                        if (res.Length < count)
                        {
                            var subString = s.Substring(j, count);
                            if (IsPalindrome(subString))
                            {
                                res = subString;
                            }
                        }

                    }

                }
            }
            return res;
        }
        public bool IsPalindrome(string s)
        {
            int left = 0;
            int right = s.Length - 1;
            bool res = true;
            while (left < right)
            {
                if (s[left++] != s[right--])
                {
                    return false;
                }
            }
            return true;
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


        public string Convert(string s, int numRows)
        {
            //#region 本地方法
            //(int m, int n) cMath(int i)
            //{
            //    return (i / (2 * (numRows - 1)), i % (2 * (numRows - 1)));
            //}

            //int[] setTemp()
            //{
            //    int[] tempx = new int[2 * (numRows - 1)];
            //    int index = 0;
            //    for (int j = 0; j < tempx.Length; j++)
            //    {
            //        tempx[j] = j < numRows - 1 ? index++ : index--;
            //    }

            //    return tempx;
            //}
            //int setX(int[] tempx, int i)
            //{
            //    return tempx[i % (2 * (numRows - 1))];
            //}

            //int setY(int i)
            //{
            //    (int m, int n) = cMath(i);
            //    return n < numRows ? m * (numRows - 1) : m * (numRows - 1) + n - numRows + 1;

            //}

            //#endregion

            //if (numRows == 1)
            //{
            //    return s;
            //}

            //int p = setY(s.Length) + 1;
            //char[,] arr = new char[numRows, p];
            //int[] tempX = setTemp();
            //int x, y;
            //for (int i = 0; i < s.Length; i++)
            //{
            //    x = setX(tempX, i);
            //    y = setY(i);
            //    arr[x, y] = s[i];

            //}

            //char[] reChars = new char[s.Length];
            //int cindex = 0;
            //for (int a = 0; a < numRows; a++)
            //{
            //    for (int b = 0; b < p; b++)
            //    {
            //        if (arr[a, b] != '\0')
            //        {
            //            reChars[cindex++] = arr[a, b];
            //        }
            //    }
            //}

            //return new string(reChars);

            bool gointDown = false; ;
            List<StringBuilder> list = new List<StringBuilder>();
            for (int i = 0; i < Math.Min(numRows, s.Length); i++)
            {
                list.Add(new StringBuilder());
            }
            int curRow = 0;
            foreach (var ch in s)
            {
                list[curRow].Append(ch);
                if (curRow == 0 || curRow == numRows - 1) gointDown = !gointDown;
                curRow += gointDown ? 1 : -1;
            }
            var res = new StringBuilder();
            foreach (var sb in list)
            {
                res.Append(sb);

            }
            return res.ToString();
        }
        public string Convert2(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            List<List<char>> rows = new List<List<char>>();
            for (int i = 0; i < s.Length && i < numRows; i++)
            {
                rows.Add(new List<char>());
            }
            bool isdown = false;
            int row = 0;
            foreach (char c in s)
            {
                rows[row].Add(c);
                if (row == 0 || row == numRows - 1)
                {
                    isdown = !isdown;
                }
                row += isdown ? 1 : -1;
            }

            StringBuilder sb = new StringBuilder();
            foreach (List<char> l in rows)
            {
                sb.Append(new string(l.ToArray()));
            }

            return sb.ToString();
        }
        /// <summary>
        /// 官方做法再优化
        /// </summary>
        /// <param name="s"></param>
        /// <param name="numRows"></param>
        /// <returns></returns>
        public string Convert3(string s, int numRows)
        {
            if (numRows == 1)
            {
                return s;
            }

            List<List<char>> rows = new List<List<char>>();
            for (int i = 0; i < s.Length && i < numRows; i++)
            {
                rows.Add(new List<char>());
            }
            bool isdown = false;
            int row = 0;
            foreach (char c in s)
            {
                rows[row].Add(c);
                if (row == 0 || row == numRows - 1)
                {
                    isdown = !isdown;
                }
                row += isdown ? 1 : -1;
            }

            StringBuilder sb = new StringBuilder();
            foreach (List<char> l in rows)
            {
                sb.Append(new string(l.ToArray()));
            }

            return sb.ToString();
        }
        public void DisPlayConvert()
        {
            Console.WriteLine(this.Convert("PAYPALISHIRING", 3));

        }
        #endregion
        #region 8. 字符串转换整数 (atoi) https://leetcode-cn.com/problems/string-to-integer-atoi/
        public int MyAtoi(string str) //还有点问题
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return 0;
            }

            int i;
            int x = 1;
            for (i = 0; i < str.Length; i++)
            {
                if (' '.Equals(str[i]))
                {
                    continue;
                }

                if ('-'.Equals(str[i]) || '+'.Equals(str[i]))
                {
                    i++;
                    x = '+'.Equals(str[i]) ? 1 : -1;
                    if (i.Equals(str.Length))
                    {
                        return 0;
                    }

                    break;
                }
                if (char.IsNumber(str[i]))
                {
                    break;
                }

                return 0;
            }
            char[] res = new char[10];
            int index = 0;
            int j = i;
            for (; j < str.Length; j++)
            {
                if (!char.IsNumber(str[i]) && j == i)
                {
                    return 0;
                }

                if (char.IsNumber(str[i]))
                {
                    res[index++] = str[i];
                }
                else
                {
                    break;
                }
            }

            string t = new string(res);
            if (int.TryParse(t, out int resint))
            {
                return resint * x;
            }

            if (x == 1)
            {
                return int.MaxValue;
            }

            return int.MinValue;

        }
        #endregion

        #region 7. 整数反转 https://leetcode-cn.com/problems/reverse-integer/
        public int Reverse(int x)
        {
            int p = x > 0 ? 1 : -1;
            x = x * p;
            string s = new string(x.ToString().Reverse().ToArray());
            if (int.TryParse(s, out int tResult))
            {
                return tResult * p;
            }

            return 0;
        }

        public int Reverse2(int x)
        {
            int ans = 0;
            while (x != 0)
            {
                int pop = x % 10;
                if (ans > int.MaxValue / 10 || (ans == int.MaxValue / 10 && pop > 7))
                {
                    return 0;
                }

                if (ans < int.MinValue / 10 || (ans == int.MinValue / 10 && pop < -8))
                {
                    return 0;
                }

                ans = ans * 10 + pop;
                x /= 10;
            }
            return ans;
        }

        #endregion
        /// <summary>
        /// https://leetcode-cn.com/problems/container-with-most-water/
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int MaxArea(int[] height)
        {
            //int max = 0;

            //for (int i = 1; i < height.Length; i++)
            //{
            //    for (int j = 0; j < i; j++)
            //    {
            //        max = Math.Max((i - j) * Math.Min(height[i], height[j]), max);
            //    }
            //}
            //return max;

            int left = 0;
            int right = height.Length - 1;
            int res = (right - left) * Math.Min(height[left], height[right]);
            while (left < right)
            {
                if (height[left] < height[right])
                {
                    left++;

                }
                else
                {
                    right--;
                }
                res = Math.Max(res, (right - left) * Math.Min(height[left], height[right]));
            }
            return res;
        }
        /// <summary>
        /// https://leetcode-cn.com/problems/integer-to-roman/
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        readonly (int n, string c)[] valueSymbols = {
        (1000, "M"),
        (900, "CM"),
        (500, "D"),
        (400, "CD"),
        (100, "C"),
        (90, "XC"),
        (50, "L"),
        (40, "XL"),
        (10, "X"),
        (9, "IX"),
        (5, "V"),
        (4, "IV"),
        (1, "I")
    };

        public string IntToRoman(int num)
        {
            StringBuilder roman = new StringBuilder();
            foreach (var tuple in valueSymbols)
            {
                int value = tuple.n;
                string symbol = tuple.c;
                while (num >= value)
                {
                    num -= value;
                    roman.Append(symbol);
                }
                if (num == 0)
                {
                    break;
                }
            }
            return roman.ToString();
        }

        Dictionary<char, int> symbolValues = new Dictionary<char, int> {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000},
    };

        public int RomanToInt(string s)
        {
            int ans = 0;
            int n = s.Length;
            for (int i = 0; i < n; ++i)
            {
                int value = symbolValues[s[i]];
                if (i < n - 1 && value < symbolValues[s[i + 1]])
                {
                    ans -= value;
                }
                else
                {
                    ans += value;
                }
            }
            return ans;
        }
        /// <summary>
        /// https://leetcode-cn.com/problems/3sum/
        /// </summary>
        /// <param name="nums"></param>
        /// <returns></returns>
        //public IList<IList<int>> ThreeSum(int[] nums)
        //{
        //    if (nums.Length < 3) return null;

        //}
        //public int ThreeSumClosest(int[] nums, int target)
        //{

        //}

    }


}


