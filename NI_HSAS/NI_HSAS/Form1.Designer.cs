namespace mathffttest
{
    partial class Form1
    {

        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SamplingTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DataLengthtextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChanneltextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FreqrangetextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DeviceIDtextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.FreqMintextBox = new System.Windows.Forms.TextBox();
            this.FreqMaxtextBox = new System.Windows.Forms.TextBox();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.StreamcheckBox = new System.Windows.Forms.CheckBox();
            this.LongTermcheckBox = new System.Windows.Forms.CheckBox();
            this.ResetGraphBtn = new System.Windows.Forms.Button();
            this.SavecheckBox = new System.Windows.Forms.CheckBox();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 19);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 21);
            this.button2.TabIndex = 3;
            this.button2.Text = "Start Data acquisition";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(191, 19);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(178, 21);
            this.button3.TabIndex = 4;
            this.button3.Text = "Stop Data Acquisition";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // SamplingTextbox
            // 
            this.SamplingTextbox.Location = new System.Drawing.Point(141, 19);
            this.SamplingTextbox.Name = "SamplingTextbox";
            this.SamplingTextbox.Size = new System.Drawing.Size(100, 22);
            this.SamplingTextbox.TabIndex = 5;
            this.SamplingTextbox.Text = "10000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "Sampling Rate:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Data Length:\r\n (Buffer)";
            // 
            // DataLengthtextBox
            // 
            this.DataLengthtextBox.Location = new System.Drawing.Point(141, 48);
            this.DataLengthtextBox.Name = "DataLengthtextBox";
            this.DataLengthtextBox.Size = new System.Drawing.Size(100, 22);
            this.DataLengthtextBox.TabIndex = 9;
            this.DataLengthtextBox.Text = "10000";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 10;
            this.label3.Text = "Channel:";
            // 
            // ChanneltextBox
            // 
            this.ChanneltextBox.Location = new System.Drawing.Point(141, 84);
            this.ChanneltextBox.Name = "ChanneltextBox";
            this.ChanneltextBox.Size = new System.Drawing.Size(100, 22);
            this.ChanneltextBox.TabIndex = 11;
            this.ChanneltextBox.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Frequency Range:\r\n";
            // 
            // FreqrangetextBox
            // 
            this.FreqrangetextBox.Location = new System.Drawing.Point(141, 116);
            this.FreqrangetextBox.Name = "FreqrangetextBox";
            this.FreqrangetextBox.Size = new System.Drawing.Size(100, 22);
            this.FreqrangetextBox.TabIndex = 13;
            this.FreqrangetextBox.Text = "20";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.DeviceIDtextBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.FreqrangetextBox);
            this.groupBox1.Controls.Add(this.SamplingTextbox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ChanneltextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.DataLengthtextBox);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(1205, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(570, 185);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DAQ Info";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(247, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(18, 12);
            this.label11.TabIndex = 23;
            this.label11.Text = "Hz";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(247, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 12);
            this.label10.TabIndex = 22;
            this.label10.Text = "Count";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(247, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "Hz";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(271, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 12);
            this.label7.TabIndex = 17;
            this.label7.Text = "(Must > 2)";
            // 
            // DeviceIDtextBox
            // 
            this.DeviceIDtextBox.Location = new System.Drawing.Point(141, 150);
            this.DeviceIDtextBox.Name = "DeviceIDtextBox";
            this.DeviceIDtextBox.Size = new System.Drawing.Size(100, 22);
            this.DeviceIDtextBox.TabIndex = 15;
            this.DeviceIDtextBox.Text = "DemoDevice,BID#0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "DAQ DeviceID:";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.FreqMintextBox);
            this.groupBox2.Controls.Add(this.FreqMaxtextBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Location = new System.Drawing.Point(1205, 239);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 74);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Frequency Band Calculation ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(153, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 12);
            this.label12.TabIndex = 24;
            this.label12.Text = "Hz";
            // 
            // FreqMintextBox
            // 
            this.FreqMintextBox.Location = new System.Drawing.Point(50, 17);
            this.FreqMintextBox.Name = "FreqMintextBox";
            this.FreqMintextBox.Size = new System.Drawing.Size(100, 22);
            this.FreqMintextBox.TabIndex = 20;
            this.FreqMintextBox.Text = "1";
            // 
            // FreqMaxtextBox
            // 
            this.FreqMaxtextBox.Location = new System.Drawing.Point(50, 46);
            this.FreqMaxtextBox.Name = "FreqMaxtextBox";
            this.FreqMaxtextBox.Size = new System.Drawing.Size(100, 22);
            this.FreqMaxtextBox.TabIndex = 18;
            this.FreqMaxtextBox.Text = "5000";
            // 
            // zedGraphControl3
            // 
            this.zedGraphControl3.BackColor = System.Drawing.Color.Aqua;
            this.zedGraphControl3.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl3.Location = new System.Drawing.Point(1205, 315);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zedGraphControl3.ScrollGrace = 0D;
            this.zedGraphControl3.ScrollMaxX = 0D;
            this.zedGraphControl3.ScrollMaxY = 0D;
            this.zedGraphControl3.ScrollMaxY2 = 0D;
            this.zedGraphControl3.ScrollMinX = 0D;
            this.zedGraphControl3.ScrollMinY = 0D;
            this.zedGraphControl3.ScrollMinY2 = 0D;
            this.zedGraphControl3.Size = new System.Drawing.Size(570, 373);
            this.zedGraphControl3.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(27, 12);
            this.label8.TabIndex = 19;
            this.label8.Text = "Min:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 12);
            this.label6.TabIndex = 18;
            this.label6.Text = "Max : ";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ResetGraphBtn);
            this.groupBox3.Controls.Add(this.SavecheckBox);
            this.groupBox3.Controls.Add(this.zedGraphControl2);
            this.groupBox3.Controls.Add(this.zedGraphControl1);
            this.groupBox3.Controls.Add(this.zedGraphControl3);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 11);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1785, 703);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SMG Data Acquisition Analysis System";
            // 
            // StreamcheckBox
            // 
            this.StreamcheckBox.AutoSize = true;
            this.StreamcheckBox.Location = new System.Drawing.Point(8, 34);
            this.StreamcheckBox.Name = "StreamcheckBox";
            this.StreamcheckBox.Size = new System.Drawing.Size(56, 16);
            this.StreamcheckBox.TabIndex = 22;
            this.StreamcheckBox.Text = "Stream";
            this.StreamcheckBox.UseVisualStyleBackColor = true;
            this.StreamcheckBox.CheckedChanged += new System.EventHandler(this.StreamcheckBox_CheckedChanged);
            // 
            // LongTermcheckBox
            // 
            this.LongTermcheckBox.AutoSize = true;
            this.LongTermcheckBox.Location = new System.Drawing.Point(8, 15);
            this.LongTermcheckBox.Name = "LongTermcheckBox";
            this.LongTermcheckBox.Size = new System.Drawing.Size(77, 16);
            this.LongTermcheckBox.TabIndex = 21;
            this.LongTermcheckBox.Text = "Long Term";
            this.LongTermcheckBox.UseVisualStyleBackColor = true;
            this.LongTermcheckBox.CheckedChanged += new System.EventHandler(this.LongTermcheckBox_CheckedChanged);
            // 
            // ResetGraphBtn
            // 
            this.ResetGraphBtn.Location = new System.Drawing.Point(375, 19);
            this.ResetGraphBtn.Name = "ResetGraphBtn";
            this.ResetGraphBtn.Size = new System.Drawing.Size(178, 21);
            this.ResetGraphBtn.TabIndex = 23;
            this.ResetGraphBtn.Text = "Reset All Graph";
            this.ResetGraphBtn.UseVisualStyleBackColor = true;
            this.ResetGraphBtn.Click += new System.EventHandler(this.ResetGraphBtn_Click);
            // 
            // SavecheckBox
            // 
            this.SavecheckBox.AutoSize = true;
            this.SavecheckBox.Location = new System.Drawing.Point(559, 24);
            this.SavecheckBox.Name = "SavecheckBox";
            this.SavecheckBox.Size = new System.Drawing.Size(96, 16);
            this.SavecheckBox.TabIndex = 20;
            this.SavecheckBox.Text = "Store Raw Data";
            this.SavecheckBox.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.BackColor = System.Drawing.Color.Aqua;
            this.zedGraphControl2.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl2.Location = new System.Drawing.Point(6, 370);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(1193, 318);
            this.zedGraphControl2.TabIndex = 18;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.BackColor = System.Drawing.Color.Aqua;
            this.zedGraphControl1.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl1.Location = new System.Drawing.Point(6, 46);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1193, 318);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightCyan;
            this.groupBox4.Controls.Add(this.StreamcheckBox);
            this.groupBox4.Controls.Add(this.LongTermcheckBox);
            this.groupBox4.Location = new System.Drawing.Point(178, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(103, 55);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chart attribute";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1806, 715);
            this.Controls.Add(this.groupBox3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "SMG High Sampling Analysis System (HSAS)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox SamplingTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DataLengthtextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ChanneltextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox FreqrangetextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox DeviceIDtextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox FreqMintextBox;
        private System.Windows.Forms.TextBox FreqMaxtextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private ZedGraph.ZedGraphControl zedGraphControl2;
        private ZedGraph.ZedGraphControl zedGraphControl3;
        private System.Windows.Forms.CheckBox SavecheckBox;
        private System.Windows.Forms.CheckBox StreamcheckBox;
        private System.Windows.Forms.CheckBox LongTermcheckBox;
        private System.Windows.Forms.Button ResetGraphBtn;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

