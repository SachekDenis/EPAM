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
            if (!shapes.Contains(shape))
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
            return shapes.Where(e=>e is Circle).Select(e=>e as Circle).ToList();
        }

        public List<IMembrane> GetAllMembrane()
        {
            return shapes.Where(e=>e is IMembrane).Select(e=>e as IMembrane).ToList();
        }
    }
}
