﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EInvoice.DAL.Models
{
    public enum InvoiceType
    {
        Invoice,
        Return,
        Debit,
        Credit
    }
    public class Invoice
    {
        #region Properties

        [Key]
        public int InvoiceID { get; set; }

        [Required(ErrorMessage = "Type of Invoice is required")]
        public InvoiceType Type {  get; set; }

        [Required(ErrorMessage ="Code is required")]
        public string Code { get; set; }

        public DateTime DateTimeInssured { get; set; }

        #region Navigational Properties
        
        [Required(ErrorMessage = "Customer is required")]
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

        public List<InvoiceItem> InvoiceItems { get; set; }

        #endregion

        #region Calculated Properties
        
        public decimal NetAmount => InvoiceItems?.Sum(ii => ii.ItemNetAmount) ?? 0;

        #endregion

        #endregion
    }
}
