using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GaussianElimination.Tests
{
    [TestClass]
    public class GaussianEliminationTest
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

        private static readonly double[,] System =
        {
            {-3, 4, 1, 4, -1},
            {0, 1, 3, 2, -1},
            {4, 0, -2, -3, 4},
            {1000, 3, 1, -5, -2}
        };
 
        [TestMethod]
        public void MatrixEqualsTest()
        {
            var inputMatrix = GaussianElimination.Data.MatrixOperation.MergeMatrix(MatrixA, MatrixB);
            CollectionAssert.AreEqual(inputMatrix, System);
        }

        [TestMethod]
        public void ResultTest()
        {
            var inputMatrix = GaussianElimination.Data.MatrixOperation.MergeMatrix(MatrixA, MatrixB);
            var gauss = new GaussianElimination.Data.Gauss(inputMatrix);
            var triangleMatrix = gauss.TriangeMatrix();
            var result = gauss.ResultMatrix(triangleMatrix);

            Assert.IsTrue(Math.Abs(result[0] - (-0.01367)) < 0.1);
            Assert.IsTrue(Math.Abs(result[1] - 1.21367) < 0.1);
            Assert.IsTrue(Math.Abs(result[2] - 0.29367) < 0.1);
            Assert.IsTrue(Math.Abs(result[3] - (-1.54734)) < 0.1);
        }

        [TestMethod]
        public void ErrorTest()
        {
            var mergeArray = GaussianElimination.Data.MatrixOperation.MergeMatrix(MatrixA, MatrixB);
            var gauss = new GaussianElimination.Data.Gauss(mergeArray);
            var triangleArray = gauss.TriangeMatrix();
            var result = gauss.ResultMatrix(triangleArray);
            var error = GaussianElimination.Data.MatrixOperation.GetErrorOfGaussian(MatrixA, MatrixB, result);

            Assert.IsTrue(Math.Abs(error[0]) < 0.0001);
            Assert.IsTrue(Math.Abs(error[1]) < 0.0001);
            Assert.IsTrue(Math.Abs(error[2]) < 0.0001);
            Assert.IsTrue(Math.Abs(error[3]) < 0.0001);
        }
    }
}
