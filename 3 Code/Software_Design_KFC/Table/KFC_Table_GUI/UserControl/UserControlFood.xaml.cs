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
using TableDTO;

namespace KFC_Table_GUI
{
	/// <summary>
	/// Interaction logic for UserControlFood.xaml
	/// </summary>
	public partial class UserControlFood : UserControl
	{
        public delegate void ControlClick(UserControlFood food);
        public event ControlClick ChooseFoodclick;

        public delegate void ControlFocus(UserControlFood food);
        public event ControlFocus FoodFocus;

        private string foodID;

        public string FoodID
        {
            get { return foodID; }
            set { foodID = value; }
        }
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

        public ImageSource FoodImageSource
        {
            get { return image.Source; }
            set { image.Source = value; }
        }
		public UserControlFood()
		{
			this.InitializeComponent();
            // declare for options bar clicked
            optionsBar.OKClick += new KFC_Table_GUI.UserControlOptionsBar.ControlClicked(optionsBar_OKClick);
		}

        public UserControlFood(FoodDTO info)
        {
            this.InitializeComponent();
            optionsBar.OKClick += new KFC_Table_GUI.UserControlOptionsBar.ControlClicked(optionsBar_OKClick);
            this.FoodName = info.FoodName;
            this.FoodPrice = info.FoodPrice.ToString();
            this.FoodDetails = info.FoodDescription + "\nGia : " + this.FoodPrice;
            this.FoodImageSource = new BitmapImage(new Uri(info.FoodImageSource));
        }

        void optionsBar_OKClick()
        {
            ChooseFoodclick(this);
        }

        private void image_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FoodFocus(this);
        }
	}
}