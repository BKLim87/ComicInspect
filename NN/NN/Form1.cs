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

            Matrix a = new Matrix(2, 2);
            a.zero();
            
            setText((3.0*new Matrix(2,2)).toString());
        }
        public void setText(String tt) {
            label1.Text = tt;
        }
    }
}
