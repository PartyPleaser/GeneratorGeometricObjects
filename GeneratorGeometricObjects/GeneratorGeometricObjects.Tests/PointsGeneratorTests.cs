using Aspose.Gis.Geometries;
using NUnit.Framework;
using System.Collections.Generic;

namespace GeneratorGeometricObjects.Tests
{
    public class PointsGeneratorTests
    {
        private IGenerator _target;

        [SetUp]
        public void SetUp()
        {
            _target = Generators.PointsGenerator;
        }

        [Test]
        [TestCase(1, 10)]
        [TestCase(2, 10)]
        [TestCase(3, 10)]
        [TestCase(4, 10)]
        [TestCase(5, 10)]
        [TestCase(7, 10)]
        [TestCase(8, 10)]
        [TestCase(9, 10)]
        [TestCase(10, 10)]
        [TestCase(15, 10)]
        [TestCase(16, 10)]
        [TestCase(17, 10)]
        [TestCase(31, 10)]
        [TestCase(32, 10)]
        [TestCase(33, 10)]
        [TestCase(63, 10)]
        [TestCase(65, 10)]
        [TestCase(999, 1)]
        [TestCase(99999, 1)]
        [TestCase(999999, 1)]
        public void Should_Generate_Evenly(int countOfObject, double size)
        {
            //arrange
            int firstQuarter = 0;
            int secondQuarter = 0;
            int thirdQuarter = 0;
            int fourthQuarter = 0;

            //act
            List<Geometry> pointlist = _target.Generate(countOfObject, size);
            //should be almost the same objects in every quarter
            foreach (Point point in pointlist)
            {
                if (Util.IsPointInFisrtQuarter(point, size))
                    firstQuarter++;
                else if (Util.IsPointInSecondQuarter(point, size))
                    secondQuarter++;
                else if (Util.IsPointInThirdQuarter(point, size))
                    thirdQuarter++;
                else
                    fourthQuarter++;
            }
            //assert
            Assert.AreEqual(firstQuarter + secondQuarter + thirdQuarter + fourthQuarter, countOfObject);
            Assert.IsTrue(firstQuarter >= countOfObject / 4 && firstQuarter <= (countOfObject / 4) + 1);
            Assert.IsTrue(secondQuarter >= countOfObject / 4 && secondQuarter <= (countOfObject / 4) + 1);
            Assert.IsTrue(thirdQuarter >= countOfObject / 4 && thirdQuarter <= (countOfObject / 4) + 1);
            Assert.IsTrue(fourthQuarter >= countOfObject / 4 && fourthQuarter <= (countOfObject / 4) + 1);
        }

        [Test]
        [TestCase(0, 10)]
        [TestCase(-1, 0)]
        public void Should_ReturnWrong_InputCountOfObjectException(int countOfObject, double size)
        {
            var exception = Assert.Throws<WrongInputCountOfObjectException>(() => _target.Generate(countOfObject, size));
            Assert.AreEqual("Parameter 'countOfObject' should be more than 0", exception.Message);
        }

        [Test]
        [TestCase(1, 0)]
        [TestCase(11, -1)]
        public void Should_Return_WrongInputSizeException(int countOfObject, double size)
        {
            var exception = Assert.Throws<WrongInputSizeException>(() => _target.Generate(countOfObject, size));
            Assert.AreEqual("Parameter 'size' should be more than 0", exception.Message);
        }
    }
}