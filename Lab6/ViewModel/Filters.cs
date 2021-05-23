using System.Windows.Data;
using Lab3;

namespace ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        static public bool Filter1(object _obj)
        {
            if (_obj is V2DataCollection)
                return true;
            else
                return false;
        }

        static public bool Filter2(object _obj)
        {
            if (_obj is V2DataOnGrid)
                return true;
            else
                return false;
        }
    }
}
