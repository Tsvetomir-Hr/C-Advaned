using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        HashSet<Stock> Portfoliio;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            Portfoliio = new HashSet<Stock>();
        }

        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => Portfoliio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization>10000 && MoneyToInvest>=stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfoliio.Add(stock);
            }
        }
        public string SellStock(string companyName,decimal sellPrice)
        {
          
                Stock stock = Portfoliio.FirstOrDefault(x => x.CompanyName == companyName);
                if (stock == null)
                {
                    return $"{companyName} does not exist.";
                }
                if (sellPrice<stock.PricePerShare)
                {
                    return $"Cannot sell {companyName}.";
                }

                return $"{companyName} was sold.";

            
           
        }
        public Stock FindStock(string companyName)
        {
            return Portfoliio.FirstOrDefault(x => x.CompanyName == companyName);
        }
        public Stock FindBiggestCompany()
        {
            return Portfoliio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var stock in Portfoliio)
            {
                sb.AppendLine(stock.ToString());
            }
            return sb.ToString();
        }
    }
}
