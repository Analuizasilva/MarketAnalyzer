using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class StockAnalysis
    {


        //vai receber como parâmetro toda a informação da bd necessária e referente a uma company
        //company, Incomestatements, balancesheets, etc

        //public Company...
        //public List<Income....

       //public SlopeInfo RoicSlopeInfo ... q` \di-=67890
        public void _StockAnalysis(/*parametros*/)
        {
            //vai atribuir as props
            //RoicSlopeInf = new RoicSlopeInfo(FinancialAnalysis.ExtractRoic(KeyRatios));

        }

        //vai ter várias propriedades públicas cada uma referente ao que se pretende analisar, i.e. SlopeInfos
        //vai ter também informação sobre as restantes informações de análise da empresa, como debttoequity


        public Company Company { get; set; }
        public List<ExtractedIncomeStatement> IncomeStatements { get; set; }
        public List<ExtractedBalanceSheet> BalanceSheets { get; set; }
        public List<ExtractedCashFlowStatement> CashFlowStatements { get; set; }
        public List<ExtractedKeyRatio> KeyRatios { get; set; }
        public ExtractedIncomeStatementTtm IncomeStatementTtm { get; set; }
        public ExtractedCashFlowStatementTtm CashFlowStatementTtm { get; set; }
        public SlopeInfo RoicSlopeInfo { get; set; }
        public SlopeInfo RevenueSlopeInfo { get; set; }
        public SlopeInfo MarketCapSlopeInfo { get; set; }
        public SlopeInfo DividendsSlopeInfo { get; set; }
        public SlopeInfo EPSSlopeInfo { get; set; }
        public SlopeInfo EquitySlopeInfo { get; set; }
        public SlopeInfo PriceToEarningsSlopeInfo { get; set; }
        public double? DebtToEquity { get; set; }
        public double? AssetsToLiabilities { get; set; }
        public double? Roic { get; set; }
        public double? Equity { get; set; }
        public double? EPS { get; set; }
        public double? Revenue { get; set; }
        public double? PERatio { get; set; }
        public double? StockPrice { get; set; }
        

        public StockAnalysis(CompanyDataPoco dataPoco)
        {
            var financial = new FinancialAnalysis();

            RoicSlopeInfo = new SlopeInfo(financial.GetRoic(dataPoco));
            RevenueSlopeInfo = new SlopeInfo(financial.GetRevenue(dataPoco));
            MarketCapSlopeInfo = new SlopeInfo(financial.GetMarketCap(dataPoco));
            DividendsSlopeInfo = new SlopeInfo(financial.GetDividends(dataPoco));
            EPSSlopeInfo = new SlopeInfo(financial.GetEPS(dataPoco));
            EquitySlopeInfo = new SlopeInfo(financial.GetEquity(dataPoco));
            PriceToEarningsSlopeInfo = new SlopeInfo(financial.GetPriceToEarnings(dataPoco));

            Company = dataPoco.Company;
            IncomeStatements = dataPoco.IncomeStatements;
            BalanceSheets = dataPoco.BalanceSheets;
            KeyRatios = dataPoco.KeyRatios;
            CashFlowStatements = dataPoco.CashFlowStatements;
            IncomeStatementTtm = dataPoco.IncomeStatementTtm;
            CashFlowStatementTtm = dataPoco.CashFlowStatementTtm;

            DebtToEquity = financial.GetDebtToEquity(dataPoco);
            AssetsToLiabilities = financial.GetAssetsToLiabilities(dataPoco);
            if(financial.GetRoic(dataPoco).LastOrDefault()!=null) Roic = financial.GetRoic(dataPoco).LastOrDefault().Value;
            if(financial.GetEquity(dataPoco).LastOrDefault()!=null) Equity = financial.GetEquity(dataPoco).LastOrDefault().Value;
            if(financial.GetEPS(dataPoco).LastOrDefault()!=null) EPS = financial.GetEPS(dataPoco).LastOrDefault().Value;
            if(financial.GetRevenue(dataPoco).LastOrDefault()!=null) Revenue = financial.GetRevenue(dataPoco).LastOrDefault().Value;
            if(financial.GetPriceToEarnings(dataPoco).LastOrDefault()!=null) PERatio = financial.GetPriceToEarnings(dataPoco).LastOrDefault().Value;
            if(financial.GetStockPrice(dataPoco)!=null) StockPrice = financial.GetStockPrice(dataPoco).Value;
        }
    }
}
