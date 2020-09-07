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

        private double? _valueOfShares;

        [Required]
        [Display(Name = "Value of Shares")]
        public double? ValueOfShares
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

        private double? _valueOfSharesWithdrawn;

        [Required]
        [Display(Name = "Value of Shares Withdrawn")]
        public double? ValueOfSharesWithdrawn
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
        public Guid CompanyUserRelationshipId { get; set; }
        public CompanyUserRelationship CompanyUserRelationship { get; set; }
        #endregion

        #region Constructors
        public UserTransaction() : base()
        {

        }

        public UserTransaction(double numberOfShares, double valueOfShares, double numberOfSharesWithdrawn, double valueOfSharesWithdrawn, DateTime dateOfMovement) : base()
        {
            _numberOfShares = numberOfShares;
            _valueOfShares = valueOfShares;
            _numberOfSharesWithdrawn = numberOfSharesWithdrawn;
            _valueOfSharesWithdrawn = valueOfSharesWithdrawn;
            _dateOfMovement = dateOfMovement;
        }

        public UserTransaction(Guid id, DateTime createAt, DateTime updateAt, double numberOfShares, double valueOfShares, double numberOfSharesWithdrawn, double valueOfSharesWithdrawn, DateTime dateOfMovement) : base(id, createAt, updateAt)
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
