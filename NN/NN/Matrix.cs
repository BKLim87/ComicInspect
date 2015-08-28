using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN
{
    public class Matrix
    {
        double[][] body;

        public Matrix()
        {

        }
        public Matrix(double[][] b)
        {
            body = b;
        }
        public Matrix(int m, int n)
        {
            body = new double[m][];
            for (int i = 0; i < m; i++)
            {
                body[i] = new double[n];
                for (int j = 0; j < n; j++)
                {
                    body[i][j] = 1;
                }
            }
        }
        public Matrix(int[] mn)
        {
            body = new double[mn[0]][];
            for (int i = 0; i < mn[0]; i++)
            {
                body[i] = new double[mn[1]];
                for (int j = 0; j < mn[1]; j++)
                {
                    body[i][j] = 1;
                }
            }
        }

        public void randomize()
        {
            Random r = new Random();
            for (int i = 0; i < body.Length; i++)
            {
                for (int j = 0; j < body[0].Length; j++)
                {
                    body[i][j] = r.NextDouble();
                }
            }
        }

        public void zero()
        {
            for (int i = 0; i < body.Length; i++)
            {
                for (int j = 0; j < body[0].Length; j++)
                {
                    body[i][j] = 0;
                }
            }
        }

        public void Trans()
        {
            for (int i = 0; i < body.Length; i++)
            {
                for (int j = 0; j < body[0].Length; j++)
                {
                    if (i == j) body[i][j] = 1;
                    else body[i][j] = 0;
                }
            }
        }

        public double get(int i, int j)
        {
            return body[i][j];
        }
        public double get(int[] ij)
        {
            return body[ij[0]][ij[1]];
        }
        public static Matrix operator +(Matrix m1, Matrix m2) {
            int n = m1.body.Length;
            int m = m1.body[0].Length;

            double[][] re = new double[n][];

            for (int i = 0; i < n; i++)
            {
                re[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    re[i][j] = m1.body[i][j] + m2.body[i][j];
                }
            }
            return new Matrix(re);
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            int n = m1.body.Length;
            int m = m1.body[0].Length;

            double[][] re = new double[n][];

            for (int i = 0; i < n; i++)
            {
                re[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    re[i][j] = m1.body[i][j] - m2.body[i][j];
                }
            }
            return new Matrix(re);
        }
        public static Matrix operator *(double d, Matrix m1)
        {
            int n = m1.body.Length;
            int m = m1.body[0].Length;

            double[][] re = new double[n][];

            for (int i = 0; i < n; i++)
            {
                re[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    re[i][j] = d*m1.body[i][j];
                }
            }
            return new Matrix(re);
        }
        public static Matrix operator *(Matrix mat1, Matrix mat2)
        {
            int n1 = mat1.body.Length;
            int m1 = mat1.body[0].Length;
            int n2 = mat2.body.Length;
            int m2 = mat2.body[0].Length;

            double[][] re = new double[n1][];

            for (int i = 0; i < n1; i++)
            {
                re[i] = new double[m1];

                for (int k = 0; k < m1; k++)
                {
                    re[i][k] = 0;
                    for (int j = 0; j < m2; j++)
                    {
                        re[i][k] += mat1.body[i][k] * mat1.body[k][j];
                    }
                }
            }
            return new Matrix(re);
        }
        public String toString()
        {
            String text = "[";
            for (int i = 0; i < body.Length; i++)
            {
                text = text + "[";
                for (int j = 0; j < body[0].Length; j++)
                {
                    text = text + body[i][j] + " ";
                } 
                text = text + "]";
            }
            text = text + "]";

            return text;
        }
    }
}
