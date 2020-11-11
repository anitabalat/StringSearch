using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;

namespace StringSearch
{
    class Threaded
    {
        private readonly object matchesLock = new object();
        private readonly object comparesLock = new object();

        public int GetTotalMatches(string[] args)
        {
            int lineNumber = 1;
            int totalCompares = 0;
            int totalMatches = 0;
            int SEARCH_OPTION = Convert.ToInt16(args[2]);
            int THREADS = 2;
            Random random = new Random();
            var fileToSearch = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + args[0];
            var searchPattern = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + args[1];

            if (!(File.Exists(fileToSearch) && File.Exists(searchPattern)))
            {
                Console.WriteLine("Files do not exist.\n");
                return -1;
            }

            string[] lines = File.ReadAllLines(fileToSearch);
            string[] search = File.ReadAllLines(searchPattern);
            string searchString = search[0];

            Thread[] threads = new Thread[THREADS];

            for (int i = 0; i < THREADS; i++)
            {
                int id = i;
                threads[i] = new Thread(() => StringSearch(lines, searchString, lineNumber, SEARCH_OPTION, ref totalMatches, ref totalCompares, THREADS, id));
                threads[i].Start();
            }

            for (int i = 0; i < THREADS; i++)
            {
                threads[i].Join();
            }

            Console.WriteLine(Environment.NewLine + "In C# StringSearchThreaded: ({0} THREADS)", THREADS);
            Console.WriteLine("Total Compares:{0}", totalCompares);
            Console.WriteLine("Total Matches: {0}", totalMatches);

            return totalMatches;
        }

        void StringSearch(string[] lines, string searchString, int lineNumber, int SEARCH_OPTION, ref int totalMatches, ref int totalCompares, int threads, int ID)
        {
            for (int line = ID; line < lines.Length; line += threads)
            {
                lineNumber = line;
                string oneLine = lines[line];
                int i, j, k;
                int match = 0;                                               // keeps track of match returned by charcmp
                int matchFound = 0;                                          // keeps track of whether a complete match has been found
                int startPoint = 0;                                          // holds starting point of where a match was found
                int lineLength = oneLine.Length;
                int searchStringLength = searchString.Length;

                for (i = 0; i < (lineLength - 1); i++)                        // for each element in the line array
                {
                    for (j = 0, k = i; j < searchStringLength; j++, k++)      // for each element in the search string
                    {                                                         // if there are as many elements left to check in the line array as there are elements in the search string...
                        if ((i + (searchStringLength - 1)) < (lineLength - 1))
                        {
                            match = CharCmp(oneLine[k], searchString[j], SEARCH_OPTION);    // check for matching characters

                            if (match == 1)
                            {
                                matchFound++;                                // if characters matches, keep a tally of number of matched characters
                            }

                            if (matchFound == searchStringLength)             // if the number of matched characters is the same as the number of chacters in the search string
                            {
                                startPoint = i;

                                lock (matchesLock)
                                {
                                    totalMatches += 1;           // update the total number of matches found and print a message saying where the match was found
                                }

                                Console.WriteLine(Environment.NewLine + $"Match Found on Line: {lineNumber} Column: {startPoint}");
                            }
                        }
                    }

                    matchFound = 0;                                          // reinitialize matchFound to 0 for next iteration

                    lock (comparesLock)
                    {
                        totalCompares += 1;                     // update total number of compares
                    }
                }
            }
        }

        int CharCmp(char a, char b, int c)
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
