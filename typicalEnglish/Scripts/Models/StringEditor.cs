using System.Text.RegularExpressions;

namespace typicalEnglish.Scripts.Models
{
    class StringEditor
    {
        private static string Str { get; set; }

        public static string RemoveExcessSymbols(string str)
        {
            if (str != null && str.Length > 0)
            {
                Str = str.ToLower();
                Str = Regex.Replace(Str, @"\s+", " ");
                RemoveSpacesAtBeginning();
                RemoveSpacesAtEnd();
                return Str;
            }
            return str;
        }

        private static void RemoveSpacesAtBeginning()
        {
            while (Str[0] == ' ')
                Str = Str.Remove(0, 1);
        }

        private static void RemoveSpacesAtEnd()
        {
            while (Str[Str.Length - 1] == ' ')
                Str = Str.Remove(Str.Length - 1);
        }

    }
}
