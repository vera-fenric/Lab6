using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3;

namespace ViewModel
{

    public partial class MainViewModel : ViewModelBase
    {

        private V2MainCollection _MyMainCollection;
        private V2Data _CurrV2Data;
        private V2DataCollection _CurrV2DataCollection;
        private DataItemViewModel _MyDataItemView;
        private AvgViewModel _avg = AvgViewModel.FromError("Input is empty");
        private bool _saved;

        private readonly IUIServices UI;

        public MainViewModel(IUIServices svc)
        {
            MyMainCollection = new V2MainCollection();
            Saved = true;
            MyDataItemView = new DataItemViewModel(null);
            UI = svc;
        }

        public V2MainCollection MyMainCollection
        {
            get => _MyMainCollection;
            set
            {
                _MyMainCollection = value;
                RaisePropertyChanged("Avg");
                RaisePropertyChanged("MyDataCollection");
                RaisePropertyChanged("MyDataOnGrid");
                RaisePropertyChanged();
            }
        }
        public IEnumerable<V2DataCollection> MyDataCollection
        {
            get
            {
                return from col in MyMainCollection where col is V2DataCollection select col as V2DataCollection;
            }
        }
        public IEnumerable<V2DataOnGrid> MyDataOnGrid
        {
            get
            {
                return from col in MyMainCollection where col is V2DataOnGrid select col as V2DataOnGrid;
            }
        }
        public DataItemViewModel MyDataItemView
        {
            get => _MyDataItemView;
            set
            {
                _MyDataItemView = value;
                RaisePropertyChanged();
            }
        }
        public V2Data CurrV2Data
        {
            get => _CurrV2Data;
            set
            {
                _CurrV2Data = value;
                RaisePropertyChanged();
            }
        }
        public V2DataCollection CurrV2DataCollection
        {
            get => _CurrV2DataCollection;
            set
            {
                _CurrV2DataCollection = value;
                RaisePropertyChanged();
            }
        }
        
        public AvgViewModel Avg
        {
            get
            {
                try
                {
                    _avg = AvgViewModel.FromResult(MyMainCollection.Mid);
                    return _avg;
                }
                catch (Exception ex)
                {
                    _avg = AvgViewModel.FromError(ex.Message);
                    return _avg;
                }
            }
         }

        public bool Saved
        {
            get => _saved;
            set
            {
                _saved = value;
                RaisePropertyChanged();
            }
        }

    }
}
