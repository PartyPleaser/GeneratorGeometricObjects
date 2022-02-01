using System;

namespace GeneratorGeometricObjects
{
    public class WrongInputCountOfObjectException : ArgumentException
    {
        public WrongInputCountOfObjectException() 
            : base("Parameter 'countOfObject' should be more than 0")
        { }
    }
}
