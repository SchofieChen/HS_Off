using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;

namespace Advantech_HSAS
{
    class StoreData
    {
        private List<double[]> Data = new List<double[]>();
        public void CreateExcelFile(double[] excel_rows, double[] times, double[] sectionBuffers)
        {
            try
            {
                //建立Excel 2003檔案
                IWorkbook wb = new XSSFWorkbook();
                ISheet ws = wb.CreateSheet("Class");
                string datetime = DateTime.Now.ToString("yyyy-MM-dd HH_mm_ss");
                ////建立Excel 2007檔案
                //IWorkbook wb = new XSSFWorkbook();
                //ISheet ws = wb.CreateSheet("Class");

                ws.CreateRow(0);//第一行為欄位名稱
                ws.GetRow(0).CreateCell(0).SetCellValue("name");
                ws.GetRow(0).CreateCell(1).SetCellValue("score");

                Data.Add(sectionBuffers);

                foreach (int excel_row in excel_rows)
                {
                    ws.CreateRow(excel_row);
                }
                for (int i = 0; i < sectionBuffers.Length; i++)
                {
                    ws.GetRow(i).CreateCell(0).SetCellValue(times[i]);
                    ws.GetRow(i).CreateCell(1).SetCellValue(sectionBuffers[i]);
                }

                string filepath = @"C:\Data\npoi";
                FileStream file;
                if (File.Exists(filepath))
                {
                    file = new FileStream(filepath + datetime + ".csv", FileMode.Create);//產生檔案
                    wb.Write(file);
                    file.Close();
                }
                else
                {
                    file = new FileStream(filepath + datetime + ".csv", FileMode.Create);//產生檔案
                    wb.Write(file);
                    file.Close();
                }
            }
            catch (Exception err)
            {               
                throw err;
            }
           
        }
    }
}
