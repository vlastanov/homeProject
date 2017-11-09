using SingleAPp.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text;

namespace SingleAPp
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fileInput = dir + @"\TestDir\Symyrset_Moym_-_Edna_ljubov_v_Parizh_-6121-b.txt";
            string fileOutput = dir + @"\TestDir\Symyrset_Moym_-_Edna_ljubov_v_Parizh_-6121-bOutput.txt";
            
            using (StreamReader sr = new StreamReader(fileInput))
            {
                String line = sr.ReadToEnd();
                var paragraph = new Paragraph();
                var book = new WholeBook(line);
                File.WriteAllLines(fileOutput, book.ParagraphsDecorated(paragraph.SplitIntoSentences));
            }
        }
    }
}
