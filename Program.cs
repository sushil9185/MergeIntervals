namespace MergeIntervals
{
    internal class Program
    {
        //Problem Link: https://leetcode.com/problems/merge-intervals/description
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        //Optimal Solution
        public int[][] Merge1(int[][] intervals)
        {
            int n = intervals.Length;
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            // Use a List<int[]> for dynamic storage
            List<int[]> result = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                if (result.Count == 0 || intervals[i][0] > result[result.Count - 1][1])
                {
                    result.Add(intervals[i]);
                }
                else
                {
                    result[result.Count - 1][1] = Math.Max(result[result.Count - 1][1], intervals[i][1]);
                }


                //result.Add(new int[] { start, end });
            }


            return result.ToArray();
        }

        //brute force solution
        public int[][] Merge(int[][] intervals)
        {
            int n = intervals.Length;
            Array.Sort(intervals, (a, b) => a[0].CompareTo(b[0]));
            // Use a List<int[]> for dynamic storage
            List<int[]> result = new List<int[]>();
            for (int i = 0; i < n; i++)
            {
                int start = intervals[i][0];
                int end = intervals[i][1];

                if (result.Count > 0 && end <= result[result.Count - 1][1])
                {
                    continue;
                }

                for (int j = i + 1; j < n; j++)
                {
                    if (intervals[j][0] <= end)
                    {
                        end = Math.Max(end, intervals[j][1]);
                    }
                    else
                    {
                        break;
                    }
                }
                result.Add(new int[] { start, end });
            }


            return result.ToArray();
        }
    }
}
