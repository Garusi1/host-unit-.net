using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



namespace BE
{

    public static class Tools
    {




        /// <summary>
        /// deep cloning
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static T Clone<T>(this T source)
        {
            if (source == null)
                return default(T);
            if (!typeof(T).IsSerializable)
                throw new ArgumentException("The type must be serializable.", "source");
            IFormatter formatter = new BinaryFormatter();  // serialize or convert the object to a binary format
            Stream stream = new MemoryStream(); //כאן אפשר גם לשלח לקובץ עם נשמתמש בזרימה בהפנייה אחרת
            using (stream)
            {
                formatter.Serialize(stream, source); //מעבירים מהמקור לזרימת הנתונים
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }


        //public static T Clone<T>(this T source)
        //{
        //    var isNotSerializable = !typeof(T).IsSerializable;
        //    if (isNotSerializable)
        //        throw new ArgumentException("The type must be serializable.", "source");
        //    var sourceIsNull = ReferenceEquals(source, null);
        //    if (sourceIsNull)
        //        return default(T);
        //    var formatter = new BinaryFormatter();
        //    using (var stream = new MemoryStream())
        //    {
        //        formatter.Serialize(stream, source);
        //        stream.Seek(0, SeekOrigin.Begin);
        //        return (T)formatter.Deserialize(stream);
        //    }
        //}




        ///// <summary>
        ///// deep cloning
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="source"></param>
        ///// <returns></returns>
        //public static T Clone<T>(this T source)
        //{
        //    if (source == null)
        //        return default(T);
        //    if (!typeof(T).IsSerializable)
        //        throw new ArgumentException("The type must be serializable.", "source");
        //    IFormatter formatter = new BinaryFormatter();
        //    Stream stream = new MemoryStream();
        //    using (stream)
        //    {
        //        formatter.Serialize(stream, source);
        //        stream.Seek(0, SeekOrigin.Begin);
        //        return (T)formatter.Deserialize(stream);
        //    }
        //}



        public static bool ValidateID(string IDNum)
        {
            // Validate correct input
            if (!System.Text.RegularExpressions.Regex.IsMatch(IDNum, @"^\d{5,9}$"))
                return false;

            // The number is too short - add leading 0000
            while (IDNum.Length < 9)
                IDNum = '0' + IDNum;

            // CHECK THE ID NUMBER
            int mone = 0;
            int incNum;
            for (int i = 0; i < 9; i++)
            {
                incNum = Convert.ToInt32(IDNum[i].ToString()) * ((i % 2) + 1);
                if (incNum > 9)
                    incNum -= 9;
                mone += incNum;
            }
            return (mone % 10 == 0);
        }


        [Serializable]
        public class UnLogicException : Exception
        {
            public int capacity { get; private set; }
            public UnLogicException() : base() { }
            public UnLogicException(string message) : base(message) { }
            public UnLogicException(string message, Exception inner) : base(message, inner) { }
            protected UnLogicException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
            // special constructor for our custom exception
            public UnLogicException(int capacity, string message) : base(message)
            {
                this.capacity = capacity;
            }
            override public string ToString()
            {
                return "UnLogicException: שגיאה לוגית  " + Message;
            }
        }



    }
}
