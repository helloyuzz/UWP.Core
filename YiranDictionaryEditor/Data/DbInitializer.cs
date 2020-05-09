using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data {
    public class DbInitializer {
        internal static void Initialize(WebAppContext context) {
            context.Database.EnsureCreated();
            if(context.DbConfig.Any()) {
                return;
            } else {
                context.DbConfig.Add(new DbConfig { ServerIP = "192.168.3.31" });
                context.SaveChanges();
            }
        }
    }
}
