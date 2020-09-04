using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

public class UWPUtil {
    public static Frame CreateRootFrame() {
        Frame rootFrame = Window.Current.Content as Frame;

        // Do not repeat app initialization when the Window already has content,
        // just ensure that the window is active
        if(rootFrame == null) {
            rootFrame = new Frame();                                                        // Create a Frame to act as the navigation context and navigate to the first page                    
            rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];   // Set the default language

            rootFrame.NavigationFailed += OnNavigationFailed;

            Window.Current.Content = rootFrame;                                             // Place the frame in the current Window
        }
        return rootFrame;
    }

    private static void OnNavigationFailed(object sender,NavigationFailedEventArgs e) {
        throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
    }
}