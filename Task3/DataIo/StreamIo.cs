using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Shapes;

namespace DataIo
{
    public class StreamIo : IDataIo
    {
        public string HttpUtility { get; private set; }

        public List<IShape> ReadFile(string file)
        {
            List<IShape> shapes = new List<IShape>();
            StreamReader streamReader = new StreamReader(file);
            XmlDocument document = new XmlDocument();
            document.Load(streamReader);
            XmlNodeList nodeList = document.SelectNodes("/shapes");
            foreach (XmlNode node in nodeList)
            {
                if (node.Name.Equals("circle"))
                {
                    Circle circle;
                    if (node.Attributes.GetNamedItem("material").Value.Equals("paper"))
                        circle = new PaperCircle(double.Parse(node.Attributes.GetNamedItem("radius").Value), (Color)int.Parse(node.Attributes.GetNamedItem("color").Value));
                    else
                        circle = new MembraneCircle(double.Parse(node.Attributes.GetNamedItem("radius").Value));
                    shapes.Add(circle);
                }
                if (node.Name.Equals("square"))
                {
                    Square square;
                    if (node.Attributes.GetNamedItem("material").Value.Equals("paper"))
                        square = new PaperSquare(double.Parse(node.Attributes.GetNamedItem("side").Value), (Color)int.Parse(node.Attributes.GetNamedItem("color").Value));
                    else
                        square = new MembraneSquare(double.Parse(node.Attributes.GetNamedItem("side").Value));
                    shapes.Add(square);
                }
                if (node.Name.Equals("rectangle"))
                {
                    Rectangle rectangle;
                    if (node.Attributes.GetNamedItem("material").Value.Equals("paper"))
                        rectangle = new PaperRectangle(double.Parse(node.Attributes.GetNamedItem("firstSide").Value), double.Parse(node.Attributes.GetNamedItem("secondSide").Value), (Color)int.Parse(node.Attributes.GetNamedItem("color").Value));
                    else
                        rectangle = new MembraneRectangle(double.Parse(node.Attributes.GetNamedItem("firstSide").Value), double.Parse(node.Attributes.GetNamedItem("secondSide").Value));
                    shapes.Add(rectangle);
                }
            }
            return shapes;
        }

        public void WriteFile(IEnumerable<IShape> data, string file)
        {
            using (StreamWriter streamWriter = new StreamWriter(file))
            {
                XmlDocument document = new XmlDocument();
                XmlElement root = document.CreateElement("shapes");
                document.AppendChild(root);
                data.ToList().ForEach(element =>
                {
                    XmlElement shape = null;
                    if (element is Circle)
                    {
                        shape = document.CreateElement("circle");
                        shape.SetAttribute("radius", (element as Circle).Radius.ToString());
                    }
                    if (element is Square)
                    {
                        shape = document.CreateElement("square");
                        shape.SetAttribute("side", (element as Square).Side.ToString());
                    }
                    if (element is Rectangle)
                    {
                        shape = document.CreateElement("rectangle");
                        shape.SetAttribute("firstSide", (element as Rectangle).FirstSide.ToString());
                        shape.SetAttribute("secondSide", (element as Rectangle).SecondSide.ToString());
                    }
                    if (element is IPaper)
                        shape.SetAttribute("material", "paper");
                    else
                        shape.SetAttribute("material", "membrane");
                    shape.SetAttribute("color", (element as IMaterial).GetColor().ToString());
                    root.AppendChild(shape);
                });
                document.Save(streamWriter);
            }
        }
    }
}


