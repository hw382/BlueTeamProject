using HighLowTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] num = new[] { 0.70, 0.68, 0.69, 0.66, 0.69, 0.69, 0.65 };
            Currency GBP = new Currency("GBP", 0.70, num);
            BaseCurrency bc = new BaseCurrency();
            bc.addCurr(GBP);
            bc.GetHigh();

        }
    }
}
