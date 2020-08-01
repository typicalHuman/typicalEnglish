using System.Text.RegularExpressions;

namespace typicalEnglish.Scripts.Models
{
    /// <summary>
    /// Class for removing garbage from string.
    /// </summary>
    class StringEditor
    {
        private static string Str { get; set; }

        /// <param name="str">String which needs to remove garbage.</param>
        /// <returns>String with low letters and without excess spaces</returns>
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
