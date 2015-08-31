using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN
{
    public class Matrix
    {
        public double[,] body;

        public Matrix()
        {

        }
        public Matrix(double[,] b)
        {
            body = b;
        }
        public Matrix(int m, int n)
        {
            body = new double[m,n];
            for (int i = 0; i < m; i++)
            {   
                for (int j = 0; j < n; j++)
                {
                    body[i,j] = 1;
                }
            }
        }
        public Matrix(int[] mn)
        {
            body = new double[mn[0], mn[1]];
            for (int i = 0; i < mn[0]; i++)
            {
                for (int j = 0; j < mn[1]; j++)
                {
                    body[i,j] = 1;
                }
            }
        }
        public void randomize()
        {
            Random r = new Random();
            for (int i = 0; i < body.GetLength(0); i++)
            {
                for (int j = 0; j < body.GetLength(1); j++)
                {
                    body[i,j] = r.NextDouble();
                }
            }
        }
        public void randomize(double min, double max)
        {
            Random r = new Random();
            for (int i = 0; i < body.GetLength(0); i++)
            {
                for (int j = 0; j < body.GetLength(1); j++)
                {
                    body[i,j] = min + (max-min)*r.NextDouble();
                }
            }
        }
        public void zero()
        {
            for (int i = 0; i < body.GetLength(0); i++)
            {
                for (int j = 0; j < body.GetLength(1); j++)
                {
                    body[i,j] = 0;
                }
            }
        }

        public void unit()
        {
            for (int i = 0; i < body.GetLength(0); i++)
            {
                for (int j = 0; j < body.GetLength(1); j++)
                {
                    if (i == j) body[i,j] = 1;
                    else body[i,j] = 0;
                }
            }
        }

        public Matrix trans()
        {
            Matrix tran = new Matrix(body.GetLength(1), body.GetLength(0));

            for(int i=0; i<body.GetLength(0); i++)
            {
                for (int j = 0; j < body.GetLength(1); j++)
                {
                    tran.body[j, i] = body[i, j];
                }
            }
            return tran;
        }

        public double get(int i, int j)
        {
            return body[i,j];
        }
        public double get(int[] ij)
        {
            return body[ij[0],ij[1]];
        }
        public static Matrix operator +(Matrix m1, Matrix m2) {
            int n = m1.body.GetLength(0);
            int m = m1.body.GetLength(1);

            double[,] re = new double[n,m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    re[i,j] = m1.body[i,j] + m2.body[i,j];
                }
            }
            return new Matrix(re);
        }
        public static Matrix operator -(Matrix m1, Matrix m2)
        {
            int n = m1.body.GetLength(0);
            int m = m1.body.GetLength(1);

            double[,] re = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    re[i, j] = m1.body[i, j] - m2.body[i, j];
                }
            }
            return new Matrix(re);
        }
        public static Matrix operator *(double d, Matrix m1)
        {
            int n = m1.body.GetLength(0);
            int m = m1.body.GetLength(1);

            double[,] re = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    re[i,j] = d*m1.body[i,j];
                }
            }
            return new Matrix(re);
        }
        public static Matrix operator *(Matrix mat1, Matrix mat2)
        {
            int n1 = mat1.body.GetLength(0);
            int m1 = mat1.body.GetLength(1);
            int n2 = mat2.body.GetLength(0);
            int m2 = mat2.body.GetLength(1);

            double[,] re = new double[n1,m2];

            for (int i = 0; i < n1; i++)
            {
                for (int k = 0; k < m2; k++)
                {
                    re[i,k] = 0;
                    for (int j = 0; j < m1; j++)
                    {
                        re[i,k] += mat1.body[i,j] * mat2.body[j,k];
                    }
                }
            }
            return new Matrix(re);
        }
        public String toString()
        {
            String text = "[";
            for (int i = 0; i < body.GetLength(0); i++)
            {
                text = text + "[";
                for (int j = 0; j < body.GetLength(1); j++)
                {
                    text = text + body[i,j] + " ";
                } 
                text = text + "]";
            }
            text = text + "]";

            return text;
        }
        public Matrix resize(int mplus, int nplus, double num)
        {
            Matrix newMat = new Matrix(body.GetLength(0) + mplus, body.GetLength(1) + nplus);
            if(mplus >= 0 && nplus >=0)
            {
                for(int i=0; i<newMat.body.GetLength(0); i++)
                {
                    for(int j=0; j<newMat.body.GetLength(1); j++)
                    {
                        if(i<body.GetLength(0) && j<body.GetLength(1))
                        {
                            newMat.body[i, j] = body[i, j];
                        }
                        else
                        {
                            newMat.body[i, j] = num;
                        }
                    }
                }
            }
            return newMat;
        }
        public double[,] todouble()
        {
            return body;
        }
        public Boolean equals(Matrix m2)
        {
            if(body.GetLength(0) == m2.body.GetLength(0))
            {
                if (body.GetLength(1) == m2.body.GetLength(1))
                {
                    for (int i = 0; i < body.GetLength(0); i++)
                    {
                        for (int j = 0; j < body.GetLength(1); j++)
                        {
                            if (body[i, j] != m2.body[i, j]) return false;
                        }
                    }
                    return true;
                }
            }
            return false;
        }
        public int[] getSize()
        {
            return new int[2] { body.GetLength(0), body.GetLength(1) };
        }
        public void toSigmoid()
        {
            for (int i = 0; i < body.GetLength(0); i++)
            {
                for (int j = 0; j < body.GetLength(1); j++)
                {
                    body[i, j] = Calculate.sigmoid(body[i, j]);
                }
            }
        }
    }
}
