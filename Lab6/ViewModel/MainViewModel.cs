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
        public V2MainCollection MyMainCollection
        {
            get => _MyMainCollection;
            set
            {
                _MyMainCollection = value;
                RaisePropertyChanged();
            }
        }
        private DataItemViewModel _MyDataItemView;
        public DataItemViewModel MyDataItemView
        {
            get => _MyDataItemView;
            set
            {
                _MyDataItemView = value;
                RaisePropertyChanged();
            }
        }
        public MainViewModel()
        {
            MyMainCollection = new V2MainCollection();
            //MainCollection.AddDefaults();
            Saved = true;
            MyDataItemView = new DataItemViewModel(null);
        }
        public BoolViewModel New()
        {
            MyMainCollection = new V2MainCollection();
            Saved = true;
            RaisePropertyChanged("Avg");
            return BoolViewModel.FromResult(true);
        }
        public BoolViewModel Default() {
            try
            {
                if (MyMainCollection == null)
                {
                    return BoolViewModel.FromError("Коллекция не создана!");
                }
                MyMainCollection.AddDefaults();
                Saved = false;
                RaisePropertyChanged("Avg");
                RaisePropertyChanged("MyMainCollection");
                return BoolViewModel.FromResult(true);
            }
            catch (Exception ex)
            {
                return BoolViewModel.FromError(ex.Message);
            }
        }
        public BoolViewModel Default_V2DataCollection()
        {
            try
            {
                if (MyMainCollection == null)
                {
                    return BoolViewModel.FromError("Коллекция не создана!");
                }
                MyMainCollection.Add_Default_V2DataCollection();
                Saved = false;
                RaisePropertyChanged("Avg");
                RaisePropertyChanged("MyMainCollection");
                return BoolViewModel.FromResult(true);
            }
            catch (Exception ex)
            {
                return BoolViewModel.FromError(ex.Message);
            }
        }
        public BoolViewModel Default_V2DataOnGrid()
        {
            try
            {
                if (MyMainCollection == null)
                {
                    return BoolViewModel.FromError("Коллекция не создана!");
                }
                MyMainCollection.Add_Default_V2DataOnGrid();
                Saved = false;
                RaisePropertyChanged("Avg");
                RaisePropertyChanged("MyMainCollection");
                return BoolViewModel.FromResult(true);
            }
            catch (Exception ex)
            {
                return BoolViewModel.FromError(ex.Message);
            }
        }
        public BoolViewModel SaveToFile(string s)
        {
            try {
                MyMainCollection.Save(s);
                Saved = true;
                return BoolViewModel.FromResult(true);
            }
            catch (Exception ex)
            {
                return BoolViewModel.FromError(ex.Message);
            }
        }
        public BoolViewModel OpenFile(string s)
        {
            try
            {
                MyMainCollection.Load(s);
                Saved = true;
                RaisePropertyChanged("Avg");
                RaisePropertyChanged("MyMainCollection");
                if (MyMainCollection==null)
                    return BoolViewModel.FromError("Ошибка при чтении из файла!");
                return BoolViewModel.FromResult(true);
            }
            catch (Exception ex)
            {
                return BoolViewModel.FromError(ex.Message);
            }
        }
        public BoolViewModel Remove() { throw new NotImplementedException(); }
        public BoolViewModel AddFromFile(string s)
        {
            try
            {
                V2DataCollection c = new V2DataCollection(s);
                MyMainCollection.Add(c);
                RaisePropertyChanged("Avg");
                RaisePropertyChanged("MyMainCollection");
                return BoolViewModel.FromResult(true);
            }
            catch (Exception ex)
            {
                return BoolViewModel.FromError(ex.Message);
            }
        }

        //private double _min;
        //public double Min { get => _min; }
        //private double _max;
        //public double Max { get => _max; }
        private AvgViewModel _avg = AvgViewModel.FromError("Input is empty");
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
        private bool _saved;
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
