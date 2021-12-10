using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.Validation
{
    public class PhraseAndPriceAttribure : ValidationAttribute
    {
        public string Phrase { get; set; }
        public string Price { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Product product = value as Product;

            if (product != null
                && product.Name.StartsWith(Phrase, StringComparison.OrdinalIgnoreCase)
                && product.Price > decimal.Parse(Price))
            {
                return new ValidationResult(ErrorMessage ?? $"{Phrase} pruducts cannot cost more that ${Price}");
            }

            return ValidationResult.Success; 
        }
    }
}
