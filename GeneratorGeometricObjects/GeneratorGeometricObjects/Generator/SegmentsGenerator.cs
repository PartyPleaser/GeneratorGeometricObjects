using Aspose.Gis.Geometries;
using System;
using System.Collections.Generic;

namespace GeneratorGeometricObjects
{
    internal class SegmentsGenerator : IGenerator
    {
        /// <summary>
        /// Generate Segments in the square with side 'size'
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

            double coordinateX1, coordinateY1, coordinateX2, coordinateY2;

            List<Geometry> lineList = new List<Geometry>();
            Random rnd = new Random();

            RectangleSpliter rectangleSpliter = new RectangleSpliter();
            List<Rectangle> rectangleList = rectangleSpliter.Split(countOfObject, size);

            foreach (Rectangle rectangle in rectangleList)
            {
                List<Point> points = new List<Point>();
                coordinateX1 = rnd.NextDouble() * (rectangle.EndPointX - rectangle.StartPointX) + rectangle.StartPointX;
                coordinateY1 = rnd.NextDouble() * (rectangle.EndPointY - rectangle.StartPointY) + rectangle.StartPointY;
                coordinateX2 = rnd.NextDouble() * (rectangle.EndPointX - rectangle.StartPointX) + rectangle.StartPointX;
                coordinateY2 = rnd.NextDouble() * (rectangle.EndPointY - rectangle.StartPointY) + rectangle.StartPointY;
                Point startPoint = new Point(coordinateX1, coordinateY1);
                Point endPoint = new Point(coordinateX2, coordinateY2);
                points.Add(startPoint);
                points.Add(endPoint);
                LineString line = new LineString(points);
                lineList.Add(line);
            }
            return lineList;
        }
    }
}
