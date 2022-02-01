namespace GeneratorGeometricObjects
{
    /// <summary>
    /// Main class to work with generators
    /// </summary>
    public static class Generators
    {
        static Generators()
        {
            PointsGenerator = new PointsGenerator();
            SegmentsGenerator = new SegmentsGenerator();
        }

        public static IGenerator PointsGenerator { get; private set; }
        public static IGenerator SegmentsGenerator { get; private set; }
    }
}
