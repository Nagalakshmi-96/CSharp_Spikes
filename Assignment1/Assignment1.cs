using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public class ProductionDetails
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double StartDate { get; set; }
        public double EndDate { get; set; }
    }
    public class Assignment1
    {
        static void Main()
        {
            double i, RangeStart, RangeEnd;
            int RangeCount = 1;

            DateTime StartDate = new DateTime(2016, 1, 1);
            DateTime EndDate = new DateTime(2016, 12, 31);

            double StartDateNumber = StartDate.ToOADate();
            double EndDateNumber = EndDate.ToOADate();

            IDictionary<double, int> DateDictionary = new Dictionary<double, int>();
            IList<ProductionDetails> pd = new List<ProductionDetails>();


            for (i = StartDateNumber; i <= EndDateNumber; i++)
                DateDictionary.Add(i, 0);

            DateTime range1Start = new DateTime(2016, 2, 15);
            DateTime range1End = new DateTime(2016, 3, 18);

            DateTime range2Start = new DateTime(2016, 6, 2);
            DateTime range2End = new DateTime(2016, 8, 20);

            double range1StartNumber = range1Start.ToOADate();
            double range1EndNumber = range1End.ToOADate();

            double range2StartNumber = range2Start.ToOADate();
            double range2EndNumber = range2End.ToOADate();

            for (i = range1StartNumber; i <= range1EndNumber; i++)
                DateDictionary[i] = 1;
            for (i = range2StartNumber; i <= range2EndNumber; i++)
                DateDictionary[i] = 1;

            i = StartDateNumber;

            while (i <= EndDateNumber)
            {
                if (DateDictionary[i] == 0)
                {
                    RangeStart = i;
                    while (i <= EndDateNumber && DateDictionary[i] == 0)
                        i++;
                    RangeEnd = i - 1;
                    pd.Add(new ProductionDetails() { ProductID = RangeCount, ProductName = "Test" + RangeCount, StartDate = RangeStart, EndDate = RangeEnd });
                    RangeCount++;
                }
                i++;
            }

            foreach (var obj in pd)
                Console.WriteLine("{0}  {1}  {2}  {3} ", obj.ProductID, obj.ProductName, DateTime.FromOADate(obj.StartDate).ToShortDateString(), DateTime.FromOADate(obj.EndDate).ToShortDateString());

            Console.Read();

        }
    }
}
