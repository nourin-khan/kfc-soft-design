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

namespace CashierGUI
{
	/// <summary>
	/// Interaction logic for LogInForm.xaml
	/// </summary>
	public partial class LogInForm : Window
	{
		public LogInForm()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void OKbut_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (!(string.IsNullOrWhiteSpace(this.usernameTxtBox.Text) || string.IsNullOrEmpty(this.usernameTxtBox.Text)))
            {
                EmployeeCTL empCtl = new EmployeeCTL();
                string empId = empCtl.checkCashierPermission(this.usernameTxtBox.Text,this.passwordTxtBox.Password);
                if (empId == null)
                {
                    MainWindow main = new MainWindow();
                    main.empId = empId;
                    this.Close();
                    main.Show();
                }
            }
            else
            {
                MessageBox.Show("Thông tin nhập vào sai. Mời bạn kiểm tra lại");
                this.passwordTxtBox.Clear();
            }
        }
	}
}