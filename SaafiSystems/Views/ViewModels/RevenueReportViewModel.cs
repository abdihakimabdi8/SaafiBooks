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
    public class RevenueReportViewModel
    {
        private readonly SaafiDbContext context;

        public RevenueReportViewModel(SaafiDbContext dbContext)
        {
            this.context = dbContext;
        }

        public IList<LoadCategory> LoadCategories { get; set; }

        public IList<Load> Loads { get; set; }



        public IList<Load> TotalRevenue { get; set; }
        public RevenueReportViewModel() { }
        public RevenueReportViewModel(IEnumerable<Load> loadsForCategory)

        {

            foreach (var item in Loads)
            {
                TotalRevenue.Add(item);

            };
        }
    }
}


