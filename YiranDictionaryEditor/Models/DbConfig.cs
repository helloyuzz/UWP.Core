using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Data {
    public class DbConfig {
        public int Id {
            get;set;
        }
        public string ServerIP {
            get;set;
        }
        public string ServerPort {
            get;set;
        }
        public string Schema {
            get;set;
        }
        public string User {
            get;set;
        }
        public string Password {
            get;set;
        }
    }
}
