using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HighLowTests
{
    public class BaseCurrency
    {
        public List<Currency> CCList = new List<Currency>();
        public Dictionary<string, double> highNum = new Dictionary<string, double>();
        public Dictionary<string, double> lowNum = new Dictionary<string, double>();
        public Dictionary<string, double> diffNum = new Dictionary<string, double>();
        public Dictionary<string, double> diffNum2 = new Dictionary<string, double>();
        //public SortedDictionary<string, double> diffNum = new SortedDictionary<string, double>();
        List<double> highValues = new List<double>();
        List<double> lowValues = new List<double>();
        List<double> diffValues = new List<double>();

        //public Dictionary<Tuple<Currency, double>, Tuple<Currency, double>> highNum;
        public double largest;
        public double smallest = 10;
        public double compLargest;
        public double compSmallest = 10;
        public double change;
        public string smallestChange;
        public double greatestChange;
        public string currGC;
        public List<string> listSmall;

        public List<Currency> addCurr (Currency currency)
        {
            CCList.Add(currency);
            return CCList;
        }

        
        public double GetHigh()
        {
            foreach (Currency c in CCList)
            {
                if (c.pastRates != null)
                {

                    largest = c.pastRates[0];
                    for (int i = 1; i < c.pastRates.Length; i++)
                    {
                        if (c.pastRates[i] > largest)
                            largest = c.pastRates[i];
                    }
                    Console.WriteLine("The highest value is: " + largest);
                    highValues.Add(largest);
                    highNum.Add(c.currencyName, largest);
                    Console.WriteLine("Number of currencies in list: " + highNum.Count);

                    //foreach (double v in highValues)
                    //{
                    //    if (v > compLargest)
                    //    {
                    //        compLargest = v;
                    //    }
                    //}
                    //Console.WriteLine("Highest value for more than one currency is this mofo: " + compLargest);
                    //largest = compLargest;
                }
                Console.WriteLine("No values to assess.");               
            } 
            return largest;
        }

        public double GetLow()
        {
            foreach (Currency c in CCList)
            {
                if (c.pastRates != null)
                {
                    smallest = c.pastRates[0];
                    for (int i = 1; i < c.pastRates.Length; i++)
                    {
                        if (c.pastRates[i] < smallest)
                            smallest = c.pastRates[i];
                    }
                    Console.WriteLine("The lowest value is: " + smallest);
                    //foreach (double i in c.pastRates)
                    //{
                        
                    //    if (i < smallest)
                    //    {
                    //        smallest = i;
                    //    }
                    //    Console.WriteLine("The lowest value is: " + smallest);
                    //}
                    //Console.WriteLine("The ABSOLUTE lowest value is: " + smallest);
                    lowValues.Add(smallest);
                    lowNum.Add(c.currencyName, smallest);
                    Console.WriteLine("Number of currencies in list: " + lowNum.Count);

                    //foreach (double v in lowValues)
                    //{
                    //    if (v < compSmallest)
                    //    {
                    //        compSmallest = v;
                    //    }
                    //}
                    //Console.WriteLine("Lowest value for more than one currency is this mofo: " + compSmallest);
                    //smallest = compSmallest;
                }
                Console.WriteLine("No values to assess.");
            }
            return smallest;
        }

        public double doubChange()
        {
            foreach (Currency c in CCList)
            {
                if (highNum.Count != 0 && lowNum.Count != 0)
                {
                    for (int i = 0; i < highNum.Count; i++)
                    {
                        largest = highValues[i];
                        smallest = lowValues[i];

                        change = Math.Round((largest - smallest), 2);
                        Console.WriteLine("Change is " + change);

                        diffValues.Add(change);
                        Console.WriteLine(c.currencyName);
                        if(!diffNum.ContainsKey(c.currencyName))
                        {
                            diffNum.Add(c.currencyName, change);
                        }
                    }
                    Console.WriteLine("Number of currencies in list: " + diffNum.Count);
                }



                //if (c.pastRates != null)
                //{
                //    for (int i = 0; i < highValues.Count; i++)
                //    {
                //        largest = highValues[i];
                //        smallest = lowValues[i];
                //        change = Math.Round((largest - smallest), 2);
                //        Console.WriteLine("Change is " + change);
                //        diffValues.Add(change);
                //        diffNum.Add(c.currencyName, change);                        
                //    }

                    
                    //Console.WriteLine(smallest);
                    //Console.WriteLine(largest);
                    //change = Math.Round((largest - smallest), 2);
                    //Console.WriteLine("Change is " + change);
                    ////return change;
                    //diffValues.Add(change);
                //}
                Console.WriteLine("No values to assess.");

            //return change;
                //foreach (double v in diffValues)
                //    {
                //        if (v > greatestChange)
                //        {
                //            greatestChange = v;
                //        }
                //    }

                    greatestChange = diffValues[0];
                    for (int i = 1; i < diffValues.Count; i++)
                    {
                        if (diffValues[i] > greatestChange)
                            greatestChange = diffValues[i];
                        //Console.WriteLine(c.currencyName[i]);
                    }
                    //Console.WriteLine(c.currencyName[i]);
                    //Console.WriteLine("Greatest change value for more than one currency is this mofo: " + greatestChange);
                    change = greatestChange;

            } return change;
        }

        public string strChange()
        {
            foreach (Currency c in CCList)
            {
                if (highNum.Count != 0 && lowNum.Count != 0)
                {
                    for (int i = 0; i < highNum.Count; i++)
                    {
                        largest = highValues[i];
                        smallest = lowValues[i];

                        change = Math.Round((largest - smallest), 2);
                        Console.WriteLine("Change is " + change);

                        diffValues.Add(change);
                        Console.WriteLine(c.currencyName);
                        if (!diffNum.ContainsKey(c.currencyName))
                        {
                            diffNum.Add(c.currencyName, change);
                        }
                    }
                    Console.WriteLine("Number of currencies in list: " + diffNum.Count);


                    //List<KeyValuePair<string, double>> myList = diffNum.ToList();
                    //myList.Sort((firstPair, nextPair) =>
                    //{
                    //    return firstPair.Value.CompareTo(nextPair.Value);
                    //}
                    //);

                    //currGC = myList.First<KeyValuePair<string, double>>

                    

                    //KeyValuePair<string, double> diffNum3 = new KeyValuePair<string, double>();
                    //diffNum3 = diffNum.OrderByDescending(p => p.Value);
                    //var first = diffNum3.First();
                    //currGC = first.Key;
                    
                    //var first = orderedDic.First();
                    
                    //currGC = diffNum.FirstOrDefault(x => x.Value.Contains(greatestChange)).Key;

                    //currGC = diffNum.FirstOrDefault(x => x.Value.Equals(greatestChange)).Key;
                    
                    //currGC = diffNum.OrderByDescending(q => q.Value).FirstOrDefault(p => p.Key);
                    //currGC = diffNum.OrderByDescending(r => r.Value).First(s => s.Key);
                    //diffNum = diffNum.OrderByDescending(q => q.Value);
                    //currGC = diffNum.FirstOrDefault(x => x.Key);


                    //Console.WriteLine(c.currencyName[i]);   
                }
                Console.WriteLine("No values to assess.");
                
            }
            greatestChange = diffValues[0];
            for (int i = 1; i < diffValues.Count; i++)
            {
                Console.WriteLine(diffValues.Count);
                if (diffValues[i] > greatestChange)
                    greatestChange = diffValues[i];
                //var orderedDic = diffNum.OrderBy(p => p.Value).First();
                //Console.WriteLine("{0} => {1}", orderedDic.Key, orderedDic.Value);
                //currGC = orderedDic.Key;
            }
            Console.WriteLine("Greatest change value for more than one currency is this mofo: " + currGC);
            //LAST COMMENTED OUT THING - ADDED THE DO STUFF TO THE FUNCTION ASSIGNING GREATEST CHANGE
            if (greatestChange != null)
            {
                var orderedDic = diffNum.OrderBy(p => p.Value).First();
                Console.WriteLine("{0} => {1}", orderedDic.Key, orderedDic.Value);
                currGC = orderedDic.Key;
            }            
            
            return currGC;
        }


        public string gtestChg()
        {
            //foreach (Currency c in CCList)
            //{
                if (highNum.Count != 0 && lowNum.Count != 0)
                {
                    Console.WriteLine("TESTING: " + diffValues.Count);
                        foreach (Currency c in CCList)
                        //foreach (KeyValuePair<string, double> kp in highNum)
                        {
                            for (int i = 0; i < highNum.Count; i++)
                            {
                                largest = highValues[i];
                                smallest = lowValues[i];

                                change = Math.Round((largest - smallest), 2);
                                Console.WriteLine("Change is " + change);
                            }
                        }
                        Console.WriteLine("Number of currencies in list: " + diffNum.Count);

                    diffValues.Add(change);
                }
                Console.WriteLine("No values to assess.");
                
            //}

            //Finds the value of the greatestchange
            greatestChange = diffValues[0];
            for (int i = 1; i < diffValues.Count; i++)
            {
                Console.WriteLine(diffValues.Count);
                if (diffValues[i] > greatestChange)
                    greatestChange = diffValues[i];
                //var orderedDic = diffNum.OrderBy(p => p.Value).First();
                //Console.WriteLine("{0} => {1}", orderedDic.Key, orderedDic.Value);
                //currGC = orderedDic.Key;
            }
            
            //Retrieve the name of the currency with the greatest change
            if (greatestChange != null)
            {
                var orderedDic = diffNum.OrderByDescending(p => p.Value).First();
                Console.WriteLine("{0} => {1}", orderedDic.Key, orderedDic.Value);
                currGC = orderedDic.Key;
            }
            Console.WriteLine("Greatest change value for more than one currency is this mofo: " + currGC);
            return currGC;
        }

        public string testChg()
        {
            foreach (Currency c in CCList)
            {
                if (c.pastRates != null)
                {
                    //find largest
                    largest = c.pastRates.Max<double>;
                    Console.WriteLine("The highest value is: " + largest);
                    highValues.Add(largest);
                    highNum.Add(c.currencyName, largest);
                    Console.WriteLine("Number of currencies in high list: " + highNum.Count);

                    //find smallest
                    smallest = c.pastRates.Min<double>;
                    Console.WriteLine("The lowest value is: " + smallest);
                    lowValues.Add(smallest);
                    lowNum.Add(c.currencyName, smallest);

                    Console.WriteLine("Number of currencies in low list: " + lowNum.Count);
                }
                Console.WriteLine("No values to assess.");               
            } 
            return currGC;
        }


        public string strSmallest()
        {
            //var keyR = tempDictionary.MinBy(kvp => kvp.Value).Key;
            //var smallestChange = lowNum.MinBy(k => k.Value).Key;

            //to retrieve the currency name (key) where the smallest currency change (value) is
            //var matchSmall = lowNum.Where(p => p.Value == smallestChange).Select(p => p.Key);
            //foreach (var key in matchSmall)
            //{
            //    Console.WriteLine(key);
            //}

            //var keyAndValue = tempDictionary.OrderBy(kvp => kvp.Value).First();
            //Console.WriteLine("{0} => {1}", keyAndValue.Key, keyAndValue.Value);
            if (lowNum != null)
            {
                var lowKeyValue = lowNum.OrderBy(k => k.Value).First();
                Console.WriteLine("{0} => {1}", lowKeyValue.Key, lowKeyValue.Value);
                smallestChange = lowKeyValue.Key;
            }      
            //below does not recognise 'Collection'
            //Collection.Sort(lowNum, new CurrencyRateComparator());
            
            return smallestChange;
        }

        public List<string> listSmallest()
        {
            //var keyR = tempDictionary.MinBy(kvp => kvp.Value).Key;
            //var smallestChange = lowNum.MinBy(k => k.Value).Key;

            //to retrieve the currency name (key) where the smallest currency change (value) is
            //var matchSmall = lowNum.Where(p => p.Value == smallestChange).Select(p => p.Key);
            //foreach (var key in matchSmall)
            //{
            //    Console.WriteLine(key);
            //}

            //var keyAndValue = tempDictionary.OrderBy(kvp => kvp.Value).First();
            //Console.WriteLine("{0} => {1}", keyAndValue.Key, keyAndValue.Value);
            if (lowNum != null)
            {
                var lowKeyValue = lowNum.OrderBy(k => k.Value).First();
                Console.WriteLine("{0} => {1}", lowKeyValue.Key, lowKeyValue.Value);
                smallestChange = lowKeyValue.Key;
            }
            //below does not recognise 'Collection'
            //Collection.Sort(lowNum, new CurrencyRateComparator());

            return listSmall;
        }
        
        //end of methods, below is end of class
    }
}
