namespace Advantech_HSAS
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.StartAcquisitionBtn = new System.Windows.Forms.Button();
            this.StopAcquisitionBtn = new System.Windows.Forms.Button();
            this.SamplingTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DataLengthtextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ChanneltextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.FreqrangetextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CoupletypecomboBox = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.highcutoffbox = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Lowcutoffbox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ConnecttypecomboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.InputrangecomboBox = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.DeviceIDtextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.StreamcheckBox = new System.Windows.Forms.CheckBox();
            this.LongTermcheckBox = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.FreqMintextBox = new System.Windows.Forms.TextBox();
            this.FreqMaxtextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.zedGraphControl3 = new ZedGraph.ZedGraphControl();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.IEPEcheckbox = new System.Windows.Forms.CheckBox();
            this.toolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.acquisitionstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.acquisitionbar = new System.Windows.Forms.ToolStripProgressBar();
            this.ResetGraphBtn = new System.Windows.Forms.Button();
            this.SavecheckBox = new System.Windows.Forms.CheckBox();
            this.zedGraphControl2 = new ZedGraph.ZedGraphControl();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsNewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.overWriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.supportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastFourierTransformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nyquistSamplingTheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
            this.shorTimeFourierTransformSTFTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waveletTransformToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fastFourierTransformFFTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.toolStripContainer2.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartAcquisitionBtn
            // 
            this.StartAcquisitionBtn.Location = new System.Drawing.Point(26, 19);
            this.StartAcquisitionBtn.Name = "StartAcquisitionBtn";
            this.StartAcquisitionBtn.Size = new System.Drawing.Size(159, 21);
            this.StartAcquisitionBtn.TabIndex = 3;
            this.StartAcquisitionBtn.Text = "Start Data acquisition";
            this.StartAcquisitionBtn.UseVisualStyleBackColor = true;
            this.StartAcquisitionBtn.Click += new System.EventHandler(this.StartAcquisitionBtn_Click);
            // 
            // StopAcquisitionBtn
            // 
            this.StopAcquisitionBtn.Location = new System.Drawing.Point(191, 19);
            this.StopAcquisitionBtn.Name = "StopAcquisitionBtn";
            this.StopAcquisitionBtn.Size = new System.Drawing.Size(178, 21);
            this.StopAcquisitionBtn.TabIndex = 4;
            this.StopAcquisitionBtn.Text = "Stop Data Acquisition";
            this.StopAcquisitionBtn.UseVisualStyleBackColor = true;
            this.StopAcquisitionBtn.Click += new System.EventHandler(this.StopAcquisitionBtn_Click);
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
            this.groupBox1.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox1.Controls.Add(this.CoupletypecomboBox);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.highcutoffbox);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.Lowcutoffbox);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.ConnecttypecomboBox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.InputrangecomboBox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label15);
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
            this.groupBox1.Location = new System.Drawing.Point(1123, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 185);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DAQ Info";
            // 
            // CoupletypecomboBox
            // 
            this.CoupletypecomboBox.FormattingEnabled = true;
            this.CoupletypecomboBox.Items.AddRange(new object[] {
            "ACCouple",
            "DCCouple",
            "None"});
            this.CoupletypecomboBox.Location = new System.Drawing.Point(388, 72);
            this.CoupletypecomboBox.Name = "CoupletypecomboBox";
            this.CoupletypecomboBox.Size = new System.Drawing.Size(121, 20);
            this.CoupletypecomboBox.TabIndex = 37;
            this.CoupletypecomboBox.Text = "ACCouple";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(300, 76);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(65, 12);
            this.label19.TabIndex = 36;
            this.label19.Text = "Couple type:\r\n";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(485, 141);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(18, 12);
            this.label18.TabIndex = 35;
            this.label18.Text = "Hz";
            // 
            // highcutoffbox
            // 
            this.highcutoffbox.Location = new System.Drawing.Point(405, 135);
            this.highcutoffbox.Name = "highcutoffbox";
            this.highcutoffbox.Size = new System.Drawing.Size(77, 22);
            this.highcutoffbox.TabIndex = 34;
            this.highcutoffbox.Text = "5000";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(404, 120);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(59, 12);
            this.label17.TabIndex = 33;
            this.label17.Text = "High cutoff";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(301, 120);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(57, 12);
            this.label14.TabIndex = 32;
            this.label14.Text = "Low cutoff";
            // 
            // Lowcutoffbox
            // 
            this.Lowcutoffbox.Location = new System.Drawing.Point(302, 135);
            this.Lowcutoffbox.Name = "Lowcutoffbox";
            this.Lowcutoffbox.Size = new System.Drawing.Size(77, 22);
            this.Lowcutoffbox.TabIndex = 24;
            this.Lowcutoffbox.Text = "5";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(301, 106);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(26, 12);
            this.label13.TabIndex = 31;
            this.label13.Text = "FIR:";
            // 
            // ConnecttypecomboBox
            // 
            this.ConnecttypecomboBox.FormattingEnabled = true;
            this.ConnecttypecomboBox.Items.AddRange(new object[] {
            "Differential",
            "PsuedoDifferential",
            "SingleEnded"});
            this.ConnecttypecomboBox.Location = new System.Drawing.Point(388, 46);
            this.ConnecttypecomboBox.Name = "ConnecttypecomboBox";
            this.ConnecttypecomboBox.Size = new System.Drawing.Size(121, 20);
            this.ConnecttypecomboBox.TabIndex = 30;
            this.ConnecttypecomboBox.Text = "Differential";
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
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(300, 50);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(85, 12);
            this.label16.TabIndex = 29;
            this.label16.Text = "Connection type:\r\n";
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
            // InputrangecomboBox
            // 
            this.InputrangecomboBox.FormattingEnabled = true;
            this.InputrangecomboBox.Items.AddRange(new object[] {
            "-1 to 1 V",
            "-1.25 to 1.25 V",
            "-5 to 5 V",
            "-10 to 10 V",
            "4 to 20 mA"});
            this.InputrangecomboBox.Location = new System.Drawing.Point(388, 15);
            this.InputrangecomboBox.Name = "InputrangecomboBox";
            this.InputrangecomboBox.Size = new System.Drawing.Size(121, 20);
            this.InputrangecomboBox.TabIndex = 28;
            this.InputrangecomboBox.Text = "-10 to 10 V";
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
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(300, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 12);
            this.label15.TabIndex = 27;
            this.label15.Text = "Input range:\r\n";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(17, 131);
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
            this.groupBox2.Location = new System.Drawing.Point(1123, 259);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 74);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Frequency Band Calculation ";
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
            // zedGraphControl3
            // 
            this.zedGraphControl3.BackColor = System.Drawing.Color.Aqua;
            this.zedGraphControl3.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl3.Location = new System.Drawing.Point(1121, 368);
            this.zedGraphControl3.Name = "zedGraphControl3";
            this.zedGraphControl3.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zedGraphControl3.ScrollGrace = 0D;
            this.zedGraphControl3.ScrollMaxX = 0D;
            this.zedGraphControl3.ScrollMaxY = 0D;
            this.zedGraphControl3.ScrollMaxY2 = 0D;
            this.zedGraphControl3.ScrollMinX = 0D;
            this.zedGraphControl3.ScrollMinY = 0D;
            this.zedGraphControl3.ScrollMinY2 = 0D;
            this.zedGraphControl3.Size = new System.Drawing.Size(545, 369);
            this.zedGraphControl3.TabIndex = 19;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.IEPEcheckbox);
            this.groupBox3.Controls.Add(this.toolStripContainer2);
            this.groupBox3.Controls.Add(this.ResetGraphBtn);
            this.groupBox3.Controls.Add(this.SavecheckBox);
            this.groupBox3.Controls.Add(this.zedGraphControl2);
            this.groupBox3.Controls.Add(this.zedGraphControl1);
            this.groupBox3.Controls.Add(this.zedGraphControl3);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.StartAcquisitionBtn);
            this.groupBox3.Controls.Add(this.StopAcquisitionBtn);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Font = new System.Drawing.Font("新細明體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(9, 48);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1680, 768);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "SMG Data Acquisition Analysis System";
            // 
            // IEPEcheckbox
            // 
            this.IEPEcheckbox.AutoSize = true;
            this.IEPEcheckbox.ForeColor = System.Drawing.Color.Maroon;
            this.IEPEcheckbox.Location = new System.Drawing.Point(664, 24);
            this.IEPEcheckbox.Name = "IEPEcheckbox";
            this.IEPEcheckbox.Size = new System.Drawing.Size(92, 16);
            this.IEPEcheckbox.TabIndex = 24;
            this.IEPEcheckbox.Text = "IEPE activated";
            this.IEPEcheckbox.UseVisualStyleBackColor = true;
            // 
            // toolStripContainer2
            // 
            // 
            // toolStripContainer2.ContentPanel
            // 
            this.toolStripContainer2.ContentPanel.Size = new System.Drawing.Size(518, 0);
            this.toolStripContainer2.Location = new System.Drawing.Point(6, 743);
            this.toolStripContainer2.Name = "toolStripContainer2";
            this.toolStripContainer2.Size = new System.Drawing.Size(518, 19);
            this.toolStripContainer2.TabIndex = 20;
            this.toolStripContainer2.Text = "toolStripContainer2";
            // 
            // toolStripContainer2.TopToolStripPanel
            // 
            this.toolStripContainer2.TopToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acquisitionstatus,
            this.acquisitionbar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(518, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // acquisitionstatus
            // 
            this.acquisitionstatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.acquisitionstatus.Name = "acquisitionstatus";
            this.acquisitionstatus.Size = new System.Drawing.Size(83, 17);
            this.acquisitionstatus.Text = "Status : None";
            // 
            // acquisitionbar
            // 
            this.acquisitionbar.MarqueeAnimationSpeed = 50;
            this.acquisitionbar.Name = "acquisitionbar";
            this.acquisitionbar.Size = new System.Drawing.Size(150, 16);
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
            this.SavecheckBox.ForeColor = System.Drawing.Color.Maroon;
            this.SavecheckBox.Location = new System.Drawing.Point(559, 24);
            this.SavecheckBox.Name = "SavecheckBox";
            this.SavecheckBox.Size = new System.Drawing.Size(99, 16);
            this.SavecheckBox.TabIndex = 20;
            this.SavecheckBox.Text = "Store Raw Data ";
            this.SavecheckBox.UseVisualStyleBackColor = true;
            // 
            // zedGraphControl2
            // 
            this.zedGraphControl2.BackColor = System.Drawing.Color.Aqua;
            this.zedGraphControl2.EditButtons = System.Windows.Forms.MouseButtons.Left;
            this.zedGraphControl2.Location = new System.Drawing.Point(6, 368);
            this.zedGraphControl2.Name = "zedGraphControl2";
            this.zedGraphControl2.PanModifierKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)));
            this.zedGraphControl2.ScrollGrace = 0D;
            this.zedGraphControl2.ScrollMaxX = 0D;
            this.zedGraphControl2.ScrollMaxY = 0D;
            this.zedGraphControl2.ScrollMaxY2 = 0D;
            this.zedGraphControl2.ScrollMinX = 0D;
            this.zedGraphControl2.ScrollMinY = 0D;
            this.zedGraphControl2.ScrollMinY2 = 0D;
            this.zedGraphControl2.Size = new System.Drawing.Size(1109, 369);
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
            this.zedGraphControl1.Size = new System.Drawing.Size(1109, 316);
            this.zedGraphControl1.TabIndex = 0;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1427, 4);
            this.toolStripContainer1.Location = new System.Drawing.Point(9, 13);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1427, 29);
            this.toolStripContainer1.TabIndex = 19;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripDropDownButton2,
            this.toolStripSeparator1,
            this.toolStripDropDownButton3});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(236, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.printToolStripMenuItem,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(40, 22);
            this.toolStripDropDownButton1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsNewToolStripMenuItem,
            this.overWriteToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // saveAsNewToolStripMenuItem
            // 
            this.saveAsNewToolStripMenuItem.Name = "saveAsNewToolStripMenuItem";
            this.saveAsNewToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.saveAsNewToolStripMenuItem.Text = "Save as new";
            // 
            // overWriteToolStripMenuItem
            // 
            this.overWriteToolStripMenuItem.Name = "overWriteToolStripMenuItem";
            this.overWriteToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.overWriteToolStripMenuItem.Text = "Overwrite";
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.printToolStripMenuItem.Text = "Print";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(105, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.supportToolStripMenuItem});
            this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(56, 22);
            this.toolStripDropDownButton2.Text = "About";
            // 
            // supportToolStripMenuItem
            // 
            this.supportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fastFourierTransformToolStripMenuItem,
            this.nyquistSamplingTheToolStripMenuItem});
            this.supportToolStripMenuItem.Name = "supportToolStripMenuItem";
            this.supportToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.supportToolStripMenuItem.Text = "Support";
            // 
            // fastFourierTransformToolStripMenuItem
            // 
            this.fastFourierTransformToolStripMenuItem.Name = "fastFourierTransformToolStripMenuItem";
            this.fastFourierTransformToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.fastFourierTransformToolStripMenuItem.Text = "Fast Fourier Transform";
            // 
            // nyquistSamplingTheToolStripMenuItem
            // 
            this.nyquistSamplingTheToolStripMenuItem.Name = "nyquistSamplingTheToolStripMenuItem";
            this.nyquistSamplingTheToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.nyquistSamplingTheToolStripMenuItem.Text = "Nyquist sampling theorem";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton3
            // 
            this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shorTimeFourierTransformSTFTToolStripMenuItem,
            this.waveletTransformToolStripMenuItem,
            this.fastFourierTransformFFTToolStripMenuItem});
            this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
            this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
            this.toolStripDropDownButton3.Size = new System.Drawing.Size(122, 22);
            this.toolStripDropDownButton3.Text = "Spectrum Analysis";
            // 
            // shorTimeFourierTransformSTFTToolStripMenuItem
            // 
            this.shorTimeFourierTransformSTFTToolStripMenuItem.Name = "shorTimeFourierTransformSTFTToolStripMenuItem";
            this.shorTimeFourierTransformSTFTToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.shorTimeFourierTransformSTFTToolStripMenuItem.Text = "Shor Time Fourier Transform (STFT)";
            // 
            // waveletTransformToolStripMenuItem
            // 
            this.waveletTransformToolStripMenuItem.Name = "waveletTransformToolStripMenuItem";
            this.waveletTransformToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.waveletTransformToolStripMenuItem.Text = "Continuous Wavelet Transform (CWT) ";
            // 
            // fastFourierTransformFFTToolStripMenuItem
            // 
            this.fastFourierTransformFFTToolStripMenuItem.Name = "fastFourierTransformFFTToolStripMenuItem";
            this.fastFourierTransformFFTToolStripMenuItem.Size = new System.Drawing.Size(290, 22);
            this.fastFourierTransformFFTToolStripMenuItem.Text = "Fast Fourier Transform (FFT)";
            this.fastFourierTransformFFTToolStripMenuItem.Click += new System.EventHandler(this.fastFourierTransformFFTToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1686, 851);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.groupBox3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMG High Sampling Analysis System (HSAS)";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.toolStripContainer2.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer2.TopToolStripPanel.PerformLayout();
            this.toolStripContainer2.ResumeLayout(false);
            this.toolStripContainer2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button StartAcquisitionBtn;
        private System.Windows.Forms.Button StopAcquisitionBtn;
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
        private System.Windows.Forms.CheckBox StreamcheckBox;
        private System.Windows.Forms.CheckBox LongTermcheckBox;
        private System.Windows.Forms.Button ResetGraphBtn;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsNewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem overWriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripMenuItem supportToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastFourierTransformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nyquistSamplingTheToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
        private System.Windows.Forms.ToolStripMenuItem shorTimeFourierTransformSTFTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waveletTransformToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fastFourierTransformFFTToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel acquisitionstatus;
        private System.Windows.Forms.ToolStripProgressBar acquisitionbar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ComboBox ConnecttypecomboBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox InputrangecomboBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.CheckBox SavecheckBox;
        private System.Windows.Forms.TextBox highcutoffbox;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Lowcutoffbox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.CheckBox IEPEcheckbox;
        private System.Windows.Forms.ComboBox CoupletypecomboBox;
        private System.Windows.Forms.Label label19;
    }
}

