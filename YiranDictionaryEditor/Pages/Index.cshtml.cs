using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        public string EasyUI {
            get;set;
        }
        public IList<DbField> DbFields {
            get;set;
        }
        //public IndexModel(ILogger<IndexModel> logger) {
        //    _logger = logger;
        //}
        public void OnGet() {
            DbSchemas = _context.DbSchemas.ToList();
            EasyUI = JsonConvert.ToString("[{'id':1,'name':'C','size':'','date':'02 / 19 / 2010','children':[{'id':2,'name':'ProgramFiles','size':'120MB','date':'03 / 20 / 2010','children':[{'id':21,'name':'Java','size':'','date':'01 / 13 / 2010','state':'closed','children':[{'id':211,'name':'java.exe','size':'142KB','date':'01 / 13 / 2010'},{'id':212,'name':'jawt.dll','size':'5KB','date':'01 / 13 / 2010'}]},{'id':22,'name':'MySQL','size':'','date':'01 / 13 / 2010','state':'closed','children':[{'id':221,'name':'my.ini','size':'10KB','date':'02 / 26 / 2009'},{'id':222,'name':'my - huge.ini','size':'5KB','date':'02 / 26 / 2009'},{'id':223,'name':'my - large.ini','size':'5KB','date':'02 / 26 / 2009'}]}]},{'id':3,'name':'eclipse','size':'','date':'01 / 20 / 2010','children':[{'id':31,'name':'eclipse.exe','size':'56KB','date':'05 / 19 / 2009'},{'id':32,'name':'eclipse.ini','size':'1KB','date':'04 / 20 / 2010'},{'id':33,'name':'notice.html','size':'7KB','date':'03 / 17 / 2005'}]}]}]");
            //DbFields = _context.DbFields.ToList();
        }

        public async Task OnGetSync() {
            DbSchemas = await _context.DbSchemas.ToListAsync();
            //EasyUI = "[{	\"id\":1,	\"name\":\"C\",	\"size\":\"\",	\"date\":\"02/19/2010\",	\"children\":[{		\"id\":2,		\"name\":\"Program Files\",		\"size\":\"120 MB\",		\"date\":\"03/20/2010\",		\"children\":[{			\"id\":21,			\"name\":\"Java\",			\"size\":\"\",			\"date\":\"01/13/2010\",			\"state\":\"closed\",			\"children\":[{				\"id\":211,				\"name\":\"java.exe\",				\"size\":\"142 KB\",				\"date\":\"01/13/2010\"			},{				\"id\":212,				\"name\":\"jawt.dll\",				\"size\":\"5 KB\",				\"date\":\"01/13/2010\"			}]		},{			\"id\":22,			\"name\":\"MySQL\",			\"size\":\"\",			\"date\":\"01/13/2010\",			\"state\":\"closed\",			\"children\":[{				\"id\":221,				\"name\":\"my.ini\",				\"size\":\"10 KB\",				\"date\":\"02/26/2009\"			},{				\"id\":222,				\"name\":\"my-huge.ini\",				\"size\":\"5 KB\",				\"date\":\"02/26/2009\"			},{				\"id\":223,				\"name\":\"my-large.ini\",				\"size\":\"5 KB\",				\"date\":\"02/26/2009\"			}]		}]	},{		\"id\":3,		\"name\":\"eclipse\",		\"size\":\"\",		\"date\":\"01/20/2010\",		\"children\":[{			\"id\":31,			\"name\":\"eclipse.exe\",			\"size\":\"56 KB\",			\"date\":\"05/19/2009\"		},{			\"id\":32,			\"name\":\"eclipse.ini\",			\"size\":\"1 KB\",			\"date\":\"04/20/2010\"		},{			\"id\":33,			\"name\":\"notice.html\",			\"size\":\"7 KB\",			\"date\":\"03/17/2005\"		}]	}]}]";
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
