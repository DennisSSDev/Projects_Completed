using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Peg_Game
{
    public partial class Form1 : Form
    {
        float timer_count = 0f;
        string nice = null;
        
        public Form1()
        {
            InitializeComponent();
            PinSolution obj = new PinSolution();
            string a = null;
            int c = 0;
            int b = 2;
            a = obj.AddText(a,b,c );
            a = obj.RemoveText(a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Start the solution to the peg game
            label1.Show();
            timer1.Start();
            button2.Enabled = false;
            for (int i = 0; i < 10000; i++)
            {
                nice += "nice\r\n";
            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_count += 0.01f;
            if (timer_count > 2.00f)
            {
                timer1.Stop();
                label1.Hide();
                textBox1.AppendText(nice);
                MessageBox.Show(timer_count.ToString());
            }
                

        }

	
    }
}
