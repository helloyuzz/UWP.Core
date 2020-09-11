using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWP_FisherCore.Pages;

namespace UWP_FisherCore {
    public static class UWPPages {
        static public Type Page_Login { get { return typeof(LoginPage); } }
        static public Type Page_Main { get { return typeof(MainPage); } }
        static public Type Page_Demo { get { return typeof(DemoPage); } }
        static public Type Page_Account { get { return typeof(Page_Account); } }
        static public Type Page_Licence  { get { return typeof(Page_Licence); } }
        static public Type Page_Project { get { return typeof(Page_Project); } }
        static public Type Page_SecurityLog { get { return typeof(Page_SecurityLog); } }
        static public Type Page_Index { get { return typeof(Page_Index); } }

    }
}
