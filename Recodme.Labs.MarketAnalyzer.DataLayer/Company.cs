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
        public virtual ICollection<KeyRatio> BalanceSheets { get; set; }
        public virtual ICollection<CashFlowStatement> CashFlowStatements { get; set; }
        public virtual ICollection<CashFlowStatementTTM> CashFlowStatementsTTM { get; set; }
        public virtual ICollection<KeyRatio> KeyRatios { get; set; }

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

        private double _price;
        [Required]
        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                RegisterChange();
            }
        }

        public Company(string name) : base(name)
        {

        }

        public Company(string name, string ticker, int rank, double price) : base(name)
        {
            _ticker = ticker;
            _rank = rank;
            _price = price;
        }

        public Company(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name, string ticker, string description, int rank, double price) : base(id, createdAt, updatedAt, isDeleted, name)
        {
            _ticker = ticker;
            _description = description;
            _rank = rank;
            _price = price;
        }
    }
}
