using System;
using System.IO;

namespace StringSearch
{   
    public class StrSearch
    {
        public static void Main(string[] args)                                    // to display results in console window
        {
            var sequentialSearch = new Sequential();
            var totalSequentialMatches = sequentialSearch.GetTotalMatches(args);

            var threadedSearch = new Threaded();
            var totalThreadedMatches = threadedSearch.GetTotalMatches(args);

            var parallelSearch = new Threaded();
            var parallelMatches = parallelSearch.GetTotalMatches(args);
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
            var parallelSearch = new Parallel();
            return parallelSearch.GetTotalMatches(args);
        }
    }
}
