using System;
using GaussianElimination.Data;

namespace GaussianElimination
{
    class Program
    {

        private static readonly double[,] MatrixA =
        {
            {-3, 4, 1, 4},
            {0, 1, 3, 2},
            {4, 0, -2, -3},
            {1000, 3, 1, -5}
        };

        private static readonly double[] MatrixB =
        {
            -1, -1, 4, -2
        };

        static void Main(string[] args)
        {
            var mergeArray = MatrixOperation.MergeMatrix(MatrixA, MatrixB);
            var gauss = new Gauss(mergeArray);
            var triangleArray = gauss.TriangeMatrix();
            var result = gauss.ResultMatrix(triangleArray);
            var error = MatrixOperation.GetErrorOfGaussian(MatrixA, MatrixB, result);
            
            Console.WriteLine("Input matrix");
            MatrixOperation.PrintMatrix(mergeArray, mergeArray.GetLength(0), mergeArray.GetLength(1));

            Console.WriteLine("Matrix determinant : {0}\n", gauss.GetDeterminant);
    
            Console.WriteLine("Triangle Matrix");
            MatrixOperation.PrintMatrix(triangleArray, triangleArray.GetLength(0), triangleArray.GetLength(1));

            Console.WriteLine("Result Matrix");
            MatrixOperation.PrintMatrix(result);

            Console.WriteLine("Vector of Errors");
            MatrixOperation.PrintMatrix(error);
           
            Console.ReadLine();
        }
    }
}
