using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ViewModel
{
    public partial class MainViewModel : ViewModelBase
    {
        public bool CanSave()
        {
            if (!Saved) return true;
            return false;
        }
        public bool CanDelete()
        {
            if (CurrV2Data != null) return true;
            return false;
        }
        public bool CanAdd()
        {
            MyDataItemView.col = CurrV2DataCollection;
            if (CurrV2DataCollection != null) return true;
            return false;
        }
    }
}
