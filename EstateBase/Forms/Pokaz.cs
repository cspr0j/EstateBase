using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace makler_qlav
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //****************************************************************************************************************

        public SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\" + Environment.UserName + @"\AppData\Roaming\makler_qlav\BaseDB\makler.mdf;Integrated Security = True");


        public int R, ID, Nomer = 0, Max;

        //****************************************************************************************************************

        public void Otr_new(string s)
        {
            con.Open();
            DataSet dataSet = new DataSet();
            new SqlDataAdapter(s, con).Fill(dataSet);

            DataColumn d1 = new DataColumn();
            d1.ColumnName = "Mərtəbə";
            d1.Expression = "FLOOR1+'/'+FLOOR2";
            d1.DataType = System.Type.GetType("System.String");
            dataSet.Tables[0].Columns.Add(d1);
            con.Close();

            textBox1.Text = dataSet.Tables[0].Rows[0].ItemArray[16].ToString();
            gridControl1.DataSource = dataSet.Tables[0];

            cardView1.Columns["Mərtəbə"].VisibleIndex = 8;

            cardView1.Columns[0].Visible = false;
            cardView1.Columns[8].Visible = false;
            cardView1.Columns[9].Visible = false;
            cardView1.Columns[16].Visible = false;

            cardView1.Columns[1].Caption = "Tarix";
            cardView1.Columns[2].Caption = "Əmlakın növü";
            cardView1.Columns[3].Caption = "Əməliyyat";
            cardView1.Columns[4].Caption = "Ünvan";
            cardView1.Columns[5].Caption = "Tikintinin növü";
            cardView1.Columns[6].Caption = "Layihə";
            cardView1.Columns[7].Caption = "Otaq sayı";
            cardView1.Columns[10].Caption = "Sahə";
            cardView1.Columns[11].Caption = "Qiymət";
            cardView1.Columns[12].Caption = "Valyuta";
            cardView1.Columns[13].Caption = "Əlaqə";
            cardView1.Columns[14].Caption = "Əlaqədar şəxs";
            cardView1.Columns[15].Caption = "Təmiri";
            cardView1.Columns[17].Caption = "Sənədin tipi";
        }
        public void Otrazit1(string s, int P)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();
            Max = ds.Tables[0].Rows.Count;

            try
            {
                pictureBox1.ImageLocation = ds.Tables[0].Rows[P].ItemArray[1].ToString();
            }
            catch { }

        }
        
        //****************************************************************************************************************
       
        private void button3_Click(object sender, EventArgs e)
        {
            Nomer++;
            if (Nomer < Max)
            {
                Otrazit1("select* from t2 where kluch like '" + Class2.PR2() + "'", Nomer);
            }
            else
            {
                Nomer = 0;
                Otrazit1("select* from t2 where kluch like '" + Class2.PR2() + "'", Nomer);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Nomer--;
            if (Nomer >= 0)
            {
                Otrazit1("select* from t2 where kluch like '" + Class2.PR2() + "'", Nomer);
            }
            else
            {
                Nomer = Max - 1;
                Otrazit1("select* from t2 where kluch like '" + Class2.PR2() + "'", Nomer);
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.Fill;
            panel1.Location = new Point(130, 423);
            simpleButton2.Visible = true;
            label1.Visible = false;
        }
        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Dock = DockStyle.None;
            panel1.Location = new Point(226, 215);
            simpleButton2.Visible = false;
            label1.Visible = true;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Otr_new("select* from t1 where ID like '" + Class2.PR2() + "'");

            Otrazit1("select* from t2 where kluch like '" + Class2.PR2() + "'", Nomer);

            this.Height = Screen.PrimaryScreen.Bounds.Height - 260;
        }
    }
}
