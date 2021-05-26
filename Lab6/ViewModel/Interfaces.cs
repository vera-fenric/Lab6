using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public enum YNC {Yes, No, Cancel};

    public interface ConfirmInterface
    {
        YNC ConfirmFunc(string s);
    }
    public interface SaveFileInterface
    {
        string SaveFileFunc();
    }
    public interface OpenFileInterface
    {
        string OpenFileFunc();
    }
    public interface ErrorUserInterface
    {
        void ErrorFunc(string s);
    }
    public interface IUIServices: ConfirmInterface, SaveFileInterface, OpenFileInterface, ErrorUserInterface
    { }
}
