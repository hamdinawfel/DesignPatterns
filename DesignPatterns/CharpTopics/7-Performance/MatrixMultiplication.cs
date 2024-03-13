using DesignPatterns.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.CharpTopics.Performance
{
    public class MatrixMultiplication : IExecuteDemo
    {
        static void DrawMatrix(int[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            Console.WriteLine("------------");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] Multiply(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0);
            int cols1 = matrix1.GetLength(1);
            int cols2 = matrix2.GetLength(1);

            int[,] result = new int[rows1, cols2];

            for (int i = 0; i < rows1; i++)
            {
                for (int j = 0; j < cols2; j++)
                {
                    int sum = 0;
                    for (int k = 0; k < cols1; k++)
                    {
                        sum += matrix1[i, k] * matrix2[k, j];
                    }
                    result[i, j] = sum;
                }
            }

            return result;
        }

        public class Matrix : IEnumerable
        {
            private int[,] _data;

            public int Rows { get { return _data.GetLength(0); } }
            public int Columns { get { return _data.GetLength(1); } }

            public int this[int row, int col]
            {
                get { return _data[row, col]; }
                set { _data[row, col] = value; }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _data.GetEnumerator();
            }

            public Matrix(int[,] value)
            {
                _data = value;
            }
        }
        public Matrix Multiply(Matrix a, Matrix b)
        {
            var result = new Matrix(new int[a.Rows, b.Columns]);
            for (int i = 0; i < result.Rows; i++)
            {
                for (int j = 0; j < result.Columns; j++)
                {
                    result[i, j] = 0;
                    for (int k = 0; k < a.Columns; k++)
                        result[i, j] += (a[i, k] * b[k, j]);
                }
            }
            return result;
        }

        public void Execute()
        {
            var matrix1 = new int[,] { { 1, 2, 3}, { 4, 5, 6 } };
            var matrix2 = new int[,] { { 7, 8 }, { 9, 10 }, { 11, 12} };

            //DrawMatrix(matrix1);
            //DrawMatrix(matrix2);

            //var result = Multiply(matrix1, matrix2);

            //DrawMatrix(result);

            var a = new Matrix(matrix1);
            var b = new Matrix(matrix2);

            var result = Multiply(a, b);

        }
    }
}
