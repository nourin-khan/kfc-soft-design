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
	/// Interaction logic for BillDetailWindow.xaml
	/// </summary>
	public partial class BillDetailWindow : Window
	{
        #region  Attribute
        OrderCTL orderCtl = new OrderCTL();
        private int _tableNum;
        private string _orderId;
        private List<OrderFoodDTO> _foodList;
        private string _empId;
        private bool _isCashed = false;
        private bool _isDeleted = false;

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
        public string empId
        {
            get { return _empId; }
            set { _empId = value; }
        }
        public bool isCashed
        {
            get { return _isCashed; }
            set { _isCashed = value; }
        }
        public bool isDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
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
            OrderDTO orderDto = orderCtl.viewOrderInfo(tableNum);
            this.orderId = orderDto.OrderID;
            orderDateDtPicker.DisplayDate = orderDto.OrderDate;
            if (orderDto.OrderStatus == 1)
            {
                orderStatusTxtBlock.Text = "Đã xác nhận";
            }
            else
                orderStatusTxtBlock.Text = "Chưa xác nhận";

            //get food detail of order, note here: quantity in foodlist is the quantity customer orders
            _foodList = orderCtl.viewFoodDetail(orderId);
            FoodGridView.ItemsSource = _foodList;
            FormatFoodGridView();

		}

        private void FormatFoodGridView()
        {
            if (this.FoodGridView.Columns.Count != 0)
            {
                this.FoodGridView.Columns[0].Visibility = Visibility.Hidden;
                this.FoodGridView.Columns[1].DisplayIndex = 5; //discountPrice
                this.FoodGridView.Columns[1].Header = "GIẢM             ";
                this.FoodGridView.Columns[2].Header = "MÃ MÓN ĂN        "; //foodID
                this.FoodGridView.Columns[3].Header = "TÊN MÓN ĂN                       "; //foodName
                this.FoodGridView.Columns[4].Header = "GIÁ GỐC          "; //foodPrice
                this.FoodGridView.Columns[5].Header = "SỐ LƯỢNG         "; //quantity
                this.FoodGridView.Columns[5].DisplayIndex = 3;
            }
        }
        #endregion

        #region Eventhandler
        private void cashBut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            MoneyCalWindow moneyCal = new MoneyCalWindow();
            moneyCal.orderTotal = orderCtl.getOrderTotal(orderId);
            moneyCal.empId = this.empId;
            moneyCal.ShowDialog();
            if (!moneyCal.closed)
            {
                this._isCashed = true;
                this.Close();
            }

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
                OrderFoodDTO foodItem = new OrderFoodDTO();
                foodItem.FoodID = addWindow.selectedFood.FoodID;
                foodItem.FoodName = addWindow.selectedFood.FoodName;
                foodItem.quantity = addWindow.quantity;
                foodItem.FoodPrice = int.Parse(addWindow.selectedFood.FoodPrice.ToString());
                foodItem.DiscountPrice = int.Parse(addWindow.selectedFood.DiscountPrice.ToString()) ;
                _foodList.Add(foodItem);
                this.FoodGridView.ItemsSource = null;
                this.FoodGridView.ItemsSource = _foodList;
                FormatFoodGridView();
                this.FoodGridView.UpdateLayout();
                //this.FoodGridView.Items.Add(foodItem);// thu nghiem
                //DataContext = _foodList;
                //FoodGridView.Columns[0].Visibility = Visibility.Hidden;
            }
        }

        private void deleteBut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (FoodGridView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Mời bạn chọn thức ăn muốn xóa trước");
                return;
            }            

            System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("Bạn có chắc muốn xóa món ăn này", "", System.Windows.Forms.MessageBoxButtons.OKCancel);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                OrderDetailCTL ordDetailCtl = new OrderDetailCTL();
                for (int i = 0; i < this.FoodGridView.SelectedItems.Count; i++)
                {
                    OrderFoodDTO item = (OrderFoodDTO)this.FoodGridView.SelectedItems[i];
                    //delete in db
                    ordDetailCtl.delete(this.orderId, item.FoodID);

                    //find and remove in _foodList
                    int index = this._foodList.FindIndex(
                        delegate(OrderFoodDTO dto)
                        {
                            OrderFoodDTO ordFood = (OrderFoodDTO)this.FoodGridView.SelectedItems[i];
                            return dto.FoodID == ordFood.FoodID;
                        }
                        );
                    this._foodList.RemoveAt(index);
                }
                this.FoodGridView.ItemsSource = null;
                this.FoodGridView.ItemsSource = this._foodList;
                FormatFoodGridView();
                this.UpdateLayout();

                //huy lun don dat hang neu da xoa tat ca mon an
                if (this._foodList.Count == 0)
                {
                    System.Windows.Forms.DialogResult dr2 = System.Windows.Forms.MessageBox.Show("Bạn có muốn hủy luôn đơn đặt hàng ở bàn này?", "", System.Windows.Forms.MessageBoxButtons.OKCancel);
                    if (dr2 == System.Windows.Forms.DialogResult.OK)
                    {
                        this.orderCtl.delete(this.orderId);
                        this.isDeleted = true;
                    }
                }
            }
        }
        #endregion    
	}
}