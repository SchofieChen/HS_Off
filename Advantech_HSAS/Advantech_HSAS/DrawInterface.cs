using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZedGraph;

namespace Advantech_HSAS
{
    interface DrawInterface
    {
       /// <summary>
       /// Draw Chart input zgc as graph ID, sectionBuffers is Data
       /// </summary>
       /// <param name="zgc"></param>
       /// <param name="sectionBuffers"></param>
       /// <returns></returns>
        List<double[]> DrawChart(ZedGraphControl zgc, double[] Data);
  
    }
}
