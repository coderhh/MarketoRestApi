using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;

namespace Marketo.Mis
{
    class Program
    {
        static void Main(string[] args)
        {
            //Send();
            //var a = new List<List<int>>()
            //{
            //    new List<int>(){11,2,4},
            //    new List<int>(){4,5,66},
            //    new List<int>(){10,8,-12}
            //};

            //var host = "smtp.ethereal.email";
            //var sub = host.Substring(1, 1);
            ////var digd = digD(a);
            /////Console.WriteLine("{0}" , digd);
            /////
            //var b = new List<int>() { 1, 3, 4, 5, 6, };
            //var r = countingSort(b);
            //var aTree = new int[] { 3, 4, 5, 3, 7 };
            //var isAse = AdjacentTree(aTree);

            //DeadLockDemo();
            //var transferManager = new TransferManager();
            //var ac1 = new Account(){ Id = 1 };
            //var ac2 = new Account(){ Id = 2 };
            //transferManager.DoDoubleTransfer(ac1, ac2);

            //int[] arr = { 2, 4, 10, 3, 5 };
            //int N = arr.Length;
            //int K = 3;
            //Console.WriteLine(evenSumK(arr, N, K));
            var distance = ExpectedCrabWalk(100);

            //var pos = new List<(int, int, bool)>();
            

            Console.WriteLine($"result: {distance}");
        }


        public static double ExpectedCrabWalk(int numsteps)
        {
            double expectedDis = 0.0;
            if (numsteps < 1)
            {
                expectedDis = 0.8 * numsteps;
            }
            else
            {
                int x = 0;
                int y = 0;
                var pos = new List<(int, int, bool)>();
                NextStepPos(x, y, true, numsteps, ref pos);
                //pos.Add((x, y, true));
                //for (int i = 1; i <= numsteps; i++)
                //{
                //    var tempPos = new List<(int, int, bool)>();

                //    foreach (var item in pos)
                //    {
                //        var nextPos = new List<(int, int, bool)>();
                //        nextPos = NextStepPos(item.Item1, item.Item2, item.Item3);

                //        foreach (var n in nextPos)
                //        {
                //            tempPos.Add((n.Item1, n.Item2, n.Item3));
                //        }
                //    }
                //    pos = tempPos;
                //}

                // calculate dis
                double p = 1 / Math.Pow(5, numsteps);

                foreach (var item in pos)
                {
                    expectedDis += p * Math.Sqrt(item.Item1 * item.Item1 + item.Item2 * item.Item2);
                }
            }
            return expectedDis;
        }

        private static List<(int, int, bool)> NextStepPos(int x, int y, bool move)
        {
            var pos = new List<(int, int, bool)>();

            if (move)
            {
                pos.Add((x, y, false));
                pos.Add((x + 1, y, true));
                pos.Add((x - 1, y, true));
                pos.Add((x, y + 1, true));
                pos.Add((x, y - 1, true));
            }
            else
            {
                pos.Add((x, y, false));
                pos.Add((x, y, false));
                pos.Add((x, y, false));
                pos.Add((x, y, false));
                pos.Add((x, y, false));
            }

            return pos;
        }

        private static void NextStepPos(int x, int y, bool move, int maxnum, ref List<(int, int, bool)> finalPos)
        {

            if (maxnum == 1)
            {
                if (move)
                {
                    finalPos.Add((x, y, false));
                    finalPos.Add((x + 1, y, true));
                    finalPos.Add((x - 1, y, true));
                    finalPos.Add((x, y + 1, true));
                    finalPos.Add((x, y - 1, true));
                }
                else
                {
                    finalPos.Add((x, y, false));
                    finalPos.Add((x, y, false));
                    finalPos.Add((x, y, false));
                    finalPos.Add((x, y, false));
                    finalPos.Add((x, y, false));
                }

                return;
            }
            else
            {
                if (move)
                {
                    NextStepPos(x, y, false, maxnum - 1, ref finalPos);
                    NextStepPos(x + 1, y, true, maxnum -1, ref finalPos);
                    NextStepPos(x - 1, y, true, maxnum -1, ref finalPos);
                    NextStepPos(x, y + 1, true, maxnum - 1, ref finalPos);
                    NextStepPos(x, y - 1, true, maxnum - 1, ref finalPos);
                }
                else
                {
                    NextStepPos(x, y, false, maxnum - 1, ref finalPos);
                    NextStepPos(x, y, false, maxnum-1, ref finalPos);
                    NextStepPos(x, y, false, maxnum -1, ref finalPos);
                    NextStepPos(x, y, false, maxnum - 1, ref finalPos);
                    NextStepPos(x, y, false, maxnum -1 , ref finalPos);
                }
            }
        }

        public static void Send()
        {
            var host = "smtp.ethereal.email";
            host.Substring(0, 1);
            var port = 587;
            using var smtp = new SmtpClient();
            smtp.Connect(host, port, SecureSocketOptions.StartTls);
            //smtp.Authenticate(_appSettings.SmtpUser, _appSettings.SmtpPass);
        }

        public static int digD(List<List<int>> arr)
        {
            int n = arr.Count;
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < n; i++)
            {
                sum1 = sum1 + arr[i][i];
                sum2 = sum2 + arr[i][n - 1 - i];
            }
            return Math.Abs(sum1 - sum2);
        }

        public static List<int> countingSort(List<int> arr)
        {
            int n = arr.Max();
            int[] arrR = new int[n + 1];
            foreach (int i in arr)
            {
                arrR[i] = arrR[i] + 1;
            }
            return arrR.ToList();
        }

        public static int AdjacentTree(int[] A)
        {
            int count = 0;
            int num = A.Length;
            var newList = A.ToList();
            
           
            if (IsAesPleasing(newList))
            {
                count = 0;
                return count;
            }
            else
            {
                for(int i = 0; i < num; i++)
                {
                    var tempList = newList.ToList();
                    tempList.RemoveAt(i);
                    if (IsAesPleasing(tempList))
                    {
                        count++;
                    }
                }
            }

            if (count == 0)
            {
                return -1;
            }

            return count;
        }

        private static bool IsAesPleasing(List<int> A)
        {
            int num = A.Count;
            bool isAesPleasing = false;
            for (int i = 0; i < num - 2; i++)
            {
                if (A[i] > A[i + 1] && A[i + 1] < A[i + 2])
                {
                    isAesPleasing = true;
                }
                else if (A[i] < A[i + 1] && A[i + 1] > A[i + 2])
                {
                    isAesPleasing = true;
                }
                else
                {
                    isAesPleasing = false;
                    break;
                }
            }

            return isAesPleasing;
        }


        public static void DeadLockDemo()
        {
            object lock1 = new object();
            object lock2 = new object();
            Console.WriteLine("starting...");

            var task1 = Task.Run(() =>
            {
                lock (lock1)
                {
                    Thread.Sleep(1000);
                    lock (lock2)
                    {
                        Console.WriteLine("finished thread1");
                    }
                }
            });

            var task2 = Task.Run(() =>
            {
                lock (lock2)
                {
                    Thread.Sleep(1000);
                    lock (lock1)
                    {
                        Console.WriteLine("finished thread 2");
                    }
                }
            });

            Task.WaitAll(task1, task2);
            Console.WriteLine("finished...");
        }


        public static int evenSumK(int[] arr, int N, int K)
        {
            // If count of elements
            // is less than K
            if (K > N)
            {
                return -1;
            }

            // Stores maximum even
            // subsequence sum
            int maxSum = 0;

            // Stores Even numbers
            List<int> Even = new List<int>();

            // Stores Odd numbers
            List<int> Odd = new List<int>();

            // Traverse the array
            for (int l = 0; l < N; l++)
            {
                // If current element
                // is an odd number
                if (arr[l] % 2 == 1)
                {
                    // Insert odd number
                    Odd.Add(arr[l]);
                }
                else
                {
                    // Insert even numbers
                    Even.Add(arr[l]);
                }
            }

            // Sort Odd[] array
            Odd.Sort();

            // Sort Even[] array
            Even.Sort();

            // Stores current index
            // Of Even[] array
            int i = Even.Count - 1;

            // Stores current index
            // Of Odd[] array
            int j = Odd.Count - 1;

            while (K > 0)
            {
                // If K is odd
                if (K % 2 == 1)
                {
                    // If count of elements
                    // in Even[] >= 1
                    if (i >= 0)
                    {
                        // Update maxSum
                        maxSum += Even[i];

                        // Update i
                        i--;
                    }

                    // If count of elements
                    // in Even[] array is 0.
                    else
                    {
                        return -1;
                    }

                    // Update K
                    K--;
                }

                // If count of elements
                // in Even[] and odd[] >= 2
                else if (i >= 1 && j >= 1)
                {
                    if (Even[i] + Even[i - 1]
                        <= Odd[j] + Odd[j - 1])
                    {
                        // Update maxSum
                        maxSum += Odd[j] + Odd[j - 1];

                        // Update j
                        j -= 2;
                    }
                    else
                    {
                        // Update maxSum
                        maxSum += Even[i] + Even[i - 1];

                        // Update i
                        i -= 2;
                    }

                    // Update K
                    K -= 2;
                }

                // If count of elements
                // in Even[] array >= 2.
                else if (i >= 1)
                {
                    // Update maxSum
                    maxSum += Even[i] + Even[i - 1];

                    // Update i
                    i -= 2;

                    // Update K
                    K -= 2;
                }

                // If count of elements
                // in Odd[] array >= 2
                else if (j >= 1)
                {
                    // Update maxSum
                    maxSum += Odd[j] + Odd[j - 1];

                    // Update i.
                    j -= 2;

                    // Update K.
                    K -= 2;
                }
            }
            return maxSum;
        }

        static int CountOptiverOccurrences(List<string> words)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            int count = 0;
            int length = words.Count;
            string targetStr = "OPTIVER";
            // count horizontally
            foreach (var s in words)
            {
                int tempCount = GetSubStringNum(s, targetStr);
                count = count + tempCount;
                string reversedStr = ReverseString(s);
                tempCount = GetSubStringNum(reversedStr, targetStr);
                count = count + tempCount;
            }

            // count vertically 
            var vertical = new List<string>();
            for (int i = 0; i < length; i++)
            {
                string verticalStr = "";
                foreach (var s in words)
                {
                    verticalStr = verticalStr + s[i];
                }
                vertical.Add(verticalStr);
            }

            foreach (var s in vertical)
            {
                int tempCount = GetSubStringNum(s, targetStr);
                count = count + tempCount;
                string reversedStr = ReverseString(s);
                tempCount = GetSubStringNum(reversedStr, targetStr);
                count = count + tempCount;
            }

            //final return
            return count;

        }
        // method to get reverseString
        private static string ReverseString(string originalStr)
        {
            string reversedStr = "";
            int currentIndex = originalStr.Length - 1;
            while (currentIndex >= 0)
            {
                reversedStr = reversedStr + originalStr[currentIndex];
                currentIndex--;
            }
            return reversedStr;
        }
        // method to get substring num
        private static int GetSubStringNum(string s, string target)
        {
            int L = s.Length;
            int l = target.Length;
            int num = 0;
            if (L < l)
            {
                num = 0;
                return num;
            }
            s = s.ToUpper();
            for (int i = 0; i <= L - l; i++)
            {
                int j;
                for (j = 0; j < l; j++)
                {
                    if (s[i + j] != target[j])
                    {
                        break;
                    }
                }
                if (j == l)
                {
                    num++;
                    j = 0;
                }
            }
            return num;
        }


    }
}
