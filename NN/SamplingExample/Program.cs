using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MatrixLibrary;
using RandomLibrary;


namespace SamplingExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Matrix RealMass = new Matrix(new double[,]{{1,2,3,4,5,6,7,8,9,10,10,9,8,7,6,5,4,3,2,1}});
            Matrix Realdist = new Matrix(RealMass.body);
            Realdist.toProbabilty();

            int samplingtime = 500000;

            Matrix RSdist = RejectionSampling(Realdist, samplingtime);
            Matrix IPdist = ImportanceSampling(Realdist, samplingtime);
            Matrix MCdist = MCMCSampling(Realdist, samplingtime);
            Matrix GBdist = GibbsSampling(Realdist, samplingtime);

            Console.WriteLine(Realdist.toStringSimply());
            Console.WriteLine("Sampling Distribution by Rejection Sampling");
            Console.WriteLine(RSdist.toStringSimply());
            Console.WriteLine("distance between Real and Rejection Sampling");
            Console.WriteLine((Realdist - RSdist).toStringSimply());

            Console.WriteLine("Sampling Distribution by MCMC Sampling");
            Console.WriteLine(MCdist.toStringSimply());
            Console.WriteLine("distance between Real and MCMC Sampling");
            Console.WriteLine((Realdist - MCdist).toStringSimply());

            Console.WriteLine("Sampling Distribution by Gibbs Sampling");
            Console.WriteLine(GBdist.toStringSimply());
            Console.WriteLine("distance between Real and Rejection Sampling");
            Console.WriteLine((Realdist - GBdist).toStringSimply());
         
            Console.WriteLine("Sampling Distribution by Importants Sampling");
            Console.WriteLine(IPdist.toStringSimply());
            Console.WriteLine("distance between Real and Importants Sampling");
            Console.WriteLine((Realdist - IPdist).toStringSimply());

            Console.WriteLine("Results of Rejection, MCMC, Gibbs, Importants");
            Console.Write((1000*(Realdist - RSdist) * (1000*(Realdist - RSdist)).trans()).toStringSimply()+",");
            Console.Write((1000 * (Realdist - MCdist) * (1000 * (Realdist - MCdist)).trans()).toStringSimply() + ",");
            Console.Write((1000 * (Realdist - GBdist) * (1000 * (Realdist - GBdist)).trans()).toStringSimply() + ",");
            Console.Write((1000 * (Realdist - IPdist) * (1000 * (Realdist - IPdist)).trans()).toStringSimply() + ",");
        }
        public static Matrix RejectionSampling(Matrix GoalFunc, int tryn)
        {
            Random r = new Random();

            int[] sample = new int[tryn];
            double rejectionprob;
            int point;

            for (int i = 0; i < tryn; i++)
            {
                point = r.Next(0, 19);
                rejectionprob = r.NextDouble();

                if (rejectionprob > GoalFunc.get(0, point))
                {
                    sample[i] = -1;
                }
                else
                {
                    sample[i] = point;
                }
            }

            double[,] sumnum = new double[1,20];
            for (int i = 0; i < 20; i++)
            {
                sumnum[0,i] = 0;
            }

            for (int i = 0; i < tryn; i++)
            {
                if (sample[i] == -1)
                {

                }
                else
                {
                    sumnum[0,sample[i]]++;
                }
            }

            Matrix getdist = new Matrix(sumnum);
            getdist.toProbabilty();

            return getdist;
        }
        public static Matrix ImportanceSampling(Matrix GoalFunc, int tryn)
        {
            Random r = new Random();

            int[] sample = new int[tryn];
            int point;

            double[,] sumnum = new double[1, 20];
            for (int i = 0; i < 20; i++)
            {
                sumnum[0, i] = 0;
            }

            for (int i = 0; i < tryn; i++)
            {
                point = r.Next(0, 19);

                sumnum[0, point] = sumnum[0, point] + GoalFunc.body[0, point];
                
            }

            Matrix getdist = new Matrix(sumnum);
            getdist.toProbabilty();

            return getdist;
        }
        public static Matrix GibbsSampling(Matrix GoalFunc, int tryn)
        {
            Random r = new Random();

            int[] sample = new int[tryn];
            int point = r.Next(0, 19);
            int newpoint;

            for (int i = 0; i < tryn; i++)
            {
                sample[i] = point;
                newpoint = JumpPointGibbs(point, r, GoalFunc);
                double ttt = GoalFunc.get(0, newpoint) / (GoalFunc.get(0, newpoint) + GoalFunc.get(0, point));
                point = newpoint;
            }
            double[,] sumnum = new double[1, 20];
            for (int i = 0; i < 20; i++)
            {
                sumnum[0, i] = 0;
            }

            for (int i = 0; i < tryn; i++)
            {
                if (sample[i] == -1)
                {

                }
                else
                {
                    sumnum[0, sample[i]]++;
                }
            }

            Matrix getdist = new Matrix(sumnum);
            getdist.toProbabilty();

            return getdist;

        }
        public static int JumpPointGibbs(int point, Random r, Matrix GoalFunc)
        {
            RandomLi rl = new RandomLi(r);

            int[] gfsize = GoalFunc.getSize();
            double[] varprob = new double[gfsize[1]];

            for (int i = 0; i < gfsize[1]; i++)
            {
                varprob[i] = GoalFunc.get(new int[] { 0, i });
            }

            return rl.NextfromProbMass(varprob);

        }
        public static Matrix MCMCSampling(Matrix GoalFunc, int tryn)
        {
            Random r = new Random();

            int[] sample = new int[tryn];
            int point = r.Next(0,19);
            int newpoint;

            for (int i = 0; i < tryn; i++)
            {
                sample[i] = point;
                newpoint = JumpPointMCMC(point, r);
                double ttt = GoalFunc.get(0, newpoint) / (GoalFunc.get(0, newpoint) + GoalFunc.get(0, point));
                if ((r.NextDouble() < GoalFunc.get(0, newpoint) / (GoalFunc.get(0, newpoint) + GoalFunc.get(0, point))))
                {
                    point = newpoint;
                }
            }
            double[,] sumnum = new double[1,20];
            for (int i = 0; i < 20; i++)
            {
                sumnum[0,i] = 0;
            }

            for (int i = 0; i < tryn; i++)
            {
                if (sample[i] == -1)
                {

                }
                else
                {
                    sumnum[0,sample[i]]++;
                }
            }

            Matrix getdist = new Matrix(sumnum);
            getdist.toProbabilty();

            return getdist;
        }
        public static int JumpPointMCMC(int point, Random r)
        {

            double prob = r.NextDouble();
            if (point == 0)
            {
                if (prob < 0.67) point++;
            }
            else if (point == 19)
            {
                if (prob < 0.67) point--;
            }
            else
            {
                if (prob < 0.25) { point--; }
                else if (prob < 0.75) { }
                else { point++; }
            }

            return point;
            
        }
    }
}
