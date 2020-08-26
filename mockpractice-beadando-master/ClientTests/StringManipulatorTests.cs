using MockPractice.StringManipulator;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientTests
{
    [TestFixture]
    class StringManipulatorTests
    {
        StringManipulator stringManipulator;
        [SetUp]
        public void Setup()
        {
            stringManipulator = new StringManipulator();
        }

        [TestCase('a')]
        [TestCase('e')]
        [TestCase('i')]
        [TestCase('o')]
        [TestCase('u')]
        public void IsVowel_Should_Return_True_When_CalledWithTheTestParams(char c)
        {
            var result = stringManipulator.IsVowel(c);

            Assert.IsTrue(result);
        }

        [TestCase('q')]
        [TestCase('w')]
        [TestCase('r')]
        [TestCase('t')]
        [TestCase('z')]
        public void IsVowel_Should_Return_False_When_CalledWithTheTestParams(char c)
        {
            var result = stringManipulator.IsVowel(c);

            Assert.IsFalse(result);
        }

        [TestCase("kutya")]
        public void Transform_Should_Return_VowelsFirst_And_ConsonantsSecond_When_Called(string word)
        {
            var result = stringManipulator.Transform(word);

            Assert.AreEqual(result, "uakty");
        }

        [TestCase("MACSKA")]
        public void Transform_Should_Return_WithLoweredAndTransformed_When_Called(string word)
        {
            var result = stringManipulator.Transform(word);

            Assert.AreEqual(result, "aamcsk");
        }

        [TestCase("")]
        public void Transform_Should_Return_EmptyString_When_CalledWithEmptyString(string word)
        {
            var result = stringManipulator.Transform(word);

            Assert.AreEqual(result, "");
        }

    }
}
