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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace KFC_Table_GUI
{
	/// <summary>
	/// Interaction logic for UserControlFoodInCart.xaml
	/// </summary>
	public partial class UserControlFoodInCart : UserControl
	{
        private string foodName;

        public string FoodName
        {
            get { return name.Text; }
            set { name.Text = value; }
        }
        private string foodPrice;

        public string FoodPrice
        {
            get { return price.Text; }
            set { price.Text = value; }
        }

		public UserControlFoodInCart()
		{
			this.InitializeComponent();
		}
	}
}