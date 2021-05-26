using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            //if (ViewModel != null)
                e.CanExecute = ViewModel.CanSave();
        }
        private void SaveCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            ViewModel.Save();
        }


        //--------------------------Open----------------------------------
        private void OpenCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            ViewModel.Open();
        }

        //-----------------------------Delete---------------------
        private void CanDeleteCommandHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            //if (ViewModel != null)
                e.CanExecute = ViewModel.CanDelete();
        }
        private void DeleteCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            ViewModel.Remove();
        }

        //-------------------------------AddFromFile----------------------------
        private void Add_Element_from_File(object sender, RoutedEventArgs e)
        {
            ViewModel.AddFromFile();
        }
        //-----------------------------------Add------------------------------------

        //Так как мы используем валидацию, я почти не трогала CanAdd
        //Но по факту можно было в ViewModel.CanAdd() вставить функцию HasError из DataItemViewModel
        //А в функцию HasError из DataItemViewModel практически скопировать текст проверки
        //который мы писали для валидации, только вместо string возвращать bool
        private void CanAddCommandHandler(object sender, CanExecuteRoutedEventArgs e)
        {
            if (ViewModel != null)
                if (!(e.CanExecute = ViewModel.CanAdd()))
                    return;
            try
            {
                if (Validation.GetHasError(TextBox_x) || Validation.GetHasError(TextBox_y) || Validation.GetHasError(TextBox_a) || Validation.GetHasError(TextBox_b))
                {
                    e.CanExecute = false;
                    return;
                }

                e.CanExecute = true;
            }
            catch
            {
                e.CanExecute = false;
                return;
            }
            
        }
        private void AddCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            ViewModel.Add();
        }

    }
}
