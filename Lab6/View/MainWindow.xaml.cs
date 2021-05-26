using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Globalization;
using ViewModel;
using System.Windows.Input;

namespace View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel ViewModel = new MainViewModel(new UIServices());
        public static RoutedCommand AddCommand = new RoutedCommand("AddCommand", typeof(View.MainWindow));
        public MainWindow()
        {
            InitializeComponent();
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            DataContext = ViewModel;
        }

        private void New(object sender, RoutedEventArgs e)
        {
            ViewModel.New();
        }
        private void Add_Defaults(object sender, RoutedEventArgs e)
        {
            ViewModel.Default();
        }
        private void Add_Default_V2DataCollection(object sender, RoutedEventArgs e)
        {
            ViewModel.Default_V2DataCollection();
        }
        private void Add_Default_V2DataOnGrid(object sender, RoutedEventArgs e)
        {
            ViewModel.Default_V2DataOnGrid();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) { }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void Window_Closed(object sender, EventArgs e)
        {
            ViewModel.Close();
        }
        
    }
}
