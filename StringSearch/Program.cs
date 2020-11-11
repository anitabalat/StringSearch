using System;

namespace StringSearch
{
    public class StrSearch
    {
        public static void Main(string[] args)                                    // to display results in console window
        {
            int programChoice = Convert.ToInt16(args[3]);

            if (programChoice == 1)
            {
                var sequentialSearch = new Sequential();
                var totalSequentialMatches = sequentialSearch.GetTotalMatches(args);
            }

            if (programChoice == 2)
            {
                var threadedSearch = new Threaded();
                var totalThreadedMatches = threadedSearch.GetTotalMatches(args);
            }

            if (programChoice == 3)
            {
                var parallelSearch = new ParallelFor();
                var parallelMatches = parallelSearch.GetTotalMatches(args);
            }
        }
                                                                                 
        public int GetTotalSequentialSearchMatches(string[] args)               // to be used for unit tests
        {
            var sequentialSearch = new Sequential();
            return sequentialSearch.GetTotalMatches(args);
        }

        public int GetTotalThreadedSearchMatches(string[] args)
        {
            var threadedSearch = new Threaded();
            return threadedSearch.GetTotalMatches(args);
        }

        public int GetTotalParallelSearchMatches(string[] args)
        {
            var parallelSearch = new ParallelFor();
            return parallelSearch.GetTotalMatches(args);
        }
    }
}
