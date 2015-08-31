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
        public NN(int[] l)
        {
            List<int> ll = new List<int>();
            for (int i = 0; i < l.Length; i++) ll.Add(l[i]);

            Random r = new Random();

            layer = ll;
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
                Matrix temp;
                if (i != layer.Count - 2)
                {
                    temp = new Matrix(layer.ElementAt(i) + 1, layer.ElementAt(i + 1) + 1);
                }
                else
                {
                    temp = new Matrix(layer.ElementAt(i) + 1, layer.ElementAt(i));
                }
                temp.randomize();
                weights.Add(temp);
            }
        }
        public void weightsRandomize(double min, double max)
        {
            weights = new List<Matrix>();
            for (int i = 0; i < layer.Count - 1; i++)
            {
                Matrix temp = new Matrix(layer.ElementAt(i)+1, layer.ElementAt(i + 1));
                temp.randomize(min, max);
                weights.Add(temp);
            }
        }
        public Matrix setBiasValue(Matrix input)
        {
            Matrix re = new Matrix(input.getSize());

            for(int i=0; i<re.body.GetLength(0); i++) {
                for (int j = 0; j < re.body.GetLength(1); j++ )
                {
                    re.body[i, j] = input.body[i, j];
                }
            }

            re.body[0, re.body.GetLength(1) - 1] = 1;
            return re;
        }

        public Matrix calculate(Matrix input)
        {
            Matrix re = new Matrix(1, layer.Last());

            Matrix LayerValue = input.resize(0, 1, 1); 
            for (int i = 0; i < weights.Count; i++)
            {

                LayerValue = LayerValue * weights.ElementAt(i);

                LayerValue.toSigmoid();
                if (i == weights.Count - 1)
                {
                   
                }
                else
                {
                    LayerValue = setBiasValue(LayerValue);
                }
            }
            return LayerValue;
        }
    }
}
