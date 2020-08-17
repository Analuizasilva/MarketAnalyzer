using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class Company : NamedEntity
    {
        public virtual ICollection<IncomeStatement> IncomeStatements { get; set; }
        public virtual ICollection<IncomeStatementTTM> IncomeStatementsTTM { get; set; }
        public virtual ICollection<BalanceSheet> BalanceSheets { get; set; }
        public virtual ICollection<CashFlowStatement> CashFlowStatements { get; set; }
        public virtual ICollection<CashFlowStatementTTM> CashFlowStatementsTTM { get; set; }
        public virtual ICollection<KeyRatio> KeysRatios { get; set; }

        private string _ticker;
        [Required]
        public string Ticker
        {
            get => _ticker;
            set
            {
                _ticker = value;
                RegisterChange();
            }
        }

        private string _description;
        [Required]
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                RegisterChange();
            }
        }

        private int _rank;
        [Required]
        public int Rank
        {
            get => _rank;
            set
            {
                _rank = value;
                RegisterChange();
            }
        }

        public Company(string name) : base(name)
        {

        }

        public Company(string name, string ticker, string description, int rank) : base(name)
        {
            _ticker = ticker;
            _description = description;
            _rank = rank;
        }

        public Company(Guid id, DateTime createdAt, DateTime updatedAt, string name, string ticker, string description, int rank) : base(id, createdAt, updatedAt, name)
        {
            _ticker = ticker;
            _description = description;
            _rank = rank;
        }
    }
}
