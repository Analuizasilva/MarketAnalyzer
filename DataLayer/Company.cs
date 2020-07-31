using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.DataLayer
{
    public class Company : NamedEntity
    {
        [Required]
        [Display(Name = "Ticker")]
        private string _ticker;
        public string Ticker
        {
            get => _ticker;
            set
            {
                _ticker = value;
                RegisterChange();
            }
        }

        [Required]
        [Display(Name = "Description")]
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

        [Required]
        [Display(Name = "Rank")]
        private int _rank;
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

        public Company(string name, string ticker,  string description, int rank) : base(name)
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
