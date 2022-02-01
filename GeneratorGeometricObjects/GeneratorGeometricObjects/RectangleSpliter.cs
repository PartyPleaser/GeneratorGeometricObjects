using System;
using System.Collections.Generic;

namespace GeneratorGeometricObjects
{
    /// <summary>
    /// Split the square to rectangles. 
    /// First devide the square vertically in two half and then by horizontal if need it
    /// </summary>
    internal class RectangleSpliter
    {
        /// <summary>
        /// split square to Rectangles
        /// </summary>
        /// <param name="countOfObject"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        /// <exception cref="WrongInputCountOfObjectException"></exception>
        /// <exception cref="WrongInputSizeException"></exception>
        public List<Rectangle> Split(int countOfObject, double size)
        {
            if (countOfObject <= 0)
                throw new WrongInputCountOfObjectException();
            if (size <= 0)
                throw new WrongInputSizeException();

            double additionalSplitCount;
            double stepByX, stepByY;
            int degree;
            int devidedByHorizontalCount, devidedByVerticalCount;
            bool isNeedShiftByX = false;
            bool isNeedShiftByY = false;
            double coordinateX, coordinateY;

            List<Rectangle> rectangles = new List<Rectangle>();
            if (countOfObject == 1)
            {
                rectangles.Add(new Rectangle(0, 0, size, size));
                return rectangles;
            }

            //divide square by vertically then by horizontal
            //find out how many we made vertical and horizontal lines
            degree = 1;
            devidedByVerticalCount = 0;
            devidedByHorizontalCount = 0;
            while (countOfObject >= Math.Pow(2, degree))
            {
                if (degree % 2 > 0)
                    devidedByVerticalCount = devidedByVerticalCount * 2 + 1;
                else
                    devidedByHorizontalCount = devidedByHorizontalCount * 2 + 1;
                degree++;
            }
            degree--;
            //find out how many we need additional split.
            //these split should be evenly in the square
            additionalSplitCount = countOfObject - Math.Pow(2, degree);
            stepByX = size / (devidedByVerticalCount + 1);
            stepByY = size / (devidedByHorizontalCount + 1);
            for (double y = 0; y < size; y = y + stepByY)
            {
                for (double x = 0; x < size; x = x + stepByX)
                {
                    coordinateX = x;
                    coordinateY = y;
                    // use 'isNeedShiftByY' and 'isNeedShiftByX' to get evenly split
                    if (countOfObject > 8)
                    {
                        if (isNeedShiftByY)
                        {
                            if (coordinateY + size / 2 < size)
                                coordinateY = coordinateY + size / 2;
                            else
                                coordinateY = coordinateY - size / 2;
                        }
                        if (isNeedShiftByX)
                        {
                            if (coordinateX + size / 2 < size)
                                coordinateX = coordinateX + size / 2;
                            else
                                coordinateX = coordinateX - size / 2;

                            isNeedShiftByY = !isNeedShiftByY;
                        }
                        isNeedShiftByX = !isNeedShiftByX;
                    }

                    if (additionalSplitCount > 0)
                    {   
                        if (degree % 2 > 0)
                        {
                            //additionally divide by horizontally 'additionalSplitCount' times
                            rectangles.Add(new Rectangle(coordinateX, coordinateY, coordinateX + stepByX, coordinateY + stepByY / 2));
                            rectangles.Add(new Rectangle(coordinateX, coordinateY + stepByY / 2, coordinateX + stepByX, coordinateY + stepByY));
                        }
                        else
                        {
                            //additionally divide by vertically 'additionalSplitCount' times
                            rectangles.Add(new Rectangle(coordinateX, coordinateY, coordinateX + stepByX / 2, coordinateY + stepByY));
                            rectangles.Add(new Rectangle(coordinateX + stepByX / 2, coordinateY, coordinateX + stepByX, coordinateY + stepByY));

                        }
                        additionalSplitCount--;
                    }
                    else
                    {
                        rectangles.Add(new Rectangle(coordinateX, coordinateY, coordinateX + stepByX, coordinateY + stepByY));
                    }
                }
            }
            return rectangles;
        }
    }
}
