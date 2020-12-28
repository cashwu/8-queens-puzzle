using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_queens_puzzle
{
    class Program
    {
        //定義一個max表示共有多少個皇后
        static int _max = 8;

        //定義陣列arr,儲存皇后放置位置的結果，比如 arr={0,4,7,5,2,6,1,3}
        static int[] _arr = new int[_max];

        //初始化解法次數
        static int _count = 0;


        /// <summary>
        ///編寫一個方法，放置第n個皇后
        ///Check是每一次遞迴時，進入到Check中都有for(int i=0;i<_max;i++)，因此會有回溯
        /// </summary>
        /// <param name="n"></param>
        private static void Check(int n)
        {
            if (n == _max) //當n=8,說明8個皇后已經方法，因為初始值從0開始
            {
                Print();

                return;
            }

            //依次放入皇后，並判斷是否有衝突
            for (int i = 0; i < _max; i++)
            {
                //先把當前這個皇后n,放到該行的第1列
                _arr[n] = i;

                //判斷當放置第n個皇后到i列時，是否衝突
                if (Judge(n))
                {
                    //如果不衝突，接著放n+1個皇后，即開始遞迴
                    Check(n + 1);
                }

                //如果衝突，就繼續執行arr[n]=i,即將第n個皇后，放置在本行的後移的一個位置
            }
        }

        private static bool Judge(int n)
        {

            for (int i = 0; i < n; i++)
            {
                //Math.Abs(n - i) == Math.Abs(_arr[n] - _arr[i])表示判斷第n個皇后是否和第i個皇后在同一個斜線
                if (_arr[i] == _arr[n] || Math.Abs(n - i) == Math.Abs(_arr[n] - _arr[i]))
                {
                    return false;
                }
            }

            return true;
        }

        private static void Print()
        {
            _count++;

            Console.WriteLine("["+_count+"]");

            string lineStr = "";

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (j == 0) { lineStr = ""; }

                    if (_arr[i] == j)
                    {
                        lineStr += "Q";
                    }
                    else
                    {
                        lineStr += ".";
                    }

                }
                Console.Write(lineStr);
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine();
        }


        static void Main(string[] args)
        {
            // 為什麼需要多傳入 0 ?? 
            Check(0);
            Console.WriteLine($"一共有{_count}種解法");

            Console.WriteLine($"按任意鍵結束....");
            //Console.ReadLine();// 使畫面停住
            Console.ReadKey();  //可按任意鍵結束畫面
        }


    }
}
