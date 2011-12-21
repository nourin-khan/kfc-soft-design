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
using TableDTO;
using System.Threading;
using System.Windows.Media.Animation;

namespace KFC_Table_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Attributes
        private const int FOOD_NUMBER = 9;
        private List<UserControlFood> foods;        
        #endregion        

        #region Controller
        FoodCTL foodCtrl;
        OrderCTL orderCtrl;
        #endregion

        public MainWindow()
        {
            this.InitializeComponent();
            foodCtrl = new FoodCTL();
            orderCtrl = new OrderCTL();
        }

        #region Events Handle
		private void Window_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            #region OldRegion
            statusItems.SelectedIndex = 0;

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

            FoodDTO[] foodList = foodCtrl.getFoodGroup("chicken");
            if (foodList == null)
            {
                return;
            }
            int idx = 0;
            while (idx < foods.Count)
            {
                foods[idx].FoodName = foodList[idx].FoodName;
                foods[idx].FoodPrice = foodList[idx].FoodPrice.ToString();
                foods[idx].FoodDetails = foodList[idx].FoodDescription + "\nGia : " + foodList[idx].FoodPrice.ToString();
                foods[idx].FoodImageSource = new BitmapImage(new Uri(foodList[idx].FoodImageSource));
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
            orderInfo.OrderTime = DateTime.Now;
            orderInfo.OrderStatus = OrderStatus.UNCONFIRMED;
            orderInfo.OrderNote = null;
            orderInfo.TableNum = ConfigurationCTL.TableNum;
            // order id is complexity string that's include table No. and datetime.now
            orderInfo.OrderID = ConfigurationCTL.TableNum + orderInfo.OrderTime.ToString();

            foreach (UserControlFoodInCart item in lstboxOrder.Items)
            {
                OrderDetailDTO info = new OrderDetailDTO();
                info.CompleteTime = DateTime.Now;
                info.Quantity = item.FoodCount;
                info.FoodID = item.FoodID;
                info.FoodNote = string.Empty;
                info.OrderID = orderInfo.OrderID;
                orderInfo.FoodList.Add(info);

                UserControlFoodInKitchen foodInKitchen = new UserControlFoodInKitchen();
                foodInKitchen.image.Source = item.image.Source;
                foodInKitchen.FoodName = item.FoodName;
                lstboxKitchen.Items.Add(foodInKitchen);
            }

            // add new order using order controller
            orderCtrl.add(orderInfo);
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
 
	    #endregion    
    }
}