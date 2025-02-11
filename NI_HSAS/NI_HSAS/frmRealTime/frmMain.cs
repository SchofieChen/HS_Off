﻿using Automation.BDaq;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using log4net;
using NationalInstruments.DAQmx;
using NationalInstruments;
using System.Collections.Generic;

namespace NI_HSAS
{
    public partial class frmMain : Form
    {
        
        double[] xMaxchartxaxis = new double[1];
        private double[,] pretrigger;
        const int second = 1000;
        int convertClkRate = 10000;
        string deviceDescription = "DemoDevice,BID#0";
        //string profilePath = "../../../profile/DemoDevice.xml";
        int startChannel = 0;
        int sectionLength = 10000;
        int Freqrange = 2;
        int ptSize;
        int ptSaved;
        double maxinputrange;
        double mininputrange;
        int lowcutoff, highcutoff;
        private AnalogWaveform<double>[] data;
        private AnalogMultiChannelReader analogInReader;
        private AnalogMultiChannelReader reader;
        private NationalInstruments.DAQmx.Task myTask;
        private NationalInstruments.DAQmx.Task runningTask;
        private AsyncCallback analogCallback;
        SignalFilter SF = new SignalFilter();
        PointPairList list = new PointPairList();
        StoreData sd = new StoreData();
        private readonly static ILog _log = LogManager.GetLogger(typeof(Program));

        #region Into program log

        private static void LoadLog4netConfig()
        {
            System.IO.FileInfo f = new System.IO.FileInfo("log4net.config");
            log4net.Config.XmlConfigurator.Configure(f);
        }
        #endregion
        // Step 2: Set the notification event Handler by which we can known the state of operation effectively. 
        #region GUI Delegate Declarations
        public delegate void ChartDelegate(double[] sectionBuffers);
        public delegate void Chart2Delegate(double[] sectionBuffers);
        public delegate void Chart3Delegate(double[] sectionBuffers);
        #endregion

        #region Delegate Functions
        public void DoChart1update(double[] sectionBuffers)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    ChartDelegate delegateMethod = new ChartDelegate(this.DoChart1update);
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
        private void SaveDataMethod(int[] time, double[] timex,double[] sectionBuffers)
        {
            if (SavecheckBox.Checked)
            {

                _log.Info("Start store raw data");
                sd.CreateExcelFile(time, timex, sectionBuffers);
            }
        }
        private void CreateTimeGraph(ZedGraphControl zgc, double[] sectionBuffers)
        {
            try
            {
                convertClkRate = int.Parse(SamplingTextbox.Text);
                sectionLength = int.Parse(DataLengthtextBox.Text);
                int[] time = new int[sectionBuffers.Length];
                double[] timex = new double[sectionBuffers.Length];
                double[] storesectionBuffers = new double[10 * sectionBuffers.Length];
                for (int i = 0; i < sectionBuffers.Length; i++)
                {
                    time[i] = i;
                    timex[i] = i;
                    timex[i] = timex[i] / convertClkRate;
                }
                SaveDataMethod(time, timex, sectionBuffers);
                zgc.GraphPane.CurveList.Clear();
                GraphPane myPane = zgc.GraphPane;
                // Set the titles and axis labels
                double[] y = sectionBuffers;
                // Make up some data points from the Sine function
                LineItem myCurve;
                // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
                myCurve = zedGraphControl1.GraphPane.AddCurve("Channel 0 ", timex, y, Color.Blue, SymbolType.None);
                myCurve.Line.Width = 2.0f;
                // Make the symbols opaque by filling them with white
                myCurve.Symbol.Fill = new Fill(Color.White);
                // Fill the axis background with a color gradient
                zgc.AxisChange();
                zgc.Refresh();

            }
            catch (Exception err)
            {
                //waveformAiCtrl.Stop();
                _log.Error("Time domain calculate or drawing Error message is---" + err.Message);
                MessageBox.Show(err.Message);
                //waveformAiCtrl.Dispose();
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

        public void DoChart2update(double[] sectionBuffers)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Chart2Delegate delegateMethod = new Chart2Delegate(this.DoChart2update);
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

                int FreqMin = int.Parse(FreqMintextBox.Text);
                int FreqMax = int.Parse(FreqMaxtextBox.Text);
                convertClkRate = int.Parse(SamplingTextbox.Text);
                sectionLength = int.Parse(DataLengthtextBox.Text);
                Freqrange = int.Parse(FreqrangetextBox.Text);
                Complex[] fftsamples = new Complex[sectionLength];

                for (int i = 0; i < sectionLength; i++)
                {
                    fftsamples[i] = sectionBuffers[i];

                }
                Fourier.Forward(fftsamples, FourierOptions.NoScaling);
                double[] hzsample = new double[sectionBuffers.Length / Freqrange];
                double[] mag = new double[sectionBuffers.Length / Freqrange];
                for (int i = 0; i < fftsamples.Length / Freqrange; i++)
                {
                    mag[i] = 2000*(2.0 / sectionLength) * (Math.Abs(Math.Sqrt(Math.Pow(fftsamples[i].Real, 2) + Math.Pow(fftsamples[i].Imaginary, 2))));
                    hzsample[i] = convertClkRate / sectionLength * i;
                }
                int Minxlength = int.Parse(FreqMintextBox.Text);
                int Maxxlength = int.Parse(FreqMaxtextBox.Text);
                double[] x = new double[Minxlength];
                double[] y = new double[Minxlength];
                double[] x1 = new double[Maxxlength];
                double[] y1 = new double[Maxxlength];

                for (int i = 0; i < x.Length; i++)
                {
                    x[i] = i;
                }
                for (int i = 0; i < x1.Length; i++)
                {
                    x1[i] = i;
                }
                y[Minxlength - 1] = 10;
                y1[Maxxlength - 1] = 10;
                zgc.GraphPane.CurveList.Clear();
                GraphPane myPane = zgc.GraphPane;
                // Set the titles and axis labels  
                // Make up some data points from the Sine function
                LineItem myCurve;
                LineItem Mincurve;
                LineItem Maxcurve;
                PointPairList list = new PointPairList();
                list.Add(hzsample, mag);
                // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
                myCurve = zedGraphControl2.GraphPane.AddCurve("Channel 0", list, Color.Red, SymbolType.None);
                //myCurve = zedGraphControl2.GraphPane.AddCurve("Channel 0", hzsample, mag, Color.Red, SymbolType.None);
                Mincurve = zedGraphControl2.GraphPane.AddCurve("FreqMin", x, y, Color.DarkBlue, SymbolType.None);
                Maxcurve = zedGraphControl2.GraphPane.AddCurve("FreqMax", x1, y1, Color.DarkOrange, SymbolType.None);
                Mincurve.Line.Style = DashStyle.Custom;
                Mincurve.Line.Width = 2;
                Mincurve.Line.DashOn = 5;
                Mincurve.Line.DashOff = 5;
                Maxcurve.Line.Style = DashStyle.Custom;
                Maxcurve.Line.Width = 2;
                Maxcurve.Line.DashOn = 5;
                Maxcurve.Line.DashOff = 5;
                // Make the symbols opaque by filling them with white
                myCurve.Line.Fill = new Fill(Color.White, Color.Red, 45F);
                myCurve.Symbol.Fill = new Fill(Color.White);
                // Fill the axis background with a color gradient
                zgc.AxisChange();
                zgc.Refresh();

            }
            catch (Exception err)
            {
                _log.Error("Frequency domain calculate or drawing Error message is---" + err.Message);
                MessageBox.Show(err.Message);
            }


        }

        public void DoChart3update(double[] sectionBuffers)
        {
            try
            {
                if (this.InvokeRequired)
                {
                    Chart3Delegate delegateMethod = new Chart3Delegate(this.DoChart3update);
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
                zgc.GraphPane.CurveList.Clear();
                int FreqMin = int.Parse(FreqMintextBox.Text);
                int FreqMax = int.Parse(FreqMaxtextBox.Text);
                convertClkRate = int.Parse(SamplingTextbox.Text);
                sectionLength = int.Parse(DataLengthtextBox.Text);
                Freqrange = int.Parse(FreqrangetextBox.Text);
                Complex[] fftsamples = new Complex[sectionLength];
                xMaxchartxaxis[0] = xMaxchartxaxis[0] + 1 * sectionLength / convertClkRate;
                try
                {

                    for (int i = 0; i < sectionLength; i++)
                    {
                        fftsamples[i] = sectionBuffers[i];

                    }
                    Fourier.Forward(fftsamples, FourierOptions.NoScaling);
                    double[] mag = new double[sectionBuffers.Length];
                    double[] fftmax = new double[1];
                    for (int i = FreqMin; i < FreqMax; i++)
                    {
                        mag[i] = 2000 * (2.0 / sectionLength) * (Math.Abs(Math.Sqrt(Math.Pow(fftsamples[i].Real, 2) + Math.Pow(fftsamples[i].Imaginary, 2))));
                    }

                    fftmax[0] = mag.Max();

                    GraphPane myPane = zgc.GraphPane;
                    // Set the titles and axis labels  
                    double[] y = sectionBuffers;
                    LineItem myCurve;
                    if (LongTermcheckBox.Checked)
                    {
                        list.Add(xMaxchartxaxis, fftmax);
                        // Generate a blue curve with circle symbols, and "My Curve " in the legend          
                        myCurve = myPane.AddCurve("Channel 0", list, Color.DarkGreen, SymbolType.Square);
                        myCurve.Line.Width = 3.0f;
                        zgc.AxisChange();
                        zgc.Refresh();
                        StreamcheckBox.Checked = false;
                    }

                    else if (StreamcheckBox.Checked)
                    {
                        list.Add(xMaxchartxaxis, fftmax);
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
                    _log.Error("Time Max Chart drawing Error message is---" + err.Message);
                    MessageBox.Show(err.Message);
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
                // Fill the pane background with a color gradient
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
            //Thread.Sleep(3000);
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
                deviceDescription = DeviceIDtextBox.Text;

                string DAQinputrange = InputrangecomboBox.Text;
                string DAQaisignaltype = ConnecttypecomboBox.Text;
                convertClkRate = int.Parse(SamplingTextbox.Text);
                sectionLength = int.Parse(DataLengthtextBox.Text);
                startChannel = int.Parse(ChanneltextBox.Text);
                lowcutoff = int.Parse(Lowcutoffbox.Text);
                highcutoff = int.Parse(highcutoffbox.Text);
                bool trigger = triggerbox.Checked;
                int pretriggersamples = int.Parse(pretriggerSamples.Text);
                try
                {
                    _log.Info("Load DAQ parameter");
                    //mapping inputrange - 5 to 5 V // -10 to 10 V // -1 to 1 V // 4 to 20 mA 
                    switch (DAQinputrange)
                    {
                        case "-1 to 1 V":
                            maxinputrange = 1;
                            mininputrange = -1;
                            break;
                        case "-5 to 5 V":
                            maxinputrange = 5;
                            mininputrange = -5;
                            break;
                        case "-10 to 10 V":
                            maxinputrange = 10;
                            mininputrange = -10;
                            break;
                        default:
                            break;
                    }
            
                    if (runningTask == null)
                    {
                        try
                        {

                            // Create a new task
                            myTask = new NationalInstruments.DAQmx.Task();
      
                            // Create a virtual channel
                            myTask.AIChannels.CreateVoltageChannel(deviceDescription, "",
                                 AITerminalConfiguration.Pseudodifferential, mininputrange,
                                maxinputrange, AIVoltageUnits.Volts);

                            

                            // Configure the timing parameters
                            myTask.Timing.ConfigureSampleClock("", convertClkRate,
                                SampleClockActiveEdge.Rising, SampleQuantityMode.ContinuousSamples, 100000);
                            ptSaved = 0;

                            myTask.AIChannels.All.Coupling = AICoupling.AC;
                            if (IEPEcheckBox.Checked == true)
                            {
                                //Ai Channel 0 IEPE function output & set AC coupling 
                                myTask.AIChannels.All.ExcitationVoltageOrCurrent = AIExcitationVoltageOrCurrent.Current;
                                myTask.AIChannels.All.ExcitationSource = AIExcitationSource.Internal;
                                myTask.AIChannels.All.ExcitationValue = 0.0021;
                            }
                            

                            // Verify the Task
                            myTask.Control(TaskAction.Verify);
                            runningTask = myTask;


                            //Data buffer prepared
                            if (pretriggersamples <= sectionLength)
                            {
                                pretrigger = new double[myTask.AIChannels.Count, sectionLength];
                                ptSize = sectionLength;
                            }
                            else
                            {
                                // Make the size of the pretrigger buffer the smallest multiple of samples that is greater
                                // than the requested pretrigger samples
                                ptSize = ((int)(pretriggersamples / sectionLength) + 1) * sectionLength;
                                pretrigger = new double[myTask.AIChannels.Count, ptSize];
                            }



                            if (trigger == true)
                            {
                                reader = new AnalogMultiChannelReader(myTask.Stream);

                                // Use SynchronizeCallbacks to specify that the object 
                                // marshals callbacks across threads appropriately.
                                reader.SynchronizeCallbacks = true;
                                reader.BeginReadMultiSample(Convert.ToInt32(sectionLength), new AsyncCallback(ReadData), myTask);
                            }
                            else
                            {                            
                                analogInReader = new AnalogMultiChannelReader(myTask.Stream);
                                analogCallback = new AsyncCallback(AnalogInCallback);

                                // Use SynchronizeCallbacks to specify that the object 
                                // marshals callbacks across threads appropriately.
                                analogInReader.SynchronizeCallbacks = true;
                                analogInReader.BeginReadWaveform(sectionLength,
                                    analogCallback, myTask);
                            }
                            //Continue acquisition
                          
                        }
                        catch (NationalInstruments.DAQmx.DaqException exception)
                        {
                            // Display Errors
                            MessageBox.Show(exception.Message);
                            runningTask = null;
                            myTask.Dispose();

                        }
                    }
         
                }
                catch (Exception err)
                {
                    _log.Error("Faile to Load DAQ parameter message is---" + err.Message);
                }

                Console.WriteLine(" StreamingAI is in progress... any key to quit !\n");

                // Step 7: The device is acquiring data.

                // step 8: Stop the operation if it is running.
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
               // errorCode = waveformAiCtrl.Stop();

                //waveformAiCtrl.Dispose();
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
                MessageBox.Show(err.Message);
            }


        }

        private void AnalogInCallback(IAsyncResult ar)
        {
            string DAQinputrange = InputrangecomboBox.Text;
            string DAQaisignaltype = ConnecttypecomboBox.Text;
            convertClkRate = int.Parse(SamplingTextbox.Text);
            sectionLength = int.Parse(DataLengthtextBox.Text);
            startChannel = int.Parse(ChanneltextBox.Text);

            try
            {
                double[] sensordata = new double[sectionLength];
                if (runningTask != null && runningTask == ar.AsyncState)
                {
                    // Read the available data from the channels
                    data = analogInReader.EndReadWaveform(ar);
                    for (int i = 0; i < data[0].Samples.Count; i++)
                    {
                        sensordata[i] = data[0].Samples[i].Value;
                    }
                    // Plot your data her
                    sensordata = SF.Bandpassfilter(sensordata, convertClkRate, lowcutoff, highcutoff);
                    DoChart1update(sensordata);
                    DoChart2update(sensordata);
                    DoChart3update(sensordata);

                    //read data from data buffer 
                    analogInReader.BeginMemoryOptimizedReadWaveform(sectionLength,
                        analogCallback, myTask, data);
                }
            }
            catch (NationalInstruments.DAQmx.DaqException exception)
            {
                // Display Errors
                MessageBox.Show(exception.Message);
                runningTask = null;
                myTask.Dispose();
            }
        }
        private void StopAcquisitionBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (runningTask != null)
                {
                    // Dispose of the task
                    runningTask = null;
                    myTask.Dispose();
                }
                _log.Info("Stop to Data acquisition.");
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
                myTask.Dispose();
            }


        }
        private void ReadData(IAsyncResult ar)
        {
            try
            {
               
                if (runningTask != null && runningTask == ar.AsyncState)
                {
                    // Read the data
                    double[,] data = reader.EndReadMultiSample(ar);

                    // Get the channel index
                    int index = 0;

                    if (index < 0 || index >= myTask.AIChannels.Count)
                    {
                        MessageBox.Show("Invalid channel index.");
                        MessageBox.Show(myTask.AIChannels.Count + "");
                        myTask.Dispose();
                        runningTask = null;
                        return;
                    }
                    string DAQinputrange = InputrangecomboBox.Text;
                    string DAQaisignaltype = ConnecttypecomboBox.Text;
                    convertClkRate = int.Parse(SamplingTextbox.Text);
                    sectionLength = int.Parse(DataLengthtextBox.Text);
                    startChannel = int.Parse(ChanneltextBox.Text);
                    bool trigger = triggerbox.Checked;
                    int pretriggersamples = int.Parse(pretriggerSamples.Text);
                    // Analyze the data for a start trigger
                    double level = Convert.ToDouble(levelbox.Text);
                    double window = Convert.ToDouble(0.1);
                    int triggerLocation = FindTrigger(data, index, level, window);

                    //buffer setting
                    List<double> pretriggerbuffer = new List<double> { };
                    List<double> currentbuffer = new List<double> { };
                    List<double> remainbuffer = new List<double> { };
                    List<double> totaldata = new List<double> { };

                    // Read the next set of data
                    if (triggerLocation != -1)
                    {
                        // Found a trigger
                        int iDisplay = 0;
                        // Display pretrigger samples
                        if (pretriggersamples > triggerLocation)
                        {
                            // Figure out how many samples we need from the pretrigger buffer
                            int deficit = pretriggersamples - triggerLocation;

                            // Display samples from pretrigger buffer
                            for (int iData = 0; iData < deficit; iData++)
                            {
                                for (int iChan = 0; iChan < myTask.AIChannels.Count; iChan++)
                                {
                                    currentbuffer.Add(pretrigger[iChan, iData + ptSize - deficit]);
                                }

                                iDisplay++;
                            }

                            // Now include all samples up to the trigger location in data
                            for (int iData = 0; iData < triggerLocation; iData++)
                            {
                                for (int iChan = 0; iChan < myTask.AIChannels.Count; iChan++)
                                {
                                    remainbuffer.Add(data[iChan, iData]);
                                }

                                iDisplay++;
                            }
                            foreach (var item in currentbuffer)
                            {
                                totaldata.Add(item);
                            }
                            foreach (var item in remainbuffer)
                            {
                                totaldata.Add(item);
                            }
                            if (ptSaved + triggerLocation > pretriggersamples)
                                pretriggerAcquiredNumeric.Value = pretriggersamples;
                            else
                                pretriggerAcquiredNumeric.Value = ptSaved + triggerLocation;
                        }
                        else // pretriggerSamples <= triggerLocation
                        {
                            double[,] bufferdata;
                            
                            
                            // We have enough pretrigger samples in the current data array
                            for (int iData = 0; iData < pretriggersamples; iData++)
                            {
                                for (int iChan = 0; iChan < myTask.AIChannels.Count; iChan++)
                                {
                                    pretriggerbuffer.Add(data[iChan, iData + triggerLocation - pretriggersamples]);
                                }

                                iDisplay++;
                            }

                            pretriggerAcquiredNumeric.Value = pretriggersamples;
                        }
                        // Display data after the trigger
                        for (int iData = triggerLocation; iData < sectionLength; iData++)
                        {
                            for (int iChan = 0; iChan < myTask.AIChannels.Count; iChan++)
                            {
                                currentbuffer.Add(data[iChan, iData]);
                            }
                            
                            iDisplay++;
                        }

                        // Read more data
                        data = reader.ReadMultiSample(triggerLocation);
                        // Display additional data after trigger
                        for (int iData = 0; iData < triggerLocation; iData++)
                        {
                            for (int iChan = 0; iChan < myTask.AIChannels.Count; iChan++)
                            {
                                remainbuffer.Add(data[iChan, iData]);
                            }

                            iDisplay++;
                        }
                       
                        foreach (var item in pretriggerbuffer)
                        {
                            totaldata.Add(item);
                        }
                        foreach (var item in currentbuffer)
                        {
                            totaldata.Add(item);
                        }
                        foreach (var item in remainbuffer)
                        {
                            totaldata.Add(item);
                        }
                        DoChart1update(totaldata.ToArray());
                        // Stop the task
                        /*
                        myTask.Dispose();
                        startButton.Enabled = true;
                        stopButton.Enabled = false;
                        EnableControls(true);
                        runningTask = null;
                        */
                    }
                    else // triggerLocation == -1
                    {
                        // Trigger not found; save pretrigger samples
                        if (pretriggersamples <= sectionLength)
                        {
                            // Save only one iteration (over all channels)
                            for (int iChan = 0; iChan < myTask.AIChannels.Count; iChan++)
                            {
                                for (int iData = 0; iData < sectionLength; iData++)
                                {
                                    pretrigger[iChan, iData] = data[iChan, iData];
                                }
                            }
                        }
                        else // pretriggerSamples > samples
                        {
                            // Save over multiple iterations
                            int offset = ptSize - sectionLength;

                            // Shift elements in the array (discarding the first samples of data)
                            for (int iChan = 0; iChan < myTask.AIChannels.Count; iChan++)
                            {
                                for (int iData = 0; iData < offset; iData++)
                                {
                                    pretrigger[iChan, iData] = pretrigger[iChan, iData + sectionLength];
                                }
                            }

                            // Copy the new data into the array
                            for (int iChan = 0; iChan < myTask.AIChannels.Count; iChan++)
                            {
                                for (int iData = 0; iData < sectionLength; iData++)
                                {
                                    pretrigger[iChan, iData + offset] = data[iChan, iData];
                                }
                            }
                        }

                        ptSaved += sectionLength;

                        // Read the next set of samples
                        reader.BeginReadMultiSample(Convert.ToInt32(sectionLength), new AsyncCallback(ReadData), myTask);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                myTask.Dispose();
                // Display Errors
                runningTask = null;
            }
        }
        #endregion
        private int FindTrigger(double[,] data, int index, double level, double window)
        {
            int triggerLocation = -1;


            // Trigger if we find a voltage above the level
            for (int i = 0; i < data.GetLength(1); i++)
            {
                if (data[index, i] > level)
                {
                    triggerLocation = i;
                    break;
                }
            }

            return triggerLocation;
        }
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
