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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KFC_Table_GUI
{
	/// <summary>
	/// Interaction logic for UserControlOptionsBar.xaml
	/// </summary>
	public partial class UserControlOptionsBar : UserControl
	{
        public delegate void ControlClicked();
        public event ControlClicked OKClick;

		public UserControlOptionsBar()
		{
			this.InitializeComponent(); 
		}

        private void okControl_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OKClick();
        }
	}
}