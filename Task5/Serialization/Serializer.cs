using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TreeApp;

namespace Serialization
{
    public class Serializer<T>
    {
        public void Serialize(T serializeObject, string path)
        {
            var serializer = new DataContractSerializer(typeof(T));
            using (XmlWriter xmlWriter = XmlWriter.Create(path))
            {
                serializer.WriteObject(xmlWriter, serializeObject);
            }
        }

        public T Deserialize(string path)
        {
            var serializer = new DataContractSerializer(typeof(T));
            using (XmlReader xmlReader = XmlReader.Create(path))
            {
                return (T)serializer.ReadObject(xmlReader);
            }
        }
    }
}
