using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace YiranDictionaryEditor
{
    public class IndexModel : PageModel
    {
        private readonly WebApp.Data.WebAppContext _context;

        public IndexModel(WebApp.Data.WebAppContext context)
        {
            _context = context;
        }

        public IList<DbSchema> DbSchemas { get;set; }

        public async Task OnGetAsync()
        {
            DbSchemas = await _context.DbSchemas.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync() {
            if(!ModelState.IsValid) {
                return Page();
            }

            //_context.Customers.Add(Customer);
            //await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
