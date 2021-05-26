using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using Lab3;

namespace Tests
{
    public class YesUIServices : IUIServices
    {
        YNC ConfirmInterface.ConfirmFunc(string s)
        {
            return YNC.Yes;
        }

        void ErrorUserInterface.ErrorFunc(string s)
        {
            return;
        }

        string OpenFileInterface.OpenFileFunc()
        {
            return "openfile.txt";
        }

        string SaveFileInterface.SaveFileFunc()
        {
            return "savefile.txt";
        }
    }
    public class NoUIServices : IUIServices
    {
        YNC ConfirmInterface.ConfirmFunc(string s)
        {
            return YNC.No;
        }

        void ErrorUserInterface.ErrorFunc(string s)
        {
            throw new NotImplementedException();
        }

        string OpenFileInterface.OpenFileFunc()
        {
            return "notopenfile.txt";
        }

        string SaveFileInterface.SaveFileFunc()
        {
            return null;
        }
    }
    public class CancelUIServices : IUIServices
    {
        YNC ConfirmInterface.ConfirmFunc(string s)
        {
            return YNC.Cancel;
        }

        void ErrorUserInterface.ErrorFunc(string s)
        {
            throw new NotImplementedException();
        }

        string OpenFileInterface.OpenFileFunc()
        {
            throw new NotImplementedException();
        }

        string SaveFileInterface.SaveFileFunc()
        {
            throw new NotImplementedException();
        }
    }


}
