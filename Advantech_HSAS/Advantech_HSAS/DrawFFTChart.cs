using MathNet.Numerics.IntegralTransforms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace Advantech_HSAS
{
    class DrawFFTChart : DrawClass 
    {
        private static readonly object thisLock = new object();

        // 將唯一實例設為 private static
        private static DrawFFTChart instance;

        // 外界只能使用靜態方法取得實例
        public static new DrawFFTChart GetInstance()
        {
            if (null == instance)
            {
                lock (thisLock)
                {

                    if (null == instance)
                    {
                        instance = new DrawFFTChart();
                    }
                }
            }

            return instance;
        }


        public override List<double[]> DrawChart(ZedGraphControl zgc, double[] sectionBuffers)
        {

            
            Complex[] fftsamples = new Complex[DataLength];

            for (int i = 0; i < DataLength; i++)
            {
                fftsamples[i] = sectionBuffers[i];

            }
            Fourier.Forward(fftsamples, FourierOptions.NoScaling);
            double[] hzsample = new double[DataLength / Freqrange];
            double[] mag = new double[DataLength / Freqrange];
            for (int i = 0; i < fftsamples.Length / Freqrange; i++)
            {
                mag[i] = (2.0 / DataLength) * (Math.Abs(Math.Sqrt(Math.Pow(fftsamples[i].Real, 2) + Math.Pow(fftsamples[i].Imaginary, 2))));
                hzsample[i] = Sampling / DataLength * i;
            }
            int Minxlength = FreqMin;
            int Maxxlength = FreqMax;
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
            myCurve = zgc.GraphPane.AddCurve("Channel 0", list, Color.Red, SymbolType.None);
            //myCurve = zedGraphControl2.GraphPane.AddCurve("Channel 0", hzsample, mag, Color.Red, SymbolType.None);
            Mincurve = zgc.GraphPane.AddCurve("FreqMin", x, y, Color.DarkBlue, SymbolType.None);
            Maxcurve = zgc.GraphPane.AddCurve("FreqMax", x1, y1, Color.DarkOrange, SymbolType.None);
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

            List<double[]> return_fun = new List<double[]> { };
            return return_fun;
        }
    }
}
