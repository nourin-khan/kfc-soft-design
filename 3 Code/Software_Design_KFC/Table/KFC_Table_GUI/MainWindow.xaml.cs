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
        
        void chicken9_ChooseFoodclick()
        {
            UserControlFoodInCart cart = new UserControlFoodInCart();
            cart.FoodName = chicken9.FoodName;
            cart.FoodPrice = chicken9.FoodPrice;
            lstboxOrder.Items.Add(cart);
        }

        void chicken8_ChooseFoodclick()
        {
            UserControlFoodInCart cart = new UserControlFoodInCart();
            cart.FoodName = chicken8.FoodName;
            cart.FoodPrice = chicken8.FoodPrice;
            lstboxOrder.Items.Add(cart);
        }

        void chicken7_ChooseFoodclick()
        {
            UserControlFoodInCart cart = new UserControlFoodInCart();
            cart.FoodName = chicken7.FoodName;
            cart.FoodPrice = chicken7.FoodPrice;
            lstboxOrder.Items.Add(cart);
        }

        void chicken6_ChooseFoodclick()
        {
            UserControlFoodInCart cart = new UserControlFoodInCart();
            cart.FoodName = chicken6.FoodName;
            cart.FoodPrice = chicken6.FoodPrice;
            lstboxOrder.Items.Add(cart);
        }

        void chicken5_ChooseFoodclick()
        {
            UserControlFoodInCart cart = new UserControlFoodInCart();
            cart.FoodName = chicken5.FoodName;
            cart.FoodPrice = chicken5.FoodPrice;
            lstboxOrder.Items.Add(cart);
        }

        void chicken4_ChooseFoodclick()
        {
            UserControlFoodInCart cart = new UserControlFoodInCart();
            cart.FoodName = chicken4.FoodName;
            cart.FoodPrice = chicken4.FoodPrice;
            lstboxOrder.Items.Add(cart);
        }

        void chicken3_ChooseFoodclick()
        {
            UserControlFoodInCart cart = new UserControlFoodInCart();
            cart.FoodName = chicken3.FoodName;
            cart.FoodPrice = chicken3.FoodPrice;
            lstboxOrder.Items.Add(cart);
        }

        void chicken2_ChooseFoodclick()
        {
            UserControlFoodInCart cart = new UserControlFoodInCart();
            cart.FoodName = chicken2.FoodName;
            cart.FoodPrice = chicken2.FoodPrice;
            lstboxOrder.Items.Add(cart);            
        }

        void chicken1_ChooseFoodclick()
        {
            UserControlFoodInCart cart = new UserControlFoodInCart();
            cart.FoodName = chicken1.FoodName;
            cart.FoodPrice = chicken1.FoodPrice;
            lstboxOrder.Items.Add(cart);
        }

		private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
            statusItems.SelectedIndex = 0;

            chickens = new List<UserControlFood>();
            chickens.Add(chicken1);
            chickens.Add(chicken2);
            chickens.Add(chicken3);
            chickens.Add(chicken4);
            chickens.Add(chicken5);
            chickens.Add(chicken6);
            chickens.Add(chicken7);
            chickens.Add(chicken8);
            chickens.Add(chicken9);

            hamburgers = new List<UserControlFood>();
            hamburgers.Add(hamburger1);
            hamburgers.Add(hamburger2);
            hamburgers.Add(hamburger3);
            hamburgers.Add(hamburger4);
            hamburgers.Add(hamburger5);
            hamburgers.Add(hamburger6);
            hamburgers.Add(hamburger7);
            hamburgers.Add(hamburger8);
            hamburgers.Add(hamburger9);

            drinks = new List<UserControlFood>();
            drinks.Add(drink1);
            drinks.Add(drink2);
            drinks.Add(drink3);
            drinks.Add(drink4);
            drinks.Add(drink5);
            drinks.Add(drink6);
            drinks.Add(drink7);
            drinks.Add(drink8);
            drinks.Add(drink9);
		}

		private void iconRight_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            foreach (UserControlFood f in chickens) {
                BitmapImage i = new BitmapImage(new Uri(@"D:\temp\KFC_Table_GUI\KFC_Table_GUI\Images\Chicken\large-garan05.png"));
                f.image.Source = i;
            }
		}

		private void iconLeft_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            foreach (UserControlFood f in chickens)
            {
                BitmapImage i = new BitmapImage(new Uri(@"D:\temp\KFC_Table_GUI\KFC_Table_GUI\Images\Chicken\large-garan01.png"));
                f.image.Source = i;
            }
		}

		private void chicken_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            foreach (UserControlFood f in chickens)
            {
                BitmapImage i = new BitmapImage(new Uri(@"D:\temp\KFC_Table_GUI\KFC_Table_GUI\Images\Chicken\large-garan01.png"));
                f.image.Source = i;
            }
		}

		private void hamburger_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            foreach (UserControlFood h in hamburgers)
            {
                BitmapImage i = new BitmapImage(new Uri(@"D:\temp\KFC_Table_GUI\KFC_Table_GUI\Images\Hamburger\Bogo-Hai-San-large.png"));
                h.image.Source = i;
            }
		}

		private void drink_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            foreach (UserControlFood d in drinks)
            {
                BitmapImage i = new BitmapImage(new Uri(@"D:\temp\KFC_Table_GUI\KFC_Table_GUI\Images\Drink\Ly-Pepsi-(L)-large.png"));
                d.image.Source = i;
            }
		}
	
		private void btnOrder_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            lstboxKitchen.Items.Clear();
            foreach (UserControlFoodInCart item in lstboxOrder.Items)
            {
                UserControlFoodInKitchen foodInKitchen = new UserControlFoodInKitchen();
                foodInKitchen.FoodName = item.FoodName;
                lstboxKitchen.Items.Add(foodInKitchen);
            }
		}

		private void btnCancelOrder_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            lstboxOrder.Items.Clear();
		}		
	}
}