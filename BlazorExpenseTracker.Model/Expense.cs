using BlazorExpenseTracker.Model.Validation;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlazorExpenseTracker.Model
{
    public class Expense
    {
        public int Id { get; set; }
        [Required]
        [Range(1,double.MaxValue, ErrorMessage ="Amound needs to be greater than 0" )]
        public decimal Amount { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public  Category Category { get; set; }
        [Required]
        [ExpenceTransactionDateValidator(DaysInTheFuture = 30)]
        public DateTime TransactionDate { get; set; } 

        public ExpenseType ExpenseType { get; set; }
        /// <summary>
        /// comunicación entre componentes
        /// </summary>
        public event Action OnselectedExpenseChanged;

        /// <summary>
        /// cada vez que se actualice un expense se activa  el evento
        /// </summary>
        /// <param name="expense"></param>
        public void SelectedExpenseChanged(Expense expense) { 
        
            Id= expense.Id;
            TransactionDate = expense.TransactionDate;
            Amount = expense.Amount;
            ExpenseType = expense.ExpenseType;
            CategoryId = expense.CategoryId;
       

            NotifySelectedExpenseChanged();
        } 
        /// <summary>
        /// dispara la actualización del evento
        /// </summary>
        private void NotifySelectedExpenseChanged()
        {
            OnselectedExpenseChanged.Invoke();
        }

    }
}
