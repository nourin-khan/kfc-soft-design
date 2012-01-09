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

namespace CashierGUI
{
	/// <summary>
	/// Interaction logic for MoneyCalWindow.xaml
	/// </summary>
	public partial class MoneyCalWindow : Window
    {
        #region Attribute
        private int _orderTotal;
        private string _orderId;
        private bool _closed = true;
        private string _empId;

        public string orderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        public int orderTotal
        {
            get { return _orderTotal; }

            set 
            { 
                _orderTotal = value;
                this.sumTxtBlock.Text = value.ToString();
                this.payMoneyTxtBlock.Text = value.ToString();
            }        
        }
        public bool closed
        {
            get { return _closed; }
            set { _closed = value; }
        }
        public string empId
        {
            get { return _empId; }
            set { _empId = value; }
        }

        //delegate
        
        #endregion

        public MoneyCalWindow()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void OK_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //validation, check if customer give enough money
            if (this.backMoneyTxtBlock.Text == "-" || int.Parse(this.backMoneyTxtBlock.Text) < 0)
            {
                MessageBox.Show("Khách hàng chưa thanh toán đủ");
                return;
            }
            //set parameter for new bill
            CashierController.KFCService.BillDTO billDto = new CashierController.KFCService.BillDTO();
            billDto.BillID = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            billDto.OrderID = this.orderId;
            billDto.EmpID = this.empId;
            billDto.Total = this.orderTotal;
            billDto.BillStatus = 2;
            billDto.BillDate = DateTime.Now;
            billDto.BillID = this.orderId;
            BillCTL billCtl = new BillCTL();
            billCtl.add(billDto);

            this.closed = false;
            this.Close();
        }

        private void givenMoneyTxtBlock_TextChanged(object sender, TextChangedEventArgs e)
        {
            foreach (Char c in this.givenMoneyTxtBlock.Text)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    this.backMoneyTxtBlock.Text = "-";
                    return;
                }
            }
            this.backMoneyTxtBlock.Text = (int.Parse(this.givenMoneyTxtBlock.Text) - this.orderTotal).ToString();
        }

        private void OK_TouchEnter(object sender, TouchEventArgs e)
        {
            //validation, check if customer give enough money
            if (this.backMoneyTxtBlock.Text == "-" || int.Parse(this.backMoneyTxtBlock.Text) < 0)
            {
                MessageBox.Show("Khách hàng chưa thanh toán đủ");
                return;
            }
            //set parameter for new bill
            CashierController.KFCService.BillDTO billDto = new CashierController.KFCService.BillDTO();
            billDto.BillID = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Year.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
            billDto.OrderID = this.orderId;
            billDto.EmpID = this.empId;
            billDto.Total = this.orderTotal;
            billDto.BillStatus = 2;
            billDto.BillDate = DateTime.Now;
            billDto.BillID = this.orderId;
            BillCTL billCtl = new BillCTL();
            billCtl.add(billDto);

            this.closed = false;
            this.Close();
        }
	}
}