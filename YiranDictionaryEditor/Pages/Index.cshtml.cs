using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WebApp.Data;
using WebApp.Models;
using YiranDictionaryEditor.DAL;

namespace WebApp.Pages {
    public class IndexModel:PageModel {
        private readonly ILogger<IndexModel> _logger;
        private readonly WebApp.Data.WebAppContext _context;

        public IndexModel(WebAppContext context) {
            _context = context;
        }

        public IList<WebApp.Models.DbSchema> DbSchemas {
            get; set;
        }
        public IList<DbField> DbFields {
            get;set;
        }
        //public IndexModel(ILogger<IndexModel> logger) {
        //    _logger = logger;
        //}
        public void OnGet() {
            DbSchemas = _context.DbSchemas.ToList();
            //DbFields = _context.DbFields.ToList();
        }

        public async Task OnGetSync() {
            DbSchemas = await _context.DbSchemas.ToListAsync();
        }

        public async Task<IActionResult> OnPostSyncAsync() {
            if(!ModelState.IsValid) {
                return Page();
            }
            await SchemaDAL.SyncSchema(_context);

            //_db.Customers.Add(Customer);
            //await _db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }

    }
}
