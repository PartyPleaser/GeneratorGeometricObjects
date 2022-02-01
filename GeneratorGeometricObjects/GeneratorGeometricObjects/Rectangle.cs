namespace GeneratorGeometricObjects
{
    /// <summary>
    /// describe rectangle by two point on the surface
    /// </summary>
    internal class Rectangle
    {
        internal Rectangle(double startPointX, double startPointY, double endPointX, double endPointY)
        {
            StartPointX = startPointX;
            StartPointY = startPointY;
            EndPointX = endPointX;
            EndPointY = endPointY;
        }

        public double StartPointX { get; private set; }
        public double StartPointY { get; private set; }
        public double EndPointX { get; private set; }
        public double EndPointY { get; private set; }
    }

}
