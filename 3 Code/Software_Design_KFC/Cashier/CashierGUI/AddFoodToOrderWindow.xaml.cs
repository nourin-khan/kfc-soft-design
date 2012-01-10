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
using CashierController;
using CashierController.KFCService;

namespace CashierGUI
{
	/// <summary>
	/// Interaction logic for AddFoodToOrderWindow.xaml
    /// </summary>


    public partial class AddFoodToOrderWindow : Window
	{
        #region Attribute
        private string _orderId;
        private FoodDTO[] _foodList;
        private FoodDTO _selectedFood = null;
        private int selectedIndex; //selected index in _foodList
        private int _quantity;

        public string orderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        public FoodDTO selectedFood
        {
            get { return _selectedFood; }
            set { _selectedFood = value; }
        }
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        #endregion

		public AddFoodToOrderWindow()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //get food list
            FoodCTL foodCtl = new FoodCTL();
            _foodList = foodCtl.getAllFoodList();

            foreach (FoodDTO foodDto in _foodList)
            {
                if(foodDto.FoodStatus)
                    foodNameCmbBox.Items.Add(foodDto.FoodName);
            }
            foodNameCmbBox.SelectedIndex = 0;
        }

        private void foodNameCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedIndex = foodNameCmbBox.SelectedIndex;
            foodIdTxtBox.Text = _foodList[selectedIndex].FoodID;
            foodPriceTxtBox.Text = _foodList[selectedIndex].FoodPrice.ToString();
            discountPriceTxtBox.Text = _foodList[selectedIndex].DiscountPrice.ToString();
        }

        private void OK_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //validation
            if (string.IsNullOrEmpty(foodIdTxtBox.Text))
            {
                this.Close();
                return;
            }
            if (string.IsNullOrEmpty(qtyTxtBox.Text) || string.IsNullOrWhiteSpace(qtyTxtBox.Text) || int.Parse(qtyTxtBox.Text) <= 0)
            {
                MessageBox.Show("Thông tin số lượng không đúng. Mời bạn nhập lại");
            }                      

            //add order detail to database
            OrderDetailCTL ordDetailCtl = new OrderDetailCTL();
            OrderDetailDTO ordDetailDto = new OrderDetailDTO();
            ordDetailDto.OrderID = orderId;
            ordDetailDto.FoodID = foodIdTxtBox.Text;
            ordDetailDto.Quantity = int.Parse(qtyTxtBox.Text);
            ordDetailDto.CompleteTime = DateTime.Now;
            ordDetailCtl.add(ordDetailDto);
            selectedFood = _foodList[selectedIndex];
            quantity = ordDetailDto.Quantity;

            this.Close();
        }

        
	}
}