﻿using System;
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

namespace CashierGUI
{
	/// <summary>
	/// Interaction logic for BillDetailWindow.xaml
	/// </summary>
	public partial class BillDetailWindow : Window
	{
		public BillDetailWindow()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void border5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MoneyCalWindow moneyCal = new MoneyCalWindow();
            moneyCal.Show();
        }
	}
}