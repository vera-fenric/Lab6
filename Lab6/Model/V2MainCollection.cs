using System;
using System.Collections.Generic;
using System.Numerics;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.ComponentModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Lab3
{

    //------------------>V2MainCollection<---------------------
    public class V2MainCollection : IEnumerable<V2Data>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        //Изменения лабораторной работы 4:

        //Добавить реализацию интерфейса
        //System.Collections.Specialized.INotifyCollectionChanged;

        //открытое свойство булевского типа для информации о том, что пользователь внес изменения в коллекцию после сохранения в файле;
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        private bool saved=false;
        public bool Saved{
            get { return saved; }
            set { saved = value;
                if (PropertyChanged!=null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Saved")); }
        }

        public void Save(string filename)
        {
            FileStream fileStream = null;
            try
            {
                Saved = true;
                fileStream = File.Create(filename);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, l);
                //Saved = true;
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Save: " + ex.Message);
                
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Saved"));
            }
        }

        public void Load(string filename)
        {
            FileStream fileStream = null;
            if (l!=null)
                l.Clear();
            try
            {
                fileStream = File.OpenRead(filename);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                l = binaryFormatter.Deserialize(fileStream) as List<V2Data>;
                Saved = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Load: " + ex.Message);
                throw ex;
            }
            finally
            {
                if (fileStream != null) fileStream.Close();
                if (CollectionChanged != null)
                    CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
                Saved = true;
                
            }
        }
        [field: NonSerialized]
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        void CollectionChangedHandler(object sender, NotifyCollectionChangedEventArgs args)
        {
            Saved = false;
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Mid"));

            //if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(null));
        }

        public V2MainCollection()
        {
            CollectionChanged += CollectionChangedHandler;
        }

        public void Add_Default_V2DataCollection()
        {
            V2DataCollection c = new V2DataCollection("default v2_dc", 2);
            c.Init(4);
            Add(c);
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(null));
        }

        public void Add_Default_V2DataOnGrid()
        {
            V2DataOnGrid g = new V2DataOnGrid("default v2_dg", 1, new Grid1D(1, 2), new Grid1D(1, 2));
            g.Init();
            Add(g);
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(null));
        }

        //--------------------старое-----------------

        private List<V2Data> l = new List<V2Data>();

        //обработчик изменения одного элемента - бросает событие "изменение данных"
        public void PropertyChangedHandler(object sender, PropertyChangedEventArgs args)
        {
            if (!(sender is V2Data))
                throw new Exception("object is not V2DATA!");
            V2Data v2data = (V2Data) sender;    //нужно распаковать sender, чтобы получить данные Frequency
            if (DataChanged != null)
                DataChanged(this, new DataChangedEventArgs(ChangeInfo.ItemChanged, v2data.Frequency));
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            //Console.WriteLine("PropertyChanged");
        }
        
        public V2Data this[int index]
        {
            get { return l[index]; }
            set
            {
             
                l[index].PropertyChanged -= PropertyChangedHandler;
                l[index] = value;
                l[index].PropertyChanged += PropertyChangedHandler;
                if (DataChanged != null)
                    DataChanged(this, new DataChangedEventArgs(ChangeInfo.Replace, l[index].Frequency));
                if (CollectionChanged != null)
                    CollectionChanged(this, null);
            }
        }
        [field: NonSerialized]
        public event DataChangedEventHandler DataChanged;
        public int Count
        {
            get { return l.Count; }
        }
        public void Add(V2Data item)
        {
            l.Add(item);
            if (DataChanged != null)
                DataChanged(this, new DataChangedEventArgs(ChangeInfo.Add, item.Frequency));
            item.PropertyChanged += PropertyChangedHandler;
            //if (item is V2DataCollection)
                //(item as V2DataCollection).CollectionChanged += CollectionChangedHandler;

            //НОВОЕ ->>>>>>>>>>>>
            CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(null));
        }
        public bool Remove(string id, double w)
        {
            bool b = false;
            for (int i = l.Count - 1; i > -1; i--)
            {
                if ((l[i].Info == id) && (l[i].Frequency == w))
                {
                    if (DataChanged != null)
                        DataChanged(this, new DataChangedEventArgs(ChangeInfo.Remove, l[i].Frequency));
                    l[i].PropertyChanged -= PropertyChangedHandler;
                    l.Remove(l[i]);
                    b = true;
                }
            }
            if (CollectionChanged != null)
                CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(null));
            return b;
        }
        public void AddDefaults()
        {
            
            V2DataOnGrid g1 = new V2DataOnGrid("info 1", 1, new Grid1D(1, 2), new Grid1D(1, 2)); g1.Init(); Add(g1);
            //элемент V2DataOnGrid, у которого число узлов сетки 0
            V2DataOnGrid g2 = new V2DataOnGrid("info 2", 2, new Grid1D(0, 0), new Grid1D(0, 0)); Add(g2);
            //V2DataOnGrid g3 = new V2DataOnGrid("info 3", 3, new Grid1D(1, 2), new Grid1D(1, 3)); g3.InitRandom(0, 10); Add(g3);
            //элемент V2DataCollection
            V2DataCollection c1 = new V2DataCollection("info 1", 3); c1.Init(5); Add(c1);
            //элемент V2DataCollcection, у которого в списке нет элементов
            V2DataCollection c2 = new V2DataCollection("info 2", 4); Add(c2);
            //V2DataCollection c3 = new V2DataCollection("info 3", 3); c3.InitRandom(1, 0, 0, 0, 100); Add(c3);
            CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(null));
        }

        public override string ToString()
        {
            string s = "";
            foreach (V2Data data in this)
                s = s + data;
            return s;
        }

        public string ToLongString(string format)
        {
            string s = "";
            foreach (V2Data data in this)
                s = s + data.ToLongString(format);
            return s;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)l).GetEnumerator();
        }
        IEnumerator<V2Data> IEnumerable<V2Data>.GetEnumerator()
        {
            return l.GetEnumerator();
        }

        //LINQ!

        public double Mid
        {
            get
            {
                if (l.Count == 0)
                    return -1;
                var q1 = from v2 in l where v2 is V2DataOnGrid select v2;
                var q2 = from v2 in l where v2 is V2DataCollection select v2;
                var q1_2 = from V2DataOnGrid item in q1 from x in item select x;
                var q2_2 = from V2DataCollection item in q2 from x in item select x;
                var q3 = q1_2.Union(q2_2);
                if (q3.Count() == 0)
                    return -1;
                return (from item in q3 select item.Val.Magnitude).Average();
            }
            set
            {
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Mid"));
            }
        }
        
        public IEnumerable<DataItem> Dif
        {
            get
            {
                var q1 = from v2 in l where v2 is V2DataOnGrid select v2;
                var q2 = from v2 in l where v2 is V2DataCollection select v2;
                var q1_2 = from V2DataOnGrid item in q1 from x in item select x;
                var q2_2 = from V2DataCollection item in q2 from x in item select x;
                var q3 = q1_2.Union(q2_2);
                var max = (from item in q3 select item).Max(x => Math.Abs(x.Val.Magnitude - Mid));
                return from item in q3 where Math.Abs(item.Val.Magnitude - Mid) == max select item;
            }
        }
        public IEnumerable<Vector2> Twice
        {
            get
            {
                var q1 = from v2 in l where v2 is V2DataOnGrid select v2;
                var q2 = from v2 in l where v2 is V2DataCollection select v2;
                var q1_2 = from V2DataOnGrid item in q1 from x in item select x;
                var q2_2 = from V2DataCollection item in q2 from x in item select x;
                var q3 = q1_2.Concat(q2_2);
                var q4 = from item in q3 group item by item.Point into groups where groups.Count() > 1 select groups;
                return from x in q4 select x.Key;
            }
        }
    }

}
