using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;

namespace View
{
    public class UIServices: IUIServices
    {
        YNC ConfirmInterface.ConfirmFunc(string s)
        {
            MessageBoxResult mes = MessageBox.Show(s, " ", MessageBoxButton.YesNoCancel);
            switch(mes)
            {
                case MessageBoxResult.Yes: return YNC.Yes;
                case MessageBoxResult.No: return YNC.No;
                default: return YNC.Cancel;
            }    
        }
        string SaveFileInterface.SaveFileFunc()
        {
            Microsoft.Win32.SaveFileDialog dlg_save = new Microsoft.Win32.SaveFileDialog();
            dlg_save.FileName = "Collection";
            dlg_save.DefaultExt = ".txt";
            dlg_save.Filter = "Text documents|*.txt";
            if (dlg_save.ShowDialog() == true)
                return dlg_save.FileName;
            return null;
        }

        string OpenFileInterface.OpenFileFunc()
        {
            Microsoft.Win32.OpenFileDialog dlg_open = new Microsoft.Win32.OpenFileDialog();
            dlg_open.FileName = "Collection";
            dlg_open.DefaultExt = ".txt";
            dlg_open.Filter = "Text documents|*.txt";
            if (dlg_open.ShowDialog() == true)
                return dlg_open.FileName;
            return null;
        }
        void ErrorUserInterface.ErrorFunc(string s)
        {
            MessageBox.Show(s);
        }
    }
}
