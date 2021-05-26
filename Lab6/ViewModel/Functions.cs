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
        public void New()
        {
            if (!Saved)
            {
                switch (UI.ConfirmFunc("Сохранить изменения?"))
                {
                    case YNC.Yes: Save(); break;
                    case YNC.No: break;
                    case YNC.Cancel: return;
                }
            }
            
            MyMainCollection = new V2MainCollection();
            Saved = true;
            return;
        }
        public void Default()
        {
            try
            {
                if (MyMainCollection == null)
                {
                    UI.ErrorFunc("Коллекция не создана!");
                    return;
                }
                MyMainCollection.AddDefaults();
                Saved = false;
                RaisePropertyChanged("Avg");
                RaisePropertyChanged("MyMainCollection");
                RaisePropertyChanged("MyDataCollection");
                RaisePropertyChanged("MyDataOnGrid");
                return;
            }
            catch (Exception ex)
            {
                UI.ErrorFunc(ex.Message);
                return;
            }
        }
        public void Default_V2DataCollection()
        {
            try
            {
                if (MyMainCollection == null)
                {
                    UI.ErrorFunc("Коллекция не создана!");
                    return;
                }
                MyMainCollection.Add_Default_V2DataCollection();
                Saved = false;
                RaisePropertyChanged("Avg");
                RaisePropertyChanged("MyMainCollection");
                RaisePropertyChanged("MyDataCollection");
                return;
            }
            catch (Exception ex)
            {
                UI.ErrorFunc(ex.Message);
                return;
            }
        }
        public void Default_V2DataOnGrid()
        {
            try
            {
                if (MyMainCollection == null)
                {
                    UI.ErrorFunc("Коллекция не создана!");
                    return;
                }
                MyMainCollection.Add_Default_V2DataOnGrid();
                Saved = false;
                RaisePropertyChanged("Avg");
                RaisePropertyChanged("MyMainCollection");
                RaisePropertyChanged("MyDataOnGrid");
                return;
            }
            catch (Exception ex)
            {
                UI.ErrorFunc(ex.Message);
                return;
            }
        }
        public void Save()
        {
            try
            {
                MyMainCollection.Save(UI.SaveFileFunc());
                Saved = true;
                return;
            }
            catch (Exception ex)
            {
                UI.ErrorFunc(ex.Message);
            }
        }
        public void Open()
        {
            try
            {
                if (!Saved)
                {
                    switch (UI.ConfirmFunc("Сохранить изменения?"))
                    {
                        case YNC.Yes: Save(); break;
                        case YNC.No: break;
                        case YNC.Cancel: return;
                    }
                }
                MyMainCollection.Load(UI.OpenFileFunc());
                Saved = true;
                RaisePropertyChanged("Avg");
                RaisePropertyChanged("MyMainCollection");
                RaisePropertyChanged("MyDataCollection");
                RaisePropertyChanged("MyDataOnGrid");
                if (MyMainCollection == null)
                    UI.ErrorFunc("Ошибка при чтении из файла!");
                return;
            }
            catch (Exception ex)
            {
                UI.ErrorFunc(ex.Message);
            }
        }
        public void Remove()
        {
            try
            { 
                if (_CurrV2Data != null)
                {
                    MyMainCollection.Remove(_CurrV2Data.Info, _CurrV2Data.Frequency);
                    _CurrV2Data = null;
                    RaisePropertyChanged("Avg");
                    RaisePropertyChanged("MyMainCollection");
                    RaisePropertyChanged("MyDataCollection");
                    RaisePropertyChanged("MyDataOnGrid");
                    return;
                }
                throw new Exception("Объект не был удалён!");
            }
            catch (Exception ex)
            {
                UI.ErrorFunc(ex.Message);
            }
        }

        public void Add()
        {
            try
            {
                MyDataItemView.AddDataItem();
                MyDataItemView = new DataItemViewModel(null);
                RaisePropertyChanged("Avg");
                RaisePropertyChanged("MyMainCollection");
                RaisePropertyChanged("MyDataCollection");
                return;
            }
            catch (Exception ex)
            {
                UI.ErrorFunc(ex.Message);
            }

        }

        public void AddFromFile()
        {
            try
            {
                V2DataCollection c = new V2DataCollection(UI.OpenFileFunc());
                MyMainCollection.Add(c);
                RaisePropertyChanged("Avg");
                RaisePropertyChanged("MyMainCollection");
                RaisePropertyChanged("MyDataCollection");
                return;
            }
            catch (Exception ex)
            {
                UI.ErrorFunc(ex.Message);
                return;
            }
        }
        public void Close()
        {
            if (Saved) return;
            try
            {
                switch (UI.ConfirmFunc("Сохранить изменения?"))
                {
                    case YNC.Yes: Save(); break;
                    case YNC.No: break;
                    case YNC.Cancel: return;
                }
            }
            catch (Exception ex)
            {
                UI.ErrorFunc(ex.Message);
            }
        }
    }
}
