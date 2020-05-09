using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Models {
    public class DbField {
        public int Id {
            get;set;
        }
        public string FieldName {
            get;set;
        }
        public int SchemaId {
            get;set;
        }
        public string FieldType {
            get;set;
        }
        public string FieldComment {
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
