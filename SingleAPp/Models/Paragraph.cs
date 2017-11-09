using System;
using System.Collections.Generic;
using System.Text;

namespace SingleAPp.Models
{
    class Paragraph
    {
        
        public string SplitIntoSentences(string current)
        {
            var builder = new StringBuilder();

            current = current.Trim('\t');
            var sens = current
            .Split(new string[] { ". ", "! ", "? " }, StringSplitOptions.None);

            for (int j = 0; j < sens.Length; j++)
            {
                var sentes = sens[j];
                if (sentes=="") continue;
                
                if (containsDash(sentes,"— ")) continue;

                var containsComa = sentes.Contains(", ");
                if (containsComa)
                {
                    sentes = ReplaceFirst(sentes, ", ", ",\r\n\t");
                    if (containsComa)
                    {
                        sentes = ReplaceFirst(sentes,", ", ",\r\n\t\t");
                    }
                }

                builder.Append(j + " ");
                if (j==sens.Length-1)
                {
                    builder.Append(sentes);
                }
                else
                {
                    builder.AppendLine(sentes);
                }
            }
            var sentences = builder.ToString();
            return sentences;
        }

        public string ReplaceFirst(string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }

        Func<string,string, bool> containsDash = (current,spice) =>
        {
            var containsDash = current.Contains(spice);
            return containsDash;
         };
    }
}
