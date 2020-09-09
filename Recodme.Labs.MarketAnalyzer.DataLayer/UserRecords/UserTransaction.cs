using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords
{
    public class UserTransaction : Entity
    {
        #region Properties     
        private decimal? _numberOfShares;

        [Required]
        [Display(Name = "Number of Shares")]
        public decimal? NumberOfShares
        {
            get => _numberOfShares;
            set
            {
                _numberOfShares = value;
                RegisterChange();
            }
        }

        private decimal? _valueOfShares;

        [Required]
        [Display(Name = "Value of Shares")]
        public decimal? ValueOfShares
        {
            get => _valueOfShares;
            set
            {
                _valueOfShares = value;
                RegisterChange();
            }
        }

        private decimal? _numberOfSharesWithdrawn;

        [Required]
        [Display(Name = "Number of Shares Withdrawn")]
        public decimal? NumberOfSharesWithdrawn
        {
            get => _numberOfSharesWithdrawn;
            set
            {
                _numberOfSharesWithdrawn = value;
                RegisterChange();
            }
        }

        private decimal? _valueOfSharesWithdrawn;

        [Required]
        [Display(Name = "Value of Shares Withdrawn")]
        public decimal? ValueOfSharesWithdrawn
        {
            get => _valueOfSharesWithdrawn;
            set
            {
                _valueOfSharesWithdrawn = value;
                RegisterChange();
            }
        }

        private DateTime _dateOfMovement;


        [Display(Name = "Date of Movement")]
        public DateTime DateOfMovement
        {
            get => _dateOfMovement;
            set
            {
                _dateOfMovement = value;
                RegisterChange();
            }
        }
        #endregion

        #region Relationships
        public Guid CompanyId { get; set; }
        //public virtual Company Company { get; set; }

        public string AspNetUserId { get; set; }
        #endregion

        #region Constructors
        public UserTransaction() : base()
        {

        }

        public UserTransaction(decimal? numberOfShares, decimal? valueOfShares, decimal? numberOfSharesWithdrawn, decimal? valueOfSharesWithdrawn, DateTime dateOfMovement) : base()
        {
            NumberOfShares = numberOfShares;
            ValueOfShares = valueOfShares;
            NumberOfSharesWithdrawn = numberOfSharesWithdrawn;
            ValueOfSharesWithdrawn = valueOfSharesWithdrawn;
            DateOfMovement= dateOfMovement;
        }

        public UserTransaction(Guid id, DateTime createAt, DateTime updateAt, decimal? numberOfShares, decimal? valueOfShares, decimal? numberOfSharesWithdrawn, decimal? valueOfSharesWithdrawn, DateTime dateOfMovement) : base(id, createAt, updateAt)
        {
            _numberOfShares = numberOfShares;
            _valueOfShares = valueOfShares;
            _numberOfSharesWithdrawn = numberOfSharesWithdrawn;
            _valueOfSharesWithdrawn = valueOfSharesWithdrawn;
            _dateOfMovement = dateOfMovement;
        }
        #endregion
    }
}
