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
	/// Interaction logic for EditFoodWindow.xaml
	/// </summary>
	public partial class EditFoodWindow : Window
    {
        #region Attribute
        private FoodDTO _fooDto = new FoodDTO();
        private FoodCTL foodCtl = new FoodCTL();
        private FoodGroupDTO[] _foodGroup;
        private bool _isClosed = true;
        private bool _isChanged = false;

        public FoodDTO foodDto
        {
            get { return _fooDto; }
            set { _fooDto = value; }
        }
        public bool isClosed
        {
            get { return _isClosed; }
            set { _isClosed = value; }
        }
        #endregion
        public EditFoodWindow()
		{
			this.InitializeComponent();
		
			// Insert code required on object creation below this point.            
		}

        private void Button_Click(object sender, RoutedEventArgs e)
        {   //CHANGE HERE FOR IMAGE FILE EXTENSION
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.Filter = "Image File|*.jpeg";
            dlg.Title = "Choose Image File";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.imageTxtBox.Text = dlg.FileName;
            }
        }

        private void OK_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //check if information is changed
            if (!this._isChanged)
            {
                this.Close();
                return;
            }
            //validation
            FoodDTO foodDto = new FoodDTO();
            if (string.IsNullOrEmpty(this.foodNameTxtBox.Text) || string.IsNullOrWhiteSpace(this.foodNameTxtBox.Text))
            {
                MessageBox.Show("Tên món ăn nhập sai. Mời bạn nhập lại");
                return;
            }

            if (string.IsNullOrWhiteSpace(this.foodPriceTxtBox.Text) || string.IsNullOrEmpty(this.foodPriceTxtBox.Text))
            {
                goto WRONGNUMBER;
            }
            else
            {
                for (int i = 0; i < this.foodPriceTxtBox.Text.Length; i++)
                {
                    if (!(this.foodPriceTxtBox.Text[i] == '.' || (this.foodPriceTxtBox.Text[i] >= '0' && this.foodPriceTxtBox.Text[i] <= '9')))
                    {
                        goto WRONGNUMBER;
                    }
                }
                string[] numPoint = this.foodPriceTxtBox.Text.Split('.');
                if (numPoint.Length > 1)
                    goto WRONGNUMBER;
            }
            if (!(string.IsNullOrEmpty(this.discountPriceTxtBox.Text) || string.IsNullOrWhiteSpace(this.discountPriceTxtBox.Text)))
            {
                for (int i = 0; i < this.discountPriceTxtBox.Text.Length; i++)
                {
                    if (!(this.discountPriceTxtBox.Text[i] == '.' || (this.discountPriceTxtBox.Text[i] >= '0' && this.discountPriceTxtBox.Text[i] <= '9')))
                        goto WRONGNUMBER;
                }
                string[] numPoint = this.discountPriceTxtBox.Text.Split('.');
                if (numPoint.Length > 1)
                    goto WRONGNUMBER;
            }

            //get info and add to database
            foodDto.FoodName = this.foodNameTxtBox.Text;
            foodDto.FoodPrice = int.Parse(this.foodPriceTxtBox.Text);
            foodDto.DiscountPrice = int.Parse(this.discountPriceTxtBox.Text);
            foodDto.FoodGroupID = this._foodGroup[this.foodGroupCmbBox.SelectedIndex].FoodGroupID;
            foodDto.Image = this.imageTxtBox.Text;
            foodDto.Description = this.descriptionTxtBox.Text;

            try
            {
                FoodCTL foodCtl = new FoodCTL();
                foodCtl.update(foodDto,foodDto);
                this.isClosed = false;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        WRONGNUMBER: MessageBox.Show("Thông tin giá nhập sai. Mời bạn nhập lại");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //get data from dto
            this.foodNameTxtBox.Text = foodDto.FoodName;
            this.foodPriceTxtBox.Text = foodDto.FoodPrice.ToString();
            this.discountPriceTxtBox.Text = foodDto.DiscountPrice.ToString();
            this.imageTxtBox.Text = foodDto.Image;
            this.descriptionTxtBox.Text = foodDto.Description;
            this._foodGroup = foodCtl.getAllFoodGroup();            
            for (int i = 0; i < this._foodGroup.Length; i++)
            {
                this.foodGroupCmbBox.Items.Add(this._foodGroup[0].FoodGroupName);
                if (this._foodGroup[i].FoodGroupID == foodDto.FoodGroupID)
                {
                    this.foodGroupCmbBox.SelectedIndex = i;
                }              
             }           
        }

        private void foodNameTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this._isChanged = true;
        }

        private void foodGroupCmbBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this._isChanged = true;
        }

        private void foodPriceTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this._isChanged = true;
        }

        private void discountPriceTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this._isChanged = true;
        }

        private void imageTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this._isChanged = true;
        }

        private void descriptionTxtBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            this._isChanged = true;
        }
	}
}