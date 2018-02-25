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
            //string bookName = "Onore_dxo_Balzak_-_Velichie_i_padenie_na_kurtizankite_-5400-b";
            string bookName = "GreatFortunesHowTheyweremade";

            Обработка1(bookName);
            Обработка2(bookName);
        }

        private static void Обработка1(string bookName)
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fileInput = dir + @"\TestDir\Input\" + bookName + ".txt";
            string fileOutput = dir + @"\TestDir\РедИзречение\"+bookName+".txt";

            using (StreamReader sr = new StreamReader(fileInput))
            {
                string цялатаКнига = sr.ReadToEnd();

                var book = new WholeBook(цялатаКнига);

                File.WriteAllLines(fileOutput, book.sentences);
                //File.WriteAllLines(fileOutput, book.paragraphs);
                //File.WriteAllLines(fileOutput, book.glavi);
            }
        }

        private static void Обработка2(string bookName)
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string fileInput = dir + @"\TestDir\РедИзречение\" + bookName + ".txt";
            string fileOutput = dir + @"\TestDir\РедИзречение2\" + bookName + ".txt";

            using (StreamReader sr = new StreamReader(fileInput))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    File.AppendAllText(fileOutput, line);
                    File.AppendAllText(fileOutput, "\r\n");
                }
                

                //var book = new WholeBook(цялатаКнига);

                //File.WriteAllLines(fileOutput, book.sentences);
                //File.WriteAllLines(fileOutput, book.paragraphs);
                //File.WriteAllLines(fileOutput, book.glavi);
            }
        }
    }
}
