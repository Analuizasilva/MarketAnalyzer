using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords
{
    public class UserTransaction : Entity
    {
        #region Properties     
        private double? _numberOfShares;

        [Required]
        [Display(Name = "Number of Shares")]
        public double? NumberOfShares
        {
            get => _numberOfShares;
            set
            {
                _numberOfShares = value;
                RegisterChange();
            }
        }

        private decimal _valueOfShares;

        [Required]
        [Display(Name = "Value of Shares")]
        public decimal ValueOfShares
        {
            get => _valueOfShares;
            set
            {
                _valueOfShares = value;
                RegisterChange();
            }
        }

        private double? _numberOfSharesWithdrawn;

        [Required]
        [Display(Name = "Number of Shares Withdrawn")]
        public double? NumberOfSharesWithdrawn
        {
            get => _numberOfSharesWithdrawn;
            set
            {
                _numberOfSharesWithdrawn = value;
                RegisterChange();
            }
        }

        private decimal _valueOfSharesWithdrawn;

        [Required]
        [Display(Name = "Value of Shares Withdrawn")]
        public decimal ValueOfSharesWithdrawn
        {
            get => _valueOfSharesWithdrawn;
            set
            {
                _valueOfSharesWithdrawn = value;
                RegisterChange();
            }
        }

        private DateTime _dateOfMovement;

        [Required]
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
        public virtual Company Company { get; set; }

        public string AspNetUserId { get; set; }
        #endregion

        #region Constructors
        public UserTransaction() : base()
        {

        }

        public UserTransaction(double numberOfShares, decimal valueOfShares, double numberOfSharesWithdrawn, decimal valueOfSharesWithdrawn, DateTime dateOfMovement, Guid companyUserRelId) : base()
        {
            NumberOfShares = numberOfShares;
            ValueOfShares = valueOfShares;
            NumberOfSharesWithdrawn = numberOfSharesWithdrawn;
            ValueOfSharesWithdrawn = valueOfSharesWithdrawn;
            DateOfMovement= dateOfMovement;
        }

        public UserTransaction(Guid id, DateTime createAt, DateTime updateAt, double numberOfShares, decimal valueOfShares, double numberOfSharesWithdrawn, decimal valueOfSharesWithdrawn, DateTime dateOfMovement) : base(id, createAt, updateAt)
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
