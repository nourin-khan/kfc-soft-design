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
	/// Interaction logic for UserControlFood.xaml
	/// </summary>
	public partial class UserControlFood : UserControl
	{
        public delegate void ControlClick();
        public event ControlClick ChooseFoodclick;
        public delegate void ControlFocus();
        public event ControlFocus FoodFocus;

        private string foodName;

        public string FoodName
        {
            get { return foodName; }
            set { foodName = value; }
        }
        private string foodPrice;

        public string FoodPrice
        {
            get { return foodPrice; }
            set { foodPrice = value; }
        }

        public string FoodDetails
        {
            get { return details.Text; }
            set { details.Text = value; }
        }
        
		public UserControlFood()
		{
			this.InitializeComponent();
            // declare for options bar clicked
            optionsBar.OKClick += new KFC_Table_GUI.UserControlOptionsBar.ControlClicked(optionsBar_OKClick);
		}

        void optionsBar_OKClick()
        {
            ChooseFoodclick();
        }

        private void image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FoodFocus();
        }
	}
}