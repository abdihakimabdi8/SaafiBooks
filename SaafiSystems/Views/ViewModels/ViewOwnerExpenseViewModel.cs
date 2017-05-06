using SaafiSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaafiSystems.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SaafiSystems.ViewModels
{
    public class ViewOwnerExpenseViewModel
    {

        private readonly SaafiDbContext context;

        public ViewOwnerExpenseViewModel(SaafiDbContext dbContext)
        {
            this.context = dbContext;
        }
        public Owner Owner { get; set; }
 
        public ExpenseCategory ExpenseCategory { get; set; }
        public IList<OwnerExpense> ExpenseItems { get; set; }


        
        public IList<decimal> TotalExpense { get; set; }
        public ViewOwnerExpenseViewModel() { }
        public ViewOwnerExpenseViewModel(IEnumerable<OwnerExpense> ownerExpenses)

        {

            foreach (var item in ExpenseItems)
            {
                TotalExpense.Add(item.Expense.Amount);

            };
            //TODO: #3 refactor similar code with ViewOwnerExpenseItemsViewModel


        }
    }
}