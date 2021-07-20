using System;

namespace _2021_05
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] nums = new int[] { 1, 2, 3, 4, 5, 6, 7 };
            string[] xx = new string[] { "flower", "flow", "flight" };

            //_20210525.Instance.Merge(new int[] { 1,2,3,0,0,0},3,new int[] { 2,5,6},3);
            //_20210525.Instance.Merge(new int[] { 2, 0 }, 1, new int[] { 1 }, 1);
            //_20210526.Instance.Rob(new int[] { 1, 3, 1, 3, 100 });
            //_20210701.Instance.RomanToIntN("MDCCCLXXXIV");
            _20210707.Instance.Generate(5);
            Console.Read();
            //Console.WriteLine(3^4^3);
            //Console.WriteLine(3 ^ 0);
            //Console.WriteLine(3 ^ 3);
        }
    }
}
