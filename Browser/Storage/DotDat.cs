using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chromium
{
    public static class DotDat
    {
        /// <summary>
        /// Save Serializible Class to File
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T Load<T>(string fileName)
        {
            T res;
            if (File.Exists(fileName))
            {
                // get stram
                using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    // deserialize
                    var formatter = new BinaryFormatter();
                    res = (T)
                        formatter.Deserialize(stream);
                }
            }
            else
                //throw execption if file not existing
                throw new IOException("File not found");
            return res;
        }
        /// <summary>
        /// Load serializible class from File
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <param name="list"></param>
        public static void Save<T>(string fileName, T list)
        {
            using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                // serialize
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, list);
            }
        }
    }
}
