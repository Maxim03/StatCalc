using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatCalc1
{
    class CalcManager
    {
        public double Average { get; set; }
        public double MeasureError { get; set; }
        public List<double> Data{ get; set; }
        public List<double> Deviations{ get; set; }

        public CalcManager()
        {
            Data = new List<double>();
            Deviations = new List<double>();
        }

        public void SortData()
        {
            Data.Sort();
        }

        public void CalcAverage()
        {
            Average = Data.Average();
        }

        public void BuildDeviations()
        {
            foreach (double x in Data)
            {
                Deviations.Add(Math.Abs(x - Average));
            }
        }
        public void CalcError()
        {
            MeasureError = Deviations.Average();
        }
    }
}
