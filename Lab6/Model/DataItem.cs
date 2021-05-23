using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;
using System.Collections;
using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;

namespace Lab3
{
    //------------------>DataItem<---------------------
    [Serializable]
    public struct DataItem : ISerializable
    {
        //
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Point_X", Point.X);
            info.AddValue("Point_Y", Point.Y);
            info.AddValue("Val", Val);
        }

        public DataItem(SerializationInfo info, StreamingContext streamingContext)
        {
            float x = info.GetSingle("Point_X");
            float y = info.GetSingle("Point_Y");
            Point = new Vector2(x, y);
            Val = (Complex)info.GetValue("Val", typeof(System.Numerics.Complex));
        }


        //--------------------старое-----------------
        public Vector2 Point   //координаты двумерной точки
        { get; set; }
        public Complex Val      //комплексное значение электромагнитного поля
        { get; set; }

        public DataItem(Vector2 p, Complex v)
        {
            Point = p;
            Val = v;
        }
        public override string ToString()
        {
            return "(Point: " + Point + " Value: " + Val + ")";
        }

        public string ToString(string format) //LAB2
        {
            return Point.ToString(format) + ": " + Val.ToString(format) + " - " + Val.Magnitude.ToString(format) + "\n";
        }
            /*возвращает строку, содержащую координаты точки, в которой измеряется поле,
            комплексное значение поля в этой точке и модуль значения поля, 
            и использует параметр format для чисел с плавающей запятой*/
    }
}
