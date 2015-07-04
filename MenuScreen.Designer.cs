namespace EasimerDemoScene
{
    partial class MenuScreen
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuScreen));
        	this.startBtn = new System.Windows.Forms.Button();
        	this.pictureBox1 = new System.Windows.Forms.PictureBox();
        	this.exitBtn = new System.Windows.Forms.Button();
        	this.mapBox = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label4 = new System.Windows.Forms.Label();
        	this.pak0Box = new System.Windows.Forms.TextBox();
        	this.pak1Box = new System.Windows.Forms.TextBox();
        	this.pak2Box = new System.Windows.Forms.TextBox();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.groupBox3 = new System.Windows.Forms.GroupBox();
        	this.noMusic = new System.Windows.Forms.CheckBox();
        	this.groupBox2 = new System.Windows.Forms.GroupBox();
        	this.FSCB = new System.Windows.Forms.CheckBox();
        	this.driverDX8 = new System.Windows.Forms.RadioButton();
        	this.driverGL = new System.Windows.Forms.RadioButton();
        	this.groupBox4 = new System.Windows.Forms.GroupBox();
        	this.listBox1 = new System.Windows.Forms.ListBox();
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
        	this.groupBox1.SuspendLayout();
        	this.groupBox3.SuspendLayout();
        	this.groupBox2.SuspendLayout();
        	this.groupBox4.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// startBtn
        	// 
        	this.startBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
        	this.startBtn.FlatAppearance.BorderSize = 0;
        	this.startBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.startBtn.Font = new System.Drawing.Font("Segoe UI", 14F);
        	this.startBtn.Location = new System.Drawing.Point(340, 150);
        	this.startBtn.Name = "startBtn";
        	this.startBtn.Size = new System.Drawing.Size(128, 32);
        	this.startBtn.TabIndex = 0;
        	this.startBtn.Text = "Start";
        	this.startBtn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
        	this.startBtn.UseVisualStyleBackColor = false;
        	this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
        	// 
        	// pictureBox1
        	// 
        	this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
        	this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        	this.pictureBox1.Image = global::EasimerDemoScene.Properties.Resources.logo1;
        	this.pictureBox1.Location = new System.Drawing.Point(12, 12);
        	this.pictureBox1.Name = "pictureBox1";
        	this.pictureBox1.Size = new System.Drawing.Size(759, 132);
        	this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        	this.pictureBox1.TabIndex = 1;
        	this.pictureBox1.TabStop = false;
        	// 
        	// exitBtn
        	// 
        	this.exitBtn.BackColor = System.Drawing.Color.DeepSkyBlue;
        	this.exitBtn.FlatAppearance.BorderSize = 0;
        	this.exitBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.exitBtn.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.exitBtn.Location = new System.Drawing.Point(340, 199);
        	this.exitBtn.Name = "exitBtn";
        	this.exitBtn.Size = new System.Drawing.Size(128, 32);
        	this.exitBtn.TabIndex = 0;
        	this.exitBtn.Text = "Kilépés";
        	this.exitBtn.UseVisualStyleBackColor = false;
        	this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
        	// 
        	// mapBox
        	// 
        	this.mapBox.Location = new System.Drawing.Point(43, 16);
        	this.mapBox.Name = "mapBox";
        	this.mapBox.Size = new System.Drawing.Size(269, 20);
        	this.mapBox.TabIndex = 1;
        	this.mapBox.TabStop = false;
        	this.mapBox.Text = "devmap";
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.BackColor = System.Drawing.Color.Transparent;
        	this.label1.Location = new System.Drawing.Point(6, 19);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(36, 13);
        	this.label1.TabIndex = 3;
        	this.label1.Text = "Pálya:";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.BackColor = System.Drawing.Color.Transparent;
        	this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
        	this.label2.Location = new System.Drawing.Point(6, 49);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(34, 13);
        	this.label2.TabIndex = 4;
        	this.label2.Text = "pak0:";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.BackColor = System.Drawing.Color.Transparent;
        	this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
        	this.label3.Location = new System.Drawing.Point(6, 80);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(34, 13);
        	this.label3.TabIndex = 4;
        	this.label3.Text = "pak1:";
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.BackColor = System.Drawing.Color.Transparent;
        	this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
        	this.label4.Location = new System.Drawing.Point(6, 106);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(34, 13);
        	this.label4.TabIndex = 4;
        	this.label4.Text = "pak2:";
        	// 
        	// pak0Box
        	// 
        	this.pak0Box.Location = new System.Drawing.Point(43, 46);
        	this.pak0Box.Name = "pak0Box";
        	this.pak0Box.Size = new System.Drawing.Size(269, 20);
        	this.pak0Box.TabIndex = 2;
        	this.pak0Box.TabStop = false;
        	this.pak0Box.Text = "pak0";
        	// 
        	// pak1Box
        	// 
        	this.pak1Box.Location = new System.Drawing.Point(43, 77);
        	this.pak1Box.Name = "pak1Box";
        	this.pak1Box.Size = new System.Drawing.Size(269, 20);
        	this.pak1Box.TabIndex = 3;
        	this.pak1Box.TabStop = false;
        	this.pak1Box.Text = "pak1";
        	// 
        	// pak2Box
        	// 
        	this.pak2Box.Location = new System.Drawing.Point(43, 103);
        	this.pak2Box.Name = "pak2Box";
        	this.pak2Box.Size = new System.Drawing.Size(269, 20);
        	this.pak2Box.TabIndex = 4;
        	this.pak2Box.Text = "pak2";
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.BackColor = System.Drawing.Color.Transparent;
        	this.groupBox1.Controls.Add(this.groupBox3);
        	this.groupBox1.Controls.Add(this.groupBox2);
        	this.groupBox1.Controls.Add(this.label1);
        	this.groupBox1.Controls.Add(this.pak2Box);
        	this.groupBox1.Controls.Add(this.mapBox);
        	this.groupBox1.Controls.Add(this.label4);
        	this.groupBox1.Controls.Add(this.pak1Box);
        	this.groupBox1.Controls.Add(this.label2);
        	this.groupBox1.Controls.Add(this.pak0Box);
        	this.groupBox1.Controls.Add(this.label3);
        	this.groupBox1.Location = new System.Drawing.Point(12, 150);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(322, 411);
        	this.groupBox1.TabIndex = 6;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Beállítások";
        	// 
        	// groupBox3
        	// 
        	this.groupBox3.Controls.Add(this.noMusic);
        	this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
        	this.groupBox3.Location = new System.Drawing.Point(43, 278);
        	this.groupBox3.Name = "groupBox3";
        	this.groupBox3.Size = new System.Drawing.Size(200, 46);
        	this.groupBox3.TabIndex = 9;
        	this.groupBox3.TabStop = false;
        	this.groupBox3.Text = "Hang";
        	// 
        	// noMusic
        	// 
        	this.noMusic.AutoSize = true;
        	this.noMusic.ForeColor = System.Drawing.SystemColors.ControlText;
        	this.noMusic.Location = new System.Drawing.Point(17, 19);
        	this.noMusic.Name = "noMusic";
        	this.noMusic.Size = new System.Drawing.Size(79, 17);
        	this.noMusic.TabIndex = 0;
        	this.noMusic.Text = "Nincs zene";
        	this.noMusic.UseVisualStyleBackColor = true;
        	// 
        	// groupBox2
        	// 
        	this.groupBox2.Controls.Add(this.FSCB);
        	this.groupBox2.Controls.Add(this.driverDX8);
        	this.groupBox2.Controls.Add(this.driverGL);
        	this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
        	this.groupBox2.Location = new System.Drawing.Point(43, 129);
        	this.groupBox2.Name = "groupBox2";
        	this.groupBox2.Size = new System.Drawing.Size(200, 143);
        	this.groupBox2.TabIndex = 8;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "Grafika";
        	// 
        	// FSCB
        	// 
        	this.FSCB.AutoSize = true;
        	this.FSCB.ForeColor = System.Drawing.SystemColors.ControlText;
        	this.FSCB.Location = new System.Drawing.Point(16, 71);
        	this.FSCB.Name = "FSCB";
        	this.FSCB.Size = new System.Drawing.Size(101, 17);
        	this.FSCB.TabIndex = 7;
        	this.FSCB.Text = "Teljes képernyő";
        	this.FSCB.UseVisualStyleBackColor = true;
        	// 
        	// driverDX8
        	// 
        	this.driverDX8.AutoSize = true;
        	this.driverDX8.Checked = true;
        	this.driverDX8.ForeColor = System.Drawing.SystemColors.ControlText;
        	this.driverDX8.Location = new System.Drawing.Point(16, 19);
        	this.driverDX8.Name = "driverDX8";
        	this.driverDX8.Size = new System.Drawing.Size(69, 17);
        	this.driverDX8.TabIndex = 6;
        	this.driverDX8.TabStop = true;
        	this.driverDX8.Text = "DirectX 8";
        	this.driverDX8.UseVisualStyleBackColor = true;
        	// 
        	// driverGL
        	// 
        	this.driverGL.AutoSize = true;
        	this.driverGL.ForeColor = System.Drawing.SystemColors.ControlText;
        	this.driverGL.Location = new System.Drawing.Point(16, 50);
        	this.driverGL.Name = "driverGL";
        	this.driverGL.Size = new System.Drawing.Size(83, 17);
        	this.driverGL.TabIndex = 6;
        	this.driverGL.Text = "OpenGL 1.5";
        	this.driverGL.UseVisualStyleBackColor = true;
        	// 
        	// groupBox4
        	// 
        	this.groupBox4.BackColor = System.Drawing.Color.Transparent;
        	this.groupBox4.Controls.Add(this.listBox1);
        	this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
        	this.groupBox4.Location = new System.Drawing.Point(494, 150);
        	this.groupBox4.Name = "groupBox4";
        	this.groupBox4.Size = new System.Drawing.Size(277, 165);
        	this.groupBox4.TabIndex = 7;
        	this.groupBox4.TabStop = false;
        	this.groupBox4.Text = "Irányítás";
        	// 
        	// listBox1
        	// 
        	this.listBox1.FormattingEnabled = true;
        	this.listBox1.Items.AddRange(new object[] {
        	        	        	"Mozgás: Bal-Jobb-Fel-Le nyilak",
        	        	        	"Ugrás: Space",
        	        	        	"Auto-támadás ki-bekapcsolása: 1",
        	        	        	"Átváltás közelharci fegyverre: 2",
        	        	        	"Átváltás távolharci fegyverre: 3",
        	        	        	"Hátizsák beli tárgyak használata: 4-9",
        	        	        	"Interakció: E"});
        	this.listBox1.Location = new System.Drawing.Point(6, 16);
        	this.listBox1.Name = "listBox1";
        	this.listBox1.Size = new System.Drawing.Size(265, 147);
        	this.listBox1.TabIndex = 0;
        	// 
        	// MenuScreen
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackgroundImage = global::EasimerDemoScene.Properties.Resources.bg2;
        	this.ClientSize = new System.Drawing.Size(800, 600);
        	this.ControlBox = false;
        	this.Controls.Add(this.groupBox4);
        	this.Controls.Add(this.groupBox1);
        	this.Controls.Add(this.pictureBox1);
        	this.Controls.Add(this.exitBtn);
        	this.Controls.Add(this.startBtn);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "MenuScreen";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Easimer RPG";
        	((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	this.groupBox3.ResumeLayout(false);
        	this.groupBox3.PerformLayout();
        	this.groupBox2.ResumeLayout(false);
        	this.groupBox2.PerformLayout();
        	this.groupBox4.ResumeLayout(false);
        	this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button startBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button exitBtn;
        private System.Windows.Forms.TextBox mapBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox pak0Box;
        private System.Windows.Forms.TextBox pak1Box;
        private System.Windows.Forms.TextBox pak2Box;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton driverDX8;
        private System.Windows.Forms.RadioButton driverGL;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox noMusic;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox FSCB;
        private System.Windows.Forms.ListBox listBox1;
    }
}