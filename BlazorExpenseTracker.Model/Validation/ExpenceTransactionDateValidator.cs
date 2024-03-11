using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorExpenseTracker.Model.Validation
{
    public class ExpenceTransactionDateValidator: ValidationAttribute
    {
        public int DaysInTheFuture { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime transactionDate;

            if (DateTime.TryParse(value.ToString(), out transactionDate)) {

                if (transactionDate == DateTime.MinValue) {

                    return new ValidationResult($"Date Shouldn´t be empty", new[] { validationContext.MemberName });
                }
                else if (transactionDate > DateTime.Now.AddDays(DaysInTheFuture))
                {
                    return new ValidationResult($"Date can´t be greater than today plus{DaysInTheFuture}", new[] { validationContext.MemberName });

                }
                return null;
            }
            return new ValidationResult("invalid date", new[] { validationContext.MemberName});
        }

    }
}
