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
using System.Drawing;
using CashierController;
using CashierController.KFCService;

namespace CashierGUI
{
	/// <summary>
	/// Interaction logic for AddFoodWindow.xaml
	/// </summary>
	public partial class AddFoodWindow : Window
    {
        #region Attribute
        private FoodCTL foodCTL = new FoodCTL();
        private FoodGroupDTO[] _foodGroup;
        private FoodDTO _foodDto = new FoodDTO();
        private bool _isClosed = true;

        public FoodDTO foodDto
        {
            get { return _foodDto; }
            set { _foodDto = value; }
        }
        public bool isClosed
        {
            get { return _isClosed; }
            set { _isClosed = value; }
        }
        #endregion
        public AddFoodWindow()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this._foodGroup = this.foodCTL.getAllFoodGroup();
            for (int i = 0; i < this._foodGroup.Length; i++)
            {
                this.foodGroupCmbBox.Items.Add(this._foodGroup[i].FoodGroupName);
            }
            this.foodGroupCmbBox.SelectedIndex = 0;
            this.discountPriceTxtBox.Text = "0";
        }

        private void OK_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {            
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
                if (numPoint.Length > 2)
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
                if (numPoint.Length > 2)
                    goto WRONGNUMBER;
            }

            //discountPrice > foodPrice
            if (int.Parse(this.foodPriceTxtBox.Text) < int.Parse(this.discountPriceTxtBox.Text))
            {
                goto WRONGNUMBER;
            }

            //get info and add to database
            this.foodDto.FoodName = this.foodNameTxtBox.Text;
            this.foodDto.FoodPrice = int.Parse(this.foodPriceTxtBox.Text);
            this.foodDto.DiscountPrice = int.Parse(this.discountPriceTxtBox.Text);
            this.foodDto.FoodGroupID = this._foodGroup[this.foodGroupCmbBox.SelectedIndex].FoodGroupID;
            this.foodDto.Image = this.imageTxtBox.Text;
            this.foodDto.Description = this.descriptionTxtBox.Text;
            this.foodDto.FoodStatus = true;
            
            try
            {
                FoodCTL foodCtl = new FoodCTL();
                foodCtl.add(this.foodDto);
                this.isClosed = false;
                this.Close();
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return;
        WRONGNUMBER: MessageBox.Show("Thông tin giá nhập sai. Mời bạn nhập lại");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.Filter = "Image File(*.png)|*.png";
            dlg.Title = "Choose Image File";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.imageTxtBox.Text = dlg.FileName;
            }
        }


	}
}