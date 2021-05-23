using System.ComponentModel;
using System.Numerics;
using Lab3;

namespace ViewModel
{
    public class DataItemViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private float _XCoord;
        private float _YCoord;
        private double _RealVal;
        private double _ImVal;
        public float XCoord
        {
            get { return _XCoord; }
            set
            {
                _XCoord = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("_XCoord"));
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("_YCoord"));
            }
        }
        public float YCoord
        {
            get { return _YCoord; }
            set
            {
                _YCoord = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("_XCoord"));
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("_YCoord"));
            }
        }
        public double RealVal
        {
            get { return _RealVal; }
            set
            {
                _RealVal = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("_RealVal"));
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("_ImVal"));
            }
        }
        public double ImVal
        {
            get { return _ImVal; }
            set
            {
                _ImVal = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("_RealVal"));
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("_ImVal"));
            }
        }
        public V2DataCollection col;
        public DataItemViewModel(V2DataCollection _col)
        {
            col = _col;
            XCoord = 0;
            YCoord = 0;
            RealVal = 0;
            ImVal = 0;
        }
        public void AddDataItem()
        {
            DataItem item = new DataItem(new Vector2(XCoord, YCoord), new Complex(RealVal, ImVal));
            col.Add(item);
        }
        public string Error { get { return "Error"; } }
        public string this[string property]
        {
            //для того, чтобы проверка работала <TextBox Text="{Binding Text, ValidatesOnDataErrors=True}">
            get
            {
                string msg = null;
                if (col == null)
                {
                    return "Col is null";
                }
                switch (property)
                {
                    case "RealVal":
                    case "ImVal":
                        if ((RealVal == 0) && (ImVal == 0)) msg = "Value must have be non-zero";
                        break;
                    case "XCoord":
                    case "YCoord":
                        foreach (DataItem item in col)
                        {
                            if ((item.Point.X == XCoord) && (item.Point.Y == YCoord))
                            {
                                msg = "Point must me unique";
                                break;
                            }
                        }
                        break;
                    default:
                        break;
                }
                return msg;
            }
        }
    }
}
