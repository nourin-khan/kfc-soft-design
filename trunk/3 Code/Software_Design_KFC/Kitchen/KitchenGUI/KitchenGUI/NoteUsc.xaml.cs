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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace KitchenGUI
{
	/// <summary>
	/// Interaction logic for OrderGUI.xaml
	/// </summary>
	public partial class NoteUsc : UserControl
    {
        #region Attribute
        public string noteId = "123";
        #endregion
        public NoteUsc()
		{
			this.InitializeComponent();
		}
	}
}