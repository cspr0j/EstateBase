
namespace makler_qlav
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.buttonDelete = new Bunifu.Framework.UI.BunifuThinButton2();
            this.addButton = new Bunifu.Framework.UI.BunifuThinButton2();
            this.btnLogin = new Bunifu.Framework.UI.BunifuThinButton2();
            this.textBox1 = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pbUsername = new System.Windows.Forms.PictureBox();
            this.txtBottomUN = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.pbExit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbUsername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(281, 381);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(47, 13);
            this.labelControl2.TabIndex = 63;
            this.labelControl2.Text = "(c) 2021";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(13, 381);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(133, 13);
            this.labelControl1.TabIndex = 62;
            this.labelControl1.Text = "Daşınmaz Əmlak Bazası";
            // 
            // buttonDelete
            // 
            this.buttonDelete.ActiveBorderThickness = 1;
            this.buttonDelete.ActiveCornerRadius = 20;
            this.buttonDelete.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.buttonDelete.ActiveForecolor = System.Drawing.Color.White;
            this.buttonDelete.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.buttonDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.buttonDelete.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonDelete.BackgroundImage")));
            this.buttonDelete.ButtonText = "X";
            this.buttonDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonDelete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonDelete.ForeColor = System.Drawing.Color.White;
            this.buttonDelete.IdleBorderThickness = 1;
            this.buttonDelete.IdleCornerRadius = 20;
            this.buttonDelete.IdleFillColor = System.Drawing.Color.Red;
            this.buttonDelete.IdleForecolor = System.Drawing.Color.White;
            this.buttonDelete.IdleLineColor = System.Drawing.Color.Honeydew;
            this.buttonDelete.Location = new System.Drawing.Point(8, 44);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(5);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(60, 29);
            this.buttonDelete.TabIndex = 61;
            this.buttonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonDelete.Visible = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonAdd
            // 
            this.addButton.ActiveBorderThickness = 1;
            this.addButton.ActiveCornerRadius = 20;
            this.addButton.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.addButton.ActiveForecolor = System.Drawing.Color.White;
            this.addButton.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.addButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonAdd.BackgroundImage")));
            this.addButton.ButtonText = "add";
            this.addButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.addButton.ForeColor = System.Drawing.Color.White;
            this.addButton.IdleBorderThickness = 1;
            this.addButton.IdleCornerRadius = 20;
            this.addButton.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.addButton.IdleForecolor = System.Drawing.Color.WhiteSmoke;
            this.addButton.IdleLineColor = System.Drawing.Color.Honeydew;
            this.addButton.Location = new System.Drawing.Point(8, 14);
            this.addButton.Margin = new System.Windows.Forms.Padding(5);
            this.addButton.Name = "buttonAdd";
            this.addButton.Size = new System.Drawing.Size(60, 33);
            this.addButton.TabIndex = 60;
            this.addButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.addButton.Visible = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.ActiveBorderThickness = 1;
            this.btnLogin.ActiveCornerRadius = 20;
            this.btnLogin.ActiveFillColor = System.Drawing.Color.SeaGreen;
            this.btnLogin.ActiveForecolor = System.Drawing.Color.White;
            this.btnLogin.ActiveLineColor = System.Drawing.Color.SeaGreen;
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.ButtonText = "Daxil ol";
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.IdleBorderThickness = 1;
            this.btnLogin.IdleCornerRadius = 20;
            this.btnLogin.IdleFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(205)))), ((int)(((byte)(117)))));
            this.btnLogin.IdleForecolor = System.Drawing.Color.WhiteSmoke;
            this.btnLogin.IdleLineColor = System.Drawing.Color.Honeydew;
            this.btnLogin.Location = new System.Drawing.Point(84, 315);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(5);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(170, 55);
            this.btnLogin.TabIndex = 59;
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // textBox1
            // 
            this.textBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.textBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.textBox1.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.textBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBox1.HintForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.textBox1.HintText = "İstifadəçi adı";
            this.textBox1.isPassword = false;
            this.textBox1.LineFocusedColor = System.Drawing.Color.Silver;
            this.textBox1.LineIdleColor = System.Drawing.Color.Silver;
            this.textBox1.LineMouseHoverColor = System.Drawing.Color.Silver;
            this.textBox1.LineThickness = 3;
            this.textBox1.Location = new System.Drawing.Point(84, 223);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5);
            this.textBox1.MaxLength = 32767;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(220, 40);
            this.textBox1.TabIndex = 53;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // pbUsername
            // 
            this.pbUsername.Image = ((System.Drawing.Image)(resources.GetObject("pbUsername.Image")));
            this.pbUsername.Location = new System.Drawing.Point(51, 223);
            this.pbUsername.Name = "pbUsername";
            this.pbUsername.Size = new System.Drawing.Size(32, 32);
            this.pbUsername.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbUsername.TabIndex = 56;
            this.pbUsername.TabStop = false;
            // 
            // txtBottomUN
            // 
            this.txtBottomUN.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.txtBottomUN.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.txtBottomUN.characterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBottomUN.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtBottomUN.Enabled = false;
            this.txtBottomUN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.txtBottomUN.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.txtBottomUN.HintForeColor = System.Drawing.Color.Empty;
            this.txtBottomUN.HintText = "";
            this.txtBottomUN.isPassword = false;
            this.txtBottomUN.LineFocusedColor = System.Drawing.Color.Silver;
            this.txtBottomUN.LineIdleColor = System.Drawing.Color.Silver;
            this.txtBottomUN.LineMouseHoverColor = System.Drawing.Color.Silver;
            this.txtBottomUN.LineThickness = 3;
            this.txtBottomUN.Location = new System.Drawing.Point(51, 223);
            this.txtBottomUN.Margin = new System.Windows.Forms.Padding(4);
            this.txtBottomUN.MaxLength = 32767;
            this.txtBottomUN.Name = "txtBottomUN";
            this.txtBottomUN.Size = new System.Drawing.Size(253, 40);
            this.txtBottomUN.TabIndex = 55;
            this.txtBottomUN.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // pbLogo
            // 
            this.pbLogo.Image = ((System.Drawing.Image)(resources.GetObject("pbLogo.Image")));
            this.pbLogo.Location = new System.Drawing.Point(112, 20);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(140, 140);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogo.TabIndex = 51;
            this.pbLogo.TabStop = false;
            // 
            // pbExit
            // 
            this.pbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbExit.Image = ((System.Drawing.Image)(resources.GetObject("pbExit.Image")));
            this.pbExit.Location = new System.Drawing.Point(316, 6);
            this.pbExit.Name = "pbExit";
            this.pbExit.Size = new System.Drawing.Size(12, 12);
            this.pbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbExit.TabIndex = 52;
            this.pbExit.TabStop = false;
            this.pbExit.Click += new System.EventHandler(this.pbExit_Click);
            // 
            // Login
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 401);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pbUsername);
            this.Controls.Add(this.txtBottomUN);
            this.Controls.Add(this.pbLogo);
            this.Controls.Add(this.pbExit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("Login.IconOptions.Image")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbUsername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private Bunifu.Framework.UI.BunifuThinButton2 buttonDelete;
        private Bunifu.Framework.UI.BunifuThinButton2 addButton;
        private Bunifu.Framework.UI.BunifuThinButton2 btnLogin;
        private Bunifu.Framework.UI.BunifuMaterialTextbox textBox1;
        private System.Windows.Forms.PictureBox pbUsername;
        private Bunifu.Framework.UI.BunifuMaterialTextbox txtBottomUN;
        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.PictureBox pbExit;
    }
}