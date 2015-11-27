using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLibrary
{
    class Calculate
    {
        public static double sigmoid(double x)
        {
            return 1 / (1 + Math.Exp(-x));
        }
    }
}
