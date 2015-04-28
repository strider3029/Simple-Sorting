using System;
using System.IO;

namespace SimpleSorting
{
    class SimpleSorting
    {
        static int Main(string[] args)
        {
            // Check the argument and file exists
            if (args.Length == 0 || !File.Exists(args[0]))
            {
                Console.Write("You failed to specify the file to read, or entered a non existant file path.\nPlease try again with the file name as the first argument.");
                return 0;
            }

            using (StreamReader reader = File.OpenText(args[0]))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (null == line) continue;

                    if ("" == line) continue;

                    SortAndPrint(line);
                }
            }

            return 0;
        }

        static void SortAndPrint(string query)
        {
            string[] numberBlocks = query.Split(' ');

            if (numberBlocks.Length != 0)
            {
                double[] convertedValues = new double[numberBlocks.Length];

                for (int index = 0; index < numberBlocks.Length; ++index)
                {
                    convertedValues[index] = Convert.ToDouble(numberBlocks[index]);
                }

                Array.Sort(convertedValues);
                string output = "";

                for (int index = 0; index < numberBlocks.Length; ++index)
                {
                    output += convertedValues[index].ToString("0.000") + " ";
                }

                Console.WriteLine(output.Trim());
            }
        }
    }
}
