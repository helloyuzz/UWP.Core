using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWP_FisherCore.Xamls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace UWP_FisherCore {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage:Page {
        private ObservableCollection<NavLink> _navLinks = new ObservableCollection<NavLink>()
        {
            new NavLink() { Label = "People", Symbol = Windows.UI.Xaml.Controls.Symbol.People  },
            new NavLink() { Label = "Globe", Symbol = Windows.UI.Xaml.Controls.Symbol.Globe },
            new NavLink() { Label = "Message", Symbol = Windows.UI.Xaml.Controls.Symbol.Message },
            new NavLink() { Label = "Mail", Symbol = Windows.UI.Xaml.Controls.Symbol.Mail },
        };
        MyTitleBar myTitleBar = null;
        public ObservableCollection<NavLink> NavLinks {
            get { return _navLinks; }
        }
        public MainPage() {
            this.InitializeComponent();
            //ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
        }
        private void NavLinksList_ItemClick(object sender,ItemClickEventArgs e) {
            content.Text = (e.ClickedItem as NavLink).Label + " Page";
            main_View.IsPaneOpen = true;
        }

        private void btn_Home_Click(object sender,RoutedEventArgs e) {
            main_View.IsPaneOpen = !main_View.IsPaneOpen;
            if(main_View.IsPaneOpen == true) {
                icon_Main.Symbol = Symbol.Back;
            } else {
                icon_Main.Symbol = Symbol.Forward;
            }
        }

        private void btn_About_Click(object sender,RoutedEventArgs e) {
            AddCustomTitleBar();
        }

        private void btn_Exit_Click(object sender,RoutedEventArgs e) {

        }

        private void btn_FullScreen_Click(object sender,RoutedEventArgs e) {

        }

        private void btn_Settins_Click(object sender,RoutedEventArgs e) {

        }

        public void AddCustomTitleBar() {
            if(myTitleBar == null) {
                myTitleBar = new MyTitleBar();
                myTitleBar.EnableControlsInTitleBar(areControlsInTitleBar);

                // Make the main page's content a child of the title bar,
                // and make the title bar the new page content.
                UIElement mainContent = this.Content;
                this.Content = null;
                myTitleBar.SetPageContent(mainContent);
                this.Content = myTitleBar;
            }
        }

        public void RemoveCustomTitleBar() {
            if(myTitleBar != null) {
                // Take the title bar's page content and make it
                // the window content.
                this.Content = myTitleBar.SetPageContent(null);
                myTitleBar = null;
            }
        }
        bool areControlsInTitleBar = false;
        public bool AreControlsInTitleBar {
            get {
                return areControlsInTitleBar;
            }
            set {
                areControlsInTitleBar = value;
                if(myTitleBar != null) {
                    myTitleBar.EnableControlsInTitleBar(value);
                }
            }
        }
    }
}