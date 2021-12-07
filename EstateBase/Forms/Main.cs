using System;
using System.IO;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace makler_qlav
{
    public partial class Main : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        public Main()
        {
            InitializeComponent();
        }
        public SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename=C:\Users\" + Environment.UserName + @"\AppData\Roaming\makler_qlav\BaseDB\makler.mdf;Integrated Security = True");


        SqlCommand com;

        Label[] labels = new Label[7];

        bool isShowPanel, cellClick = false;

        public int R, Nomer = 0, Max;
        public long ID;

        string[] a = new string[3] { "Mənzil", "Ofis", "Ev / villa" };
        string[] b = new string[4] { "Bağ", "Qaraj", "Torpaq", "Obyekt" };

        //*****************************************************************************
       
        public void MelumatlariOxu(string s)
        {
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(s, con);
            DataSet ds = new DataSet();
            da.Fill(ds);


            DataColumn d1 = new DataColumn();
            d1.ColumnName = "Mərtəbə";
            d1.Expression = "FLOOR1+'/'+FLOOR2";
            d1.DataType = System.Type.GetType("System.String");
            ds.Tables[0].Columns.Add(d1);

            con.Close();

            gridControl1.DataSource = ds.Tables[0];
            label7.Text = gridView1.RowCount.ToString();
            gridView1.Columns["Mərtəbə"].VisibleIndex = 8;
            gridView1.Columns[8].Visible = false;
            gridView1.Columns[9].Visible = false;
            gridView1.Columns[16].Visible = false;
            gridView1.Columns[12].Visible = false;

            gridView1.Columns[1].Caption = " Tarix";
            gridView1.Columns[2].Caption = " Əmlakın\n\tnövü";
            gridView1.Columns[3].Caption = " Əməliyyat";
            gridView1.Columns[4].Caption = " Ünvan";
            gridView1.Columns[5].Caption = " Tikintinin\n\tnövü";
            gridView1.Columns[6].Caption = " Layihə";
            gridView1.Columns[7].Caption = " Otaq sayı";

            gridView1.Columns[10].Caption = " Sahə";
            gridView1.Columns[11].Caption = " Qiymət";
            gridView1.Columns[13].Caption = " Əlaqə";
            gridView1.Columns[14].Caption = " Əlaqədar\n\tşəxs";
            gridView1.Columns[15].Caption = " Təmiri";
            gridView1.Columns[17].Caption = " Sənədin tipi";
            fill_Cmb_box();
            Up();

        }

        /// <summary>
        /// Инициализация масок для замены текста в гридконтроле
        /// </summary>
        
        private void Up()
        {
            RepositoryItemTextEdit riAZNTextEdit = new RepositoryItemTextEdit();
            riAZNTextEdit.Name = "riAZNTextEdit";
            riAZNTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            riAZNTextEdit.Mask.Culture = System.Globalization.CultureInfo.CreateSpecificCulture("az-Latn-AZ");
            riAZNTextEdit.Mask.EditMask = "c0";

            riAZNTextEdit.Mask.UseMaskAsDisplayFormat = true;

            RepositoryItemTextEdit riUSDTextEdit = new RepositoryItemTextEdit();
            riUSDTextEdit.Name = "riUSDTextEdit";
            riUSDTextEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            riUSDTextEdit.Mask.Culture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            riUSDTextEdit.Mask.EditMask = "c0";

            riUSDTextEdit.Mask.UseMaskAsDisplayFormat = true;

            RepositoryItemTextEdit number = new RepositoryItemTextEdit();
            number.Name = "number";
            number.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple;

            number.Mask.EditMask = "(999) 000-00-00";
            number.Mask.UseMaskAsDisplayFormat = true;

            gridControl1.RepositoryItems.Add(riAZNTextEdit);
            gridControl1.RepositoryItems.Add(riUSDTextEdit);
            gridControl1.RepositoryItems.Add(number);
        }

        /// <summary>
        /// Динамическая замена данных в гридконтрол, применяя маски
        /// </summary>
        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            if (e.Column.FieldName == "PRICE")
            {
                GridView view = sender as GridView;
                string currency = view.GetRowCellValue(e.RowHandle, "CURRENCY").ToString();
                if (currency == "USD")
                {
                    e.RepositoryItem = view.GridControl.RepositoryItems["riUSDTextEdit"];
                }
                else if (currency == "AZN")
                {
                    e.RepositoryItem = view.GridControl.RepositoryItems["riAZNTextEdit"];
                }
            }

            if (e.Column.FieldName == "CONTACT")
            {
                GridView view1 = sender as GridView;
                e.RepositoryItem = view1.GridControl.RepositoryItems["number"];
            }
        }

        public void Iterate(CheckedComboBoxEdit c, int s)
        {
            foreach (CheckedListBoxItem item in c.Properties.GetItems())
            {
                if (item.CheckState == CheckState.Checked)
                    labels[s].Text += (labels[s].Text == "" ? "" : ",N") + "'" + item.Description + "'";
            }
        }

        /// <summary>
        /// Парсер данных из БД в соответствующие боксы
        /// </summary>
        void fill_Cmb_box()
        {
            comboBoxEdit1.Properties.Items.Clear();
            comboBoxEdit2.Properties.Items.Clear();
            con.Open();
            com = new SqlCommand("select * from t1", con);

            SqlDataReader reader = com.ExecuteReader();
           

            while (reader.Read())
            {
                string owner = reader["owner"].ToString();
                string contact = reader["contact"].ToString();

                comboBoxEdit2.Properties.Items.Add(owner);
                comboBoxEdit1.Properties.Items.Add(contact);
            }
            con.Close();
        }

        public void unchek(CheckedComboBoxEdit c)
        {
            for (int i = 0; i < c.Properties.Items.Count; i++)
                c.Properties.Items[i].CheckState = CheckState.Unchecked;
        }
        
        //******************************************************************************
        
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (isShowPanel)
            {
                if (panel4.Height >= 147)
                {
                    panel4.Height = 127;
                    timer2.Stop();
                }
                panel4.Height += 23;
            }
            else
            {
                if (panel4.Height <= 100)
                {
                    panel4.Height = 87;
                    timer2.Stop();
                }

                panel4.Height -= 23;
            }
        }

        private void FluentDesignForm1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            pictureEdit2.Location = dateEdit2.Location;
            timer1.Start();

            dateEdit2.Text = DateTime.Now.ToString();

            for (int i = 0; i < 7; i++)
            { labels[i] = new Label(); }

            panel4.Size = label2.Size;
            panel4.Location = label2.Location;
            accordionControl1.Size = label1.Size;
            accordionControl1.Location = label1.Location;
            accordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;

            MelumatlariOxu("select * from t1 ");
        }

        private void toggleSwitch2_Toggled(object sender, EventArgs e)
        {
            if (toggleSwitch2.IsOn)
            {
                simpleButton9.Visible = true;
                simpleButton8.Visible = true;

                accordionControl1.OptionsMinimizing.State = DevExpress.XtraBars.Navigation.AccordionControlState.Minimized;
                isShowPanel = true;
                timer2.Start();
                groupBox1.Visible = true;
            }
            else
            {
                simpleButton9.Visible = false;
                simpleButton9.Visible = false;

                isShowPanel = false;
                timer2.Start();
                groupBox1.Visible = false;
            }
        }

        private void advanced_Search(object sender, EventArgs e)
        {
            toggleSwitch2.IsOn = toggleSwitch2.IsOn != true ? true : false;
        }

        private void search_Click(object sender, EventArgs e)
        {
            Iterate(emlaknovusearch, 0);
            Iterate(tikilinovusearch, 1);
            Iterate(layihenovusearch, 2);
            Iterate(senedsearch, 3);
            Iterate(temirnovusearch, 4);
            Iterate(valyutasearch, 5);
            Iterate(emeliyatsearch, 6);

            string str = "where ",str1 = "", str2 = "", str3 = "", str4 = "", str5 = "",
                str6 = "", str7 = "", str8 = "", str9 = "", str10 = "", str11 = "", str12 = "", str13 = "";

            if (kryptonNumericUpDown1.Text != "0") { str1 = "ROOM like '" + kryptonNumericUpDown1.Text + "'"; }
            if (textBox10.Text != "" & textBox11.Text != "") { str2 = "PRICE >='" + textBox11.Text + "' and PRICE <='" + textBox10.Text + "'"; }
            if (labels[0].Text != "") { str3 = "TYPE in  (N" + labels[0].Text + ")"; }
            if (labels[1].Text != "") { str4 = "TYPE_OF_BILDING in  (N" + labels[1].Text + ")"; }
            if (labels[2].Text != "") { str5 = "PROJECT in  (N" + labels[2].Text + ")"; }
            if (labels[3].Text != "") { str6 = "DOCMNT in  (N" + labels[3].Text + ")"; }
            if (labels[4].Text != "") { str7 = "REPAIR in  (N" + labels[4].Text + ")"; }
            if (labels[5].Text != "") { str8 = "CURRENCY in  (N" + labels[5].Text + ")"; }
            if (labels[6].Text != "") { str9 = "OPERATION in  (N" + labels[6].Text + ")"; }
            if (comboBoxEdit1.Text != "") { str10 = "CONTACT like  '" + comboBoxEdit1.Text + "'"; }
            if (comboBoxEdit2.Text != "") { str11 = "OWNER like  N'" + comboBoxEdit2.Text + "'"; }
            if (textBox3.Text != "" & textBox4.Text != "") { str12 = "PLOT >='" + textBox4.Text + "' and PLOT <='" + textBox3.Text + "'"; }
            if (textBox2.Text != "" & textBox5.Text != "") { str13 = "FLOOR2 >='" + textBox2.Text + "' and FLOOR2 <='" + textBox5.Text + "'"; }

            if (checkBox1.Checked) { gridView1.Columns["DATE"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending; }
            if (checkBox2.Checked) { gridView1.Columns["DATE"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending; }
            if (checkBox3.Checked) { gridView1.Columns["PRICE"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending; }
            if (checkBox4.Checked) { gridView1.Columns["PRICE"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending; }



            if (str1 != "") { str = (str != "where ") ? (str + " and " + str1) : (str + str1); }
            if (str2 != "") { str = (str != "where ") ? (str + " and " + str2) : (str + str2); }
            if (str3 != "") { str = (str != "where ") ? (str + " and " + str3) : (str + str3); }
            if (str4 != "") { str = (str != "where ") ? (str + " and " + str4) : (str + str4); }
            if (str5 != "") { str = (str != "where ") ? (str + " and " + str5) : (str + str5); }
            if (str6 != "") { str = (str != "where ") ? (str + " and " + str6) : (str + str6); }
            if (str7 != "") { str = (str != "where ") ? (str + " and " + str7) : (str + str7); }
            if (str8 != "") { str = (str != "where ") ? (str + " and " + str8) : (str + str8); }
            if (str9 != "") { str = (str != "where ") ? (str + " and " + str9) : (str + str9); }
            if (str10 != "") { str = (str != "where ") ? (str + " and " + str10) : (str + str10); }
            if (str11 != "") { str = (str != "where ") ? (str + " and " + str11) : (str + str11); }
            if (str12 != "") { str = (str != "where ") ? (str + " and " + str12) : (str + str12); }
            if (str13 != "") { str = (str != "where ") ? (str + " and " + str13) : (str + str13); }


            if (str == "where ") { MelumatlariOxu("select* from t1"); } else { MelumatlariOxu("select * from t1 " + str); }
            labels[0].Text = ""; labels[1].Text = ""; labels[2].Text = ""; labels[3].Text = ""; labels[4].Text = "";
            labels[5].Text = ""; labels[6].Text = "";

            toggleSwitch2.IsOn = false;
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            refreshButton_Click(sender, e);
            MelumatlariOxu("select * from t1");
        }

        private void sortByDescending(object sender, EventArgs e)
        {
            gridView1.Columns["PRICE"].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
        }

        private void sortByAscending(object sender, EventArgs e)
        {
            gridView1.Columns["PRICE"].SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
        }

        private void today(object sender, EventArgs e)
        {
           
            MelumatlariOxu("select * from t1 where DATE = '" + DateTime.Now.ToString("MM.dd.yyyy") + "'");
        }

        private void yesterday(object sender, EventArgs e)
        {
            MelumatlariOxu("select * from t1 where DATE = '" + DateTime.Today.AddDays(-1).ToString("MM.dd.yyyy") + "'");
        }

        private void thisMonth(object sender, EventArgs e)
        {
            MelumatlariOxu("select * from t1 where DATE BETWEEN '" + DateTime.Today.AddDays(-Convert.ToInt32(DateTime.Today.ToString("dd"))).ToString("MM.dd.yyyy") + "'" +
                " and  '" + DateTime.Today.ToString("MM.dd.yyyy") + "'");
        }

        private void pictureEdit1_Click(object sender, EventArgs e)
        {
            dateEdit2.ShowPopup();
        }

        private void lastMonth(object sender, EventArgs e)
        {
            MelumatlariOxu("select * from t1 where DATE > '" + DateTime.Today.AddDays(-Convert.ToInt32(DateTime.Today.ToString("dd"))).AddMonths(-1).ToString("MM.dd.yyyy") + "'" +
            " and DATE <= '" + DateTime.Today.AddDays(-Convert.ToInt32(DateTime.Today.ToString("dd"))).ToString("MM.dd.yyyy") + "'");
        }

        private void yeniElan(object sender, EventArgs e)
        {
            Class1.Prinal(true);
            new SaveEdit().ShowDialog();
            MelumatlariOxu("select * from t1");
        }

        private void bag_Click(object sender, EventArgs e)
        {
            MelumatlariOxu("select * from t1 where TYPE like N'" + b[0] + "'");
        }

        private void menzil_Click(object sender, EventArgs e)
        {
            MelumatlariOxu("select * from t1 where TYPE like N'" + a[0] + "'");
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void elaniSil_Click(object sender, EventArgs e)
        {
            refreshButton_Click(sender, e);
            const string caption = "Bildiriş";
            const string message = "Silmək  istədyiniz elanı seçin!";
            string text = "Seçilən məlumat silinsinmi?";

            if (!cellClick)
            {
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else if (MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string backupdir1 = @"C:\Users\" + Environment.UserName + @"\AppData\Roaming\makler_qlav\" + textBox1.Text;


                con.Open();
                com = new SqlCommand("delete from t1 where ID like '" + textBox1.Text + "'", con);
                com.ExecuteNonQuery();
                con.Close();

                if (File.Exists(backupdir1))
                {
                    Directory.Delete(backupdir1, true);
                    con.Open();
                    com = new SqlCommand("delete from t2 where kluch like '" + textBox1.Text + "'", con);
                    com.ExecuteNonQuery();
                    con.Close();
                }

                MelumatlariOxu("select * from t1");
                cellClick = false;

            }
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            cellClick = true;
            textBox1.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            Class2.PR1(textBox1.Text);
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            cellClick = true;
            textBox1.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            Class2.PR1(textBox1.Text);
        }

        public void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(Control.MousePosition);
            DoRowDoubleClick(view, pt);
        }

        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.InRow || info.InRowCell)
            {
                Class2.PR1(textBox1.Text);
                Form2 fr1 = new Form2();
                fr1.ShowDialog();
            }
        }

        private void ofisclick(object sender, EventArgs e)
        {
            MelumatlariOxu("select * from t1 where TYPE like N'" + a[1] + "'");
        }

        private void evvillaclick(object sender, EventArgs e)
        {
            MelumatlariOxu("select * from t1 where TYPE like N'" + a[2] + "'");
        }

        private void qarajclick(object sender, EventArgs e)
        {
            MelumatlariOxu("select * from t1 where TYPE like N'" + b[1] + "'");
        }
        private void torpaqclick(object sender, EventArgs e)
        {
            MelumatlariOxu("select * from t1 where TYPE like N'" + b[2] + "'");
        }
        private void aZNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MelumatlariOxu("select * from t1 where CURRENCY like N'" + "AZN" + "'");
        }
        private void uSDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MelumatlariOxu("select * from t1 where CURRENCY like N'" + "USD" + "'");
        }
        private void onLEASEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MelumatlariOxu("SELECT * FROM t1 WHERE OPERATION like N'" + "Kirayə" + "'");
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Class1.Prinal(false);
            if (!cellClick)
            {
                const string caption = "Məlumat";
                const string message = "Düzəliş etmək istədyiniz elanı seçin!";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Class2.PR1(textBox1.Text);
                new SaveEdit().ShowDialog();
                MelumatlariOxu("select * from t1");
                cellClick = false;
            }
        }
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Class1.Prinal(false);
            if (!cellClick)
            {
                const string caption = "Məlumat";
                const string message = "Baxmaq istədiyiniz elanı seçin!";
                MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Class2.PR1(textBox1.Text);
                new Form2().ShowDialog();
                MelumatlariOxu("select * from t1");
                cellClick = false;
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.CheckState = CheckState.Unchecked;
                checkBox3.CheckState = CheckState.Unchecked;
                checkBox4.CheckState = CheckState.Unchecked;
            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.CheckState = CheckState.Unchecked;
                checkBox3.CheckState = CheckState.Unchecked;
                checkBox4.CheckState = CheckState.Unchecked;
            }
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox1.CheckState = CheckState.Unchecked;
                checkBox2.CheckState = CheckState.Unchecked;
                checkBox4.CheckState = CheckState.Unchecked;
            }
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox1.CheckState = CheckState.Unchecked;
                checkBox2.CheckState = CheckState.Unchecked;
                checkBox3.CheckState = CheckState.Unchecked;
            }
        }

        private void closeAdvancedSearch(object sender, EventArgs e)
        {
            toggleSwitch2.IsOn = false;
        }
        private void refreshButton_Click(object sender, EventArgs e)
        {
            unchek(emlaknovusearch);
            unchek(tikilinovusearch);
            unchek(layihenovusearch);
            unchek(senedsearch);
            unchek(temirnovusearch);
            unchek(valyutasearch);
            unchek(emeliyatsearch);
           
            textBox4.Text = "";
            textBox3.Text = "";
            textBox11.Text = "";
            textBox10.Text = "";
            textBox2.Text = "";
            textBox5.Text = "";

            comboBoxEdit2.Text = "";
            comboBoxEdit1.Text = "";
           
           
            checkBox1.CheckState = CheckState.Unchecked;
            checkBox3.CheckState = CheckState.Unchecked;
            checkBox4.CheckState = CheckState.Unchecked;
            checkBox2.CheckState = CheckState.Unchecked;

            kryptonNumericUpDown1.Value = 0;
            MelumatlariOxu("select * from t1");
        }
        private void texnikiDestek_Click(object sender, EventArgs e)
        {
            const string caption = "Məlumat";
            const string message = "Texniki dəstək üçün əlaqə:\n\n +994 (55) 673-74-49 (Cəlal) \n\n +994 (50) 503-99-44 (Araz)";
            MessageBox.Show(message, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textEdit1.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        private void obyekt_Click(object sender, EventArgs e)
        {
            MelumatlariOxu("select * from t1 where TYPE like N'" + b[3] + "'");
        }
    }
}




