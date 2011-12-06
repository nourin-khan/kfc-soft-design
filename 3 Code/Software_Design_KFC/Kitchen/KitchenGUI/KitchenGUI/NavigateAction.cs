using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Interactivity;

namespace KitchenGUI
{
	public class NavigateAction : TriggerAction<DependencyObject>
  {
    public static readonly DependencyProperty PageProperty = DependencyProperty.Register("Page", typeof(string), typeof(NavigateAction), new PropertyMetadata(null));
 
    public string Page
    {
      get { return GetValue(PageProperty) as string; }
      set { SetValue(PageProperty, value); }
    }
 
    private NavigationService navigationService;
    public NavigateAction()
    {
      NavigationWindow navigationWindow = Application.Current.MainWindow as NavigationWindow;
      if (navigationWindow != null)
      {
        this.navigationService = navigationWindow.NavigationService;
      }
 
    }
 
    protected override void Invoke(object o)
    {
      if (this.navigationService == null)
      {
        // Try to find a frame in the main window.
        Frame frame = FindChild<Frame>(Application.Current.MainWindow);
        if (frame != null)
        {
          this.navigationService = frame.NavigationService;
        }
      }
 
      if (this.navigationService != null)
      {
        this.navigationService.Navigate(new Uri(this.Page, UriKind.Relative));
      }
    }
 
    public static T FindChild<T>(DependencyObject parent) where T : DependencyObject
    {
      if (parent == null) return null;
      T foundChild = null;
      int childrenCount = VisualTreeHelper.GetChildrenCount(parent);
      for (int i = 0; i < childrenCount; i++)
      {
        var child = VisualTreeHelper.GetChild(parent, i);
        T childType = child as T;
        if (childType == null)
        {
          foundChild = FindChild<T>(child);
          if (foundChild != null)
          {
            return foundChild;
          }
        }
        else
        {
          return (T)child;
        }
      }
      return foundChild;
    }
  }
}
