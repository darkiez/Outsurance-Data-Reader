using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace OutSurance
{
    class Program
    {
        static void Main(string[] args)
        {

            var fName = new List<string>();
            var lName = new List<string>();
            var address = new List<string>();

            string path = @"C:\Worskspace\WeMakeItHappen\Outsurance\Outsurance\data.csv";
            string firstFilePath = @"C:\Worskspace\WeMakeItHappen\Outsurance\Outsurance\FirstFileData.txt";
            string secondFilePath = @"C:\Worskspace\WeMakeItHappen\Outsurance\Outsurance\SecondFileData.txt";

            // using (var rd = new StreamReader("filename.csv"))
            using (StreamReader sr = new StreamReader(path))
            {
                // Skip the row with the column names
                sr.ReadLine();

                while (!sr.EndOfStream)
                {
                    var splits = sr.ReadLine().Split(',');
                    fName.Add(splits[0]);
                    lName.Add(splits[1]);
                    address.Add(splits[2]);
                }

                //now order the Last Name list descending

                //get frequncy of a word
                var freqLName = from c in lName
                                group c by c into g
                                where g.Count() > 1
                                orderby g.Key
                                select new { Item = g.Key, ItemCount = g.Count() };
                Console.WriteLine("First Name:");
                Console.WriteLine();

                //Separate name and surname
                using (StreamWriter sw = new StreamWriter(firstFilePath, append: true))
                {
                    sw.WriteLine("Last Name: ");
                }

                foreach (var i in freqLName)
                {
                    Console.WriteLine(string.Format(i.Item + " , " + i.ItemCount.ToString()));

                    using (StreamWriter sw = new StreamWriter(firstFilePath, append: true))
                    {
                        sw.WriteLine(string.Format(i.Item + " , " + i.ItemCount.ToString()));
                    }

                }

                Console.WriteLine();
                Console.WriteLine();

                //First Names
                //get frequncy of a word
                var freqFName = from c in fName
                                group c by c into g
                                where g.Count() > 0
                                orderby g.Key
                                select new { Item = g.Key, ItemCount = g.Count() };
                //orderby(g => g.Count()};

                Console.WriteLine("Last Name:");
                Console.WriteLine();

                using (StreamWriter sw = new StreamWriter(firstFilePath, append: true))
                {
                    sw.WriteLine(" ");
                    sw.WriteLine("First Name: ");
                }

                foreach (var i in freqFName)
                {
                    Console.WriteLine(string.Format(i.Item + " , " + i.ItemCount.ToString()));

                    using (StreamWriter sw = new StreamWriter(firstFilePath, append: true))
                    {
                        sw.WriteLine(string.Format(i.Item + " , " + i.ItemCount.ToString()));
                    }

                }

                //Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine();

                //Display the address
                address.Sort();

                var ordered = address.Select(s => new { Str = s, Split = s.Split(' ') }).OrderBy(x => (x.Split[1])).Select(x => x.Str).ToList();

                Console.WriteLine("Address:");
                Console.WriteLine();

                using (StreamWriter sw = new StreamWriter(secondFilePath, append: true))
                {
                    sw.WriteLine("Address: ");
                }

                foreach (var i in ordered)
                {
                    Console.WriteLine(i.ToString());
                    using (StreamWriter sw1 = new StreamWriter(secondFilePath, append: true))
                    {
                        sw1.WriteLine(string.Format(i.ToString()));
                    }
                }

                //address.Sort();
                Console.ReadLine();
                Console.WriteLine("Files gerenarated!");
                Console.ReadLine();
            }

        }
    }
}
