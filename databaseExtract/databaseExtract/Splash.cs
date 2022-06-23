using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace databaseExtract
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
            //progressBar1.Value = 0;
            //for(int i = 0;i < 10;i++)
            //{
            //    progressBar1.Value += 1;
            //    System.Threading.Thread.Sleep(3000);
            //}

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Splash_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel1.Width += 3;

            if(panel1.Width >= 300)
            {
                timer1.Stop();
                Form1 fm1 = new Form1();
                fm1.Show();
                this.Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
