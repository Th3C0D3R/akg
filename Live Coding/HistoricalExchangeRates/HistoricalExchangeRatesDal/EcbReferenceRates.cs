using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HistoricalExchangeRatesDal
{
    public class EcbReferenceRates
    {
        public EcbReferenceRates(string url)
        {
            this.TradingDays = GetDatafromEcb(url);

            
        }

        private List<TradingDay> GetDatafromEcb(string url)
        {
            // System.Xml.Linq
            // System.Linq
            XDocument document = XDocument.Load(url); // XML Dokument in den Arbeitsspeicher laden und in IEnumerables zerlegen

            var days = document.Root.Descendants()
                                    .Where(  nd => nd.Name.LocalName=="Cube" && nd.Attributes().Any(at => at.Name == "time"))
                                    // Projektion:
                                    .Select(nd => new TradingDay(nd));

            return days.ToList();
        }

        public List<TradingDay> TradingDays { get; set; }
    }
}
