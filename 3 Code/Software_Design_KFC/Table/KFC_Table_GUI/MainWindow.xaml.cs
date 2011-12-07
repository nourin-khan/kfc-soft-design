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
		private List<foodControl> chickens;
        private List<foodControl> hamburgers;
        private List<foodControl> drinks;

		public MainWindow()
		{
			this.InitializeComponent();
		}

		private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
		{
            statusItems.SelectedIndex = 0;

            chickens = new List<foodControl>();
            chickens.Add(chicken1);
            chickens.Add(chicken2);
            chickens.Add(chicken3);
            chickens.Add(chicken4);
            chickens.Add(chicken5);
            chickens.Add(chicken6);
            chickens.Add(chicken7);
            chickens.Add(chicken8);
            chickens.Add(chicken9);

            hamburgers = new List<foodControl>();
            hamburgers.Add(hamburger1);
            hamburgers.Add(hamburger2);
            hamburgers.Add(hamburger3);
            hamburgers.Add(hamburger4);
            hamburgers.Add(hamburger5);
            hamburgers.Add(hamburger6);
            hamburgers.Add(hamburger7);
            hamburgers.Add(hamburger8);
            hamburgers.Add(hamburger9);

            drinks = new List<foodControl>();
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
            foreach (foodControl f in chickens) {
                BitmapImage i = new BitmapImage(new Uri(@"D:\temp\KFC_Table_GUI\KFC_Table_GUI\Images\Chicken\large-garan05.png"));
                f.image.Source = i;
            }
		}

		private void iconLeft_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            foreach (foodControl f in chickens)
            {
                BitmapImage i = new BitmapImage(new Uri(@"D:\temp\KFC_Table_GUI\KFC_Table_GUI\Images\Chicken\large-garan01.png"));
                f.image.Source = i;
            }
		}

		private void chicken_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            foreach (foodControl f in chickens)
            {
                BitmapImage i = new BitmapImage(new Uri(@"D:\temp\KFC_Table_GUI\KFC_Table_GUI\Images\Chicken\large-garan01.png"));
                f.image.Source = i;
            }
		}

		private void hamburger_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            foreach (foodControl h in hamburgers)
            {
                BitmapImage i = new BitmapImage(new Uri(@"D:\temp\KFC_Table_GUI\KFC_Table_GUI\Images\Hamburger\Bogo-Hai-San-large.png"));
                h.image.Source = i;
            }
		}

		private void drink_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
		{
            foreach (foodControl d in drinks)
            {
                BitmapImage i = new BitmapImage(new Uri(@"D:\temp\KFC_Table_GUI\KFC_Table_GUI\Images\Drink\Ly-Pepsi-(L)-large.png"));
                d.image.Source = i;
            }
		}
	}
}