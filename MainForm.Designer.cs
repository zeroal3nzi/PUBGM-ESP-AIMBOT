namespace PUBGMESP
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Btn_Activate = new System.Windows.Forms.Button();
            this.LoopTimer = new System.Windows.Forms.Timer(this.components);
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.chkBone = new System.Windows.Forms.CheckBox();
            this.chk2DBox = new System.Windows.Forms.CheckBox();
            this.chkESP = new System.Windows.Forms.CheckBox();
            this.chkLines = new System.Windows.Forms.CheckBox();
            this.chkHealth = new System.Windows.Forms.CheckBox();
            this.chkItems = new System.Windows.Forms.CheckBox();
            this.chkVehicle = new System.Windows.Forms.CheckBox();
            this.chkFastLanding = new System.Windows.Forms.CheckBox();
            this.chkSpeedCar = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtAimKey = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.trkFOV = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.trkAimSmoth = new System.Windows.Forms.TrackBar();
            this.chkDrawFOV = new System.Windows.Forms.CheckBox();
            this.chkAimbot = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkFOV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAimSmoth)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_Activate
            // 
            this.Btn_Activate.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Btn_Activate.Location = new System.Drawing.Point(0, 0);
            this.Btn_Activate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Btn_Activate.Name = "Btn_Activate";
            this.Btn_Activate.Size = new System.Drawing.Size(314, 41);
            this.Btn_Activate.TabIndex = 0;
            this.Btn_Activate.Text = "Inject";
            this.Btn_Activate.UseVisualStyleBackColor = true;
            this.Btn_Activate.Click += new System.EventHandler(this.Btn_Activate_Click);
            // 
            // LoopTimer
            // 
            this.LoopTimer.Interval = 500;
            this.LoopTimer.Tick += new System.EventHandler(this.Loop_Tick);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Tick += new System.EventHandler(this.Update_Tick);
            // 
            // chkBone
            // 
            this.chkBone.AutoSize = true;
            this.chkBone.Checked = true;
            this.chkBone.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBone.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBone.Location = new System.Drawing.Point(37, 71);
            this.chkBone.Name = "chkBone";
            this.chkBone.Size = new System.Drawing.Size(88, 19);
            this.chkBone.TabIndex = 2;
            this.chkBone.Text = "Player Bone";
            this.chkBone.UseVisualStyleBackColor = true;
            this.chkBone.CheckedChanged += new System.EventHandler(this.CheckBox_Changed);
            // 
            // chk2DBox
            // 
            this.chk2DBox.AutoSize = true;
            this.chk2DBox.Checked = true;
            this.chk2DBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk2DBox.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk2DBox.Location = new System.Drawing.Point(37, 146);
            this.chk2DBox.Name = "chk2DBox";
            this.chk2DBox.Size = new System.Drawing.Size(81, 19);
            this.chk2DBox.TabIndex = 3;
            this.chk2DBox.Text = "Player Box";
            this.chk2DBox.UseVisualStyleBackColor = true;
            this.chk2DBox.CheckedChanged += new System.EventHandler(this.CheckBox_Changed);
            // 
            // chkESP
            // 
            this.chkESP.AutoSize = true;
            this.chkESP.Checked = true;
            this.chkESP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkESP.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkESP.Location = new System.Drawing.Point(8, 6);
            this.chkESP.Name = "chkESP";
            this.chkESP.Size = new System.Drawing.Size(82, 19);
            this.chkESP.TabIndex = 5;
            this.chkESP.Text = "Playes ESP";
            this.chkESP.UseVisualStyleBackColor = true;
            this.chkESP.CheckedChanged += new System.EventHandler(this.CheckBox_Changed);
            // 
            // chkLines
            // 
            this.chkLines.AutoSize = true;
            this.chkLines.Checked = true;
            this.chkLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLines.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLines.Location = new System.Drawing.Point(37, 96);
            this.chkLines.Name = "chkLines";
            this.chkLines.Size = new System.Drawing.Size(88, 19);
            this.chkLines.TabIndex = 6;
            this.chkLines.Text = "Player Lines";
            this.chkLines.UseVisualStyleBackColor = true;
            this.chkLines.CheckedChanged += new System.EventHandler(this.CheckBox_Changed);
            // 
            // chkHealth
            // 
            this.chkHealth.AutoSize = true;
            this.chkHealth.Checked = true;
            this.chkHealth.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHealth.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHealth.Location = new System.Drawing.Point(37, 121);
            this.chkHealth.Name = "chkHealth";
            this.chkHealth.Size = new System.Drawing.Size(96, 19);
            this.chkHealth.TabIndex = 7;
            this.chkHealth.Text = "Player Health";
            this.chkHealth.UseVisualStyleBackColor = true;
            this.chkHealth.CheckedChanged += new System.EventHandler(this.CheckBox_Changed);
            // 
            // chkItems
            // 
            this.chkItems.AutoSize = true;
            this.chkItems.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkItems.Location = new System.Drawing.Point(159, 71);
            this.chkItems.Name = "chkItems";
            this.chkItems.Size = new System.Drawing.Size(74, 19);
            this.chkItems.TabIndex = 8;
            this.chkItems.Text = "Item ESP";
            this.chkItems.UseVisualStyleBackColor = true;
            this.chkItems.CheckedChanged += new System.EventHandler(this.CheckBox_Changed);
            // 
            // chkVehicle
            // 
            this.chkVehicle.AutoSize = true;
            this.chkVehicle.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkVehicle.Location = new System.Drawing.Point(159, 96);
            this.chkVehicle.Name = "chkVehicle";
            this.chkVehicle.Size = new System.Drawing.Size(87, 19);
            this.chkVehicle.TabIndex = 9;
            this.chkVehicle.Text = "Vehicle ESP";
            this.chkVehicle.UseVisualStyleBackColor = true;
            this.chkVehicle.CheckedChanged += new System.EventHandler(this.CheckBox_Changed);
            // 
            // chkFastLanding
            // 
            this.chkFastLanding.AutoSize = true;
            this.chkFastLanding.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkFastLanding.Location = new System.Drawing.Point(27, 38);
            this.chkFastLanding.Name = "chkFastLanding";
            this.chkFastLanding.Size = new System.Drawing.Size(92, 19);
            this.chkFastLanding.TabIndex = 10;
            this.chkFastLanding.Text = "Fast Landing";
            this.chkFastLanding.UseVisualStyleBackColor = true;
            // 
            // chkSpeedCar
            // 
            this.chkSpeedCar.AutoSize = true;
            this.chkSpeedCar.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSpeedCar.Location = new System.Drawing.Point(27, 63);
            this.chkSpeedCar.Name = "chkSpeedCar";
            this.chkSpeedCar.Size = new System.Drawing.Size(79, 19);
            this.chkSpeedCar.TabIndex = 11;
            this.chkSpeedCar.Text = "Speed Car";
            this.chkSpeedCar.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 43);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(314, 313);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkESP);
            this.tabPage1.Controls.Add(this.chkBone);
            this.tabPage1.Controls.Add(this.chkVehicle);
            this.tabPage1.Controls.Add(this.chk2DBox);
            this.tabPage1.Controls.Add(this.chkItems);
            this.tabPage1.Controls.Add(this.chkHealth);
            this.tabPage1.Controls.Add(this.chkLines);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(306, 287);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ESP";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Controls.Add(this.txtAimKey);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.trkFOV);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.trkAimSmoth);
            this.tabPage2.Controls.Add(this.chkDrawFOV);
            this.tabPage2.Controls.Add(this.chkAimbot);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(306, 287);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Aimbot";
            // 
            // txtAimKey
            // 
            this.txtAimKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtAimKey.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold);
            this.txtAimKey.FormattingEnabled = true;
            this.txtAimKey.Items.AddRange(new object[] {
            "LButton",
            "RButton",
            "Caps Lock",
            "LShift",
            "V",
            "E",
            "Q"});
            this.txtAimKey.Location = new System.Drawing.Point(77, 91);
            this.txtAimKey.Name = "txtAimKey";
            this.txtAimKey.Size = new System.Drawing.Size(121, 23);
            this.txtAimKey.TabIndex = 17;
            this.txtAimKey.SelectedIndexChanged += new System.EventHandler(this.AimKeyCombo_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(14, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 15);
            this.label3.TabIndex = 16;
            this.label3.Text = "Aim Key :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(14, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 15);
            this.label2.TabIndex = 15;
            this.label2.Text = "FOV :";
            // 
            // trkFOV
            // 
            this.trkFOV.Location = new System.Drawing.Point(17, 166);
            this.trkFOV.Maximum = 4;
            this.trkFOV.Name = "trkFOV";
            this.trkFOV.Size = new System.Drawing.Size(269, 45);
            this.trkFOV.TabIndex = 14;
            this.trkFOV.Value = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(14, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 15);
            this.label1.TabIndex = 13;
            this.label1.Text = "Aim Smoth :";
            // 
            // trkAimSmoth
            // 
            this.trkAimSmoth.Location = new System.Drawing.Point(17, 46);
            this.trkAimSmoth.Maximum = 15;
            this.trkAimSmoth.Name = "trkAimSmoth";
            this.trkAimSmoth.Size = new System.Drawing.Size(269, 45);
            this.trkAimSmoth.TabIndex = 12;
            this.trkAimSmoth.Value = 7;
            // 
            // chkDrawFOV
            // 
            this.chkDrawFOV.AutoSize = true;
            this.chkDrawFOV.Checked = true;
            this.chkDrawFOV.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDrawFOV.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkDrawFOV.Location = new System.Drawing.Point(56, 141);
            this.chkDrawFOV.Name = "chkDrawFOV";
            this.chkDrawFOV.Size = new System.Drawing.Size(80, 19);
            this.chkDrawFOV.TabIndex = 11;
            this.chkDrawFOV.Text = "Draw FOV";
            this.chkDrawFOV.UseVisualStyleBackColor = true;
            this.chkDrawFOV.CheckedChanged += new System.EventHandler(this.CheckBox_Changed);
            // 
            // chkAimbot
            // 
            this.chkAimbot.AutoSize = true;
            this.chkAimbot.Checked = true;
            this.chkAimbot.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAimbot.Font = new System.Drawing.Font("Yu Gothic UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAimbot.Location = new System.Drawing.Point(8, 6);
            this.chkAimbot.Name = "chkAimbot";
            this.chkAimbot.Size = new System.Drawing.Size(66, 19);
            this.chkAimbot.TabIndex = 10;
            this.chkAimbot.Text = "Aimbot";
            this.chkAimbot.UseVisualStyleBackColor = true;
            this.chkAimbot.CheckedChanged += new System.EventHandler(this.CheckBox_Changed);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.chkFastLanding);
            this.tabPage3.Controls.Add(this.chkSpeedCar);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(306, 287);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Misc";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(314, 356);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.Btn_Activate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.Text = "PUBGM HACK - [ AM7 ]";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trkFOV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trkAimSmoth)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button Btn_Activate;
        private System.Windows.Forms.Timer LoopTimer;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.CheckBox chkBone;
        private System.Windows.Forms.CheckBox chk2DBox;
        private System.Windows.Forms.CheckBox chkESP;
        private System.Windows.Forms.CheckBox chkLines;
        private System.Windows.Forms.CheckBox chkHealth;
        private System.Windows.Forms.CheckBox chkItems;
        private System.Windows.Forms.CheckBox chkVehicle;
        private System.Windows.Forms.CheckBox chkFastLanding;
        private System.Windows.Forms.CheckBox chkSpeedCar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chkDrawFOV;
        private System.Windows.Forms.CheckBox chkAimbot;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trkAimSmoth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trkFOV;
        private System.Windows.Forms.ComboBox txtAimKey;
        private System.Windows.Forms.Label label3;
    }
}

