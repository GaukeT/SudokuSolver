using System;

namespace SudokuSolver
{
    class Program
    {
        static int[,] INPUT = {{5,3,0,0,7,0,0,0,0},
                               {6,0,0,1,9,5,0,0,0},
                               {0,9,8,0,0,0,0,6,0},
                               {8,0,0,0,6,0,0,0,3},
                               {4,0,0,8,0,3,0,0,1},
                               {7,0,0,0,2,0,0,0,6},
                               {0,6,0,0,0,0,2,8,0},
                               {0,0,0,4,1,9,0,0,5},
                               {0,0,0,0,8,0,0,7,9}};

        static void Main(string[] args)
        {
            Solve();
        }
        static void Solve() 
        {
            for (var y = 0; y < 9; y++)
            {
                for (var x = 0; x < 9; x++)
                {
                    if (INPUT[y,x] == 0) {
                        // try every possibility for this position
                        for (var n = 1; n < 10; n++) 
                        {
                            if (Possible(y, x, n)) 
                            {
                                INPUT[y, x] = n;
                                Solve();
                                INPUT[y, x] = 0;
                            }
                        }
                        // if no options available you're on a dead end.
                        return;
                    }
                }
            }

            PrintMatrix(INPUT);
        }

        private static bool Possible(int y, int x, int n)
        {
            // find in same row
            for (var i = 0; i < 9; i++)
            {
                if (INPUT[y, i] == n) return false;
            }

            // find in same column
            for (var i = 0; i < 9; i++)
            {
                if (INPUT[i, x] == n) return false;
            }

            // find in same section
            var x0 = (x / 3) * 3;
            var y0 = (y / 3) * 3;

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (INPUT[y0+i, x0+j] == n) return false;
                }
            }

            return true;
        }

        private static void PrintMatrix(int[,] input)
        {
            Console.WriteLine("Solution");
            Console.WriteLine("*****************");

            for (var i = 0; i < input.GetLength(0); i++)
            {
                for (var j = 0; j < input.GetLength(1); j++)
                {
                    Console.Write(input[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("*****************");
        }
    }
}
