using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using databaseExtract;

namespace databaseExtract
{
    //public delegate void MyDeletegate(string s);
    //public delegate int MyDeletegate2(int i, int j);

    public partial class CompanyData : Form
    {
        
        public CompanyData()
        {
            InitializeComponent();

            //Form1 form1 = new Form1();

            //MyDeletegate myDeletegate = M1;
            //MyDeletegate2 myDeletegat2 = M2;

            //int i = myDeletegat2(3, 4);未将对象引用设置到对象的实例。'
            //Console.WriteLine(i);

        //myDeletegate("sad");
        }
     
        SqlConnection con;
        SqlCommand cmd;

        private void CompanyData_Load(object sender, EventArgs e)
        {

         
        }
        
        //public void M1(string s1)
        //{
        //    Label display1 = display;
        //    display1.Text = s1;

        //    Console.WriteLine(s1);
        //}

        //public int M2(int k, int l)
        //{
        //    return k + l;
        //}

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void companyDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }

        private void companyDataToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            CompanyData cd = new CompanyData();
            cd.Show();
            this.Hide();
        }

        private void containerRentalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}