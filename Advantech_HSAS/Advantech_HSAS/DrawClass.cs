using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;
using System.Drawing;
namespace Advantech_HSAS
{
    class DrawClass : DrawInterface
    {
        private static readonly object thisLock = new object();

        // 將唯一實例設為 private static
        private static DrawClass instance;

        // 外界只能使用靜態方法取得實例
        public static DrawClass GetInstance()
        {
            
            if (null == instance)
            {
                
                lock (thisLock)
                {
                   
                    if (null == instance)
                    {
                        instance = new DrawClass();
                    }
                }
            }

            return instance;
        }

        private double _Sampling;
   
        public double Sampling
        {
            get { return _Sampling; }
            set { _Sampling = value; }
        }


        private int _Freqrange;

        public int Freqrange
        {
            get { return _Freqrange; }
            set { _Freqrange = value; }
        }
        private int _DataLength;

        public int DataLength
        {
            get { return _DataLength; }
            set { _DataLength = value; }
        }
        private int _FreqMax;

        public int FreqMax
        {
            get { return _FreqMax; }
            set { _FreqMax = value; }
        }
        private int _FreqMin;

        public int FreqMin
        {
            get { return _FreqMin; }
            set { _FreqMin = value; }
        }

        private bool _LongTermcheck;
        public bool LongTermcheck
        {
            get { return _LongTermcheck; }
            set { _LongTermcheck = value; }
        }

        public virtual List<double[]> DrawChart(ZedGraphControl zgc, double[] sectionBuffers)
        {

         
            double[] excel_rows = new double[sectionBuffers.Length];
            double[] time = new double[sectionBuffers.Length];
            double[] storesectionBuffers = new double[10 * sectionBuffers.Length];
            for (int i = 0; i < sectionBuffers.Length; i++)
            {
                excel_rows[i] = i;
                time[i] = i / Sampling;
            }
            zgc.GraphPane.CurveList.Clear();
            GraphPane myPane = zgc.GraphPane;
            // Set the titles and axis labels
            double[] y = sectionBuffers;
            // Make up some data points from the Sine function
            LineItem myCurve;
            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            myCurve = zgc.GraphPane.AddCurve("Channel 0 ", time, y, Color.Blue, SymbolType.None);
            myCurve.Line.Width = 2.0f;
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Fill the axis background with a color gradient
            zgc.AxisChange();
            zgc.Refresh();
            List<double[]> excel_info = new List<double[]> { };
            excel_info.Add(excel_rows);
            excel_info.Add(time);

            return excel_info;


        }
    }
}
