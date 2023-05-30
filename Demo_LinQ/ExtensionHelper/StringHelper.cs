using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_LinQ.ExtensionHelper
{
    internal static class StringHelper
    {
        public static bool ContainsLetterE(this string text)
        {
            return text.ToLower().Contains("e");
        }

        public static bool ContainsLetter(this string text, char letter)
        {
            return text.ToLower().Contains(letter.ToString().ToLower());
        }
    }
}
