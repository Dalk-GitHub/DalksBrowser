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
        public static T Load<T>(string fileName)
        {
            T list;
            if (File.Exists(fileName))
            {
                using (var stream = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    var formatter = new BinaryFormatter();
                    list = (T)
                        formatter.Deserialize(stream);
                }
            }
            else
                throw new IOException("File not found");
            return list;
        }
        public static void Save<T>(string fileName, T list)
        {
            using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, list);
            }
        }
    }
}
