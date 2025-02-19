using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using homework_7_oscardavila09.Models;
using System.Diagnostics.Contracts;

namespace homework_7_oscardavila09.Pages_Orders
{
    public class IndexModel : PageModel
    {
        private readonly homework_7_oscardavila09.Models.AppDbContext _context;

        public IndexModel(homework_7_oscardavila09.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Order> Order { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public int PageNum {get;set;} = 1;
        public int PageSize {get;set;} = 10;
        public int TotalPages {get;set;}

        [BindProperty(SupportsGet = true)]
        public string CurrentSort{get;set;} = string.Empty;
        [BindProperty(SupportsGet =true)]
        public string NextSort{get;set;} = string.Empty;

        [BindProperty(SupportsGet =true)]
        public string CurrentSearch{get;set;} = string.Empty;
        [BindProperty(SupportsGet = true)]
        public string ProductSearch{get;set;} = string.Empty;
        public async Task OnGetAsync()
        {
            
            var query = _context.Orders.Include(s => s.ProductOrders!).ThenInclude(sc=>sc.Product).Select(s=>s);

            if (!string.IsNullOrEmpty(CurrentSearch))
            {
                query = query.Where(s => s.CustomerName.ToUpper().Contains(CurrentSearch.ToUpper()) || s.ProductOrders.Any(sc=>sc.Product.Name.ToUpper().Contains(CurrentSearch.ToUpper())));
            }

            switch (CurrentSort)
            {
                case "first_asc":
                query = query.OrderBy(s => s.CustomerName);
                break;
                case "first_desc":
                query = query.OrderByDescending(s => s.CustomerName);
                break;
            }
            switch (NextSort)
            {
                case "second_asc":
                query = query.OrderBy(s =>s.OrderDate);
                break;
                case "second_desc":
                query = query.OrderByDescending(s => s.OrderDate);
                break;
            }
            TotalPages = (int)Math.Ceiling(query.Count() / (double)PageSize);

            Order = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
        }
    }
}
