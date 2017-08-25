using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
namespace Peg_Game
{
    public partial class Form1 : Form
    {
        float timer_count = 0f;
        PinSolution solution = new PinSolution();
        string text = null;
        string intro = "Program has begun Running\r\n";
        string message = "Give it some time";
        Thread solThread;


        public Form1()
        {
            InitializeComponent();
            PinSolution obj = new PinSolution();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Start the solution to the peg game
            label1.Show();
            timer1.Start();
            button2.Enabled = false;
            textBox1.AppendText(intro);
            solThread = new Thread(solution.PlayGame);
            solThread.Start();
            textBox1.AppendText(message);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer_count += 0.01f;
            string temp = null;
            if (solution.SolutionDone)
            {
                temp = solution.GetFullSolution();
                textBox1.AppendText(temp);
                timer1.Stop();
                label1.Hide();
                MessageBox.Show(timer_count.ToString());
            }  
        }

	
    }
}
