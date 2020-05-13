using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YiranDictionaryEditor.DAL {
    public class SchemaDAL {
        internal static async Task SyncSchema(WebApp.Data.WebAppContext _context) {
            //Action<object> action = (object obj) =>
            //{
            //    DbSync(_context);
            //};
            //Task task = new Task(action,"dbsync");
            //task.Start();
            //task.Wait();
            //return task;

           await Task.Run(() => { DbSync(_context); });
        }

        private static void DbSync(WebApp.Data.WebAppContext _context) {
            for(int n = 1;n <= 16;n++) {
                _context.DbSchemas.Add(new WebApp.Models.DbSchema() { SchemaName = "SchemaName_" + n,UpdateTime = DateTime.Now });
            }
            _context.SaveChanges();
        }
    }
}
