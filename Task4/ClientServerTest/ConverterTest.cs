using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslitConverter;

namespace ClientServerTest
{
    /// <summary>
    /// Defines test class ConverterTest.
    /// </summary>
    [TestClass]
    public class ConverterTest
    {
        /// <summary>
        /// Defines the test method ConvertRussianStringMustReturnValidResult.
        /// </summary>
        /// <param name="russianText">The russian text.</param>
        /// <param name="translitText">The translit text.</param>
        [TestMethod]
        [DataRow("русский","russkij")]
        [DataRow("быстро", "bistro")]
        public void ConvertRussianStringMustReturnValidResult(string russianText,string translitText)
        {
            Converter converter = new Converter();
            string converterText = converter.ToTranslit(russianText);

            Assert.AreEqual(translitText, converterText);
        }

        /// <summary>
        /// Defines the test method ConvertEmptyStringMustThrowsExeption.
        /// </summary>
        /// <param name="text">The text.</param>
        [TestMethod]
        [DataRow("")]
        public void ConvertEmptyStringMustThrowsExeption(string text)
        {
            Converter converter = new Converter();
            Assert.ThrowsException<ArgumentException>(()=>converter.ToTranslit(text));

        }

        /// <summary>
        /// Defines the test method ConvertNullStringMustThrowsExeption.
        /// </summary>
        /// <param name="text">The text.</param>
        [TestMethod]
        [DataRow(null)]
        public void ConvertNullStringMustThrowsExeption(string text)
        {
            Converter converter = new Converter();
            Assert.ThrowsException<ArgumentNullException>(() => converter.ToTranslit(text));

        }
    }
}
