using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.Analysis
{
    public class StockAnalysis
    {
        

        //vai receber como parâmetro toda a informação da bd necessária e referente a uma company
        //company, Incomestatements, balancesheets, etc

        //public Company...
        //public List<Income....

        //public SlopeInfo RoicSlopeInfo ...


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


        public StockAnalysis(CompanyDataPoco dataPocos)
        {
            var financial = new FinancialAnalysis();

            RoicSlopeInfo = new SlopeInfo(financial.GetRoic(dataPocos));
            RevenueSlopeInfo = new SlopeInfo(financial.GetRevenue(dataPocos));
            MarketCapSlopeInfo = new SlopeInfo(financial.GetMarketCap(dataPocos));
            DividendsSlopeInfo = new SlopeInfo(financial.GetDividends(dataPocos));
            EPSSlopeInfo = new SlopeInfo(financial.GetEPS(dataPocos));
            EquitySlopeInfo = new SlopeInfo(financial.GetEquity(dataPocos));
            PriceToEarningsSlopeInfo= new SlopeInfo(financial.GetPriceToEarnings(dataPocos));
            Company = dataPocos.Company;
            IncomeStatements = dataPocos.IncomeStatements;
            BalanceSheets = dataPocos.BalanceSheets;
            KeyRatios = dataPocos.KeyRatios;
            CashFlowStatements = dataPocos.CashFlowStatements;
            IncomeStatementTtm = dataPocos.IncomeStatementTtm;
            CashFlowStatementTtm = dataPocos.CashFlowStatementTtm;
            DebtToEquity = financial.GetDebtToEquity(dataPocos);

        }
    }
}
