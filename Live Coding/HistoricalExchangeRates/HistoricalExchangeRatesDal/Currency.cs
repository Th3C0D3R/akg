using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoricalExchangeRatesDal
{
    public class Currency
    {
        public string Symbol { get; set; }
        public double ExchangeRate { get; set; }

        //public string DisplayString
        //{
        //    get
        //    {
        //        //StringBuilder builder = new StringBuilder(this.Symbol);
        //        //builder.Append(": ");
        //        //builder.Append(this.ExchangeRate);

        //        return $"{this.Symbol}: {this.ExchangeRate:#,##0.0000}";
        //    }
        //}

        //public override string ToString()
        //{
        //    return $"{this.Symbol}: {this.ExchangeRate:#,##0.0000}";
        //}
    }
}
