using Microsoft.EntityFrameworkCore;
using Recodme.Labs.MarketAnalyzer.DataLayer;
using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using Recodme.Labs.MarketAnalyzer.DataLayer.Context;
using Recodme.Labs.MarketAnalyzer.DataLayer.Pocos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;

namespace Recodme.Labs.MarketAnalyzer.DataAccessLayer
{
    public class CompanyDataAccessObject
    {
        public List<CompanyDataPoco> GetCompaniesInfo()
        {
            var companyPoco = new List<CompanyDataPoco>();
            var _context = new MarketAnalyzerDBContext();
            var incomeStatements = (from a in _context.Companies
                                    select new CompanyDataPoco
                                    {
                                        IncomeStatements = a.ExtractedIncomeStatements.ToList(),

                                        Company = a,
                                    }).ToList();
            
            var balanceSheets = (from a in _context.Companies
                                 select new CompanyDataPoco
                                 {
                                     BalanceSheets = a.ExtractedBalanceSheets.ToList(),
                                     Company = a,
                                 }).ToList();
            var cashFlowStatements = (from a in _context.Companies
                                      select new CompanyDataPoco
                                      {
                                          CashFlowStatements = a.ExtractedCashFlowStatements.ToList(),
                                          Company = a,
                                      }).ToList();
            var keyRatios = (from a in _context.Companies
                             select new CompanyDataPoco
                             {
                                 KeyRatios = a.ExtractedKeyRatios.ToList(),
                                 Company = a,
                             }).ToList();
            var incomeStatementTtm = (from a in _context.Companies
                                      select new CompanyDataPoco
                                      {
                                          IncomeStatementTtm = a.ExtractedIncomeStatementTtms.SingleOrDefault(),
                                          Company = a,
                                      }).ToList();
            var cashFlowStatementTtm = (from a in _context.Companies
                                        select new CompanyDataPoco
                                        {
                                            CashFlowStatementTtm = a.ExtractedCashFlowStatementTtms.SingleOrDefault(),
                                            Company = a,
                                        }).ToList();
            companyPoco.AddRange(incomeStatements);
            for (var i = 0; i < incomeStatements.Count; i++)
            {
                companyPoco[i].BalanceSheets = balanceSheets[i].BalanceSheets;
                companyPoco[i].CashFlowStatements = cashFlowStatements[i].CashFlowStatements;
                companyPoco[i].KeyRatios = keyRatios[i].KeyRatios;
                companyPoco[i].IncomeStatementTtm = incomeStatementTtm[i].IncomeStatementTtm;
                companyPoco[i].CashFlowStatementTtm = cashFlowStatementTtm[i].CashFlowStatementTtm;
            }
            return companyPoco;
        }
    }
}
