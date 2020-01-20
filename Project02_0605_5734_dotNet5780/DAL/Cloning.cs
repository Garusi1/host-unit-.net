using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public static class Cloning
    {
        /// <summary>
        /// deep cloning
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        ////public static T Clone<T>(this T source)
        ////{
        ////    if (source == null)
        ////        return default(T);
        ////    if (!typeof(T).IsSerializable)
        ////        throw new ArgumentException("The type must be serializable.", "source");
        ////    IFormatter formatter = new BinaryFormatter();  // serialize or convert the object to a binary format
        ////    Stream stream = new MemoryStream(); //כאן אפשר גם לשלח לקובץ עם נשמתמש בזרימה בהפנייה אחרת
        ////    using (stream)
        ////    {
        ////        formatter.Serialize(stream, source); //מעבירים מהמקור לזרימת הנתונים
        ////        stream.Seek(0, SeekOrigin.Begin);
        ////        return (T)formatter.Deserialize(stream);
        ////    }
        ////}



        public static T Clone<T>(this T source)
        {
            var isNotSerializable = !typeof(T).IsSerializable;
            if (isNotSerializable)
                throw new ArgumentException("The type must be serializable.", "source");
            var sourceIsNull = ReferenceEquals(source, null);
            if (sourceIsNull)
                return default(T);
            var formatter = new BinaryFormatter();
            using (var stream = new MemoryStream())
            {
                formatter.Serialize(stream, source);
                stream.Seek(0, SeekOrigin.Begin);
                return (T)formatter.Deserialize(stream);
            }
        }





    }
}
