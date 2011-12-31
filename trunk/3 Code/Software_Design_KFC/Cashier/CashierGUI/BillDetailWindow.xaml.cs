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
            DataTable foodList = orderCtl.viewFoodDetail(orderId);                      
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

       
	}
}