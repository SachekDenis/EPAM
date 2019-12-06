using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataIo
{
    public class XmlIo : IDataIo
    {
        public List<IShape> ReadFile(string file)
        {
            List<IShape> shapes = new List<IShape>();
            using (XmlReader reader = XmlReader.Create(file))
            {
                while(reader.Read())
                {
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.None:
                            break;
                        case XmlNodeType.Element:
                            {
                                if(reader.Name.Equals("circle"))
                                {
                                    Circle circle;
                                    if (reader.GetAttribute("material").Equals("paper"))
                                        circle = new PaperCircle(double.Parse(reader.GetAttribute("radius")), int.Parse(reader.GetAttribute("color"))));
                                }
                            }
                            break;
                        case XmlNodeType.Attribute:
                            break;
                        default:
                            break;
                    }
                }
            }
            return shapes;
        }

        public void WriteFile(List<IShape> data, string file)
        {
            using (XmlWriter writer = XmlWriter.Create(file))
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("shapes");
                data.ForEach(element =>
                {
                    if (element is Circle)
                    {
                        writer.WriteStartElement("circle");
                        writer.WriteAttributeString("radius", (element as Circle).Radius.ToString());
                    }
                    if (element is Square)
                    {
                        writer.WriteStartElement("square");
                        writer.WriteAttributeString("side", (element as Square).Side.ToString());
                    }
                    if(element is Rectangle)
                    {
                        writer.WriteStartElement("rectangle");
                        writer.WriteAttributeString("firstSide", (element as Rectangle).FirstSide.ToString());
                        writer.WriteAttributeString("secondSide", (element as Rectangle).SecondSide.ToString());
                    }
                    if(element is IPaper)
                        writer.WriteAttributeString("material", "paper");
                    else
                        writer.WriteAttributeString("material", "membrane");
                    writer.WriteAttributeString("color", (element as IMaterial).GetColor().ToString());
                    writer.WriteEndElement();
                });
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }
        }
    }
}
