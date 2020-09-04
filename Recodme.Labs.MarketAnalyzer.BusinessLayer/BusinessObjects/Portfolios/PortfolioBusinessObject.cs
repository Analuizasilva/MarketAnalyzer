using Recodme.Labs.MarketAnalyzer.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.Portfolios
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
