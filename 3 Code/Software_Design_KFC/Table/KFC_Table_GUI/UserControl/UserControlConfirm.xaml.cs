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

namespace KFC_Table_GUI
{
	/// <summary>
	/// Interaction logic for UserControlConfirm.xaml
	/// </summary>
	public partial class UserControlConfirm : Window
	{
        private bool isConfirm = false;

        public bool IsConfirm
        {
            get { return isConfirm; }
            set { isConfirm = value; }
        }

		public UserControlConfirm()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

		private void Cancel_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            this.Close();
		}

		private void OK_Click(object sender, System.Windows.RoutedEventArgs e)
		{
            isConfirm = true;
            this.Close();
		}
	}
}