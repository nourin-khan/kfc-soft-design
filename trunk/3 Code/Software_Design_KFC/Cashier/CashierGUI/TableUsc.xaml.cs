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

namespace CashierGUI
{
	/// <summary>
	/// Interaction logic for TableUsc.xaml
	/// </summary>
	public partial class TableUsc : UserControl
	{
		private bool _free = true;
		
		public bool free
		{
			get {return _free;}
			set 
			{
                _free = value;
                if (value == false)
                {
                    this.freeLbl.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.freeLbl.Visibility = Visibility.Visible;
                }
			}
		}
		public TableUsc()
		{
			this.InitializeComponent();
		}

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            BillDetailWindow billDetail = new BillDetailWindow();
            billDetail.Show();
        }
	}
}