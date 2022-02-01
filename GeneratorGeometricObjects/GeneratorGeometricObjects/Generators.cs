using System;
using System.Collections.Generic;
using System.Text;

namespace GeneratorGeometricObjects
{
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
