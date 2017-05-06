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
    public class ViewOwnerViewModel
    {
        private readonly SaafiDbContext context;

        public ViewOwnerViewModel(SaafiDbContext dbContext)
        {
            this.context = dbContext;
        }

        public Owner Owner { get; set; }

        public IList<OwnerLoad> Items { get; set; }

       
        public LoadCategory LoadCategory { get; set; }
        public IList<decimal> Total { get; set; }
        public  ViewOwnerViewModel() { }
        public ViewOwnerViewModel(IEnumerable<OwnerLoad> ownerLoads)
       
        {

            foreach (var item in Items)
            {
                Total.Add(item.Load.Amount);

            };
        }
    }
}


