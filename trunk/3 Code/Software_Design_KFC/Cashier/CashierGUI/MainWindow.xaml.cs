using System;
using System.Collections.Generic;
using System.Linq;
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
using CashierController;
using CashierController.KFCService;
using System.Data;

namespace CashierGUI
{
    enum TableStatus
    {
        FREE =0,
        UNFREE = 1,
        PRINTEDBILL = 2,
        NOPRINTEDBILL = 3
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Initialization

        #region Attribute
        private string _empId;
        private bool _isManagerFuncEnabled = true;
        
        public string empId
        {
            get { return _empId; }
            set { _empId = value; }
        }
        public bool isManagerFuncEnabled
        {
            get { return _isManagerFuncEnabled; }
            set
            {
                _isManagerFuncEnabled = value;
                if (!_isManagerFuncEnabled)
                {
                    this.Add.Opacity = 0.5;
                    this.Delete.Opacity = 0.5;
                    this.Edit.Opacity = 0.5;
                    this.Report.Opacity = 0.5;
                    this.Add_MouseEnter.IsEnabled = false;
                    this.Add_MouseLeave.IsEnabled = false;
                    this.Delete_MouseEnter.IsEnabled = false;
                    this.Delete_MouseLeave.IsEnabled = false;
                    this.Save_MouseEnter.IsEnabled = false;
                    this.Save_MouseLeave.IsEnabled = false;
                    this.Report_MouseEnter.IsEnabled = false;
                    this.Report_MouseLeave.IsEnabled = false;
                }
            }
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            //set initialized status  for tableBitMap (free status)
            //for (int i = 0; i < _floorQty; i++)
            //{
            //    for (int j = 0; j < _tableQtyOnFloor; j++)
            //        _tableBitmap[i, j] = TableStatus.FREE;
            //}
            for (int i = 0; i < _tableQtyOnFloor; i++)
            {
                TableUsc table = (TableUsc)FloorWrappnl.Children[i];
                table.empId = this.empId;
                for (int j = 0; j < _floorQty; j++)
                    _tableBitmap[j, i] = TableStatus.FREE;
            }
            this.isManagerFuncEnabled = false;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < _floorQty; i++)
            {
                //search for unfree table in db to reset status
                OrderDTO[] unfreeTables = orderCtl.getUnfreeTable(i + 1);

                if (unfreeTables != null)
                {
                    for (int k = 0; k < unfreeTables.Length; k++)
                    {
                        _tableBitmap[i, unfreeTables[k].TableNum % 100] = TableStatus.UNFREE;
                    }
                }
            }
            showTableOnFloor(1);

            _foodList.AddRange(foodCtl.getAllFoodList());
            this.FoodGridView.ItemsSource = _foodList;          
        }
        #endregion

        #region Cash Tab
        #region Attribute

        private static int _tableQtyOnFloor = 15;
        private static int _floorQty = 3;
        OrderCTL orderCtl = new OrderCTL();
        private TableStatus[,] _tableBitmap = new TableStatus[_floorQty, _tableQtyOnFloor];       //false when free     

        
        #endregion                    

        #region Event
        private void Floor1SelBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            showTableOnFloor(1);            
        }

        private void Floor2SelBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            showTableOnFloor(2);
        }

        private void Floor3SelBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            showTableOnFloor(3);
        }
        #endregion

        #region EventHandler

        //Event: FloornSelBox_MouseLeftDownButton
        //show tableUSC (free or not) when selecting floor
        public void showTableOnFloor(int floorNum)
        {   
            //set number of table and status for all table
            for (int i = 0; i < _tableQtyOnFloor; i++)
            {
                TableUsc table = (TableUsc)FloorWrappnl.Children[i];
                table.tableNum = floorNum * 100 + i + 1;
                
                switch(_tableBitmap[floorNum -1, i])
                {
                    case TableStatus.FREE: 
                        table.free = true;
                        break;
                    case TableStatus.UNFREE:
                        table.free = false;
                        break;
                    case TableStatus.PRINTEDBILL:
                        table.printedBill = true;
                        break;
                    case TableStatus.NOPRINTEDBILL:
                        table.printedBill = false;
                        break;
                }
            }            
        }
        #endregion   

        private void SignoutTxtBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {            
            LogInForm login = new LogInForm();
            login.Show();
            this.Close();
        }
        #endregion     
       
   
        #region FoodTab

        #region Attribute
        private FoodCTL foodCtl = new FoodCTL();
        private List<FoodDTO> _foodList = new List<FoodDTO>();
        #endregion
        private void Add_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AddFoodWindow foodWin = new AddFoodWindow();
            foodWin.ShowDialog();
            if (foodWin.isClosed == true)
                return;
            this._foodList.Add(foodWin.foodDto);
        }
        #endregion

        private void TabFood_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            this.FoodGridView.Columns[0].Visibility = Visibility.Hidden;
            this.FoodGridView.Columns[4].DisplayIndex = 0; //foodID
            this.FoodGridView.Columns[5].DisplayIndex = 1; //foodName
            this.FoodGridView.Columns[6].DisplayIndex = 2; //foodPrice
            this.FoodGridView.Columns[2].DisplayIndex = 3; //discountPrice
            this.FoodGridView.Columns[1].DisplayIndex = 4; //description
            this.FoodGridView.Columns[3].DisplayIndex = 5; //foodGroupID
            this.FoodGridView.Columns[7].DisplayIndex = 6; //imagePath 
        }

        private void Delete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.FoodGridView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Mời bạn chón món ăn cần xóa trước");
                return;
            }
            System.Windows.Forms.DialogResult dr = System.Windows.Forms.MessageBox.Show("Bạn có chắc muốn xóa món ăn này", "", System.Windows.Forms.MessageBoxButtons.OKCancel);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                for (int i = 0; i < this.FoodGridView.SelectedItems.Count; i++)
                {
                    FoodDTO item = (FoodDTO)this.FoodGridView.SelectedItems[i];
                    foodCtl.delete(item.FoodID);
                    int index = this._foodList.FindIndex(
                        delegate(FoodDTO dto)
                        {
                            FoodDTO food = (FoodDTO)this.FoodGridView.SelectedItems[i];
                            return dto.FoodID == food.FoodID;
                        }
                        );
                    this._foodList.RemoveAt(index);
                    this.FoodGridView.ItemsSource = this._foodList;
                    this.UpdateLayout();
                }
            }
                        
        }

        private void Edit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (this.FoodGridView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Mời bạn chọn món ăn muốn sửa đổi");
                return;
            }
            EditFoodWindow editWind = new EditFoodWindow();
            editWind.foodDto = (FoodDTO)this.FoodGridView.SelectedItem;
            editWind.ShowDialog();
            if (!editWind.isClosed)
            {
                int index = this._foodList.FindIndex(delegate(FoodDTO dto) { return dto.FoodID == editWind.foodDto.FoodID;  });
                this._foodList[index] = editWind.foodDto;
                this.FoodGridView.UpdateLayout();
            }
        }

        private void Report_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DailyReport rptCtl = new DailyReport();
            DateTime date = DateTime.Parse("9/18/2011");
            int total = rptCtl.getTotalOfDay(date);
            MessageBox.Show(total.ToString());
            //DataTable data = rptCtl.getDailyReport(date);
            //this.ReportGridView.DataContext = data;
        }

    }
}
