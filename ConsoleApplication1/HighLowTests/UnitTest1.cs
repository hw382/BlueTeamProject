using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HighLowTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_currencyComp_AddGBPToListToCompare()
        {
            //arrange
            BaseCurrency Euro = new BaseCurrency();
            double[] num = new[] { 0.70, 0.68, 0.69, 0.70, 0.69, 0.69, 0.65 };
            Currency GBP = new Currency("GBP", 0.70, num);

            //act
            Euro.addCurr(GBP);
            int count = Euro.CCList.Count;

            //assert
            Assert.AreEqual(1, count);
        }

        [TestMethod]
        public void Test_GetHigh_ReturnHighestValueForGBPAgainstEuro()
        {
            //arrange
            BaseCurrency Euro = new BaseCurrency();
            double[] num = { 0.70, 0.68, 0.69, 0.66, 0.69, 0.69, 0.65 };
            Currency GBP = new Currency("GBP", 0.70, num);
            //List<double> lst = num.OfType<double>().ToList();       
            
            //act
            Euro.addCurr(GBP);
            double highGBP = Euro.GetHigh();

            //assert
            Assert.AreEqual(0.70, highGBP);
        }

        [TestMethod]
        public void Test_GetLow_ReturnLowestValueForGBPAgainstEuro()
        {
            //arrange
            BaseCurrency Euro = new BaseCurrency();
            double[] num = { 0.70, 0.68, 0.69, 0.66, 0.69, 0.69, 0.65 };
            Currency GBP = new Currency("GBP", 0.70, num);

            //act
            Euro.addCurr(GBP);
            double lowGBP = Euro.GetLow();

            //assert
            Assert.AreEqual(0.65, lowGBP);

        }

        [TestMethod]
        public void Test_GetHigh_ReturnHighestValueForTheLastInputCurrencyWhenAssessingForTwoCurrenciesAgainstEuro()
        {
            //arrange
            BaseCurrency Euro = new BaseCurrency();
            double[] num = { 0.70, 0.68, 0.69, 0.66, 0.69, 0.69, 0.65 };
            Currency GBP = new Currency("GBP", 0.70, num);
            double[] arr = { 1.41, 1.40, 1.39, 1.30, 1.39, 1.39, 1.45 };
            Currency JPY = new Currency("JPY", 1.41, arr);
            //List<double> lst = num.OfType<double>().ToList();       

            //act
            Euro.addCurr(GBP);
            Euro.addCurr(JPY);
            double high = Euro.GetHigh();
            //double highBoth = Euro.MultiHigh();
            //Dictionary<Currency, double> newDict = new Dictionary<Currency, double>();
            

            //assert
            Assert.AreEqual(1.45, high);
        }

        [TestMethod]
        public void Test_GetLow_ReturnLowestValueForTheLastInputCurrencyWhenAssessingTwoCurrenciesAgainstEuro()
        {
            //arrange
            BaseCurrency Euro = new BaseCurrency();
            double[] num = { 0.70, 0.68, 0.69, 0.66, 0.69, 0.69, 0.65 };
            Currency GBP = new Currency("GBP", 0.70, num);
            double[] arr = { 1.41, 1.40, 1.39, 1.30, 1.39, 1.39, 1.45 };
            Currency JPY = new Currency("JPY", 1.41, arr);
            //act
            Euro.addCurr(GBP);
            Euro.addCurr(JPY);
            double lowGBP = Euro.GetLow();

            //assert
            Assert.AreEqual(1.3, lowGBP);

        }

        //v.The currency with the greatest change (using the highest and lowest) 
        //against the Euro for the last 90 days

        [TestMethod]
        public void Test_doubChange_ReturnDifferenceBetweenHighestAndLowestForOneCurrencyGBP()
        {
            //arrange
            BaseCurrency Euro = new BaseCurrency();
            double[] num = { 0.70, 0.68, 0.69, 0.66, 0.69, 0.69, 0.65 };
            Currency GBP = new Currency("GBP", 0.70, num);

            //act
            Euro.addCurr(GBP);
            double highGBP = Euro.GetHigh();
            double lowGBP = Euro.GetLow();
            double testGC = Euro.doubChange();

            //assert
            Assert.AreEqual(0.05, testGC);
        }

        [TestMethod]
        public void Test_doubChange_ReturnGreatestDifferenceBetweenHighestAndLowestForTwoCurrencies()
        {
            //arrange
            BaseCurrency Euro = new BaseCurrency();
            double[] num = { 0.70, 0.68, 0.69, 0.66, 0.69, 0.69, 0.65 };
            Currency GBP = new Currency("GBP", 0.70, num);
            double[] arr = { 1.41, 1.40, 1.39, 1.30, 1.39, 1.39, 1.45 };
            Currency JPY = new Currency("JPY", 1.41, arr);

            //act
            Euro.addCurr(GBP);
            Euro.addCurr(JPY);
            double highGBP = Euro.GetHigh();
            double lowGBP = Euro.GetLow();
            double testGC = Euro.doubChange();

            //assert
            Assert.AreEqual(0.15, testGC);
            //Assert.AreEqual(2, Euro.CCList.Count);
        }

        [TestMethod]
        public void Test_doubChange_ReturnGreatestDifferenceBetweenHighestAndLowestForThreeCurrencies()
        {
            //arrange
            BaseCurrency Euro = new BaseCurrency();
            double[] num = { 0.70, 0.68, 0.69, 0.66, 0.69, 0.69, 0.65 };
            Currency GBP = new Currency("GBP", 0.70, num);
            double[] arr = { 1.41, 1.40, 1.39, 1.30, 1.39, 1.39, 1.45 };
            Currency JPY = new Currency("JPY", 1.41, arr);
            double[] hfn = { 310.94, 310.40, 309.78, 309.86, 310.01, 309.99, 310.45 };
            Currency HUF = new Currency("HUF", 310.89, hfn);

            //act
            Euro.addCurr(GBP);
            Euro.addCurr(HUF);
            Euro.addCurr(JPY);
            double highGBP = Euro.GetHigh();
            double lowGBP = Euro.GetLow();
            double testGC = Euro.doubChange();

            //assert
            Assert.AreEqual(1.16, testGC);
            //Assert.AreEqual("HUF", )
            //Assert.AreEqual(2, Euro.CCList.Count);
        }

        [TestMethod]
        public void Test_strChange_ReturnNameOfCurrencyWithGreatestDifferenceBetweenHighestAndLowestForThreeCurrencies()
        {
            //arrange
            BaseCurrency Euro = new BaseCurrency();
            double[] num = { 0.70, 0.68, 0.69, 0.66, 0.69, 0.69, 0.65 };
            Currency GBP = new Currency("GBP", 0.70, num);
            double[] arr = { 1.41, 1.40, 1.39, 1.30, 1.39, 1.39, 1.45 };
            Currency JPY = new Currency("JPY", 1.41, arr);
            double[] hfn = { 310.94, 310.40, 309.78, 309.86, 310.01, 309.99, 310.45 };
            Currency HUF = new Currency("HUF", 310.89, hfn);

            //act
            Euro.addCurr(GBP);
            Euro.addCurr(HUF);
            Euro.addCurr(JPY);
            double highGBP = Euro.GetHigh();
            double lowGBP = Euro.GetLow();
            double testGC = Euro.doubChange();
            string testGSC = Euro.strChange();

            //assert
            Assert.AreEqual("HUF", testGSC);
            //Assert.AreEqual(3, Euro.CCList.Count);
        }

        [TestMethod]
        public void Test_testChg_testing()
        {
            //arrange
            BaseCurrency Euro = new BaseCurrency();
            double[] num = { 0.70, 0.68, 0.69, 0.66, 0.69, 0.69, 0.65 };
            Currency GBP = new Currency("GBP", 0.70, num);
            double[] arr = { 1.41, 1.40, 1.39, 1.30, 1.39, 1.39, 1.45 };
            Currency JPY = new Currency("JPY", 1.41, arr);
            double[] hfn = { 310.94, 310.40, 309.78, 309.86, 310.01, 309.99, 310.45 };
            Currency HUF = new Currency("HUF", 310.89, hfn);

            //act
            Euro.addCurr(GBP);
            Euro.addCurr(HUF);
            Euro.addCurr(JPY);
            double highGBP = Euro.GetHigh();
            double lowGBP = Euro.GetLow();
            double testGC = Euro.doubChange();
            string testGSC = Euro.testChg();

            //assert
            Assert.AreEqual("HUF", testGSC);
            //Assert.AreEqual(3, Euro.CCList.Count);
        }

        [TestMethod]
        //vi.The ten currencies with the smallest change against the Euro over the last 90 days
        public void Test_tenSmall_ReturnNameOfSingleCurrencyWithSmallestChangeAgainstEuro()
        {
            //arrange
            BaseCurrency Euro = new BaseCurrency();
            double[] num = { 0.70, 0.68, 0.69, 0.66, 0.69, 0.69, 0.65 };
            Currency GBP = new Currency("GBP", 0.70, num);
            double[] arr = { 1.41, 1.40, 1.39, 1.30, 1.39, 1.39, 1.45 };
            Currency JPY = new Currency("JPY", 1.41, arr);
            double[] hfn = { 310.94, 310.40, 309.78, 309.86, 310.01, 309.99, 310.45 };
            Currency HUF = new Currency("HUF", 310.89, hfn);

            //act
            Euro.addCurr(GBP);
            Euro.addCurr(JPY);
            Euro.addCurr(HUF);
            double bothLow = Euro.GetLow();
            string smallest = Euro.strSmallest();

            //assert
            Assert.AreEqual("GBP", smallest);
        }

        [TestMethod]
        public void Test_tenSmall_ReturnNameOfTwoCurrenciesWithSmallestChangeAgainstEuro()
        {
            //arrange
            BaseCurrency Euro = new BaseCurrency();
            double[] num = { 0.70, 0.68, 0.69, 0.66, 0.69, 0.69, 0.65 };
            Currency GBP = new Currency("GBP", 0.70, num);
            double[] arr = { 1.41, 1.40, 1.39, 1.30, 1.39, 1.39, 1.45 };
            Currency JPY = new Currency("JPY", 1.41, arr);
            double[] hfn = { 310.94, 310.40, 309.78, 309.86, 310.01, 309.99, 310.45 };
            Currency HUF = new Currency("HUF", 310.89, hfn);

            //act
            Euro.addCurr(GBP);
            Euro.addCurr(JPY);
            Euro.addCurr(HUF);
            double bothLow = Euro.GetLow();
            List<string> smallest = Euro.listSmallest();

            //assert
            Assert.AreEqual(2, smallest.Count);
        }
    }
}
