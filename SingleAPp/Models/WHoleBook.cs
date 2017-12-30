using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SingleAPp.Models
{
    class WholeBook
    {
        private string content;

        public List<string> glavi = new List<string>();
        public List<string> paragraphs = new List<string>();
        public List<string> sentences = new List<string>();

        public WholeBook(string content)
        {
            this.content = content;
            this.GlaviDecorated();
            this.ParagraphsDecorated();
            this.SentencesDecorated();
        }

        private void GlaviDecorated()
        {
            this.content.
                  Split(new string[] { "\r\n\r\n\r\n" }, StringSplitOptions.None)
                  .Where(glava => glava != "")
                  .ToList()
                  .ForEach(glava => this.glavi.Add(glava));
        }

        private void ParagraphsDecorated()
        {
            this.glavi.ForEach(glava =>
            {
                glava.Split(new string[] { "\r\n" }, StringSplitOptions.None)
                  .Where(paragraph => paragraph.Trim() != "")
                  .ToList()
                  .ForEach(paragraph => this.paragraphs.Add(new Paragraph(paragraph).ToString()));
            });
        }

        private void SentencesDecorated()
        {
            this.paragraphs.ForEach(paragraph =>
            {
                Regex.Split(paragraph, @"(?<=[\.!\?])\s+")
                    .Select(sentence => sentence.Trim())
                    .Where(x => !x.Contains("— "))
                    .ToList()
                    .ForEach(sentence => sentences.Add(new Sentence(sentence).ToString()));
            });

        }
    }
}
