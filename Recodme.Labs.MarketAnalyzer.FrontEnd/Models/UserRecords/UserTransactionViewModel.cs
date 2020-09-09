﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Recodme.Labs.MarketAnalyzer.FrontEnd.Models.UserRecords
{
    public class UserTransactionViewModel
    {
        
        public string AspNetUserId { get; set; }
        [Display(Name = "Company")]
        public Guid CompanyId { get; set; }
        [Display(Name = "Number of Shares")]
        public decimal? NumberOfShares { get; set; }
        [Display(Name = "Value of Shares")]
        public decimal? ValueOfShares { get; set; }
        [Display(Name = "Number of Shares Withdrawn")]
        public decimal? NumberOfSharesWithdrawn { get; set; } 
        [Display(Name = "Value of Shares Withdrawn")]
        public decimal? ValueOfSharesWithdrawn { get; set; } 
        [Display(Name = "Date of Movement")]
        public DateTime DateOfMovement { get; set; }



    }
}
