using System;

namespace GeneratorGeometricObjects
{
    public class WrongInputSizeException : ArgumentException
    {
        public WrongInputSizeException()
            : base("Parameter 'size' should be more than 0")
        { }
    }
}
