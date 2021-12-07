using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using System.IO;

namespace makler_qlav
{
    public partial class Login : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Login()
        {
            InitializeComponent();
        }

      
        public SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\" + Environment.UserName + @"\AppData\Roaming\makler_qlav\BaseDB\makler.mdf;Integrated Security = True");
        SqlCommand com;

        const string caption = "Məlumat";
        const string message1 = "Bu istifadəci qeydiyyata alınmamışdır!";

        string backupdir1 = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\makler_qlav"; 
        string backupdir2 = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\makler_qlav\BaseDB\makler.mdf";
        string dir1 = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\makler_qlav\BaseDB\";

        //****************************************************************************************************************
       
        /// <summary>
        /// Поиск по БД(sql запросы)
        /// </summary>
        public int Poisk(string s)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            con.Close();

            return (ds.Tables[0].Rows.Count);
        }
        
        /// <summary>
        /// Регистрация пользователя по Мак-Адресу
        /// </summary>
        private string GetMacAddress()
        {
            string macAddresses = "";
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }

        //****************************************************************************************************************

        private void Login_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(backupdir1))
            {
                string dir = @"C:\Program Files (x86)\EstateBase\EstateBaseSetUp\makler.mdf";
                DirectoryInfo makler = Directory.CreateDirectory(backupdir1);
                DirectoryInfo Base = Directory.CreateDirectory(dir1);
                File.Copy(dir, backupdir2);
            }
            con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\" + Environment.UserName + @"\AppData\Roaming\makler_qlav\BaseDB\makler.mdf;Integrated Security = True");

            if (Poisk("select * from t3 where mak like '" + GetMacAddress() + "'") != 0)
            {
                Main fr1 = new Main();
                fr1.ShowDialog();
                this.Hide();
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            switch (textBox1.Text)
            {
                case (string)"admin": 
                        addButton.Visible = true;  
                        buttonDelete.Visible = true;
                   break;

                case (string)"user":
                    if (Poisk("select * from t3 where mak like '" + GetMacAddress() + "'") != 0) // проверка по базе данных
                    {
                        Main fr1 = new Main();
                        fr1.ShowDialog();
                        this.WindowState = FormWindowState.Minimized;
                    }
                    else { MessageBox.Show(message1, caption, MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    break;

                default:
                    MessageBox.Show(message1, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }

        /// <summary>
        ///  Удаление всех записей из таблицы БД
        /// </summary>
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            con.Open();
            com = new SqlCommand("delete from t3", con);
            com.ExecuteNonQuery();
            con.Close();
        }

        /// <summary>
        /// Добавление пользователя в БД
        /// </summary>
        private void addButton_Click(object sender, EventArgs e)
        {
            if (Poisk("select * from t3 where mak like '" + GetMacAddress() + "'") != 0)
            {
                MessageBox.Show("Bu istifadəçi artıq qeydiata alınmışdır", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                con.Open();
                com = new SqlCommand("insert into t3 (mak) values('" + GetMacAddress() + "')", con);
                com.ExecuteNonQuery();
                con.Close();

               

                addButton.Visible = false;
                buttonDelete.Visible = false;
                textBox1.ResetText();
                MessageBox.Show("success!");
            }
        }

        /// <summary>
        /// EXIT
        /// </summary>
        private void pbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}



