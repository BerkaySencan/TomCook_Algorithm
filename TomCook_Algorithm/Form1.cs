using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Numerics;

namespace TomCook_Algorithm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            BigInteger x = BigInteger.Parse(textBox1.Text);
            BigInteger y = BigInteger.Parse(textBox2.Text);

            TomCook tk = new TomCook();
          
            
            textBox3.Text= tk.Recomposition(tk.Interpolation(
                tk.PointWise(
                    tk.Evalution(
                        tk.RightSplit(x)), tk.Evalution(
                            tk.RightSplit(y))))).ToString();



        }
    }
}
