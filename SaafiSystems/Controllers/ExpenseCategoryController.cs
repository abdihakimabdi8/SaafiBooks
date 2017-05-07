using Microsoft.AspNetCore.Mvc;
using SaafiSystems.Models;
using System.Collections.Generic;
using SaafiSystems.ViewModels;
using SaafiSystems.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SaafiSystems.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        private readonly SaafiDbContext context;

        public ExpenseCategoryController(SaafiDbContext dbContext)
        {
            this.context = dbContext;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(int? page)
        {
            var expenseCategories = from eCat in context.ExpenseCategories
                                    select eCat;
            int pageSize = 3;
            return View(await PaginatedList<ExpenseCategory>.CreateAsync(expenseCategories.AsNoTracking(), page ?? 1, pageSize));

        }

        public IActionResult Add()
        {
            AddExpenseCategoryViewModel addExpenseCategoryViewModel =
                new AddExpenseCategoryViewModel();
            return View(addExpenseCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddExpenseCategoryViewModel addExpenseCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                ExpenseCategory newCategory = new ExpenseCategory
                {
                    Name = addExpenseCategoryViewModel.Name,
                };

                context.ExpenseCategories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/ExpenseCategory");
            }

            return View(addExpenseCategoryViewModel);
        }


        public IActionResult Remove(int ID)
        {
            var expenseCat = context.ExpenseCategories.Single(e => e.ID == ID);
            if (expenseCat != null)
                context.ExpenseCategories.Remove(expenseCat);

            context.SaveChanges();

            return Redirect("/ExpenseCategory");


        }

        [HttpPost]
        public IActionResult Remove(int[] expenseCategoryIds)
        {
            foreach (int expenseCategoryId in expenseCategoryIds)
            {
                ExpenseCategory theExpenseCategory = context.ExpenseCategories.Single(c => c.ID == expenseCategoryId);
                context.ExpenseCategories.Remove(theExpenseCategory);
            }

            context.SaveChanges();

            return Redirect("/ExpenseCategory");
        }


        //    [HttpPost]
        public async Task<IActionResult>Category(int id, int? page)
        {
            if (id == 0)
            {
                Redirect("/Category");
            }

            ExpenseCategory theCategory = context.ExpenseCategories
                .Include(cat => cat.Expenses)
                .Single(cat => cat.ID == id);

            /* 
             * IList<Cheese> theCheese = Context.Cheeses
             * .Include(c => c.Category)
             * .Single(c => c.CategoryID ==id)
             .ToList();*/

            ViewBag.Title = "Expenses in Category" + theCategory.Name;

            //var theCategorys = from eCat in context.ExpenseCategories.Include(cat => cat.Expenses)
                               
            //                   select eCat;
                                    
            int pageSize = 3;
           // return View(await PaginatedList<ExpenseCategory>.CreateAsync(theCategorys.AsNoTracking(), page ?? 1, pageSize));
        return View(theCategory.Expenses);
        }
    }
}