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

namespace CashierGUI
{
	/// <summary>
	/// Interaction logic for TableUsc.xaml
	/// </summary>
    
	public partial class TableUsc : UserControl
    {
        #region Attribute
        private bool _free = true;  // free: no customer
        private bool _printedBill = false; //payment flag: paid bill
        private int _tableNum = 101; //table number
        private string _empId;
		
		public bool free
		{
			get {return _free;}
			set 
			{
                _free = value;
                if (value == false)
                {
                    this.freeLbl.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.freeLbl.Visibility = Visibility.Visible;
                }
			}
		}
        public bool printedBill
        {
            get { return _printedBill; }
            set 
            {
                _printedBill = value;
                if(_printedBill)
                {
                    paymentMessage.Text = "In hóa đơn";
                    paymentCallOut.Visibility = Visibility.Visible;
                }
                else
                {
                    paymentMessage.Text = "Không hóa đơn";
                    paymentCallOut.Visibility = Visibility.Visible;                        
                }
            }
        }
        public int tableNum
        {
            get { return _tableNum; }
            set 
            {
                _tableNum = value;
                this.TableNumLbl.Content = "BÀN " + _tableNum.ToString();
            }
        }
        public string empId
        {
            get { return _empId; }
            set { _empId = value; }
        }

        #endregion
        public TableUsc()
		{
			this.InitializeComponent();
		}

        private void UserControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (this.free != true) //note here, != true (changes for test and coding)
            {
                BillDetailWindow billDetail = new BillDetailWindow();
                billDetail.tableNum = this.tableNum;
                billDetail.empId = this.empId;
                billDetail.ShowDialog();
                if (billDetail.isCashed || billDetail.isDeleted)
                {
                    this.free = true;
                }
            }
            else
            {
                MessageBox.Show("Bàn trống chưa có thông tin");
            }
            
        }
	}
}