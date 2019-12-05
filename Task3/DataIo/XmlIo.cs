using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataIo
{
    public class XmlIo:IDataIo
    {
        public List<IShape> ReadFile()
        {
            throw new NotImplementedException();
        }

        public void WriteFile(List<IShape> data, string file)
        {
            using (XmlWriter writer = XmlWriter.Create(file))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("shapes");
                data.ForEach(element =>
                {
                    if(element is Circle)
                    writer.WriteAttributeString("radius", (element as Circle).Radius.ToString());
                });
            }
        }
    }
}
