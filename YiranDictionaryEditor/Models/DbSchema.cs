using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models {
    public class DbSchema {
        public int Id {
            get;set;
        }
        public string SchemaName {
            get;set;
        }
        public DateTime UpdateTime {
            get;set;
        }
        public bool IsDeleted {
            get;set;
        }
    }
}
