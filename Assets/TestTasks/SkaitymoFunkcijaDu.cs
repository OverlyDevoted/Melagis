using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileIODemo
{
    class Program
    {
        static void Main(string[args])
        {
            string filePath = @"Assets/Tests/NuskaitomasisFailas.txt";

            //string[] lines = File.ReadAllLines(filePath);

            List<string> lines = File.ReadAllLines(filePath);
            lines = File.ReadAllLines(filePath).ToList();

            foreach (String line in lines)
            {
                Console.WriteLine(line);
            }

            lines.Add("John, Does, www.nobody.com");
            File.WrittenAllLines(filePath, lines);


            Console.ReadLine();
        }
    }

}