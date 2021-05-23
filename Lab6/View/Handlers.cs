using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using ViewModel;

namespace View
{
    public partial class MainWindow : Window
    {
        //--------------------------Save----------------------------------
        private void CanSaveCommandHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            if ((ViewModel==null) || (ViewModel.Saved)) e.CanExecute = false;
            else e.CanExecute = true;
        }
        private void SaveCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (Check()) return;
            try
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Collection";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text documents|*.txt";
                if (dlg.ShowDialog() == true)
                {
                    BoolViewModel.ErrorResultViewModel x = ViewModel.SaveToFile(dlg.FileName) as BoolViewModel.ErrorResultViewModel;
                    if (x!=null)
                        MessageBox.Show(x.Error);
                }
            }
            catch
            {
                MessageBox.Show("Не удалось сохранить коллекцию!");
            }
        }

        //--------------------------Open----------------------------------
        private void OpenCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (Check()) return;
            try
            {
                if (!ViewModel.Saved)
                {
                    MessageBoxResult mes = MessageBox.Show("Сохранить изменения?", " ", MessageBoxButton.YesNoCancel);
                    if (mes == MessageBoxResult.Yes)
                    {
                        Microsoft.Win32.SaveFileDialog dlg_save = new Microsoft.Win32.SaveFileDialog();
                        dlg_save.FileName = "Collection";
                        dlg_save.DefaultExt = ".txt";
                        dlg_save.Filter = "Text documents|*.txt";
                        if (dlg_save.ShowDialog() == true)
                        {
                            BoolViewModel.ErrorResultViewModel x = ViewModel.SaveToFile(dlg_save.FileName) as BoolViewModel.ErrorResultViewModel;
                            if (x != null)
                                MessageBox.Show(x.Error);
                        }
                    }
                    else if (mes == MessageBoxResult.Cancel)
                    {
                        return;
                    }
                }
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
                if (dlg.ShowDialog() == true)
                {
                    BoolViewModel.ErrorResultViewModel x = ViewModel.OpenFile(dlg.FileName) as BoolViewModel.ErrorResultViewModel;
                    if (x != null)
                        MessageBox.Show(x.Error);
                }
            }
            catch
            {
                MessageBox.Show("Не удалось загрузить коллекцию!", "Ошибка");
            }
        }

        //-----------------------------Delete---------------------
        private void CanDeleteCommandHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = false;
            if ((ViewModel == null)) return;
            CollectionViewSource view = TryFindResource("All_Collection_View") as CollectionViewSource;
            if (view == null) return;
            if (view.View == null) return;
            if (view.View.CurrentItem == null) return;
            e.CanExecute = true;
            return;
        }

        private void DeleteCommandHandler(object sender, ExecutedRoutedEventArgs e) { }
        /*
        private void DeleteCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                CollectionViewSource view = TryFindResource("All_Collection_View") as CollectionViewSource;
                V2Data v2_collection = view.View.CurrentItem as V2Data;
                if (v2_collection != null)
                    MyCollection.Remove(v2_collection.Info, v2_collection.Frequency);
            }
            catch
            {
                MessageBox.Show("Не удалось удалить элемент!", "Ошибка");
            }
        }*/

        //-------------------------------AddFromFile----------------------------
        private void Add_Element_from_File(object sender, RoutedEventArgs e)
        {
            if (Check()) return;
            try
            {
                Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();
                if (dialog.ShowDialog() == true)
                {
                    BoolViewModel.ErrorResultViewModel x = ViewModel.AddFromFile(dialog.FileName) as BoolViewModel.ErrorResultViewModel;
                    if (x!=null)
                        MessageBox.Show(x.Error);
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при чтении из файла!");
            }
        }
        //-----------------------------------Add------------------------------------
        private void CanAddCommandHandler(object sender, CanExecuteRoutedEventArgs e) { }
        private void AddCommandHandler(object sender, ExecutedRoutedEventArgs e) { }

    }
}
