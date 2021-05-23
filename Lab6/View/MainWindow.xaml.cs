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
        public MainViewModel ViewModel;
        public static RoutedCommand AddCommand = new RoutedCommand("AddCommand", typeof(View.MainWindow));
        public MainWindow()
        {
            InitializeComponent();
            CultureInfo.CurrentCulture = new CultureInfo("ru-RU");
            ViewModel = new MainViewModel();
            DataContext = ViewModel;
        }
        private bool Check()
        {
            if (ViewModel == null)
            {
                MessageBox.Show("Критическая ошибка");
                return true;
            }
            return false;
        }
        private void New(object sender, RoutedEventArgs e)
        {
            if (Check()) return;
            if (ViewModel.Saved == true)
            {
                ViewModel.New();
                return;
            }
            MessageBoxResult mes = MessageBox.Show("Сохранить изменения?", " ", MessageBoxButton.YesNoCancel);
            switch (mes)
            {
                case MessageBoxResult.Yes:
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    dlg.FileName = "Collection";
                    dlg.DefaultExt = ".txt";
                    dlg.Filter = "Text documents|*.txt";
                    if (dlg.ShowDialog() == true)
                    {
                        ViewModel.SaveToFile(dlg.FileName);
                    };
                    break;
                case MessageBoxResult.No:
                    break;
                case MessageBoxResult.Cancel:
                    return;
            }
            ViewModel.New();
            return;

        }
        private void Add_Defaults(object sender, RoutedEventArgs e)
        {
            if (Check()) return;
            BoolViewModel.ErrorResultViewModel x = ViewModel.Default() as BoolViewModel.ErrorResultViewModel;
            if (x!=null)
                MessageBox.Show(x.Error);
            return;
        }
        private void Add_Default_V2DataCollection(object sender, RoutedEventArgs e)
        {
            if (Check()) return;
            BoolViewModel.ErrorResultViewModel x = ViewModel.Default_V2DataCollection() as BoolViewModel.ErrorResultViewModel;
            if (x != null)
                MessageBox.Show(x.Error);
            return;
        }
        private void Add_Default_V2DataOnGrid(object sender, RoutedEventArgs e)
        {
            if (Check()) return;
            BoolViewModel.ErrorResultViewModel x = ViewModel.Default_V2DataOnGrid() as BoolViewModel.ErrorResultViewModel;
            if (x != null)
                MessageBox.Show(x.Error);
            return;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e) { }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) { }
        private void Window_Closed(object sender, EventArgs e)
        {
            try
            {
                if (Check()) return;
                if (ViewModel.Saved == true)
                    return;
                MessageBoxResult mes = MessageBox.Show("Сохранить изменения?", " ", MessageBoxButton.YesNo);
                if (mes == MessageBoxResult.Yes)
                {
                    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                    dlg.FileName = "Collection";
                    dlg.DefaultExt = ".txt";
                    dlg.Filter = "Text documents|*.txt";

                    if (dlg.ShowDialog() == true)
                    {
                        ViewModel.SaveToFile(dlg.FileName);
                    }
                }
                return;
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить коллекцию!", "Ошибка");
            }

        }
        private void V2DC_Collection_View_Filter(object sender, FilterEventArgs args)
        {
            if (args.Item != null)
            {
                if (MainViewModel.Filter1(args.Item))
                {
                    args.Accepted = true;
                }
                else
                {
                    args.Accepted = false;
                }
            }
        }

        private void V2DoG_Collection_View_Filter(object sender, FilterEventArgs args)
        {
            if (args.Item != null)
            {
                if (MainViewModel.Filter2(args.Item))
                {
                    args.Accepted = true;
                }
                else
                {
                    args.Accepted = false;
                }
            }
        }
    }
}
