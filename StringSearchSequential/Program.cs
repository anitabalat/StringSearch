using System;
using System.IO;

namespace StringSearchSequential
{   
    class Program
    {
        static void Main(string[] args)
        {
            int lineNumber = 1;
            int totalCompares = 0;
            int totalMatches = 0;
            int SEARCH_OPTION = 3;
            Random random = new Random();

            if (!(File.Exists(args[0]) && File.Exists(args[1])))
            {
                Console.WriteLine("Files do not exist.\n");
                return;
            }

            string[] lines = File.ReadAllLines(args[0]);
            string[] search = File.ReadAllLines(args[1]);
            string searchString = search[0];

            for( int i = 0; i < lines.Length; i++, lineNumber++)
            {
                string line = lines[i];
                stringSearch(line, searchString, lineNumber, SEARCH_OPTION, ref totalMatches, ref totalCompares);
            }

            Console.WriteLine("In C# StringSearchSequential: (1 THREAD)");
            Console.WriteLine("Total Compares:{0}", totalCompares);
            Console.WriteLine("Total Matches: {0}", totalMatches);

        }

        static void stringSearch(string line, string searchString, int lineNumber, int SEARCH_OPTION, ref int totalMatches, ref int totalCompares )
        {
            int i, j, k;
            int match = 0;                                               // keeps track of match returned by charcmp
            int matchFound = 0;                                          // keeps track of whether a complete match has been found
            int startPoint = 0;                                          // holds starting point of where a match was found
            int lineLength = line.Length;
            int searchStringLength = searchString.Length;

            for (i = 0; i < (lineLength - 1); i++)                        // for each element in the line array
            {
                for (j = 0, k = i; j < searchStringLength; j++, k++)      // for each element in the search string
                {                                                         // if there are as many elements left to check in the line array as there are elements in the search string...
                    if ((i + (searchStringLength - 1)) < (lineLength - 1))
                    {
                        match = charcmp(line[k], searchString[j], SEARCH_OPTION);    // check for matching characters

                        if (match == 1)
                        {
                            matchFound++;                                // if characters matches, keep a tally of number of matched characters
                        }

                        if (matchFound == searchStringLength)             // if the number of matched characters is the same as the number of chacters in the search string
                        {
                            startPoint = i;
                            totalMatches += 1;           // update the total number of matches found and print a message saying where the match was found

                            Console.WriteLine(Environment.NewLine + $"Match Found on Line: {lineNumber} Column: {startPoint}");
                        }
                    }
                }

                matchFound = 0;                                          // reinitialize matchFound to 0 for next iteration
                totalCompares += 1;                     // update total number of compares
            }
        }
        static int charcmp(char a, char b, int c)
        {
            //int k, x;
            //x = random.Next(1000000);

            //for (k = 0; k < 1000 * a; k++)
            //{
            //   if (x % 2 == 0)
            //  {
            //      x = x + 2;
            //  }
            //   else
            //   {
            //       x = x - 1;
            //  }
            // }
            //  for (k = 0; k < 1000 * b; k++)
            //  {
            //      if (x % 2 == 0)
            //     {
            //       x = x + 2;
            //      }
            //      else
            //      {
            //       x = x - 1;
            //   }
            //   }

            if (c == 1)                                         // perfect match
            {
                if (a == b)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            a = char.ToUpper(a);                                   // convert a and b to the same case for case insensitive matches
            b = char.ToUpper(b);

            if (c == 2)                                        // perfect match and different case match
            {
                if (a == b)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            if (c == 3)                                                  // perfect, different case, and different digit match
            {
                if (a == b)
                {
                    return 1;
                }
                else if ((a >= 48 && a <= 57) && (b >= 48 && b <= 57))  // if a or b are ascii digits
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }

            return 0;
        }

    }
}
