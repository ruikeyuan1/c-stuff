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
using System.Windows;
using System.Data.SqlClient;

namespace databaseExtract
{
    public partial class Form1 : Form
    {
        //SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=containerRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public Form1()
        {
            //Thread t = new Thread(new ThreadStart(Splash));
            //t.Start();
            //Thread.Sleep(3000);
            InitializeComponent();
            
        //t.Abort();
        }
        public delegate void MyDelegate(object sender, EventArgs e);
        public event MyDelegate MyEvent;

        public string companyInfo = "";
        SqlConnection con;
        SqlCommand cmd;
        public Company company = new Company();
        public List<Rental> myrentals;
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=containerRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private void label1_Click(object sender, EventArgs e)
        {

            //string query = @"SELECT Id, startDate, endDate, totalRentalDays, payabaleCharges, volumeOfContainer
            //                FROM rental ORDER BY Id;";
            //string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=containerRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            //SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connectionString);
            //DataSet result = new DataSet();
            //dataAdapter.Fill(result);
            //lblname.Text = String.Empty; // "";
            //int countLongestPeriod;
            //double countPayableCharges;
            //double countaverageVolume;
            //countLongestPeriod = 0;
            //countPayableCharges = 0;
            //int countRows = 0;
            //countaverageVolume = 0;
            //foreach (DataRow row in result.Tables[0].Rows)
            //{
            //    countRows++;
            //    //lblname.Text += String.Format("{0} {1} {2} {3} {4}\n", row["Id"], row["startDate"], row["endDate"], row["totalRentalDays"], row["payabaleCharges"], row["volumeOfContainer"]);

            //    if ((int)row["totalRentalDays"] > countLongestPeriod)
            //    {
            //        countLongestPeriod = (int)row["totalRentalDays"];

            //    }
            //    countPayableCharges = countPayableCharges + (double)row["payabaleCharges"];
            //    countaverageVolume = countaverageVolume + (double)row["volumeOfContainer"];
            //}
            //countaverageVolume = countaverageVolume / countRows;
            //lblname.Text += String.Format("{0}\n {1}\n {2} \n", countaverageVolume, countLongestPeriod, countPayableCharges);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {


        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        public void calculationAndInsert()
        {
            int volume = int.Parse(textBox1.Text);
            Container container = new Container(volume);
            Rental rental = new Rental(container, dateTimePicker1.Value, dateTimePicker2.Value);
            company.addRental(rental);
           // string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=containerRental;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand("Insert into rental values (/*@Id,*/ @startDate ,@endDate , @totalRentalDays,  @payabaleCharges, @volumeOfContainer)", con);
            cmd.Parameters.AddWithValue("startDate", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("endDate", dateTimePicker2.Value);
            cmd.Parameters.AddWithValue("totalRentalDays", rental.getPeriod());
            cmd.Parameters.AddWithValue("payabaleCharges", rental.getPayableCharges());
            cmd.Parameters.AddWithValue("volumeOfContainer", volume);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("record inserted successfully");
            //DateTime start_date = DateTime.ParseExact(dateTimePicker1.Value, "dd-MMM-yy", null);
            //DateTime end_date = DateTime.ParseExact(dateTimePicker2.Value, "dd-MMM-yy", null);
            //label1.Text = company.totalIncome().ToString() + " $ \n" + company.longestPeriod().ToString() + " days \n"+ company.averageVolume() + "m^3\n" + container.getPrice();
            //+company.averageVolume() + "m^3\n" + rental.getPeriod().ToString() + "days\n" + container.getPrice();
            label1.Text = "Total:" + rental.getPayableCharges() + "$";
        }

        
        public void button1_Click(object sender, EventArgs e)
        {
            calculationAndInsert();
            companyInfo = printCompanyInfo();
            Console.WriteLine(companyInfo);
        }

        public string valuePass()
        {
            companyInfo = printCompanyInfo();
            return companyInfo;
        }

        public string printCompanyInfo()
        {
           
            SqlConnection con = new SqlConnection(connectionString);

            con.Open();
            //Preparing statement against SQL Injections and also inserting them in the Database
            cmd = new SqlCommand("UPDATE company SET TotalIncome=@TotalIncome, AverageVolume=@AverageVolume, LongestPeriod=@LongestPeriod where Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", 0);
            cmd.Parameters.AddWithValue("@AverageVolume", company.averageVolume());
            cmd.Parameters.AddWithValue("@LongestPeriod", company.longestPeriod());
            cmd.Parameters.AddWithValue("@TotalIncome", company.totalIncome());

            cmd.ExecuteNonQuery();
            con.Close();
            string getCompanyInfo = company.totalIncome().ToString() + " $ \n" + company.longestPeriod().ToString() + " days \n" + company.averageVolume() + "m^3\n";
            //Console.WriteLine(getCompanyInfo);
            return getCompanyInfo;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void companyDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompanyData cd = new CompanyData();
            cd.Show();
            this.Hide();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About a = new About();
            a.Show();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {  
            About a = new About();
            a.Show(); 
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {  
            Form1 form = new Form1();
            form.Show();          
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void companyDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CompanyData cd = new CompanyData();
            cd.Show();
            this.Hide();
        }

        private void containerRentalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }
    }
}