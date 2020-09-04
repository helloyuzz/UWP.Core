using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//https://go.microsoft.com/fwlink/?LinkId=234236 上介绍了“用户控件”项模板

namespace UWP_FisherCore.Xamls {
    public sealed partial class MyTitleBar:UserControl, INotifyPropertyChanged {
        private CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;

        public MyTitleBar() {
            this.InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void UserControl_Loaded(object sender,RoutedEventArgs e) {
            coreTitleBar.LayoutMetricsChanged += OnLayoutMetricsChanged;
            coreTitleBar.IsVisibleChanged += OnIsVisibleChanged;

            // The SizeChanged event is raised when the view enters or exits full screen mode.
            Window.Current.SizeChanged += OnWindowSizeChanged;

            UpdateLayoutMetrics();
            UpdatePositionAndVisibility();
        }

        private void UserControl_Unloaded(object sender,RoutedEventArgs e) {
            coreTitleBar.LayoutMetricsChanged -= OnLayoutMetricsChanged;
            coreTitleBar.IsVisibleChanged -= OnIsVisibleChanged;
            Window.Current.SizeChanged -= OnWindowSizeChanged;
        }
        void OnLayoutMetricsChanged(CoreApplicationViewTitleBar sender,object e) {
            UpdateLayoutMetrics();
        }

        void UpdateLayoutMetrics() {
            if(PropertyChanged != null) {
                PropertyChanged(this,new PropertyChangedEventArgs("CoreTitleBarHeight"));
                PropertyChanged(this,new PropertyChangedEventArgs("CoreTitleBarPadding"));
            }
        }
        void OnIsVisibleChanged(CoreApplicationViewTitleBar sender,object e) {
            UpdatePositionAndVisibility();
        }

        void OnWindowSizeChanged(object sender,WindowSizeChangedEventArgs e) {
            UpdatePositionAndVisibility();
        }
        void UpdatePositionAndVisibility() {
            if(ApplicationView.GetForCurrentView().IsFullScreenMode) {
                // In full screen mode, the title bar overlays the content.
                // and might or might not be visible.
                TitleBar.Visibility = coreTitleBar.IsVisible ? Windows.UI.Xaml.Visibility.Visible : Windows.UI.Xaml.Visibility.Collapsed;
                Grid.SetRow(TitleBar,1);
            } else {
                // When not in full screen mode, the title bar is visible and does not overlay content.
                TitleBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
                Grid.SetRow(TitleBar,0);
            }
        }
        UIElement pageContent = null;

        public UIElement SetPageContent(UIElement newContent) {
            UIElement oldContent = pageContent;
            if(oldContent != null) {
                pageContent = null;
                RootGrid.Children.Remove(oldContent);
            }
            pageContent = newContent;
            if(newContent != null) {
                RootGrid.Children.Add(newContent);
                // The page content is row 1 in our grid. (See diagram above.)
                Grid.SetRow((FrameworkElement)pageContent,1);
            }
            return oldContent;
        }
        public Thickness CoreTitleBarPadding {
            get {
                // The SystemOverlayLeftInset and SystemOverlayRightInset values are
                // in terms of physical left and right. Therefore, we need to flip
                // then when our flow direction is RTL.
                if(FlowDirection == FlowDirection.LeftToRight) {
                    return new Thickness() { Left = coreTitleBar.SystemOverlayLeftInset,Right = coreTitleBar.SystemOverlayRightInset };
                } else {
                    return new Thickness() { Left = coreTitleBar.SystemOverlayRightInset,Right = coreTitleBar.SystemOverlayLeftInset };
                }
            }
        }
        public double CoreTitleBarHeight {
            get {
                return coreTitleBar.Height;
            }
        }

        public void EnableControlsInTitleBar(bool enable) {
            if(enable) {
                TitleBarControl.Visibility = Visibility.Visible;
                // Clicks on the BackgroundElement will be treated as clicks on the title bar.
                Window.Current.SetTitleBar(BackgroundElement);
            } else {
                TitleBarControl.Visibility = Visibility.Collapsed;
                Window.Current.SetTitleBar(null);
            }
        }
    }
}
