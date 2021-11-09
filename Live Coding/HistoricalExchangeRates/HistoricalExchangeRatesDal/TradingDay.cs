using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;

namespace HistoricalExchangeRatesDal
{
    public class TradingDay
    {
        public TradingDay(XElement tradingDayNode)
        {
            this.Date = Convert.ToDateTime(tradingDayNode.Attribute("time").Value);

            //CultureInfo ciEzb = new CultureInfo("en-US");
            NumberFormatInfo nfiEzb = new NumberFormatInfo() { NumberDecimalSeparator = ".", NumberGroupSeparator = "" };

            this.Currencies = tradingDayNode.Elements()
                                            .Where(el => el.Attributes().Any(at => at.Name == "currency") && el.Attributes().Any(at => at.Name == "rate"))
                                            .Select(el => new Currency()
                                            {
                                                Symbol = el.Attribute("currency").Value,
                                                ExchangeRate = Convert.ToDouble(el.Attribute("rate").Value, nfiEzb)
                                            }).ToList();

        }

        public DateTime Date { get; set; }
        public List<Currency> Currencies { get; set; }
    }
}