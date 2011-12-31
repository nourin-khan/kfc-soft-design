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
using System.Data;

namespace CashierGUI
{
	/// <summary>
	/// Interaction logic for BillDetailWindow.xaml
	/// </summary>
	public partial class BillDetailWindow : Window
	{
        #region  Attribute
        OrderCTL orderCtl = new OrderCTL();
        private int _tableNum;
        private string _orderId;
        private DataTable _foodList;

        public int tableNum
        {
            get { return _tableNum; }
            set 
            { 
                _tableNum = value;
                tableNumTxtBlock.Text = "BÀN " + _tableNum.ToString();
            }
        }
        public string orderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        #endregion

		public BillDetailWindow()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        #region Initialization
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //get Order information
            //OrderDTO orderDto = orderCtl.viewOrderInfo(tableNum);
            //this.orderId = orderDto.OrderID;
            //orderDateDtPicker.DisplayDate = orderDto.OrderDate;
            //if (orderDto.OrderStatus == 1)
            //{
            //    orderStatusTxtBlock.Text = "Đã xác nhận";
            //}
            //else
            //    orderStatusTxtBlock.Text = "Chưa xác nhận";

            //get food detail of order, note here: quantity in foodlist is the quantity customer orders
            _foodList = orderCtl.viewFoodDetail(orderId);
            FoodGridView.DataContext = _foodList;
            FoodGridView.Columns[0].Visibility = Visibility.Hidden;
		}
        #endregion

        #region Eventhandler
        #endregion

        private void cashBut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MoneyCalWindow moneyCal = new MoneyCalWindow();
            moneyCal.Show();
        }

        private void OK_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void addBut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddFoodToOrderWindow addWindow = new AddFoodToOrderWindow();
            addWindow.orderId = orderId;
            addWindow.ShowDialog();

            //add new row to datagrid
            if (addWindow.selectedFood != null)
            {
                _foodList.Rows.Add(addWindow.selectedFood.FoodID, addWindow.selectedFood.FoodName, addWindow.quantity, addWindow.selectedFood.FoodPrice, addWindow.selectedFood.DiscountPrice);
                FoodGridView.DataContext = _foodList;
                FoodGridView.Columns[0].Visibility = Visibility.Hidden;
            }
        }

        private void deleteBut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (FoodGridView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Mời bạn chọn thức ăn muốn xóa trước");
                return;
            }

            string foodID = _foodList.Rows[FoodGridView.SelectedIndex][0].ToString(); //index 0 means foodID columns
            OrderDetailCTL ordDetailCtl = new OrderDetailCTL();
            //OrderDetailDTO ordDetailDto = new OrderDetailDTO();
            //delete in db
            ordDetailCtl.delete(orderId, foodID);
            
            //remove in _foodList and update GUI
            _foodList.Rows.RemoveAt(FoodGridView.SelectedIndex);
            FoodGridView.DataContext = _foodList;
            FoodGridView.Columns[0].Visibility = Visibility.Hidden;
        }

       
	}
}