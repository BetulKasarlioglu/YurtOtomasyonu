namespace YurtOtomasyonu
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
            this.components = new System.ComponentModel.Container();
            this.txtKullanici = new System.Windows.Forms.TextBox();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.gbLogin = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.yURTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new YurtOtomasyonu.DataSet1();
            this.yURTTableAdapter = new YurtOtomasyonu.DataSet1TableAdapters.YURTTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.gbLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yURTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtKullanici
            // 
            this.txtKullanici.Location = new System.Drawing.Point(36, 47);
            this.txtKullanici.Name = "txtKullanici";
            this.txtKullanici.Size = new System.Drawing.Size(100, 20);
            this.txtKullanici.TabIndex = 0;
            this.txtKullanici.Text = "Selim";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(36, 109);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.PasswordChar = '*';
            this.txtSifre.Size = new System.Drawing.Size(100, 20);
            this.txtSifre.TabIndex = 1;
            this.txtSifre.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kullanıcı Adı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Şifre";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(47, 164);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Giriş";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // gbLogin
            // 
            this.gbLogin.Controls.Add(this.button1);
            this.gbLogin.Controls.Add(this.label1);
            this.gbLogin.Controls.Add(this.btnLogin);
            this.gbLogin.Controls.Add(this.txtKullanici);
            this.gbLogin.Controls.Add(this.txtSifre);
            this.gbLogin.Controls.Add(this.label2);
            this.gbLogin.Location = new System.Drawing.Point(33, 64);
            this.gbLogin.Name = "gbLogin";
            this.gbLogin.Size = new System.Drawing.Size(182, 226);
            this.gbLogin.TabIndex = 5;
            this.gbLogin.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 109);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(22, 20);
            this.button1.TabIndex = 5;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // yURTBindingSource
            // 
            this.yURTBindingSource.DataMember = "YURT";
            this.yURTBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "DataSet1";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // yURTTableAdapter
            // 
            this.yURTTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 332);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 357);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gbLogin);
            this.Name = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.gbLogin.ResumeLayout(false);
            this.gbLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.yURTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtKullanici;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox gbLogin;
        private System.Windows.Forms.Button button1;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource yURTBindingSource;
        private DataSet1TableAdapters.YURTTableAdapter yURTTableAdapter;
        public System.Windows.Forms.Label label3;
    }
}

