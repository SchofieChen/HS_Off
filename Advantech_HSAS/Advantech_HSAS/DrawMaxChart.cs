using MathNet.Numerics.IntegralTransforms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace Advantech_HSAS
{
    class DrawMaxChart : DrawClass
    {

        private static readonly object thisLock = new object();
        double[] xMaxchartxaxis = new double[1];
        // 將唯一實例設為 private static
        private static DrawMaxChart instance;

        // 外界只能使用靜態方法取得實例
        public new static DrawMaxChart GetInstance()
        {

            if (null == instance)
            {

                lock (thisLock)
                {

                    if (null == instance)
                    {
                        instance = new DrawMaxChart();
                    }
                }
            }

            return instance;
        }
        public new List<double[]> DrawChart(ZedGraphControl zgc, double[] data)
        {
            zgc.GraphPane.CurveList.Clear();           
            Complex[] fftsamples = new Complex[DataLength];
            xMaxchartxaxis[0] = xMaxchartxaxis[0] + 1 * DataLength / Sampling;

            for (int i = 0; i < DataLength; i++)
            {
                fftsamples[i] = data[i];

            }
            Fourier.Forward(fftsamples, FourierOptions.NoScaling);
            double[] mag = new double[data.Length];
            double[] fftmax = new double[1];
            for (int i = FreqMin; i < FreqMax; i++)
            {
                mag[i] = (2.0 / DataLength) * (Math.Abs(Math.Sqrt(Math.Pow(fftsamples[i].Real, 2) + Math.Pow(fftsamples[i].Imaginary, 2))));
            }

            fftmax[0] = mag.Max();

            GraphPane myPane = zgc.GraphPane;

            List<double[]> return_fun = new List<double[]> { };
            return_fun.Add(xMaxchartxaxis);
            return_fun.Add(fftmax);
            return return_fun;


        }

    }
}

