using DataIo;
using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Box
{
    public class Box
    {
        private List<IShape> shapes = new List<IShape>();

        public void AddShape(IShape shape)
        {
            if (!shapes.Contains(shape) || shapes.Count == 20)
                shapes.Add(shape);
        }

        public IShape FindAt(int index)
        {
            return shapes.ElementAt(index);
        }

        public IShape Find(IShape shape)
        {
            return shapes.Find(e => e == shape);
        }

        public void ReplaceAt(int index, IShape shape)
        {
            shapes[index] = shape;
        }

        public IShape PopAt(int index)
        {
            IShape searchedShape = shapes.ElementAt(index);
            shapes.Remove(searchedShape);
            return searchedShape;
        }

        public int Count()
        {
            return shapes.Count;
        }

        public double TotalArea()
        {
            return shapes.Select(e => e.Area()).Sum();
        }

        public double TotalPerimeter()
        {
            return shapes.Select(e => e.Perimeter()).Sum();
        }

        public List<Circle> GetAllCircles()
        {
            return shapes.Where(e => e is Circle).Select(e => e as Circle).ToList();
        }

        public List<IMembrane> GetAllMembrane()
        {
            return shapes.Where(e => e is IMembrane).Select(e => e as IMembrane).ToList();
        }

        public void SaveAllShapesXmlWriter(string file)
        {
            SaveAllShapes(file, new XmlIo());
        }
        public void SaveAllShapesStreamWriter(string file)
        {
            SaveAllShapes(file, new StreamIo());
        }
        public void SavePaperShapesXmlWriter(string file)
        {
            SavePaperShapes(file, new XmlIo());
        }
        public void SavePaperShapesStreamWriter(string file)
        {
            SavePaperShapes(file, new StreamIo());
        }
        public void SaveMembraneShapesXmlWriter(string file)
        {
            SaveMembraneShapes(file, new XmlIo());
        }
        public void SaveMembraneShapesStreamWriter(string file)
        {
            SaveMembraneShapes(file, new StreamIo());
        }

        public void ReadShapesXmlReader(string file)
        {
            ReadAllShapes(file, new XmlIo());
        }

        public void ReadShapesStreamReader(string file)
        {
            ReadAllShapes(file, new StreamIo());
        }

        private void SaveAllShapes(string file,IDataIo writer)
        {
            writer.WriteFile(shapes, file);
        }

        private void SavePaperShapes(string file, IDataIo writer)
        {
            writer.WriteFile(shapes.Where(e=>e is IPaper), file);
        }

        private void SaveMembraneShapes(string file, IDataIo writer)
        {
            writer.WriteFile(shapes.Where(e => e is IMembrane), file);
        }

        private void ReadAllShapes(string file, IDataIo reader)
        {
            shapes = reader.ReadFile(file);
        }
    }
}
