using System.Text;

namespace BlagoevgradArt.Core.Extensions
{
    public static class StringExtensions
    {
        public static string TransliterateCyrillicToLatin(this string input)
        {
            StringBuilder result = new StringBuilder(input);
            int resultIndex = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (CyrillicToLatin.TryGetValue(input[i], out string? toInsert))
                {
                    result.Insert(resultIndex, toInsert);
                    result.Remove(resultIndex + toInsert.Length, 1);
                    resultIndex += toInsert.Length;
                }
                else
                {
                    resultIndex++;
                }
            }

            return result.ToString().Trim();
        }

        private static Dictionary<char, string> CyrillicToLatin = new Dictionary<char, string>()
        {
            {'А', "A"}, {'а', "a"}, {'Б', "B"}, {'б', "b"},
            {'В', "V"}, {'в', "v"}, {'Г', "G"}, {'г', "g"},
            {'Д', "D"}, {'д', "d"}, {'Е', "E"}, {'е', "e"},
            {'Ё', "YO"}, {'ё', "yo"}, {'Ж', "ZH"}, {'ж', "zh"},
            {'З', "Z"}, {'з', "z"}, {'И', "I"}, {'и', "i"},
            {'Й', "Y"}, {'й', "y"}, {'К', "K"}, {'к', "k"},
            {'Л', "L"}, {'л', "l"}, {'М', "M"}, {'м', "m"},
            {'Н', "N"}, {'н', "n"}, {'О', "O"}, {'о', "o"},
            {'П', "P"}, {'п', "p"}, {'Р', "R"}, {'р', "r"},
            {'С', "S"}, {'с', "s"}, {'Т', "T"}, {'т', "t"},
            {'У', "U"}, {'у', "u"}, {'Ф', "F"}, {'ф', "f"},
            {'Х', "H"}, {'х', "h"}, {'Ц', "TS"}, {'ц', "ts"},
            {'Ч', "CH"}, {'ч', "ch"}, {'Ш', "SH"}, {'ш', "sh"},
            {'Щ', "SHT"}, {'щ', "sht"}, {'Ъ', "a"}, {'ъ', "a"},
            {'Ы', "Y"}, {'ы', "y"}, {'Э', "E"}, {'э', "e"},
            {'Ю', "IU"}, {'ю', "iu"}, {'Я', "YA"}, {'я', "ya"}
        };
    }
}
