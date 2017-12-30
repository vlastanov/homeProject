using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SingleAPp.Models
{
    class Paragraph
    {
        private string content;

        public Paragraph(string content)
        {
            this.content = content;
        }

        public override string ToString()
        {
            return this.content;
        }
    }
}
