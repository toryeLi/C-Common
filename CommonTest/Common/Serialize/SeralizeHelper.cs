using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Common.Serialize
{
    /// <summary>
    ///二进制序列化必须添加[Serializable]序列化特性
    /// </summary>
    public class SeralizeHelper
    {
        private static string CurrentDataPath = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 二进制序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="filePath">序列化内容保存的路径</param>
        public static string BinarySerializeToFile<T>(T t, string filePath = null)
        {
            if (!File.Exists(filePath))
            {
                filePath = Path.Combine(CurrentDataPath, t.GetType().FullName + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + "_BinarySerialize.txt");
            }
            using (Stream fStream = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fStream, t);
            }
            return filePath;
        }
        /// <summary>
        /// 传入二进制文件，返回类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="filePath">二进制文件类型</param>
        /// <returns></returns>
        public static T BinarySerializeToObject<T>(string filePath){
            object o = Activator.CreateInstance(typeof(T));
            if (File.Exists(filePath)) {
                using (Stream fStream = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite)) {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    fStream.Position = 0;
                   T t=(T) binaryFormatter.Deserialize(fStream);
                    return t;
                }
            }
            return default(T);
        } 
    }
}
