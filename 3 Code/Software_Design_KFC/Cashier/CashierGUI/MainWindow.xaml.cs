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
using CashierDTO;

namespace CashierGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attribute


        static int tableQtyOnFloor = 15;
        static int floorQty = 3;
        bool[,] tableBitmap = new bool[floorQty, tableQtyOnFloor];       //false when free

        #endregion
        public MainWindow()
        {
            InitializeComponent();

            //get Bill status and set status for table
            for (int i = 0; i < floorQty; i++)
                for (int j = 0; j < tableQtyOnFloor; j++)
                    tableBitmap[i,j] = false;

            //test
            TableUsc table = (TableUsc)FloorWrappnl.Children[0];
        }

        #region Initialization method
        #endregion

        #region Event
        private void Floor1SelBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            showTableInFloor(0);

            //test
            TableUsc table =(TableUsc) FloorWrappnl.Children[0];
            table.paid = payment.NOPRINTEDBILL;

            table = (TableUsc)FloorWrappnl.Children[1];
            table.paid = payment.UNPAID;

            table = (TableUsc)FloorWrappnl.Children[2];
            table.paid = payment.PRINTEDBILL;

            //////////////////////////////////////////////////////////////////////////
        }

        private void Floor2SelBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            showTableInFloor(1);
        }

        private void Floor3SelBox_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            showTableInFloor(2);
        }
        #endregion


        #region EventHandler

        //Event: FloornSelBox_MouseLeftDownButton
        //show tableUSC (free or not) when selecting floor
        public void showTableInFloor(int floorNum)
        {
            for (int j = 0; j < tableQtyOnFloor; j++)
            {
                TableUsc table = (TableUsc)FloorWrappnl.Children[j];
                if (tableBitmap[floorNum,j])
                {
                    table.free = false;
                }
            }
        }
        #endregion



        //cac chuc nang - tab 1
        //dang nhap, dang xuat

        //hien thi chi tiet mon an

        //nhan thong tin yeu cau tinh tien => sua doi controller lai

        //thanh toan, tinh tien 

    }
}
