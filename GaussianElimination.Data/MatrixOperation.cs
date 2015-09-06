using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaussianElimination.Data
{
    public static class MatrixOperation
    {
        public static void PrintMatrix(double[,] matrix, int m, int n)
        {
            for (var i = 0; i < m; i++)
            {
                for (var j = 0; j < n; j++)
                    Console.Write("|{0}\t", Math.Round(matrix[i, j] * Math.Pow(10, 2)) / Math.Pow(10, 2));
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public static void PrintMatrix(double[] matrix)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                Console.WriteLine("| {0}\t", matrix[i]);
            }
        }

        public static double[,] MergeMatrix(double[,] matrixA, double[] matrixB)
        {
            if (matrixA.GetLength(0) != matrixB.GetLength(0))
                throw new Exception("Error in the length of the array");

            var newMatrix = new double[matrixA.GetLength(0), matrixA.GetLength(1) + 1];

            for (var i = 0; i < matrixA.GetLength(0); i++)
                for (var j = 0; j < matrixA.GetLength(1); j++)
                    newMatrix[i, j] = matrixA[i, j];

            for (var i = 0; i < matrixA.GetLength(1); i++)
                for (var j = 0; j < matrixA.GetLength(0); j++)
                    newMatrix[j, matrixA.GetLength(1)] = matrixB[j];

            return newMatrix;
        }

        static public double[] MultiplyMatrix(double[,] matrixA, double[] matrixB)
        {
            var maxtrixARows = matrixA.GetLength(0);
            var matrixAColumn = matrixA.GetLength(1);
            var maxtrixBRows = matrixB.Length;

            if (matrixAColumn != maxtrixBRows)
                throw new Exception("Error in the length of the array");

            var result = new double[maxtrixARows];
            for (var i = 0; i < maxtrixARows; i++)
                for (var k = 0; k < matrixAColumn; k++)
                {
                    var element1 = matrixA[i, k];
                    var elemnet2 = matrixB[k];
                    result[i] += matrixA[i, k] * matrixB[k];
                }
            return result;
        }

        static double[] SubMatrix(double[] matrixA, double[] matrixB)
        {
            if (matrixA.GetLength(0) != matrixB.GetLength(0))
                throw new Exception("Error in the length of the array");

            var lenght = matrixA.GetLength(0);
            var result = new double[lenght];
            for (var i = 0; i < lenght; i++)
                result[i] = matrixA[i] - matrixB[i];
            return result;
        }

        public static double[] GetErrorOfGaussian(double[,] matrixA, double[] matrixB, double[] matrixX) //E = B-A*X
        {
            return SubMatrix(matrixB, MultiplyMatrix(matrixA, matrixX));
        }
    }
}
