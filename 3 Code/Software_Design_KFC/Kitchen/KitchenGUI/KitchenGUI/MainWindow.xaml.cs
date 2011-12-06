using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace KitchenGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            // Insert code required on object creation below this point.
     
            //add event to delegate
            QueueUsc workingQueue = (QueueUsc)WorkingOrders.Children[0];
            workingQueue.clickNoteEvent += new QueueUsc.ClickNoteDelegate(workingQueue_clickNoteEvent);
        }

        void workingQueue_clickNoteEvent(string noteId)
        {
            this.ZoomOrderGrid.Children.RemoveAt(0);
            this.ZoomOrderGrid.Children.Add(new OrderUsc());
            Storyboard stb = (Storyboard)this.Resources["MouseOver"];
            stb.Begin();
        }


        private void WLeftArr_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {            
            if (WorkingOrders.Children != null)
            {
                WorkingOrders.Children.RemoveAt(0);
                WorkingOrders.Children.Add(new QueueUsc());
            }
        }

        private void WRightArr_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            QueueUsc stack = (QueueUsc)WorkingOrders.Children[0];
            stack.flyOutQueue();
            if (WorkingOrders.Children != null)
            {
                WorkingOrders.Children.RemoveAt(0);
                WorkingOrders.Children.Add(new QueueUsc());

            }
        }
    }
}
	