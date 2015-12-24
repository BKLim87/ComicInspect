using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomLibrary
{
    public class RandomLi
    {
        private Random r;

        public RandomLi()
        {
            r = new Random();
        }
        public RandomLi(Random rr)
        {
            r = rr;
        }
        public RandomLi(RandomLi rr)
        {
            r = rr.getRandom();
        }
        public void setRandom(Random rr)
        {
            r = rr;
        }
        public Random getRandom()
        {
            return r;
        }
        public int NextfromProbMass(double[] probMass)
        {
            double point = r.NextDouble();

            double sum = 0;
            foreach (double d in probMass) sum += d;

            for (int i=0;i<probMass.Length; i++)
            {
                point = point - (probMass[i] / sum);
                if (point < 0)
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
