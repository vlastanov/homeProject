using System;
using System.Text;
using System.Text.RegularExpressions;

namespace SingleAPp.Models
{
    internal class Sentence
    {
        public string content = "";
        public string result = "";

        public Sentence(string content)
        {
            this.content = content;
            this.result = this.content;
            this.НовРедСледЗапетая();
            //this.NesvarshenoMinalo();
            //NewMethod2(" а ");
            //NewMethod2(" но ");
            //NewMethod2(" и ");
            //NewMethod2(" той ");
            //NewMethod2(" тя ");
        }

        private void NesvarshenoMinalo()
        {
            string keywords =
            @"(\p{L}*ваха|\p{L}*ваше|\p{L}*меха|\p{L}*меше|\p{L}*даха|\p{L}*даше|\p{L}*веха|\p{L}*веше|\p{L}*раха|\p{L}*раше|\p{L}*ряха|\p{L}*реше|\p{L}*лиха|\p{L}*тиха|\p{L}*щаха|\p{L}*сеха|\p{L}*меха|\p{L}*веха|\p{L}*маше|\p{L}*маха|\p{L}*сяха|\p{L}*сеше|\p{L}*каха|\p{L}*каше|\p{L}*таха|\p{L}*таше\|\p{L}*чеше|\p{L}*чеха|\p{L}*чаше|\p{L}*чаха|\p{L}*реше|\p{L}*реха|\p{L}*деше|\p{L}*дяха|\p{L}*вяха|\p{L}*вяше|\p{L}*аеше|\p{L}*аеха|\p{L}*таше|\p{L}*жеше|\p{L}*жеха)";
            //@"(\p{L}*аха|\p{L}*аше|\p{L}*еха|\p{L}*еше|\p{L}*яха|\p{L}*иха|\p{L}*яше)";

            Regex regex = new Regex(keywords);
            var matches = regex.Matches(content);

            var bd = new StringBuilder();

            if (matches.Count != 0)
            {
                bd.Append("м несв" + " ");
                foreach (Match m in matches)
                {
                    bd.Append(m.Value + " ");
                }
            }
            bd.AppendLine();
            bd.Append(this.result);
            this.result = bd.ToString();
        }

        private void NewMethod2(string patt)
        {
            var containsComa = this.result.Contains("," + patt);
            if (containsComa)
            {
                this.result = ReplaceFirst(this.result, "," + patt, ",\r\n" + patt.TrimStart());
            }
        }

        private void НовРедСледЗапетая()
        {
            //string first = @"(?<=[,;:\.!\?])\s|(?<=\bи\b)\s|\s(?=\bне\b)|\s(?=\bтой\b)|\s(?=\bто\b)|\s(?=\bв\b)|\s(?=\bсъщо както\b)|(?<=\bче\b)\s|(?<=\bможе\b)\s|(?<=\bще\b)\s|(?<=\bе\b)\s|(?<=\bтях\b)\s|(?<=\bсе\b)\s|\s(?=\bтя\b)|(?<=\bВ този момент\b)\s";
            //string first = @"(?<=[,;:\.!\?])\s|(?<=\bи\b)\s|\s(?=\bне\b)|\s(?=\bтой\b)|\s(?=\bто\b)|\s(?=\bсъщо както\b)|(?<=\bче\b)\s|(?<=\bможе\b)\s|(?<=\bще\b)\s|(?<=\bтях\b)\s|(?<=\bсе\b)\s|\s(?=\bтя\b)|(?<=\bВ този момент\b)\s";
            string first = @"(?<=[,;:\.!\?])\s";

            string[] sens = Regex.Split(this.result,first);
            var sb = new StringBuilder();
            for (int i = 0; i < sens.Length; i++)
            {
                sb.AppendLine(sens[i]);
            }
            this.result = sb.ToString();
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

        public override string ToString()
        {
            return this.result;
        }
    }
}