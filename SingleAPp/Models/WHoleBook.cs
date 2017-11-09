using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingleAPp.Models
{
    class WholeBook
    {
        private string content;

        public WholeBook(string content)
        {
            this.content = content;
        }

        public List<string> ParagraphsDecorated(Func<string, string> SentenceOnNewLine)
        {
            var pars = this.content.
                  Split(new string[] { "\r\n" }, StringSplitOptions.None);

            List<string> paragraphs = new List<string>();

            for (int i = 0; i < pars.Length; i++)
            {
                var current = pars[i];
                var builder = new StringBuilder();

                current = SentenceOnNewLine(current);
                if (current == "") continue;

                builder.AppendLine("-------- " + i + " --------");

                builder.Append(current);
                var result = builder.ToString();
                paragraphs.Add(result);
            }

            return paragraphs;
        }

        

    }
}
