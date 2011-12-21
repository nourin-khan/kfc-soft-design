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
	/// Interaction logic for UserControlFoodInFocus.xaml
	/// </summary>
	public partial class UserControlFoodInFocus : Window
	{
        private bool isAddToCart = false;

        public bool IsAddToCart
        {
            get { return isAddToCart; }
            set { isAddToCart = value; }
        }

        private string foodID;

        public string FoodID
        {
            get { return foodID; }
            set { foodID = value; }
        }
        public string Details 
        {
            get {return details.Text;}
            set {details.Text = value;}
        }
        
        public Image Image
        {
            get {return image;}
            set {image = value;}
        }

		public UserControlFoodInFocus()
		{
			this.InitializeComponent();
            // set window startup position
            this.WindowStartupLocation = WindowStartupLocation.Manual;
            this.Left = 350;
            this.Top = 300;
		}

		private void close_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            this.Close();
		}

		private void addToCart_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            this.isAddToCart = true;
            this.Close();
		}
	}
}