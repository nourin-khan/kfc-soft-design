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
	/// Interaction logic for UserControlFood.xaml
	/// </summary>
	public partial class UserControlFood : UserControl
	{
        public delegate void ControlClick();
        public event ControlClick ChooseFoodclick;

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

        private string foodDetails;

        public string FoodDetails
        {
            get { return foodDetails; }
            set { foodDetails = value; }
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
	}
}