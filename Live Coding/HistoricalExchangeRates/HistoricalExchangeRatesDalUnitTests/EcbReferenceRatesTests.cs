using HistoricalExchangeRatesDal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HistoricalExchangeRatesDalUnitTests
{
    [TestClass]
    public class EcbReferenceRatesTests
    {
        string url;

        public EcbReferenceRatesTests()
        {
            url = "https://www.ecb.europa.eu/stats/eurofxref/eurofxref-hist.xml";
        }

        [TestMethod]
        public void IsEcbReferenceRatesInitializing()
        {
            EcbReferenceRates referenceRates = new EcbReferenceRates(url);
            Console.WriteLine($"referenceRates initialisiert, {referenceRates.TradingDays.Count} Tradingdays gefunden.");

            Assert.AreEqual(CountCubesWithTime(url), referenceRates.TradingDays.Count);
        }

        private int CountCubesWithTime(string url)
        {
            // TODO: XML-Datei durchiterieren und alle Cube-Knoten zählen,
            // die ein time-Attribute haben
            return 64;
        }
    }
}
