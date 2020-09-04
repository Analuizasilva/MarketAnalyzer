using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using Recodme.Labs.MarketAnalyzer.DataAccessLayer.UserRecordsDAO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserRecordsBO
{
    public class PortfolioBusinessObject
    {
        private readonly PortfolioDataAccessObject _dao;

        public PortfolioBusinessObject()
        {
            _dao = new PortfolioDataAccessObject();
        }

    }
}
