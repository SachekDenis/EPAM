using DataIo;
using Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxProject
{
    /// <summary>
    /// Class Box.
    /// </summary>
    public class Box
    {
        /// <summary>
        /// The shapes
        /// </summary>
        private List<IShape> shapes = new List<IShape>();

        /// <summary>
        /// Adds the shape.
        /// </summary>
        /// <param name="shape">The shape.</param>
        public void AddShape(IShape shape)
        {
            if(shape == null)
                throw new ArgumentNullException();
            if (!shapes.Contains(shape) && shapes.Count < 20)
                shapes.Add(shape);
        }

        /// <summary>
        /// Finds shape at index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Shape.</returns>
        public IShape FindAt(int index)
        {
            return shapes.ElementAt(index);
        }

        /// <summary>
        /// Finds the specified shape.
        /// </summary>
        /// <param name="shape">The shape.</param>
        /// <returns>Shape.</returns>
        public IShape Find(IShape shape)
        {
            if(shape == null)
                throw new ArgumentNullException();
            return shapes.Find(e => e == shape);
        }

        /// <summary>
        /// Replaces at index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="shape">The shape.</param>
        public void ReplaceAt(int index, IShape shape)
        {
            if(shape == null)
                throw new ArgumentNullException();
            shapes[index] = shape;
        }

        /// <summary>
        /// Pops shape at index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>Shape.</returns>
        public IShape PopAt(int index)
        {
            IShape searchedShape = shapes.ElementAt(index);
            shapes.Remove(searchedShape);
            return searchedShape;
        }

        /// <summary>
        /// Get count of shapes.
        /// </summary>
        /// <returns>Count</returns>
        public int Count()
        {
            return shapes.Count;
        }


        /// <summary>Gets the total area.</summary>
        /// <returns>Total area</returns>
        public double GetTotalArea()
        {
            return shapes.Select(e => e.GetArea()).Sum();
        }


        /// <summary>Gets the total perimeter.</summary>
        /// <returns>Tital perimeter.</returns>
        public double GetTotalPerimeter()
        {
            return shapes.Select(e => e.GetPerimeter()).Sum();
        }

        /// <summary>Gets all shapes.</summary>
        /// <returns>List of shapes.</returns>
        public List<IShape> GetAllShapes()
        {
            return shapes;
        }

        /// <summary>
        /// Gets all circles.
        /// </summary>
        /// <returns>List if circles.</returns>
        public List<Circle> GetAllCircles()
        {
            return shapes.Where(e => e is Circle).Select(e => e as Circle).ToList();
        }

        /// <summary>
        /// Gets all membrane.
        /// </summary>
        /// <returns>List if membrane.</returns>
        public List<IMembrane> GetAllMembrane()
        {
            return shapes.Where(e => e is IMembrane).Select(e => e as IMembrane).ToList();
        }

        /// <summary>
        /// Saves all shapes XML writer.
        /// </summary>
        /// <param name="file">The file.</param>
        public void SaveAllShapesXmlWriter(string file)
        {
            SaveAllShapes(file, new XmlIo());
        }
        /// <summary>
        /// Saves all shapes stream writer.
        /// </summary>
        /// <param name="file">The file.</param>
        public void SaveAllShapesStreamWriter(string file)
        {
            SaveAllShapes(file, new StreamIo());
        }
        /// <summary>
        /// Saves the paper shapes XML writer.
        /// </summary>
        /// <param name="file">The file.</param>
        public void SavePaperShapesXmlWriter(string file)
        {
            SavePaperShapes(file, new XmlIo());
        }
        /// <summary>
        /// Saves the paper shapes stream writer.
        /// </summary>
        /// <param name="file">The file.</param>
        public void SavePaperShapesStreamWriter(string file)
        {
            SavePaperShapes(file, new StreamIo());
        }
        /// <summary>
        /// Saves the membrane shapes XML writer.
        /// </summary>
        /// <param name="file">The file.</param>
        public void SaveMembraneShapesXmlWriter(string file)
        {
            SaveMembraneShapes(file, new XmlIo());
        }
        /// <summary>
        /// Saves the membrane shapes stream writer.
        /// </summary>
        /// <param name="file">The file.</param>
        public void SaveMembraneShapesStreamWriter(string file)
        {
            SaveMembraneShapes(file, new StreamIo());
        }

        /// <summary>
        /// Reads the shapes XML reader.
        /// </summary>
        /// <param name="file">The file.</param>
        public void ReadShapesXmlReader(string file)
        {
            ReadAllShapes(file, new XmlIo());
        }

        /// <summary>
        /// Reads the shapes stream reader.
        /// </summary>
        /// <param name="file">The file.</param>
        public void ReadShapesStreamReader(string file)
        {
            ReadAllShapes(file, new StreamIo());
        }

        /// <summary>
        /// Saves all shapes.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="writer">The writer.</param>
        private void SaveAllShapes(string file,IDataIo writer)
        {
            writer.WriteFile(shapes, file);
        }

        /// <summary>
        /// Saves the paper shapes.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="writer">The writer.</param>
        private void SavePaperShapes(string file, IDataIo writer)
        {
            writer.WriteFile(shapes.Where(e=>e is IPaper), file);
        }

        /// <summary>
        /// Saves the membrane shapes.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="writer">The writer.</param>
        private void SaveMembraneShapes(string file, IDataIo writer)
        {
            writer.WriteFile(shapes.Where(e => e is IMembrane), file);
        }

        /// <summary>
        /// Reads all shapes.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="reader">The reader.</param>
        private void ReadAllShapes(string file, IDataIo reader)
        {
            shapes = reader.ReadFile(file);
        }
    }
}
