using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;

namespace GeneratorGeometricObjects
{
    /// <summary>
    /// Points Generator
    /// </summary>
    internal class PointsGenerator : IGenerator
    {
        /// <summary>
        /// Generate points in the square with side 'size'
        /// </summary>
        /// <param name="countOfObject"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <exception cref="WrongInputCountOfObjectException"></exception>
        /// <exception cref="WrongInputSizeException"></exception>
        public List<Geometry> Generate(int countOfObject, double size)
        {
            if (countOfObject <= 0)
                throw new WrongInputCountOfObjectException();
            if (size <= 0)
                throw new WrongInputSizeException();

            double coordinateX, coordinateY;

            List<Geometry> pointlist = new List<Geometry>();
            Random rnd = new Random();

            RectangleSpliter rectangleSpliter = new RectangleSpliter();
            List<Rectangle> rectangleList = rectangleSpliter.Split(countOfObject, size);

            foreach (Rectangle rectangle in rectangleList)
            {
                coordinateX = rnd.NextDouble() * (rectangle.EndPointX - rectangle.StartPointX) + rectangle.StartPointX;
                coordinateY = rnd.NextDouble() * (rectangle.EndPointY - rectangle.StartPointY) + rectangle.StartPointY;
                Point newPoint = new Point(coordinateX, coordinateY);
                pointlist.Add(newPoint);
            }
            return pointlist;
        }
    }
}
