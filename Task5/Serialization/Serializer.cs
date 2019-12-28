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
    /// <summary>
    /// Class Serializer.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Serializer<T>
    {
        /// <summary>
        /// Serializes the specified serialize object.
        /// </summary>
        /// <param name="serializeObject">The serialize object.</param>
        /// <param name="path">The path.</param>
        public void Serialize(T serializeObject, string path)
        {
            var serializer = new DataContractSerializer(typeof(T));
            using (XmlWriter xmlWriter = XmlWriter.Create(path))
            {
                serializer.WriteObject(xmlWriter, serializeObject);
            }
        }

        /// <summary>
        /// Deserializes the specified path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>T.</returns>
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
