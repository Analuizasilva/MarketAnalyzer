using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recodme.RD.FullStoQReborn.DataLayer.UserRecords
{
    public class Profile : Entity
    {
        #region Properties      

        private string _firstName;

        [Required]
        [Display(Name = "First Name")]
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                RegisterChange();
            }
        }

        private string _lastName;

        [Required]
        [Display(Name = "Last Name")]
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                RegisterChange();
            }
        }

        private string _email;

        [Required]
        [Display(Name = "Email")]
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                RegisterChange();
            }
        }

        private DateTime _birthDate;

        [Required]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                RegisterChange();
            }
        }

        private bool _isDeleted;         
        public bool IsDeleted
        {
            get => _isDeleted;
            set
            {
                _isDeleted = value;
                RegisterChange();
            }
        } 
        #endregion

        #region Relationships
        //[ForeignKey("Account")]
        //public Guid AccountId { get; set; }
        //public virtual Account Account { get; set; }
        ICollection<User> Users { get; set; }
        #endregion

        #region Constructors
        public Profile(string firstName, string lastName, string email,
            DateTime birthDate/*, Guid accountId*/)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _birthDate = birthDate;
            //AccountId = accountId;
        }

        public Profile(Guid id, DateTime createdAt, DateTime updatedAt, string email, string firstName, string lastName, DateTime birthDate/*, Guid accountId*/) : base(id, createdAt, updatedAt)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _birthDate = birthDate;
            //AccountId = accountId;
        }
        #endregion
    }
}
