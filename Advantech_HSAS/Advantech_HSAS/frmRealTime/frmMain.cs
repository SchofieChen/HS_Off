﻿using Automation.BDaq;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Windows.Forms;
using ZedGraph;
using log4net;
using System.Collections.Generic;

namespace Advantech_HSAS
{
    public partial class frmMain : Form
    {
      
        int channelCount = 1,sectionCount = 0, lowcutoff = 0 , highcutoff;
        ErrorCode errorCode = ErrorCode.Success;
        ValueRange inputrange;
        AiSignalType aisignaltype;
        CouplingType coupletype;
        int convertClkRate;
        WaveformAiCtrl waveformAiCtrl = new WaveformAiCtrl();
        PointPairList list = new PointPairList();
        StoreData sd = new StoreData();
        SignalFilter SF = new SignalFilter();
        private readonly static ILog _log = LogManager.GetLogger(typeof(Program));


        #region Into program log

        private static void LoadLog4netConfig()
        {
            System.IO.FileInfo f = new System.IO.FileInfo("log4net.config");
            log4net.Config.XmlConfigurator.Configure(f);
        }
        #endregion

        #region GUI Delegate Declarations
        public delegate void TimeChartDelegate(double[] sectionBuffers);
        public delegate void FFTChartDelegate(double[] sectionBuffers);
        public delegate void MaxChartDelegate(double[] sectionBuffers);
        #endregion

        #region Delegate Functions
        public void DoTimeChartupdate(double[] sectionBuffers)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    TimeChartDelegate delegateMethod = new TimeChartDelegate(this.DoTimeChartupdate);
                    this.Invoke(delegateMethod, new object[] { sectionBuffers });
                }
                else
                {
                    CreateTimeGraph(zedGraphControl1, sectionBuffers);
                }
            }
            catch (Exception err)
            {
                _log.Error("Time domain Chart drawing Error message is---" + err.Message);
                MessageBox.Show(err.Message);
            }


        }

        private void CreateTimeGraph(ZedGraphControl zgc, double[] sectionBuffers)
        {
            try
            {
                DrawClass DC = DrawClass.GetInstance();
                List<double[]> excel_Info = new List<double[]> { };
                excel_Info = DC.DrawChart(zgc, sectionBuffers);

                if (SavecheckBox.Checked)
                {
                    _log.Info("Start store raw data");
                    sd.CreateExcelFile(excel_Info[0], excel_Info[1], sectionBuffers);
                }
            }
            catch (Exception err)
            {
                waveformAiCtrl.Stop();
                _log.Error("Time domain calculate or drawing Error message is---" + err.Message);
                MessageBox.Show(err.Message);
                waveformAiCtrl.Dispose();
                SamplingTextbox.Enabled = true;
                DataLengthtextBox.Enabled = true;
                ChanneltextBox.Enabled = true;
                FreqrangetextBox.Enabled = true;
                DeviceIDtextBox.Enabled = true;
                FreqMintextBox.Enabled = true;
                FreqMaxtextBox.Enabled = true;
                StartAcquisitionBtn.Enabled = true;
                StopAcquisitionBtn.Enabled = false;
            }


        }

        public void DoFFTChartupdate(double[] sectionBuffers)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    FFTChartDelegate delegateMethod = new FFTChartDelegate(this.DoFFTChartupdate);
                    this.Invoke(delegateMethod, new object[] { sectionBuffers });
                }
                else
                {
                    CreateFreqGraph(zedGraphControl2, sectionBuffers);
                }
            }
            catch (Exception err)
            {
                _log.Error("Frequency domain Chart drawing Error message is---" + err.Message);
                MessageBox.Show(err.Message);
            }

        }

        private void CreateFreqGraph(ZedGraphControl zgc, double[] sectionBuffers)
        {
            try
            {
                DrawFFTChart DFC = DrawFFTChart.GetInstance();
                DFC.DrawChart(zgc, sectionBuffers);
            }
            catch (Exception err)
            {
                _log.Error("Frequency domain calculate or drawing Error message is---" + err.Message);
                MessageBox.Show(err.Message);
            }


        }

        public void DoMaxChartupdate(double[] sectionBuffers)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    MaxChartDelegate delegateMethod = new MaxChartDelegate(this.DoMaxChartupdate);
                    this.Invoke(delegateMethod, new object[] { sectionBuffers });
                }
                else
                {
                    CreateFreqMaxGraph(zedGraphControl3, sectionBuffers);
                }
            }
            catch (Exception err)
            {
                _log.Error("Time Max Chart drawing Error message is---" + err.Message);
                MessageBox.Show(err.Message);
            }


        }

        private void CreateFreqMaxGraph(ZedGraphControl zgc, double[] sectionBuffers)
        {
            try
            {
                DrawMaxChart DMC = DrawMaxChart.GetInstance();

                List<double[]> chart_info = new List<double[]> { };
                chart_info = DMC.DrawChart(zgc, sectionBuffers);
                GraphPane myPane = zgc.GraphPane;
                // Set the titles and axis labels  

                LineItem myCurve;
                if (LongTermcheckBox.Checked)
                {
                    list.Add(chart_info[0], chart_info[1]);
                    // Generate a blue curve with circle symbols, and "My Curve " in the legend          
                    myCurve = myPane.AddCurve("Channel 0", list, Color.DarkGreen, SymbolType.Square);
                    myCurve.Line.Width = 3.0f;
                    zgc.AxisChange();
                    zgc.Refresh();
                    StreamcheckBox.Checked = false;
                }

                else if (StreamcheckBox.Checked)
                {
                    list.Add(chart_info[0], chart_info[1]);
                    // Generate a blue curve with circle symbols, and "My Curve 2" in the legend          
                    myCurve = myPane.AddCurve("Channel 0", list, Color.DarkGreen, SymbolType.Square);
                    myCurve.Line.Width = 3.0f;
                    zgc.AxisChange();
                    zgc.Refresh();
                    if (list.Count >= 30)
                    {
                        list.RemoveAt(0);

                    }
                    LongTermcheckBox.Checked = false;
                }
                else
                {
                    MessageBox.Show("chart attribute is null");
                    errorCode = waveformAiCtrl.Stop();
                    if (BioFailed(errorCode))
                    {
                        throw new Exception();
                    }
                    waveformAiCtrl.Dispose();
                    SamplingTextbox.Enabled = true;
                    DataLengthtextBox.Enabled = true;
                    ChanneltextBox.Enabled = true;
                    FreqrangetextBox.Enabled = true;
                    DeviceIDtextBox.Enabled = true;
                    FreqMintextBox.Enabled = true;
                    FreqMaxtextBox.Enabled = true;
                    StartAcquisitionBtn.Enabled = true;
                    StopAcquisitionBtn.Enabled = false;
                }



            }
            catch (Exception err)
            {
                _log.Error("initial textbox at max chart message is---" + err.Message);
                MessageBox.Show(err.Message);
            }


        }
        #endregion

        #region Initial form
        private void Intialgraph(ZedGraphControl zgc)
        {
            try
            {
                GraphPane myPane = zgc.GraphPane;
                myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
                myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
            }
            catch (Exception err)
            {
                _log.Error("Initialgraph error message is---" + err.Message);
                throw err;
            }

        }
        private void Intialgraph(ZedGraphControl zgc, string title, string xaxis, string yaxix)
        {
            try
            {
                GraphPane myPane = zgc.GraphPane;
                myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
                // Fill the pane background with a color gradient
                myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
                myPane.Title.Text = title;
                myPane.XAxis.Title.Text = xaxis;
                myPane.YAxis.Title.Text = yaxix;
                zgc.GraphPane.YAxis.MajorGrid.IsZeroLine = false;
                zgc.GraphPane.YAxis.MajorGrid.IsVisible = true;
                zgc.GraphPane.YAxis.MajorGrid.Color = Color.Black;
                zgc.GraphPane.XAxis.MajorGrid.IsVisible = true;
            }
            catch (Exception err)
            {
                _log.Error("Initialgraph error message is---" + err.Message);
                throw err;
            }

        }
        public frmMain()
        {
            Thread startformthread = new Thread(new ThreadStart(Startform));
            startformthread.Start();
            InitializeComponent();
            Intialgraph(zedGraphControl1, "Time Response", "Time (s)", "Voltage (V)");
            Intialgraph(zedGraphControl2, "Fast Fourier Transform", "Frequency (Hz)", "Voltage (V)");
            Intialgraph(zedGraphControl3, "Max chart", "Time (s)", "Voltage (V)");
            LongTermcheckBox.Checked = true;
            startformthread.Abort();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                LoadLog4netConfig();
                _log.Info("Application Start");
                DoubleBuffered = true;
                SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                StopAcquisitionBtn.Enabled = false;
                waveformAiCtrl.DataReady += new EventHandler<BfdAiEventArgs>(waveformAiCtrl_DataReady);
                waveformAiCtrl.Overrun += new EventHandler<BfdAiEventArgs>(waveformAiCtrl_Overrun);
            }
            catch (Exception err)
            {
                _log.Error("Application Start message is---" + err.Message);
                MessageBox.Show("Form Initial Failed");
            }


        }
        public void Startform()
        {
            Application.Run(new frmSplashScreen());
        }
        #endregion

        #region btn_start / stop
        private void StartAcquisitionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _log.Info("Starts to Data acquisition.");
                string deviceDescription = DeviceIDtextBox.Text;
                waveformAiCtrl.SelectedDevice = new DeviceInformation(deviceDescription);
               
                if (BioFailed(errorCode))
                {
                    throw new Exception();
                }
                string DAQinputrange = InputrangecomboBox.Text;
                string DAQaisignaltype = ConnecttypecomboBox.Text;
                string DAQCoupletype = CoupletypecomboBox.Text;
                convertClkRate = int.Parse(SamplingTextbox.Text);
                int sectionLength = int.Parse(DataLengthtextBox.Text);
                int startChannel = int.Parse(ChanneltextBox.Text);
                int Freqrange = int.Parse(FreqrangetextBox.Text);
                int Minxlength = int.Parse(FreqMintextBox.Text);
                int Maxxlength = int.Parse(FreqMaxtextBox.Text);
                lowcutoff = int.Parse(Lowcutoffbox.Text);
                highcutoff = int.Parse(highcutoffbox.Text);
                //Load parameter
                Conversion conversion = waveformAiCtrl.Conversion;
                conversion.ChannelStart = startChannel;
                conversion.ChannelCount = channelCount;
                conversion.ClockRate = convertClkRate;
                Record record = waveformAiCtrl.Record;
                record.SectionCount = sectionCount;// 'streaming' mode.
                record.SectionLength = sectionLength;
                //initial Draw parameter
                DrawClass DC = DrawClass.GetInstance();
                DC.Sampling = convertClkRate;
                DrawFFTChart DFC = DrawFFTChart.GetInstance();
                DFC.DataLength = sectionLength;
                DFC.Freqrange = Freqrange;
                DFC.FreqMax = Maxxlength;
                DFC.FreqMin = Minxlength;
                DFC.Sampling = convertClkRate;
                DrawMaxChart DMC = DrawMaxChart.GetInstance();
                DMC.DataLength = sectionLength;
                DMC.Freqrange = Freqrange;
                DMC.FreqMax = Maxxlength;
                DMC.FreqMin = Minxlength;
                DMC.Sampling = convertClkRate;
                try
                {
                    _log.Info("Load DAQ parameter");
                    //mapping inputrange - 5 to 5 V // -10 to 10 V // -1 to 1 V // 4 to 20 mA 
                    switch (DAQinputrange)
                    {
                        case "-1 to 1 V":
                            inputrange = ValueRange.V_Neg1To1;
                            break;
                        case "-1.25 to 1.25 V":
                            inputrange = ValueRange.V_Neg1pt25To1pt25;
                            break;
                        case "-5 to 5 V":
                            inputrange = ValueRange.V_Neg5To5;
                            break;
                        case "-10 to 10 V":
                            inputrange = ValueRange.V_Neg10To10;
                            break;
                        case "4 to 20 mA":
                            inputrange = ValueRange.mA_4To20;
                            break;
                        default:
                            break;
                    }

                    //mapping DAQ Signal Type // Differential // SingleEnded
                    switch (DAQaisignaltype)
                    {
                        case "Differential":
                            aisignaltype = AiSignalType.Differential;
                            break;
                        case "PsuedoDifferential":
                            aisignaltype = AiSignalType.PseudoDifferential;
                            break;
                        case "SingleEnded":
                            aisignaltype = AiSignalType.SingleEnded;
                            break;
                        default:
                            break;
                    }

                    switch (DAQCoupletype)
                    {
                        case "ACCouple":
                            coupletype = CouplingType.ACCoupling;
                            break;
                        case "DCCouple":
                            coupletype = CouplingType.DCCoupling;
                            break;
                        default:
                            break;
                    }


                    foreach (AnalogInputChannel ai in waveformAiCtrl.Channels)
                    {
                        if (DAQCoupletype != "None")
                        {
                            try
                            {
                                ai.CouplingType = coupletype;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("This DAQ do not support AC/DC Couple" + ex);
                            }

                        }
                        ai.ValueRange = inputrange;
                        ai.SignalType = aisignaltype;
                        if (IEPEcheckbox.Checked == true) 
                        {
                            ai.IepeType = IepeType.IEPE4mA;
                        }
                       
                    }
                }
                catch (Exception err)
                {
                    _log.Error("Faile to Load DAQ parameter message is---" + err.Message);
                }

                // prepare the Streaming AI. 
                errorCode = waveformAiCtrl.Prepare();
                if (BioFailed(errorCode))
                {
                    throw new Exception();
                }

                // The operation has been started
                // We can get samples via event handlers.
                errorCode = waveformAiCtrl.Start();
                if (BioFailed(errorCode))
                {
                    throw new Exception();
                }

                // The device is acquiring data.

                // Stop the operation if it is running.
                SamplingTextbox.Enabled = false;
                DataLengthtextBox.Enabled = false;
                ChanneltextBox.Enabled = false;
                FreqrangetextBox.Enabled = false;
                DeviceIDtextBox.Enabled = false;
                FreqMintextBox.Enabled = false;
                FreqMaxtextBox.Enabled = false;
                StartAcquisitionBtn.Enabled = false;
                StopAcquisitionBtn.Enabled = true;
                acquisitionstatus.Text = "Status : Start reading";
                acquisitionbar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
                _log.Info("Start Data Collection");
            }
            catch (Exception err)
            {
                errorCode = waveformAiCtrl.Stop();
                if (BioFailed(errorCode))
                {
                    throw new Exception();
                }
                waveformAiCtrl.Dispose();
                SamplingTextbox.Enabled = true;
                DataLengthtextBox.Enabled = true;
                ChanneltextBox.Enabled = true;
                FreqrangetextBox.Enabled = true;
                DeviceIDtextBox.Enabled = true;
                FreqMintextBox.Enabled = true;
                FreqMaxtextBox.Enabled = true;
                StartAcquisitionBtn.Enabled = true;
                StopAcquisitionBtn.Enabled = false;
                acquisitionstatus.Text = "Status : Stop";
                acquisitionbar.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
                _log.Error("Start acquisition failed---" + err.Message);
                // If something wrong in this execution, print the error code on screen for tracking.
                string errStr = BioFailed(errorCode) ? " Some error occurred. And the last error code is " + errorCode.ToString()
                                                        : err.Message;
                MessageBox.Show(errStr);
            }


        }

        private void StopAcquisitionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _log.Info("Stop to Data acquisition.");
                errorCode = waveformAiCtrl.Stop();
                if (BioFailed(errorCode))
                {
                    throw new Exception();
                }
                waveformAiCtrl.Dispose();
                SamplingTextbox.Enabled = true;
                DataLengthtextBox.Enabled = true;
                ChanneltextBox.Enabled = true;
                FreqrangetextBox.Enabled = true;
                DeviceIDtextBox.Enabled = true;
                FreqMintextBox.Enabled = true;
                FreqMaxtextBox.Enabled = true;
                StartAcquisitionBtn.Enabled = true;
                StopAcquisitionBtn.Enabled = false;
                acquisitionstatus.Text = "Status : Stop";
                acquisitionbar.Style = System.Windows.Forms.ProgressBarStyle.Blocks;
            }
            catch (Exception err)
            {
                _log.Error("Stop acquisition failed  message is ---" + err.Message);
                MessageBox.Show(err.Message);
            }


        }
        #endregion

        #region Data Acqusistion method
        public void waveformAiCtrl_Overrun(object sender, BfdAiEventArgs e)
        {
            try
            {
                _log.Error("Data Overrun");
                //throw new Exception("Maybe one method or operation is busy.");
            }
            catch (Exception err)
            {
                _log.Error("Data Overrun");
                MessageBox.Show(err.Message); ;
            }
        }

        public void waveformAiCtrl_DataReady(object sender, BfdAiEventArgs e)
        {
            try
            {
                Int32 returnedCount = 0;
                WaveformAiCtrl waveformAiCtrl = (WaveformAiCtrl)sender;
                Conversion conversion = waveformAiCtrl.Conversion;
                Record record = waveformAiCtrl.Record;
                int channelCountMax = waveformAiCtrl.Features.ChannelCountMax;
                int startChan = conversion.ChannelStart;
                int channelCount = conversion.ChannelCount;
                int sectionLengt = record.SectionLength;
                int getDataCount = sectionLengt * channelCount;

                // buffer section length, when 'DataReady' event been signaled, driver renew data count is e.count. 
                if (e.Count > channelCount)
                {                   
                    double[] sectionBuffers = new double[getDataCount];
                    getDataCount = Math.Min(getDataCount, e.Count);
                    waveformAiCtrl.GetData(getDataCount, sectionBuffers, 0, out returnedCount);
                    /* Filter
                    //sectionBuffers = SF.Bandpassfilter(sectionBuffers, convertClkRate, lowcutoff, highcutoff);
                    //sectionBuffers = SF.Butterworth(sectionBuffers, convertClkRate, 100);
                    */
                    DoTimeChartupdate(sectionBuffers);
                    DoFFTChartupdate(sectionBuffers);
                    DoMaxChartupdate(sectionBuffers);
                }
            }
            catch (Exception err)
            {
                _log.Error("Failed to Data Collection---" + err.Message);
                MessageBox.Show(err.Message); ;
            }

        }

        static bool BioFailed(ErrorCode err)
        {
            return err < ErrorCode.Success && err >= ErrorCode.ErrorHandleNotValid;
        }

        #endregion

        private void LongTermcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (LongTermcheckBox.Checked == true)
                StreamcheckBox.Checked = false;

        }

        private void StreamcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (StreamcheckBox.Checked == true)
                LongTermcheckBox.Checked = false;
        }

        private void ResetGraphBtn_Click(object sender, EventArgs e)
        {
            _log.Info("Reset All Graph.");
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl2.GraphPane.CurveList.Clear();
            zedGraphControl3.GraphPane.CurveList.Clear();
            zedGraphControl1.Refresh();
            zedGraphControl2.Refresh();
            zedGraphControl3.Refresh();
            list.Clear();

        }

        private void DataLengthtextBox_TextChanged(object sender, EventArgs e)
        {
            int datalength = int.Parse(DataLengthtextBox.Text);
            int FreqMax = int.Parse(FreqMaxtextBox.Text);
            if (datalength < FreqMax)
            {
                MessageBox.Show("DataLength must > Max of Frequency ");
            }
        }

        private void fastFourierTransformFFTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread startfftformthread = new Thread(new ThreadStart(Startfftform));
            startfftformthread.Start();
        }

        public void Startfftform()
        {
            Application.Run(new frmfft());
        }


    }
}
