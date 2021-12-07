using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace makler_qlav
{
    public partial class SaveEdit : Form
    {
        public SaveEdit()
        {
            InitializeComponent();
            Otaqsayicmbx.KeyPress += TextBoxOnTextChanged;
            kryptonComboBox1.KeyPress += TextBoxOnTextChanged;
            qiymettxt.KeyPress += TextBoxOnTextChanged;
            elaqetxt.KeyPress += TextBoxOnTextChanged;
            TikintininNovcmbx.KeyPress += ComboBoxOnTextChanged;
            layihecmbx.KeyPress+= ComboBoxOnTextChanged;
            Temircmbx.KeyPress+= ComboBoxOnTextChanged; 
            emeliyatcmbx.KeyPress+= ComboBoxOnTextChanged;
            Senedcmbx.KeyPress+= ComboBoxOnTextChanged;
            valyutacmbx.KeyPress+= ComboBoxOnTextChanged;
            EmlakNovucmbx.KeyPress+= ComboBoxOnTextChanged;
        }

        //*****************************************************************************
        
        public Random rnd = new Random();
        int  Nomer = 0, Max, k;
        string mas;
        bool z = false, closing;

        public SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\"
                                                    + Environment.UserName + @"\AppData\Roaming\makler_qlav\BaseDB\makler.mdf;Integrated Security = True");

        SqlCommand com;

        Dictionary<int, string> c = new Dictionary<int, string>(3);
        Dictionary<int, string> c1 = new Dictionary<int, string>(4);
       
        //*****************************************************************************
        
        public void Otr_new(string s)
        {
            con.Open();
            DataSet dataSet = new DataSet();
            new SqlDataAdapter(s, con).Fill(dataSet);
            con.Close();

            idtxt.Text = dataSet.Tables[0].Rows[0].ItemArray[0].ToString();
            EmlakNovucmbx.Text = dataSet.Tables[0].Rows[0].ItemArray[2].ToString();
            emeliyatcmbx.Text = dataSet.Tables[0].Rows[0].ItemArray[3].ToString();
            Unvantxt.Text = dataSet.Tables[0].Rows[0].ItemArray[4].ToString();
            TikintininNovcmbx.Text = dataSet.Tables[0].Rows[0].ItemArray[5].ToString();
            layihecmbx.Text = dataSet.Tables[0].Rows[0].ItemArray[6].ToString();
            Otaqsayicmbx.Text = dataSet.Tables[0].Rows[0].ItemArray[7].ToString();
            kryptonNumericUpDown1.Text = dataSet.Tables[0].Rows[0].ItemArray[8].ToString();
            kryptonComboBox1.Text = dataSet.Tables[0].Rows[0].ItemArray[9].ToString();
            UmumiSahetxt.Text = dataSet.Tables[0].Rows[0].ItemArray[10].ToString();
            qiymettxt.Text = dataSet.Tables[0].Rows[0].ItemArray[11].ToString();
            valyutacmbx.Text = dataSet.Tables[0].Rows[0].ItemArray[12].ToString();
            elaqetxt.Text = dataSet.Tables[0].Rows[0].ItemArray[13].ToString();
            melumatverentxt.Text = dataSet.Tables[0].Rows[0].ItemArray[14].ToString();
            Temircmbx.Text = dataSet.Tables[0].Rows[0].ItemArray[15].ToString();
            Senedcmbx.Text = dataSet.Tables[0].Rows[0].ItemArray[17].ToString();
            textBox1.Text = dataSet.Tables[0].Rows[0].ItemArray[16].ToString();
        }
        public void Otrazit1(string s, int P)
        {
            con.Open();
            DataSet dataSet = new DataSet();
            new SqlDataAdapter(s, con).Fill(dataSet);
            con.Close();
            Max = dataSet.Tables[0].Rows.Count;
            try
            {
                pictureBox1.ImageLocation = dataSet.Tables[0].Rows[P].ItemArray[1].ToString();
            }
            catch
            { }

        }
        public int Poisk(string s)
        {
            con.Open();
            DataSet dataSet = new DataSet();
            new SqlDataAdapter(s, con).Fill(dataSet);
            con.Close();
            return dataSet.Tables[0].Rows.Count;
        }
        public void Random()
        {
            if (Poisk("select * from t1 where ID like '" + idtxt.Text + "'") == 0)
            {
                idtxt.Text = rnd.Next(1234567, 9876543).ToString();
            }
            else
            {
                k = Convert.ToInt32(idtxt.Text);
                idtxt.Text = (rnd.Next(1, 5) + k).ToString();
            }
        }
        public void Fotki()
        {
            string backupdir1 = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\makler_qlav\" + idtxt.Text;
            if (openFileDialog1.FileName != "")
            {

                foreach (string file in openFileDialog1.FileNames)
                {
                    button4.Visible = true;
                    button3.Visible = true;
                    DirectoryInfo info = Directory.CreateDirectory(backupdir1);

                    string backupdir = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\makler_qlav\" + idtxt.Text + @"\" + rnd.Next(123_219_425,999_999_999);

                    if (File.Exists(backupdir))
                    {
                        string message = "Siz artıq bu şəkili əlavə etmisiniz";
                        string caption = "Bildiriş!";
                        MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        File.Copy(file, backupdir);
                        mas = backupdir;

                        con.Open();
                        com = new SqlCommand("insert into t2(kluch, wekil)values('" + idtxt.Text + "', '" + mas + "')", con);
                        com.ExecuteNonQuery();
                        con.Close();
                    }
                }
                if (Poisk("select * from t2 where kluch ='" + idtxt.Text + "' and wekil ='" + mas + "'") != 0)
                {
                    button7.Visible = true;
                }
            }
        }
        private void ComboBoxOnTextChanged(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void TextBoxOnTextChanged(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        //*****************************************************************************

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= kryptonNumericUpDown1.Value; i++)
                kryptonComboBox1.Items.Add(i);

            c.Add(1, "Mənzil");
            c.Add(2, "Ev / villa");
            c.Add(3, "Ofis");
            DateTime now = DateTime.Now;
            Random();
            if (Poisk("select * from t2 where kluch like '" + idtxt.Text + "'") == 0)
            {
            }
            if (Class1.Vernul(1))
            {
                SaveEditButton1.Text = "Təstiq et";
            }
            else
            {

                button1.Visible = false;
                SaveEditButton1.Location = new Point(584, 371);
                Otr_new("select* from t1 where ID like '" + Class2.PR2() + "'");
                button3.Visible = true;
                button4.Visible = true;

                Otrazit1("select* from t2 where kluch like '" + Class2.PR2() + "'", Nomer);

                SaveEditButton1.Text = "Düzəliş et";
                if (Poisk("select * from t2 where kluch like '" + idtxt.Text + "'") != 0)
                {
                    button7.Visible = true;
                }
            }
        }
        private void SaveEditButton_Click(object sender, EventArgs e)
        {
            closing = true;

            if (z == false)
            {
                Otaqsayicmbx.Text = "0";
                kryptonNumericUpDown1.Value = 0;
                kryptonComboBox1.Text = "0";
                TikintininNovcmbx.Text = "-";
                layihecmbx.Text = "-";
                Temircmbx.Text = "-";
            }
            if (EmlakNovucmbx.Text == "-" || emeliyatcmbx.Text == "-" || elaqetxt.Text == "" || melumatverentxt.Text == "")
            {
                const string caption = "Məlumat";
                const string message = "Zəhmət olmasa vacib xanaları doldurun!";
                var dr = MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {

                if (!Class1.Vernul(1))
                {

                    con.Open();

                    com = new SqlCommand("update t1 set ROOM =N'" + Otaqsayicmbx.Text + "', " +
                                                      "CURRENCY =N'" + valyutacmbx.Text + "', " +
                                                       "DOCMNT =N'" + Senedcmbx.Text + "'," +
                                                     " PROJECT =N'" + layihecmbx.Text + "'," +
                                                      " REPAIR =N'" + Temircmbx.Text + "'," +
                                              " TYPE_OF_BILDING=N'" + TikintininNovcmbx.Text + "', " +
                                                     "FLOOR1    =N'" + kryptonNumericUpDown1.Text + "'," +
                                                     "FLOOR2    =N'" + kryptonComboBox1.Text + "'," +
                                                    " ADRESS   =N'" + Unvantxt.Text + "', " +
                                                     "PLOT     =N'" + UmumiSahetxt.Text + "'," +
                                                    " OPERATION=N'" + emeliyatcmbx.Text + "'," +
                                                    " PRICE    =N'" + qiymettxt.Text + "'," +
                                                    " CONTACT  =N'" + elaqetxt.Text + "'," +
                                                    " OWNER    =N'" + melumatverentxt.Text + "'," +
                                                    "TYPE      =N'" + EmlakNovucmbx.Text + "'," +
                                                   "ADDITIONALY=N'" + textBox1.Text + "'" +

                                                  "where ID like '" + idtxt.Text + "'", con);
                    com.ExecuteNonQuery();
                    con.Close();

                    Hide();

                }
                else if (Poisk("select * from t1 where ID like '" + idtxt.Text + "'") != 0)
                {
                    Random();
                    SaveEditButton_Click(sender, e);
                }
                else
                {
                    con.Open();

                    com = new SqlCommand("insert into t1(ID,DATE,TYPE," +

                        "OPERATION,ADRESS,TYPE_OF_BILDING,PROJECT,ROOM," +

                        "FLOOR1,FLOOR2,PLOT,PRICE,CURRENCY,CONTACT,OWNER," +

                        "REPAIR,ADDITIONALY,DOCMNT)values(N'" + idtxt.Text + "'," +

                         "N'" + DateTime.Today.ToString("MM.dd.yyyy") + "'," +
                         "N'" + EmlakNovucmbx.Text + "'," +
                         "N'" + emeliyatcmbx.Text + "'," +
                         "N'" + Unvantxt.Text + "'," +
                         "N'" + TikintininNovcmbx.Text + "'," +
                         "N'" + layihecmbx.Text + "'," +
                         "N'" + Otaqsayicmbx.Text + "'," +
                         "N'" + kryptonNumericUpDown1.Text + "', " +
                         "N'" + kryptonComboBox1.Text + "'," +
                         "N'" + UmumiSahetxt.Text + "'," +
                         "N'" + qiymettxt.Text + "'," +
                         "N'" + valyutacmbx.Text + "',  " +
                         "N'" + elaqetxt.Text + "'," +
                         "N'" + melumatverentxt.Text + "'," +
                         "N'" + Temircmbx.Text + "'," +
                         "N'" + textBox1.Text + "'," +
                         "N'" + Senedcmbx.Text + "')", con);

                    com.ExecuteNonQuery();
                    con.Close();
                }

                this.Hide();
            }
        }
        private void deletephoto(object sender, EventArgs e)
        {
            const string caption = "Bildiriş";
            const string message = "Şəkil silinsin?!";

            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this.Nomer >= 0)
                {
                    int num;
                    con.Open();
                    com = new SqlCommand("delete from t2 where kluch like '" + idtxt.Text + "' and wekil like '" + pictureBox1.ImageLocation + "'", con);
                    com.ExecuteNonQuery();
                    con.Close();

                    File.Delete(pictureBox1.ImageLocation);

                    Nomer = num = 0;
                    Otrazit1("select* from t2 where kluch like '" + idtxt.Text + "'", num);
                }
                if (Poisk("select * from t2 where kluch like '" + idtxt.Text + "'") == 0)
                {
                    button4.Visible = false;
                    button3.Visible = false;
                    button7.Visible = false;
                    pictureBox1.Image = null;
                }
            }
        }
        private void ArxayaChevir(object sender, EventArgs e)
        {
            Nomer--;
            if (Nomer >= 0)
            {
                Otrazit1("select* from t2 where kluch like '" + idtxt.Text + "'", Nomer);
            }
            else
            {
                Nomer = Max - 1;
                Otrazit1("select* from t2 where kluch like '" + idtxt.Text + "'", Nomer);
            }
        }
        private void QabagaChevir(object sender, EventArgs e)
        {
            Nomer++;
            if (Nomer < Max)
            {
                Otrazit1("select* from t2 where kluch like '" + idtxt.Text + "'", Nomer);
            }
            else
            {
                Nomer = 0;
                Otrazit1("select* from t2 where kluch like '" + idtxt.Text + "'", Nomer);
            }
        }
        private void maxmertebe(object sender, EventArgs e)
        {
            kryptonComboBox1.Items.Clear();
            for (int i = 1; i <= kryptonNumericUpDown1.Value; i++)
            {
                kryptonComboBox1.Items.Add(i);

            }
        }
        private void SaveEdit_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            string backupdir1 = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\makler_qlav\" + idtxt.Text;
           
            if (Class1.Vernul(1)&& !closing)
            {
                if (emeliyatcmbx.Text != "-" || elaqetxt.Text != "" || melumatverentxt.Text != "" || pictureBox1.Image!=null)
                {
                    const string caption = "Məlumat";
                    const string message = "Əlavə et menyusu sonlandırılsınmı?\n" +
                                        "Daxil etdiyiniz məlumatlar silinəcək!";
                    var dr = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);


                    if (dr == DialogResult.Yes)
                    {
                        if (pictureBox1.Image!=null)
                        {
                            con.Open();
                            com = new SqlCommand("delete from t2 where kluch like '" + idtxt.Text + "'", con);
                            com.ExecuteNonQuery();
                            con.Close();

                            Directory.Delete(backupdir1, true);
                        }
                     }
                    else
                    {
                        e.Cancel = dr == DialogResult.No;
                    }
                }
            }
        }
        private void elaqetxt_TextChanged(object sender, EventArgs e)
        {
            if (elaqetxt.Text != "")
            {
                elaqetxt.MaxLength = 10;
            }
            else
            { 
                elaqetxt.MaxLength = 100;
            }
        }
        private void UmumiSahetxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
           
            if (e.KeyChar == '.' && UmumiSahetxt.Text.IndexOf(".") > -1)
            {
                e.Handled = true;
            }
        }
        private void legvet(object sender, EventArgs e)
        {
           this.Close();
        }
        private void EmlakNovu_TextChanged(object sender, EventArgs e)
        {
            panel1.Visible = false;
            Otaqsayicmbx.Visible = true;
            UmumiSahetxt.Location = new Point(0x61, 0x106);
            label20.Location = new Point(200,268);
            label12.Text = "Ümumi Sahə:";
            if (((EmlakNovucmbx.Text == c[1]) || (EmlakNovucmbx.Text == c[2])) || (EmlakNovucmbx.Text == c[3]))
            {
                panel1.Visible = true;
                z = true;
                label2.Text = "Otaq sayı:";
                if (EmlakNovucmbx.SelectedIndex == 0)
                {
                    panel1.Visible = true;
                }
            }
            else
            {
                z = false;
                panel1.Visible = false;
                UmumiSahetxt.Location = new Point(117, 124);
                label20.Location = new Point(220,129);
                UmumiSahetxt.Visible = true;
                Otaqsayicmbx.Visible = false;
                label2.Text = "Ümumi Sahə:";
                label12.Text = "";
            }
        }
        private void ShekilElaveEt(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = true;
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();

                if (!Class1.Vernul(1))
                {
                    Fotki();
                }
                else if (Poisk("select * from t1 where ID like '" + idtxt.Text + "'") == 0)
                {
                    Fotki();
                }
                else
                {
                    Random();
                    ShekilElaveEt(sender, e);
                }
            Otrazit1("select* from t2 where kluch like '" + idtxt.Text + "'", Nomer);
        }
    }
}
