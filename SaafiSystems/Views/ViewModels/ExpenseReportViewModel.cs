using SaafiSystems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SaafiSystems.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections;

namespace SaafiSystems.ViewModels
{
    public class ExpenseReportViewModel
    {
        private readonly SaafiDbContext context;

        public ExpenseReportViewModel(SaafiDbContext dbContext)
        {
            this.context = dbContext;
        }

        public IList<ExpenseCategory> ExpenseCategories { get; set; }

        public IList<Expense> Expenses { get; set; }


       
        public IList<Expense> TotalExpense { get; set; }
        public ExpenseReportViewModel() { }
        public ExpenseReportViewModel(IEnumerable<Expense> expensesForCategory )

        {

            foreach (var item in Expenses)
            {
                TotalExpense.Add(item);

            };
        }
    }
}


