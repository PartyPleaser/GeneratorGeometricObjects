using Aspose.Gis.Geometries;
using System.Collections.Generic;

namespace GeneratorGeometricObjects
{
    public interface IGenerator
    {
        /// <summary>
        /// Generate geometry object in the square
        /// </summary>
        /// <param name="countOfObject"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        List<Geometry> Generate(int countOfObject, double size);
    }
}
