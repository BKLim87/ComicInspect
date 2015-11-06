using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NN
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            setText("haha");

            //setText((new Matrix(3, 2) * new Matrix(2, 4)).toString());

            setNN();
        }
        public void setText(String tt) {
            label1.Text = tt;
        }
        public void setNN() {
            NN aNN = new NN(new int[] { 3, 3, 1 });

            Matrix input = new Matrix(new double[,] { { 0,0,0 } });
            String result = aNN.calculate(input).toString();
            
            setText(result);

        }
    }
}
