namespace GaussianElimination.Data
{
    public class Gauss
    {
        public double[,] InputMatrix { private set; get; }

        public Gauss(double[,] inputMatrix)
        {
            InputMatrix = inputMatrix;
        }

        public double[,] TriangeMatrix()
        {
            var column = InputMatrix.GetLength(0);
            var row = InputMatrix.GetLength(1);

            var resultMatrix = new double[column, row];

            for (var i = 0; i < row; i++)
                resultMatrix[0, i] = InputMatrix[0, i];

            for (var i = 1; i < column; i++)
                for (var j = i; j < column; j++)
                {
                    if (InputMatrix[i - 1, i - 1] != 0)
                    {
                        for (var l = 0; l < row; l++)
                            resultMatrix[j, l] = InputMatrix[j, l] -
                                                 InputMatrix[i - 1, l] * (InputMatrix[j, i - 1] / InputMatrix[i - 1, i - 1]);

                        for (var k = 0; k < row; k++)
                            InputMatrix[j, k] = resultMatrix[j, k];
                    }
            }
            return resultMatrix;
        }

        public double GetDeterminant
        {
            get
            {
                var size = InputMatrix.GetLength(0);
                double det = 1;
                for (var i = 0; i < size; i++)
                    det = det * InputMatrix[i, i];
                return det;
            }
        }

        public double[] ResultMatrix(double[,] inputMatrix)
        {
            var column = inputMatrix.GetLength(0);
            var row = inputMatrix.GetLength(1);
            var resultMatrix = new double[row - 1];

            if (GetDeterminant == 0)
                return resultMatrix;
        
            for (var i = column - 1; i >= 0; i--)
            {
                double summa = 0;
                for (var j = 0; j < row - 1; j++)
                    summa += resultMatrix[j] * inputMatrix[i, j];
                resultMatrix[i] = (inputMatrix[i, row - 1] - summa) / inputMatrix[i, i];
            }
            return resultMatrix;
        }
    }
}
