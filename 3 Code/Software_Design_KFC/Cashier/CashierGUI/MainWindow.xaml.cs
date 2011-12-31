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
        #region Attribute

        OrderCTL orderCtl = new OrderCTL();
        static int tableQtyOnFloor = 15;
        static int floorQty = 3;
        TableStatus[,] tableBitmap = new TableStatus[floorQty, tableQtyOnFloor];       //false when free

        #endregion
        public MainWindow()
        {
            InitializeComponent();


            //set initialized status  for tableBitMap (free status)
            for (int i = 0; i < floorQty; i++)
                for (int j = 0; j < tableQtyOnFloor; j++)
                    tableBitmap[i, j] = TableStatus.FREE;

            //test
            TableUsc table = (TableUsc)FloorWrappnl.Children[0];
        }

        #region Initialization method
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
            for (int i = 0; i < tableQtyOnFloor; i++)
            {
                TableUsc table = (TableUsc)FloorWrappnl.Children[i];
                table.tableNum = floorNum * 100 + i + 1;
                
                switch(tableBitmap[floorNum -1, i])
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {            
            for (int i = 0; i < floorQty; i++)
            {
                //search for unfree table in db to reset status
                OrderDTO[] unfreeTables = orderCtl.getUnfreeTable(i + 1);                
               
                if (unfreeTables != null)
                {
                    for (int k = 0; k < unfreeTables.Length; k++)
                    {
                        tableBitmap[i, unfreeTables[k].TableNum % 100] = TableStatus.UNFREE;
                    }
                }
            }
            showTableOnFloor(1);

        }



        //cac chuc nang - tab 1
        //dang nhap, dang xuat

        //hien thi chi tiet mon an

        //nhan thong tin yeu cau tinh tien => sua doi controller lai

        //thanh toan, tinh tien 

    }
}
