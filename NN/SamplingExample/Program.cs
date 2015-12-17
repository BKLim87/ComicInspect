using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLibrary;

namespace SamplingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix RealMass = new Matrix(new double[,]{{0,0,1,0,0},{0,1,2,1,0},{1,2,3,2,1},{0,1,2,1,0},{0,0,1,0,0}});
            Matrix Realdist = new Matrix(RealMass.body);
            Realdist.toProbabilty();
            
            



        }
        public Matrix MCMC(Matrix GoalFunc)
        {
            Matrix getdist = new Matrix(GoalFunc.getSize());



            return getdist;
        }
        
    }
}
