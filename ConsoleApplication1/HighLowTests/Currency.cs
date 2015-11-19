using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighLowTests
{
    public class Currency
    {
        private string _currencyName;
        public string currencyName
        {
            get { return _currencyName; }
            set { _currencyName = value; }
        }

        private double _currentRate;
        public double currentRate
        {
            get { return _currentRate; }
            set { _currentRate = value; }
        }

        private double[] _pastRates;
        public double[] pastRates
        {
            get { return _pastRates; }
            set { _pastRates = value; }
        }


        public Currency(string name, double currRate, double[] pastExRates)
        {
            this.currencyName = name;
            this.currentRate = currRate;
            this.pastRates = pastExRates;
        }

        //static List<Currency> compareCurr = new List<Currency>();
        //internal static double GetHigh()
        //{
        //    double largest = 0;

        //    foreach (Currency c in compareCurr)
        //    {
        //        Console.WriteLine("test");
        //        if (c.pastRates != null)
        //        {
        //            largest = c.pastRates[0];
        //            for (int i = 1; i < c.pastRates.Length; i++)
        //            {
        //                if (c.pastRates[i] > largest)
        //                    largest = c.pastRates[i];
        //            }
        //            Console.WriteLine("The highest value is: " + largest);
        //            Console.ReadLine();
        //            return largest;
        //        }

        //        Console.WriteLine("No values to assess.");
        //        Console.ReadLine();
        //        return largest;
        //    } return largest;
        //}

    }
}
