using Aspose.Gis.Geometries;

namespace GeneratorGeometricObjects
{
    public static class Util
    {
        /// <summary>
        /// check is point in the first quarter of the square
        /// </summary>
        /// <param name="point"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool IsPointInFisrtQuarter(IPoint point, double size)
        {
            if (point.X < size / 2 && point.Y < size / 2)
                return true;
            return false;
        }
        /// <summary>
        /// check is point in the second quarter of the square
        /// </summary>
        /// <param name="point"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool IsPointInSecondQuarter(IPoint point, double size)
        {
            if (point.X >= size / 2 && point.Y < size / 2)
                return true;
            return false;
        }
        /// <summary>
        /// check is point in the third quarter of the square
        /// </summary>
        /// <param name="point"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool IsPointInThirdQuarter(IPoint point, double size)
        {
            if (point.X < size / 2 && point.Y >= size / 2)
                return true;
            return false;
        }
        /// <summary>
        /// check is point in the fourth quarter of the square
        /// </summary>
        /// <param name="point"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static bool IsPointInFourthQuarter(IPoint point, double size)
        {
            if (point.X >= size / 2 && point.Y >= size / 2)
                return true;
            return false;
        }
    }
}
