using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApp.Validation;

namespace WebApp.Models
{
    public class Product
    {
        [PhraseAndPriceAttribure(Phrase = "Small", Price = "100")]
        public long ProductId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Column(TypeName = "decimal(8, 2)")]
        [Required(ErrorMessage = "Please enter the price")]
        [Range(1, 99999, ErrorMessage = "Plwease enter a positive price")]
        public decimal Price { get; set; }
        
        [PrimaryKey(ContextType = typeof(DataContext), DataType = typeof(Category))]
        [Remote("CategoryKey", "Validation", ErrorMessage = "Enter an exisitng key")]
        public long CategoryId { get; set; }
        public Category Category { get; set; }

        [PrimaryKey(ContextType = typeof(DataContext), DataType = typeof(Supplier))]
        [Remote("SupplierKey", "Validation", ErrorMessage = "Enter an exisitng key")]
        public long SupplierId { get; set; }
        public Supplier Supplier { get; set; }
    }
}
