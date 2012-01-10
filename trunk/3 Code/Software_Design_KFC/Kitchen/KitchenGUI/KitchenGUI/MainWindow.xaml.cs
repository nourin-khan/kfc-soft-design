using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using KitchenController.KfcService;
using KitchenController;
using System;
using System.Windows.Threading;

namespace KitchenGUI
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

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Controller
        private ConnectionCTL connectionCtrl;
        private MyCommand configureCommand;
        private OrderCTL orderCtrl;
        private OrderDetailCTL orderDetailCtrl;
        private object synchObject = new object();
        #endregion
        public MainWindow()
        {
            this.InitializeComponent();
            // Insert code required on object creation below this point.
     
            //add event to delegate
            QueueUsc workingQueue = (QueueUsc)WorkingOrders.Children[0];
            workingQueue.clickNoteEvent += new QueueUsc.ClickNoteDelegate(workingQueue_clickNoteEvent);

            // register hot keys Ctrl + Shift + C for configuration
            // Bind key
            configureCommand = new MyCommand();
            configureCommand.ReloadAll += new MyCommand.Refresh(configureCommand_ReloadAll);
            InputBinding ib = new InputBinding(configureCommand, new KeyGesture(Key.C, ModifierKeys.Control | ModifierKeys.Shift));
            this.InputBindings.Add(ib);

            // initialing controller
            orderCtrl = new OrderCTL();
            orderDetailCtrl = new OrderDetailCTL();
        }

        void configureCommand_ReloadAll()
        {
            ConfigureForm configure = new ConfigureForm();
            configure.ShowDialog();
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // create timer 
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(3);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            lock (synchObject)
            {
                OrderDTO[] newOrder = orderCtrl.getOrderByStatus("CONFIRM");
                
                if (newOrder != null)
                {
                    //MessageBox.Show("Co don dat hang");
                }
            }
        }
    }
}
	