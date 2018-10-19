using System;
using System.Text;
using System.Collections.Generic;
using System.IO;

namespace Task_CISFrequency
{
    class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(CountImmediateStringFrequency(Console.ReadLine()));
            Console.WriteLine("Enter path or leave empty for default");
            ProcessFromFile(Console.ReadLine());
            Console.ReadKey();
        }

        public static string CountImmediateStringFrequency(string inpS)
        {
            List<string> alist = new List<string>();
            if (String.IsNullOrEmpty(inpS)) return inpS;
            if (inpS.Length == 1) return "1" + inpS;
            int freq = 1, slength = inpS.Length - 1;
            for(int i = 0; i < slength; i++)
            {
                if(inpS[i] != inpS[i+1])
                {
                    alist.Add(freq.ToString() + inpS[i]);
                    freq = 1;
                }
                if (inpS[i] == inpS[i + 1])
                    freq++;
            }
            alist.Add(freq.ToString() + inpS[slength]);
            return AssembleList(alist);
        }
        public static string AssembleList(List<string> list)
        {
            string assembledList;
            StringBuilder sbAssembledList = new StringBuilder();
            foreach (var s in list)
                sbAssembledList.Append(s);
            assembledList = sbAssembledList.ToString();
            return assembledList;
        }
        public static void ProcessFromFile(string path = null)
        {
            //path = Path.Combine(Path.GetDirectoryName(typeof(Program).Assembly.Location), "InOut.txt");
            if (String.IsNullOrEmpty(path))
                path = @"C:\Users\estratulat\source\repos\Task_CISFrequency\Task_CISFrequency";
            try
            {
                using (StreamWriter sw = new StreamWriter(Path.Combine(path, "Out.txt")))
                {
                    using (StreamReader sr = new StreamReader(Path.Combine(path, "In.txt")))
                    {
                        string line;

                        while ((line = sr.ReadLine()) != null)
                        {
                            sw.WriteLine(CountImmediateStringFrequency(line));
                        }
                    }
                }
                Console.WriteLine("Done");
            }
            catch (Exception e)
            {
                Console.WriteLine("File I/O Error");
                Console.WriteLine(e.Message);
            }
        }
    }
    
}
