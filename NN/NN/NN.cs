using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN
{
    class NN
    {
        
        List<int> layer;
        List<Matrix> weights;

        public NN(List<int> l)
        {
            Random r = new Random();

            layer = l;
            Randomize();
        }
        public NN(List<Matrix> mats)
        {
            weights = mats;
            foreach(Matrix aMat in mats)
            {
                layer.Add(aMat.body.GetLength(0)-1);
            }
        }
        public void Randomize()
        {
            weights = new List<Matrix>();
            for(int i=0; i<layer.Count-1; i++)
            {
                Matrix temp = new Matrix(layer.IndexOf(i)+1, layer.IndexOf(i + 1));
                temp.randomize();
                weights.Add(temp);
            }
        }
        public void weightsRandomize(double min, double max)
        {
            weights = new List<Matrix>();
            for (int i = 0; i < layer.Count - 1; i++)
            {
                Matrix temp = new Matrix(layer.IndexOf(i)+1, layer.IndexOf(i + 1));
                temp.randomize(min, max);
                weights.Add(temp);
            }
        }
        
    }
}
