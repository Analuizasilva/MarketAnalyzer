﻿using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Recodme.Labs.MarketAnalyzer.DataAccessLayer
{
    public class CompanyDataAccessObject
    {
        public CompanyDataPoco GetCompanyInfo(Guid companyId)
        {
            
            var _context = new MarketAnalyzerDBContext();

            var companyInfo = (from a in _context.Companies
                                    where a.Id == companyId
                                    select new CompanyDataPoco
                                    {
                                        IncomeStatements = a.ExtractedIncomeStatements.ToList(),
                                        BalanceSheets = a.ExtractedBalanceSheets.ToList(),
                                        CashFlowStatements = a.ExtractedCashFlowStatements.ToList(),
                                        KeyRatios = a.ExtractedKeyRatios.ToList(),
                                        IncomeStatementTtm = a.ExtractedIncomeStatementTtms.SingleOrDefault(),
                                        CashFlowStatementTtm = a.ExtractedCashFlowStatementTtms.SingleOrDefault(),

                                        Company = a,
                                    }
                                    ).SingleOrDefault();

            return companyInfo;
        }

        public List<CompanyDataPoco> GetCompaniesInfo()
        {
            var companyPocos = new List<CompanyDataPoco>();
            var _context = new MarketAnalyzerDBContext();

            var incomeStatements = (from a in _context.Companies
                                    select new 
                                    {
                                        IncomeStatements = a.ExtractedIncomeStatements.ToList(),

                                        Company = a,
                                    }
                                    ).OrderBy(x => x.Company.Ticker).ToList();

            var balanceSheets = (from a in _context.Companies
                                 select new 
                                 {
                                     BalanceSheets = a.ExtractedBalanceSheets.ToList(),
                                     Company = a,
                                 }).OrderBy(x => x.Company.Ticker).ToList();

            var cashFlowStatements = (from a in _context.Companies
                                      select new 
                                      {
                                          CashFlowStatements = a.ExtractedCashFlowStatements.ToList(),
                                          Company = a,
                                      }).OrderBy(x => x.Company.Ticker).ToList();

            var keyRatios = (from a in _context.Companies
                             select new 
                             {
                                 KeyRatios = a.ExtractedKeyRatios.ToList(),
                                 Company = a,
                             }).OrderBy(x => x.Company.Ticker).ToList();

            var incomeStatementTtm = (from a in _context.Companies
                                      select new 
                                      {
                                          IncomeStatementTtm = a.ExtractedIncomeStatementTtms.SingleOrDefault(),
                                          Company = a,
                                      }).OrderBy(x => x.Company.Ticker).ToList();

            var cashFlowStatementTtm = (from a in _context.Companies
                                        select new 
                                        {
                                            CashFlowStatementTtm = a.ExtractedCashFlowStatementTtms.SingleOrDefault(),
                                            Company = a,
                                        }).OrderBy(x => x.Company.Ticker).ToList();
           
            if (incomeStatements.Count != balanceSheets.Count ||
                balanceSheets.Count != cashFlowStatements.Count||cashFlowStatements.Count!=keyRatios.Count)
                throw new Exception();


            companyPocos.AddRange(incomeStatements.Select(
                i => new CompanyDataPoco { IncomeStatements = i.IncomeStatements }));
     
            for (var i = 0; i < incomeStatements.Count; i++)
            {
                companyPocos[i].Company = incomeStatements[i].Company;
                companyPocos[i].BalanceSheets = balanceSheets[i].BalanceSheets;
                companyPocos[i].CashFlowStatements = cashFlowStatements[i].CashFlowStatements;
                companyPocos[i].KeyRatios = keyRatios[i].KeyRatios;
                companyPocos[i].IncomeStatementTtm = incomeStatementTtm[i].IncomeStatementTtm;
                companyPocos[i].CashFlowStatementTtm = cashFlowStatementTtm[i].CashFlowStatementTtm;
            }
            return companyPocos;
        }
    }
}
