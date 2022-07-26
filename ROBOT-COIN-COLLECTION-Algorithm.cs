using System;

using System.Diagnostics;

namespace algorithm_project

{
    public class MaxCollectByRec


    {
        int R, C;
        public MaxCollectByRec(int arrsize ) {
            R = arrsize;
            C = arrsize;
            }
        // to check whether current cell is out of the grid or not
        bool IsValid(int i, int j)
        {
           
            return (i >= 0 && i < R && j >= 0 && j < C);
            

        }

        public int MaxCoinRec(char[,] arr, int i, int j, int dir)
        {
            
            if (IsValid(i, j) == false || arr[i, j] == '#')
                return 0;
            else
            {
                int result = (arr[i, j] == 'C') ? 1 : 0;

                

                return result + Math.Max(MaxCoinRec(arr, i + 1, j, 0),     // Down 
                                   MaxCoinRec(arr, i, j + 1, 1));  // Ahead in right 



                
               
            }

        }
    }
    public class MaxCollectByDynamicP
    {
        int R, C;
        public MaxCollectByDynamicP(int arrsize)
        {
            R = arrsize;
            C = arrsize;
        }
        // to check whether current cell is out of the grid or not
        bool IsValid(int i, int j)
        {
            return (i >= 0 && i < R && j >= 0 && j < C);
        }

        public int MaxCoinUtil(char[,] arr, int i, int j, int dir, int[,,] dp)
        {


            if (IsValid(i, j) == false || arr[i, j] == '#')
                return 0;
            else if (dp[i, j, dir] != -1)
                return dp[i, j, dir];
            else
            {
                dp[i, j, dir] = (arr[i, j] == 'C') ? 1 : 0;
               
                
                    dp[i, j, dir] += Math.Max(MaxCoinUtil(arr, i + 1, j, 0, dp), MaxCoinUtil(arr, i, j + 1, 1, dp));




                  


                return dp[i, j, dir];


            }



        }
        // This function mainly creates a lookup table and calls
        public int MaxCoinDP(char[,] arr)
        {
            int[,,] dp = new int[R, C, 2];
            for (int i = 0; i < dp.GetLength(0); i++)
            {
                for (int j = 0; j < dp.GetLength(1); j++)
                {
                    for (int k = 0; k < dp.GetLength(2); k++)
                        dp[i, j, k] = -1;


                }
            }
            return MaxCoinUtil(arr, 0, 0, 1, dp);

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int coins, arrSize ;

            int counter=0;
            Random random = new Random();
            Console.WriteLine("How many coins do you have ?");
            coins = Convert.ToInt32(Console.ReadLine());
            arrSize = coins;
            
            char[,] arr = new char[arrSize, arrSize];
           
            for (int i =0; i < coins; ) {
                int x = random.Next(0, arrSize);
                int y = random.Next(0, arrSize);

                if (arr[x, y] != ' ')
                {
                    i++;
                    counter++;
                    arr[x, y] = 'C';
                } 
            }


            for (int i = 0; i < coins;)
            {
                int x = random.Next(0, arrSize);
                int y = random.Next(0, arrSize);

                if (arr[x, y] != ' ' ||  arr[x, y] != 'C' )
                {
                    i++;
                  
                    arr[x, y] = '#';
                }
            }


            for (int i = 0; i < arr.GetLength(0); i++)
            {
              
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] != 'C' && arr[i,j] != '#')
                    {
                        
                       
                        arr[i, j] = 'E';
                    }

                }
            }

           

           

          
       int numC = 0;
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    if (arr[i, j] == 'C') numC++;
                        Console.Write("{0} ", arr[i, j]); 

                }
                Console.WriteLine();
            }
            Console.WriteLine(counter);
              char[,] arr2 =  {
                         { 'E', 'C', 'C', 'C', 'C'},
                         { 'C', '#', 'C', '#', 'E'},
                         { '#', 'C', 'C', '#', 'C'},
                         { 'C', 'E', 'E', 'C', 'E'},
                         { 'C', 'E', '#', 'C', 'E'}};

            MaxCollectByRec maxCollectByRec = new MaxCollectByRec(5);
            MaxCollectByDynamicP maxCollectByDynamicP = new MaxCollectByDynamicP(5);



            
        
           
            Stopwatch timer1 = new Stopwatch();
            Stopwatch timer2 = new Stopwatch();
            timer2.Start();
            Console.WriteLine("the maximum number of collected coins is : {0}", maxCollectByDynamicP.MaxCoinDP(arr2));
            timer2.Stop();
            Console.WriteLine("The time of the  Dynamic Programming isalgorithm  :{0}", timer2.Elapsed);
            timer1.Start();
        Console.WriteLine("the maximum number of collected coins is : {0}", maxCollectByRec. MaxCoinRec(arr2, 0, 0, 1));
            timer1.Stop();
            Console.WriteLine("The time of the  Recursion algorithm :{0}", timer1.Elapsed );
           
        }


    }
}


