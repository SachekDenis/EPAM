using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslitConverter;

namespace ClientServerTest
{
    [TestClass]
    public class ConverterTest
    {
        [TestMethod]
        [DataRow("русский","russkij")]
        [DataRow("быстро", "bistro")]
        public void ConvertRussianStringMustReturnValidResult(string russianText,string translitText)
        {
            Converter converter = new Converter();
            string converterText = converter.ToTranslit(russianText);

            Assert.AreEqual(translitText, converterText);
        }

        [TestMethod]
        [DataRow("")]
        public void ConvertEmptyStringMustThrowsExeption(string text)
        {
            Converter converter = new Converter();
            Assert.ThrowsException<ArgumentException>(()=>converter.ToTranslit(text));

        }

        [TestMethod]
        [DataRow(null)]
        public void ConvertNullStringMustThrowsExeption(string text)
        {
            Converter converter = new Converter();
            Assert.ThrowsException<ArgumentNullException>(() => converter.ToTranslit(text));

        }
    }
}
