using Automation.BDaq;
using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;

namespace mathffttest
{
    public partial class Form1 : Form
    {
        double[] xMaxchartxaxis = new double[1];
        const int second = 1000;
        double convertClkRate = 10000;
        string deviceDescription = "DemoDevice,BID#0";
        //string profilePath = "../../../profile/DemoDevice.xml";
        int startChannel = 0;
        int channelCount = 1;
        int sectionLength = 10000;
        int sectionCount = 0;
        int Freqrange = 2;
        ErrorCode errorCode = ErrorCode.Success;
        // Step 1: Create a 'WaveformAiCtrl' for Streaming AI function.
        WaveformAiCtrl waveformAiCtrl = new WaveformAiCtrl();
        PointPairList list = new PointPairList();
        StoreData sd = new StoreData();
        // Step 2: Set the notification event Handler by which we can known the state of operation effectively. 
        #region GUI Delegate Declarations
        public delegate void ChartDelegate(double[] sectionBuffers);
        public delegate void Chart2Delegate(double[] sectionBuffers);
        public delegate void Chart3Delegate(double[] sectionBuffers);
        #endregion

        #region Delegate Functions
        public void DoChart1update(double[] sectionBuffers)
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

        private void CreateTimeGraph(ZedGraphControl zgc, double[] sectionBuffers)
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
            if (SavecheckBox.Checked)
            {
                sd.CreateExcelFile(time, timex, sectionBuffers);
            }

        }

        public void DoChart2update(double[] sectionBuffers)
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

        private void CreateFreqGraph(ZedGraphControl zgc, double[] sectionBuffers)
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
            double[] hzsample = new double[sectionBuffers.Length];
            double[] mag = new double[sectionBuffers.Length];
            for (int i = 0; i < fftsamples.Length / Freqrange; i++)
            {
                mag[i] = (2.0 / sectionLength) * (Math.Abs(Math.Sqrt(Math.Pow(fftsamples[i].Real, 2) + Math.Pow(fftsamples[i].Imaginary, 2))));
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
            PointPairList list = new PointPairList();
            LineItem myCurve;
            LineItem Mincurve;
            LineItem Maxcurve;
            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            myCurve = zedGraphControl2.GraphPane.AddCurve("Channel 0", hzsample, mag, Color.Red, SymbolType.None);
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

        public void DoChart3update(double[] sectionBuffers)
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

        private void CreateFreqMaxGraph(ZedGraphControl zgc, double[] sectionBuffers)
        {
            zgc.GraphPane.CurveList.Clear();

            int FreqMin = int.Parse(FreqMintextBox.Text);
            int FreqMax = int.Parse(FreqMaxtextBox.Text);
            convertClkRate = int.Parse(SamplingTextbox.Text);
            sectionLength = int.Parse(DataLengthtextBox.Text);
            Freqrange = int.Parse(FreqrangetextBox.Text);
            Complex[] fftsamples = new Complex[sectionLength];
            xMaxchartxaxis[0] = xMaxchartxaxis[0] + 1 * sectionLength / convertClkRate;
            for (int i = 0; i < sectionLength; i++)
            {
                fftsamples[i] = sectionBuffers[i];

            }
            Fourier.Forward(fftsamples, FourierOptions.NoScaling);
            double[] mag = new double[sectionBuffers.Length];
            double[] fftmax = new double[1];
            for (int i = FreqMin; i < FreqMax; i++)
            {
                mag[i] = (2.0 / sectionLength) * (Math.Abs(Math.Sqrt(Math.Pow(fftsamples[i].Real, 2) + Math.Pow(fftsamples[i].Imaginary, 2))));
            }

            fftmax[0] = mag.Max();

            GraphPane myPane = zgc.GraphPane;
            // Set the titles and axis labels  
            double[] y = sectionBuffers;
            LineItem myCurve;
            if (LongTermcheckBox.Checked)
            {
                list.Add(xMaxchartxaxis, fftmax);
                // Generate a blue curve with circle symbols, and "My Curve 2" in the legend          
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
                if (list.Count >= 20)
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
                button2.Enabled = true;
                button3.Enabled = false;
            }




        }
        #endregion

        #region Initial form
        private void Intialgraph(ZedGraphControl zgc)
        {
            GraphPane myPane = zgc.GraphPane;
            myPane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45F);
            // Fill the pane background with a color gradient
            myPane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45F);
        }
        private void Intialgraph(ZedGraphControl zgc, string title, string xaxis, string yaxix)
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
        public Form1()
        {
            InitializeComponent();
            Intialgraph(zedGraphControl1, "Time Response", "Time (s)", "Voltage (V)");
            Intialgraph(zedGraphControl2, "Fast Fourier Transform", "Frequency (Hz)", "Voltage (V)");
            Intialgraph(zedGraphControl3, "Max chart", "Time", "Voltage");
            LongTermcheckBox.Checked = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            button3.Enabled = false;
            waveformAiCtrl.DataReady += new EventHandler<BfdAiEventArgs>(waveformAiCtrl_DataReady);
            waveformAiCtrl.Overrun += new EventHandler<BfdAiEventArgs>(waveformAiCtrl_Overrun);

        }

        #endregion

        #region btn_start / stop
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                deviceDescription = DeviceIDtextBox.Text;
                // Step 3: Select a device by device number or device description and specify the access mode.
                // in this example we use ModeWrite mode so that we can fully control the device, including configuring, sampling, etc.
                waveformAiCtrl.SelectedDevice = new DeviceInformation(deviceDescription);
                //errorCode = waveformAiCtrl.LoadProfile(profilePath);//Loads a profile to initialize the device.
                if (BioFailed(errorCode))
                {
                    throw new Exception();
                }

                convertClkRate = int.Parse(SamplingTextbox.Text);
                sectionLength = int.Parse(DataLengthtextBox.Text);
                startChannel = int.Parse(ChanneltextBox.Text);
                // Step 4: Set necessary parameter
                Conversion conversion = waveformAiCtrl.Conversion;
                conversion.ChannelStart = startChannel;
                conversion.ChannelCount = channelCount;
                conversion.ClockRate = convertClkRate;
                Record record = waveformAiCtrl.Record;
                record.SectionCount = sectionCount;//The 0 means setting 'streaming' mode.
                record.SectionLength = sectionLength;

                // Step 5: prepare the Streaming AI. 
                errorCode = waveformAiCtrl.Prepare();
                if (BioFailed(errorCode))
                {
                    throw new Exception();
                }

                // Step 6: The operation has been started
                // We can get samples via event handlers.
                errorCode = waveformAiCtrl.Start();
                if (BioFailed(errorCode))
                {
                    throw new Exception();
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
                button2.Enabled = false;
                button3.Enabled = true;
            }
            catch (Exception err)
            {
                // If something wrong in this execution, print the error code on screen for tracking.
                string errStr = BioFailed(errorCode) ? " Some error occurred. And the last error code is " + errorCode.ToString()
                                                        : err.Message;
                MessageBox.Show(errStr);
            }

        }

        private void button3_Click(object sender, EventArgs e)
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
            button2.Enabled = true;
            button3.Enabled = false;
        }
        #endregion

        #region Data Acqusistion method
        public void waveformAiCtrl_Overrun(object sender, BfdAiEventArgs e)
        {
            Console.WriteLine("Streaming AI is Over run ! ");
            //throw new Exception("Maybe one method or operation is busy.");
        }

        public void waveformAiCtrl_DataReady(object sender, BfdAiEventArgs e)
        {
            Console.WriteLine(" Streaming AI data ready:count = {0},offset = {1} ", e.Count, e.Offset);
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
                Console.Write("Streaming AI get data count is {0}", returnedCount);
                Console.WriteLine(" The first sample for each channel are:");
                DoChart1update(sectionBuffers);
                DoChart2update(sectionBuffers);
                DoChart3update(sectionBuffers);
                // for (int j = 0; j < channelCount; ++j)
                //{
                //   Console.WriteLine("  channel {0}: {1}", (j % channelCount + startChan) % channelCountMax, sectionBuffer[j]);
                //}
                //Console.WriteLine();
                //foreach (var sectionBuffer in sectionBuffers)
                //{
                //    Console.WriteLine("  channel {0}: {1}", (0 % channelCount + startChan) % channelCountMax, sectionBuffer);
                //}
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
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl2.GraphPane.CurveList.Clear();
            zedGraphControl3.GraphPane.CurveList.Clear();
            zedGraphControl1.Refresh();
            zedGraphControl2.Refresh();
            zedGraphControl3.Refresh();
        }

    }
}
