using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;

namespace StringSearch
{
    class ParallelFor
    {
        private readonly object matchesLock = new object();
        private readonly object comparesLock = new object();
        
        public int GetTotalMatches(string[] args)
        {
            int lineNumber = 1;
            int totalCompares = 0;
            int totalMatches = 0;
            int SEARCH_OPTION = Convert.ToInt16(args[2]);
            int DELAY = Convert.ToInt16(args[4]);
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

            Parallel.For(0, lines.Length, index =>
            {
                lineNumber = index + 1;
                StringSearch(lines[index], searchString, lineNumber, SEARCH_OPTION, ref totalMatches, ref totalCompares, DELAY);
            });

            Console.WriteLine(Environment.NewLine + "In C# StringSearchParallelFor: (OPTIMIZED THREADS)");
            Console.WriteLine("Total Compares: {0}", totalCompares);
            Console.WriteLine("Total Matches: {0}", totalMatches);

            return totalMatches;
        }

        void StringSearch(string line, string searchString, int lineNumber, int SEARCH_OPTION, ref int totalMatches, ref int totalCompares, int delay)
        {
            int i, j, k;
            bool match = false;                                               // keeps track of match returned by charcmp
            int matchFound = 0;                                          // keeps track of whether a complete match has been found
            int startPoint = 0;                                          // holds starting point of where a match was found

            for (i = 0; i < line.Length; i++)                        // for each element in the line array
            {
                for (j = 0, k = i; j < searchString.Length; j++, k++)      // for each element in the search string
                {                                                         // if there are as many elements left to check in the line array as there are elements in the search string...
                    if ((i + (searchString.Length - 1)) < line.Length)
                    {
                        match = CharCompare.CharCmp(line[k], searchString[j], SEARCH_OPTION, delay);    // check for matching characters

                        if (match)
                        {
                            lock (matchesLock)
                            {
                                matchFound++;                                // if characters matches, keep a tally of number of matched characters
                            }
                        }

                        if (matchFound == searchString.Length)             // if the number of matched characters is the same as the number of chacters in the search string
                        {
                            startPoint = i;
                            totalMatches += 1;           // update the total number of matches found and print a message saying where the match was found

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
}
