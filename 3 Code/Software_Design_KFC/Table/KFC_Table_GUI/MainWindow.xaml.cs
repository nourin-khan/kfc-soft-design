using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace KFC_Table_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int FOOD_NUMBER = 9;
        private List<UserControlFood> chickens;
        private List<UserControlFood> hamburgers;
        private List<UserControlFood> drinks;

        public MainWindow()
        {
            this.InitializeComponent();

            chicken1.ChooseFoodclick += new UserControlFood.ControlClick(chicken1_ChooseFoodclick);
            chicken2.ChooseFoodclick += new UserControlFood.ControlClick(chicken2_ChooseFoodclick);
            chicken3.ChooseFoodclick += new UserControlFood.ControlClick(chicken3_ChooseFoodclick);
            chicken4.ChooseFoodclick += new UserControlFood.ControlClick(chicken4_ChooseFoodclick);
            chicken5.ChooseFoodclick += new UserControlFood.ControlClick(chicken5_ChooseFoodclick);
            chicken6.ChooseFoodclick += new UserControlFood.ControlClick(chicken6_ChooseFoodclick);
            chicken7.ChooseFoodclick += new UserControlFood.ControlClick(chicken7_ChooseFoodclick);
            chicken8.ChooseFoodclick += new UserControlFood.ControlClick(chicken8_ChooseFoodclick);
            chicken9.ChooseFoodclick += new UserControlFood.ControlClick(chicken9_ChooseFoodclick);

        }        
    }
}