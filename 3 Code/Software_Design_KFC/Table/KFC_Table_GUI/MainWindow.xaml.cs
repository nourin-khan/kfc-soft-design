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
using TableController;
using TableController.KfcService;
using System.Threading;
using System.Windows.Media.Animation;
using System.Collections;

namespace KFC_Table_GUI
{
    class MyCommand : ICommand
    {
        public delegate void Refresh();
        public event Refresh ReloadAll;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {            
            ReloadAll();
        }
    }

    public partial class MainWindow : Window
    {
        private MyCommand configureCommand;
        private static int foodIndex;
        private int foodTotal;
        private FoodDTO[] foodList;
        
        #region Attributes
        private const int FOOD_NUMBER = 9;
        private List<UserControlFood> foods;
        private string imagesFolder;
        #endregion        

        #region Controller
        FoodCTL foodCtrl;
        OrderCTL orderCtrl;
        ConnectionCTL connectionCtrl;
        #endregion

        public MainWindow()
        {
            this.InitializeComponent();

            // register Ctrl + Shift + C for configuration
            // Bind key
            configureCommand = new MyCommand();
            configureCommand.ReloadAll += new MyCommand.Refresh(configureCommand_ReloadAll);
            InputBinding ib = new InputBinding(configureCommand, new KeyGesture(Key.C, ModifierKeys.Control | ModifierKeys.Shift));
            this.InputBindings.Add(ib);
     
            // initialize food index
            foodIndex = 0;

            // controller
            foodCtrl = new FoodCTL();
            orderCtrl = new OrderCTL();
            connectionCtrl = new ConnectionCTL();
        }

        void configureCommand_ReloadAll()
        {
            ConfigureForm configure = new ConfigureForm();
            configure.ShowDialog();
            getAllFood();
        }

        #region Events Handle
		private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            // initialize some control
            navigate_left.Opacity = 0;

            statusItems.SelectedIndex = 0;

            #region Initialzing food control
            foods = new List<UserControlFood>();
            foods.Add(chicken1);
            foods.Add(chicken2);
            foods.Add(chicken3);
            foods.Add(chicken4);
            foods.Add(chicken5);
            foods.Add(chicken6);
            foods.Add(chicken7);
            foods.Add(chicken8);
            foods.Add(chicken9);

            foreach (UserControlFood food in foods)
            {
                food.FoodFocus += new UserControlFood.ControlFocus(focusFood);
                food.ChooseFoodclick += new UserControlFood.ControlClick(food_ChooseFoodclick);
            }  
            #endregion
            
            // join to server
            try
            {
                connectionCtrl.join();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Can't join to server\n" + ex.ToString(), "Error");
            }
            // get all food
            getAllFood();
        }

        private void getAllFood()
        {
            // set config images directory path
            imagesFolder = string.IsNullOrWhiteSpace(ConfigurationCTL.ImagesFolder) ? @"D:\2011-2012\Software analysis and design\Group-work\Project_SVN\1 Document\Thao\KFC Database\Images" : ConfigurationCTL.ImagesFolder;
            // get all food
            try
            {
                foodList = foodCtrl.getFoodGroup();
                foodTotal = foodList.Count();
                if (foodList == null)
                {
                    return;
                }
                // set food index with zero
                foodIndex = 0;
                int idx = 0;
                while (idx < FOOD_NUMBER)
                {
                    foods[idx].FoodName = foodList[idx].FoodName;
                    foods[idx].FoodPrice = foodList[idx].FoodPrice.ToString();
                    foods[idx].FoodDetails = foodList[idx].Description + "\nGiá : " + foodList[idx].FoodPrice.ToString();
                    foods[idx].FoodImageSource = new BitmapImage(new Uri(imagesFolder + foodList[idx].Image));
                    idx++;
                    foodIndex++;
                }
            }
            catch
            {
                MessageBox.Show("Server connection failed or Images directory is invalid.", "Error");
            }
        }

        void focusFood(UserControlFood food)
        {
            this.gridChicken.Opacity = 0.2;
            
            UserControlFoodInFocus focus = new UserControlFoodInFocus();
            focus.Image.Source = food.image.Source;
            focus.Details = food.FoodDetails;
            focus.ShowDialog();
            this.gridChicken.Opacity = 1;
            if (focus.IsAddToCart)
            {
                // add this food to cart
                UserControlFoodInCart f = new UserControlFoodInCart();
                f.RemoveFromCart += new UserControlFoodInCart.RemoveFromCartHandler(cart_RemoveFromCart);
                f.image.Source = food.image.Source;
                f.FoodName = food.FoodName;
                f.FoodPrice = food.FoodPrice;

                foreach (UserControlFoodInCart item in lstboxOrder.Items)
                {
                    if (item.FoodName == f.FoodName)
                    {
                        item.FoodCount++;
                        return;
                    }
                }
                lstboxOrder.Items.Add(f);
            }
        }

        void food_ChooseFoodclick(UserControlFood food)
        {
            UserControlFoodInCart cart = new UserControlFoodInCart();
            cart.image.Source = food.image.Source;
            cart.FoodName = food.FoodName;
            cart.FoodPrice = food.FoodPrice;
            cart.RemoveFromCart += new UserControlFoodInCart.RemoveFromCartHandler(cart_RemoveFromCart);

            foreach (UserControlFoodInCart f in lstboxOrder.Items)
            {
                if (f.FoodName == cart.FoodName)
                {
                    f.FoodCount++;
                    return;
                }
            }
            lstboxOrder.Items.Add(cart);            
        }

        void cart_RemoveFromCart(UserControlFoodInCart foodInCart)
        {
            // if food count > 1 => count down
            if (foodInCart.FoodCount > 1)
            {
                foodInCart.FoodCount--;
            } 
            else // food count ==1 => remove from order list
            {
                lstboxOrder.Items.Remove(foodInCart);
            }
        }

        private void chicken_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void hamburger_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }

        private void drink_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
        }    

        private void btnCancelOrder_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            lstboxOrder.Items.Clear();
        }

        private void btnPayment_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            
        }

        private void btnOrder_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // confirmation
            UserControlConfirm confirm = new UserControlConfirm();
            confirm.DisplayText.Text = "Mời bạn xác nhận đặt món ăn !";
            confirm.ShowDialog();
            // animation
            Storyboard sb = btnOrder.FindResource("mouseLeftButtonUp") as Storyboard;
            btnOrder.BeginStoryboard(sb);
            // check confirm
            if (!confirm.IsConfirm)
            {
                return;
            }

            lstboxKitchen.Items.Clear();

            // create the order
            OrderDTO orderInfo = new OrderDTO();
            orderInfo.OrderDate = DateTime.Now;
            orderInfo.OrderStatus = OrderStatus.UNCONFIRMED;
            orderInfo.OrderNote = string.Empty;
            orderInfo.TableNum = ConfigurationCTL.TableNum;
            // order id is complexity string that's include table No. and datetime.now
            orderInfo.OrderID = ConfigurationCTL.TableNum + orderInfo.OrderDate.ToString();

            ArrayList orderDetail = new ArrayList();
            foreach (UserControlFoodInCart item in lstboxOrder.Items)
            {
                OrderDetailDTO info = new OrderDetailDTO();
                info.CompleteTime = DateTime.Now;
                info.Quantity = item.FoodCount;
                info.FoodID = item.FoodID;
                info.FoodNote = string.Empty;
                info.OrderID = orderInfo.OrderID;
                orderDetail.Add(info);

                UserControlFoodInKitchen foodInKitchen = new UserControlFoodInKitchen();
                foodInKitchen.image.Source = item.image.Source;
                foodInKitchen.FoodName = item.FoodName;
                lstboxKitchen.Items.Add(foodInKitchen);
            }

            try
            {
                // add new order using order controller
                orderCtrl.add(orderInfo, orderDetail);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void btnPayment_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // confirm bill printing
            UserControlConfirm confirm = new UserControlConfirm();
            confirm.DisplayText.Text = "Bạn có cần in hóa đơn không ?";
            confirm.ShowDialog();
            if (confirm.IsConfirm)
            {
                // handling
            }
        }

        private void navigate_left_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            naviagteLeft();
        }

        private void naviagteLeft()
        {
            for (int idx = FOOD_NUMBER - 1; idx >= 0; idx--)
            {
                if (foodIndex <= 0)
                {
                    foodIndex = foodTotal - 1;
                }

                foods[idx].FoodName = foodList[foodIndex].FoodName;
                foods[idx].FoodPrice = foodList[foodIndex].FoodPrice.ToString();
                foods[idx].FoodDetails = foodList[foodIndex].Description + "\nGiá : " + foodList[foodIndex].FoodPrice.ToString();
                foods[idx].FoodImageSource = new BitmapImage(new Uri(imagesFolder + foodList[foodIndex].Image));
                foodIndex--;                
            }
        }

        private void navigate_right_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // load
            naviagteRight();
        }

        private void naviagteRight()
        {
            for (int idx = 0; idx < FOOD_NUMBER; idx++ )
            {
                foods[idx].FoodName = foodList[foodIndex].FoodName;
                foods[idx].FoodPrice = foodList[foodIndex].FoodPrice.ToString();
                foods[idx].FoodDetails = foodList[foodIndex].Description + "\nGiá : " + foodList[foodIndex].FoodPrice.ToString();
                foods[idx].FoodImageSource = new BitmapImage(new Uri(imagesFolder + foodList[foodIndex].Image));
                foodIndex++;
                if (foodIndex >= foodTotal)
                {
                    foodIndex = 0;
                }
            }
        }
 
	    #endregion    
    }
}