using MathNet.Numerics.IntegralTransforms;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace Advantech_HSAS
{
    public partial class frmfft : Form
    {

        OpenFileDialog openFileDlg = new OpenFileDialog();

        public delegate void PathtDelegate(string strpath , string strname);

    
        private void CreateTimeGraph(ZedGraphControl zgc, List<double> xData, List<double> yData, string strname)
        {
            Color color = Color.Blue;
            switch (ColorcomboBox.Text)
            {
                case "Blue":
                    color = Color.Blue;
                    break;
                case "Green":
                    color = Color.Green;
                    break;
                case "Beige":
                    color = Color.Beige;
                    break;
                case "Black":
                    color = Color.Black;
                    break;
                case "Brown":
                    color = Color.Brown;
                    break;
                case "Gray":
                    color = Color.Gray;
                    break;
                case "Ivory":
                    color = Color.Ivory;
                    break;
                case "Khaki":
                    color = Color.Blue;
                    break;
                case "Pink":
                    color = Color.Pink;
                    break;
                case "Purple":
                    color = Color.Purple;
                    break;
                case "Red":
                    color = Color.Red;
                    break;
                case "Silver":
                    color = Color.Silver;
                    break;
                case "Turquoise":
                    color = Color.Turquoise;
                    break;
                case "Violet":
                    color = Color.Violet;
                    break;
                case "Yellow":
                    color = Color.Yellow;
                    break;
                default:
                    break;
            }

            GraphPane myPane = zgc.GraphPane;
            // Set the titles and axis labels
            double[] x = xData.ToArray();
            double[] y = yData.ToArray();
            // Make up some data points from the Sine function
            LineItem myCurve;
            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            myCurve = zedGraphControl1.GraphPane.AddCurve("Time" + strname, x, y, color, SymbolType.None);
            myCurve.Line.Width = 2.0f;
            // Make the symbols opaque by filling them with white
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Fill the axis background with a color gradient
            zgc.AxisChange();
            zgc.Refresh();


        }


        private void CreateFreqGraph(ZedGraphControl zgc, List<double> xData, List<double> yData, string strname)
        {
            Color color = Color.Blue;
            switch (ColorcomboBox.Text)
            {
                case "Blue":
                    color = Color.Blue;
                    break;
                case "Green":
                    color = Color.Green;
                    break;
                case "Beige":
                    color = Color.Beige;
                    break;
                case "Black":
                    color = Color.Black;
                    break;
                case "Brown":
                    color = Color.Brown;
                    break;
                case "Gray":
                    color = Color.Gray;
                    break;
                case "Ivory":
                    color = Color.Ivory;
                    break;
                case "Khaki":
                    color = Color.Blue;
                    break;
                case "Pink":
                    color = Color.Pink;
                    break;
                case "Purple":
                    color = Color.Purple;
                    break;
                case "Red":
                    color = Color.Red;
                    break;
                case "Silver":
                    color = Color.Silver;
                    break;
                case "Turquoise":
                    color = Color.Turquoise;
                    break;
                case "Violet":
                    color = Color.Violet;
                    break;
                case "Yellow":
                    color = Color.Yellow;
                    break;
                default:
                    break;
            }
            double[] x = xData.ToArray();
            double[] y = yData.ToArray();
            double convertClkRate = 1/ (x[11] - x[10]);
            long convertClkrate = Convert.ToInt64(convertClkRate);
            int sectionLength = x.Length;
            Complex[] fftsamples = new Complex[sectionLength];

            for (int i = 0; i < sectionLength; i++)
            {
                fftsamples[i] = y[i];

            }
            Fourier.Forward(fftsamples, FourierOptions.NoScaling);
            double[] hzsample = new double[y.Length];
            double[] mag = new double[y.Length];
            for (int i = 0; i < fftsamples.Length / 2; i++)
            {
                mag[i] = (2.0 / sectionLength) * (Math.Sqrt(Math.Pow(fftsamples[i].Real, 2) + Math.Pow(fftsamples[i].Imaginary, 2)));
                hzsample[i] = convertClkRate / sectionLength * i;
            }
 
            GraphPane myPane = zgc.GraphPane;
            // Set the titles and axis labels  
            // Make up some data points from the Sine function
            PointPairList list = new PointPairList();
            list.Add(hzsample, mag);
            LineItem myCurve;
            // Generate a blue curve with circle symbols, and "My Curve 2" in the legend
            myCurve = zedGraphControl2.GraphPane.AddCurve("Freq" + strname , list, color, SymbolType.None);
            //myCurve = zedGraphControl2.GraphPane.AddCurve("Channel 0", hzsample, mag, Color.Red, SymbolType.None);

            // Make the symbols opaque by filling them with white
            myCurve.Line.Fill = new Fill(Color.White, color, 45F);
            myCurve.Symbol.Fill = new Fill(Color.White);
            // Fill the axis background with a color gradient
            zgc.AxisChange();
            zgc.Refresh();

        }
        public void Dotextupdate(string strpath , string strname)
        {
            if (this.InvokeRequired)
            {
                try
                {
                    PathtDelegate delegateMethod = new PathtDelegate(this.Dotextupdate);
                    this.Invoke(delegateMethod, new object[] { strpath, strname });
                }
                catch (Exception)
                {
                }

            }
            else
            {
                textBox1.Text = strpath;
                DataTable dt = new DataTable();
                dt = Upload(strpath);
                dataGridViewData.DataSource = dt;
                List<double> timelist = new List<double> { };
                List<double> amplitudelist = new List<double> { };
                foreach (DataRow row in dt.Rows)
                {
                    var time = row[0]; //or row[2]
                    var amplitude = row[1]; //or row[2]
                    double timeconvertedValue = Convert.ToDouble(time);
                    double amplitudeconvertedValue = Convert.ToDouble(amplitude);
                    timelist.Add(timeconvertedValue);
                    amplitudelist.Add(amplitudeconvertedValue);
                }
                CreateTimeGraph(zedGraphControl1, timelist, amplitudelist,strname);
                CreateFreqGraph(zedGraphControl2, timelist, amplitudelist, strname);
            }

        }

        public frmfft()
        {
            InitializeComponent();

        }
        private void frmfft_Load(object sender, EventArgs e)
        {
            Intialgraph(zedGraphControl1, "Time Response", "Time[s]", "Amplitude");
            Intialgraph(zedGraphControl2, "Frequency Domain", "Frequency[Hz]", "Amplitude");

        }
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Thread InvokeThread = new Thread(new ThreadStart(InvokeMethod));
                InvokeThread.SetApartmentState(ApartmentState.STA);
                InvokeThread.Start();
            }
            catch (Exception ex)
            {
              
            }
            

        }
        private void InvokeMethod()
        {
            string strname = "";
            string strPath = "";
            if (this.openFileDlg.ShowDialog() == DialogResult.OK)
            {
                strPath = openFileDlg.FileName;
                strname = openFileDlg.SafeFileName;
            }
            Dotextupdate(strPath, strname);
        }
        private DataTable Upload(string path)
        {
            DataTable table = new DataTable();
            using (FileStream fs = File.OpenRead(path))   //打開myxls.xlsx文件
            {
                XSSFWorkbook wb = new XSSFWorkbook(fs);
                ISheet sheet = wb.GetSheetAt(0);

                //由第一列取標題做為欄位名稱
                IRow headerRow = sheet.GetRow(0);
                int cellCount = headerRow.LastCellNum;

                table.Columns.Add("Time");
                table.Columns.Add("Amplitude");
                //略過第零列(標題列)，一直處理至最後一列
                for (int i = 0; i <= sheet.LastRowNum; i++)
                {
                    IRow row = sheet.GetRow(i);
                    if (row == null) continue;
                    DataRow dataRow = table.NewRow();
                    //依先前取得的欄位數逐一設定欄位內容
                    for (int j = row.FirstCellNum; j < cellCount; j++)
                        if (row.GetCell(j) != null)
                            //如要針對不同型別做個別處理，可善用.CellType判斷型別
                            //再用.StringCellValue, .DateCellValue, .NumericCellValue...取值
                            //此處只簡單轉成字串
                            dataRow[j] = row.GetCell(j).NumericCellValue;
                    table.Rows.Add(dataRow);
                }
                return table;
            }

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

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.CurveList.Clear();
            zedGraphControl2.GraphPane.CurveList.Clear();
            zedGraphControl1.Refresh();
            zedGraphControl2.Refresh();

        }

        private void fastFourierTransformToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = @"https://en.wikipedia.org/wiki/Fast_Fourier_transform";
            //當系統未安裝預設的程式來開啟相對應的資源的話，會出現例外錯誤
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nyquistSamplingTheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string target = @"https://en.wikipedia.org/wiki/Nyquist%E2%80%93Shannon_sampling_theorem";
            //當系統未安裝預設的程式來開啟相對應的資源的話，會出現例外錯誤
            try
            {
                System.Diagnostics.Process.Start(target);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ColorcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ColorcomboBox.Text)
            {
                case "Blue":
                    labelControl1.BackColor = Color.Blue;
                    break;
                case "Green":
                    labelControl1.BackColor = Color.Green;
                    break;
                case "Beige":
                    labelControl1.BackColor = Color.Beige;
                    break;
                case "Black":
                    labelControl1.BackColor = Color.Black;
                    break;
                case "Brown":
                    labelControl1.BackColor = Color.Brown;
                    break;
                case "Gray":
                    labelControl1.BackColor = Color.Gray;
                    break;
                case "Ivory":
                    labelControl1.BackColor = Color.Ivory;
                    break;
                case "Khaki":
                    labelControl1.BackColor = Color.Blue;
                    break;
                case "Pink":
                    labelControl1.BackColor = Color.Pink;
                    break;
                case "Purple":
                    labelControl1.BackColor = Color.Purple;
                    break;
                case "Red":
                    labelControl1.BackColor = Color.Red;
                    break;
                case "Silver":
                    labelControl1.BackColor = Color.Silver;
                    break;
                case "Turquoise":
                    labelControl1.BackColor = Color.Turquoise;
                    break;
                case "Violet":
                    labelControl1.BackColor = Color.Violet;
                    break;
                case "Yellow":
                    labelControl1.BackColor = Color.Yellow;
                    break;
                default:
                    break;
            }
        }
    }
}
