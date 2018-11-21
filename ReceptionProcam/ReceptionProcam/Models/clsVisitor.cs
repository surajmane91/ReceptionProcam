﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace ReceptionProcam.Models
{
    public class clsVisitor
    {
        public int Id { get; set; }
     
        public string VisitorId { get; set; }
        
        [Required(ErrorMessage = "* Please enter Name")]
        [DisplayName("Name")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string Name { get; set; }

        [DisplayName("Date of Birth")]
        [Required(ErrorMessage = "* Please enter Date of Birth")]
        public string DOB { get; set; }

        [DisplayName("Identification Proof")]
        [Required(ErrorMessage = "* Please select any identity proof")]
        public string GovId { get; set; }

        [DisplayName("Contact No")]
        [Required(ErrorMessage = "* Please enter Mobile No")]
        //[MaxLength(10, ErrorMessage = "* Please enter 10 Digit mobile No")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "* Please enter Valid Digit mobile No")]
        public string MobileNo { get; set; }
        [Required(ErrorMessage = "* Mobile No is required")]
        [DataType(DataType.EmailAddress, ErrorMessage = "* Please write valid Email Address")]
        public string Email{ get; set; }

        [DisplayName("Asset ID")]
        public string AssetId { get; set; }

         [DisplayName("From")]
        [Required(ErrorMessage = "* Please From details")]
        public string Form { get; set; }
        [Required(ErrorMessage = "* Please enter First Name")]
        [DisplayName("Meet")]
        public string ToMeet { get; set; }
        [Required(ErrorMessage = "* Please enter sub Location")]
        [DisplayName("Office Sub Location")]
        public string SubLocation { get; set; }
        [Required(ErrorMessage = "* Please enter building")]
        [DisplayName("Building")]
        public string Building { get; set; }
        [Required(ErrorMessage = "* Please enter Gate No")]
        public string Gate { get; set; }
        [Required(ErrorMessage = "* Please enter porpose to visit")]
        [DisplayName("Purpose")]
        public string Purpose { get; set; }
        [Required(ErrorMessage = "* Please enter In Time")]
        [DisplayName("Time In")]
        public string TimeIn { get; set; }
        [Required(ErrorMessage = "* Please enter Valid date Time")]
        [DisplayName("Valid Upto")]
        public string ValidUpto { get; set; }
        public string Remark { get; set; }
        public string ImagePath { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public string ModifiedDate { get; set; }
    }
}