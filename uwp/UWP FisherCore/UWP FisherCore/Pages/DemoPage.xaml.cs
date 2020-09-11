using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UWP_FisherCore.Xamls;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace UWP_FisherCore.Pages {
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class DemoPage:Page {
        Frame root;
        public DemoPage() {
            this.InitializeComponent();
            root = UWPUtil.CreateRootFrame();
        }

        string prev_SelectedText = "";
        private void nvSample_SelectionChanged(NavigationView sender,NavigationViewSelectionChangedEventArgs args) {
            NavigationViewItem item = args.SelectedItem as NavigationViewItem;

            //nvSample.Header = item.Content;
            nvSample.IsPaneOpen = true;
            navi_Frame(item.Name);
        }

        private void navi_Frame(string itemName) {
            //contentFrame.Tag = itemName;
            switch(itemName) {
                case "vItem_LicenceCode":
                    contentFrame.Navigate(UWPPages.Page_Licence);
                    break;
                case "vItem_Account":
                    contentFrame.Navigate(UWPPages.Page_Account);
                    break;
                case "vItem_Project":
                    contentFrame.Navigate(UWPPages.Page_Project);
                    break;
                case "vItem_Log":
                    contentFrame.Navigate(UWPPages.Page_SecurityLog);
                    break;
                case "vItem_Homepage":
                    contentFrame.Navigate(UWPPages.Page_Index);
                    break;
            }
            prev_SelectedText = itemName;
        }

        private void sug_tip_TextChanged(AutoSuggestBox sender,AutoSuggestBoxTextChangedEventArgs args) {
            if(args.Reason == AutoSuggestionBoxTextChangeReason.UserInput) {
                List<string> suggestions = new List<string>()
                {
                    sender.Text + "1",
                    sender.Text + "2"
                };
                sug_tip.ItemsSource = suggestions;
            }
        }

        private void sug_tip_QuerySubmitted(AutoSuggestBox sender,AutoSuggestBoxQuerySubmittedEventArgs args) {

        }

        private void sug_tip_SuggestionChosen(AutoSuggestBox sender,AutoSuggestBoxSuggestionChosenEventArgs args) {
            sug_tip.Text = args.SelectedItem.ToString();
        }

        private void nvSample_Tapped(object sender,TappedRoutedEventArgs e) {
            Type itemType = e.OriginalSource.GetType();
            if(itemType.Equals(typeof(Grid))) {
                Grid grid = e.OriginalSource as Grid;
                switch(grid.Name) {
                    case "LayoutRoot":
                        //FlyoutBase.ShowAttachedFlyout(nvSample as FrameworkElement);
                        break;
                }
                e.Handled = true;
            } else if(itemType.Equals(typeof(TextBlock))) {
                TextBlock textBlock = e.OriginalSource as TextBlock;
                switch(textBlock.Name) {
                    case "":
                    case "Icon":
                        //e.Handled = true;
                        break;
                    default:
                        nvSample.IsPaneOpen = true;
                        break;
                }                
            } else if(itemType.Equals(typeof(ContentPresenter))) {
                return;
            } else {
                //nvSample.IsPaneOpen = true;               
            }
            //check_CurrentFrame();
        }

        private void check_CurrentFrame() { // 只打开新页面，去重
            if(prev_SelectedText.Equals("Homepage")) {
                if(nvSample.SelectedItem != null) {
                    NavigationViewItem navigationViewItem = nvSample.SelectedItem as NavigationViewItem;
                    navi_Frame(navigationViewItem.Name);
                }
            }
        }

        private void StackPanel_Tapped(object sender,TappedRoutedEventArgs e) {
            FlyoutBase.ShowAttachedFlyout(sender as FrameworkElement);
        }

        private void btn_Exit_Tapped(object sender,TappedRoutedEventArgs e) {
            root.Navigate(UWPPages.Page_Login);
        }

        private void btn_Exit_Click(object sender,RoutedEventArgs e) {
            root.Navigate(UWPPages.Page_Login);
        }

        private void MenuFlyoutItem_Click(object sender,RoutedEventArgs e) {

        }

        private void vItem_About_Click(object sender,RoutedEventArgs e) {
            AboutDialog aboutDialog = new AboutDialog();
            aboutDialog.ShowAsync();
        }

        private void Page_Demo_Loaded(object sender,RoutedEventArgs e) {
            contentFrame.Navigate(UWPPages.Page_Index);
        }

        private void homepage_PaneHyperlink_Click(object sender,RoutedEventArgs e) {
            navi_Frame("Homepage");
        }
    }
}