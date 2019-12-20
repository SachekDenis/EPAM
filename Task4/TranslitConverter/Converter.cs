using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslitConverter
{
    public class Converter
    {
        private Dictionary<string, string> translitPairs;

        public Converter()
        {
            translitPairs = new Dictionary<string, string>()
            {
                {"а", "a"},
                {"б", "b"},
                {"в", "v"},
                {"г", "g"},
                {"д", "d"},
                {"е", "e"},
                {"ё", "yo"},
                {"ж", "zh"},
                {"з", "z"},
                {"и", "i"},
                {"й", "j"},
                {"к", "k"},
                {"л", "l"},
                {"м", "m"},
                {"н", "n"},
                {"о", "o"},
                {"п", "p"},
                {"р", "r"},
                {"с", "s"},
                {"т", "t"},
                {"у", "u"},
                {"ф", "f"},
                {"х", "h"},
                {"ц", "c"},
                {"ч", "ch"},
                {"ш", "sh"},
                {"щ", "sch"},
                {"ъ", "j"},
                {"ы", "i"},
                {"ь", "j"},
                {"э", "e"},
                {"ю", "yu"},
                {"я", "ya"},
                {"А", "A"},
                {"Б", "B"},
                {"В", "V"},
                {"Г", "G"},
                {"Д", "D"},
                {"Е", "E"},
                {"Ё", "Yo"},
                {"Ж", "Zh"},
                {"З", "Z"},
                {"И", "I"},
                {"Й", "J"},
                {"К", "K"},
                {"Л", "L"},
                {"М", "M"},
                {"Н", "N"},
                {"О", "O"},
                {"П", "P"},
                {"Р", "R"},
                {"С", "S"},
                {"Т", "T"},
                {"У", "U"},
                {"Ф", "F"},
                {"Х", "H"},
                {"Ц", "C"},
                {"Ч", "Ch"},
                {"Ш", "Sh"},
                {"Щ", "Sch"},
                {"Ъ", "J"},
                {"Ы", "I"},
                {"Ь", "J"},
                {"Э", "E"},
                {"Ю", "Yu"},
                {"Я", "Ya"},
        };
        }

        public string ToTranslit(string russianText)
        {
            if (russianText == String.Empty)
                throw new ArgumentException();
            if (russianText == null)
                throw new ArgumentNullException();
            return russianText.Select(letter => translitPairs[letter.ToString()])
                              .Aggregate((prevTranslitString, curTranslitString) => String.Concat(prevTranslitString,curTranslitString));
        }
    }
}
