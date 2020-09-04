using Recodme.Labs.MarketAnalyzer.DataLayer.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Recodme.Labs.MarketAnalyzer.DataLayer.UserRecords
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
        ICollection<User> Users { get; set; }
        #endregion

        #region Constructors
        public Profile(): base()
        {
        }

        public Profile(string firstName, string lastName, string email,
            DateTime birthDate)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _birthDate = birthDate;           
        }

        public Profile(Guid id, DateTime createdAt, DateTime updatedAt, string email, string firstName, string lastName, DateTime birthDate) : base(id, createdAt, updatedAt)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _birthDate = birthDate;           
        }

        
        #endregion
    }
}
