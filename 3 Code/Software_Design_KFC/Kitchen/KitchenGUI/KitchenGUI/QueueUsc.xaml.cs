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
	/// Interaction logic for QueueUsc.xaml
	/// </summary>
	public partial class QueueUsc : UserControl
	{
		public QueueUsc()
		{
			this.InitializeComponent();
		}

        #region Delegate
        /*
         * @description: delegate when clicking on object
         * @author: hathao298
         */
        public delegate void ClickNoteDelegate(string noteId);
        public event ClickNoteDelegate clickNoteEvent;

        /*
         * @description: trigger the flyout event
         * @author: hathao298
         */
        public void flyOutQueue()
        {
            Storyboard stb = (Storyboard)this.Resources["FlyOut"];
            stb.Begin();
        }
        #endregion

        #region Method
        public void clickNote(Grid obj)
        {
            if (!(obj.Children[0] is EmptyNote))
            {
                NoteUsc order = (NoteUsc)obj.Children[0];
                this.clickNoteEvent(order.noteId);
            }
        }
        #endregion

        private void Obj1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clickNote(Obj1);
        }

        private void Obj2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clickNote(Obj2);
        }

        private void Obj3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clickNote(Obj3);
        }

        private void Obj4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clickNote(Obj4);
        }

        private void Obj5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            clickNote(Obj5);
        }
    }
}