using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace StringSearchSequentialTest
{
    [TestClass]
    public class ThreadedTest
    {
        [TestMethod]
        public void ThreadedDevTest()
        {
            var lines = "raw";
            var search = "pat2";
            var SEARCH_OPTION = "1";
            var expectedMatches = 3;

            string[] args = { lines, search, SEARCH_OPTION };

            var stringSearchThreaded = new StringSearchThreaded.Program();

            stringSearchThreaded.Main(args);

            var totalMatches = stringSearchThreaded.totalMatches;

            Assert.AreEqual(expectedMatches, totalMatches);
        }


        [TestMethod]
        public void Question1Test()
        {
            var lines = "raw";
            var search = "pat2";
            var SEARCH_OPTION = "1";
            var expectedMatches = 3;

            string[] args = { lines, search, SEARCH_OPTION };

            var stringSearchThreaded = new StringSearchThreaded.Program();

            stringSearchThreaded.Main(args);

            var totalMatches = stringSearchThreaded.totalMatches;

            Assert.AreEqual(expectedMatches, totalMatches);
        }

        [TestMethod]
        public void Question2Test()
        {
            var lines = "src";
            var search = "pat2";
            var SEARCH_OPTION = "1";
            var expectedMatches = 6;
            string[] args = { lines, search, SEARCH_OPTION };
            var stringSearchThreaded = new StringSearchThreaded.Program();

            stringSearchThreaded.Main(args);

            var totalMatches = stringSearchThreaded.totalMatches;

            Assert.AreEqual(expectedMatches, totalMatches);
        }

        [TestMethod]
        public void Question3Test()
        {
            var lines = "src";
            var search = "pat2";
            var SEARCH_OPTION = "1";
            var expectedMatches = 6;
            string[] args = { lines, search, SEARCH_OPTION };
            var stringSearchThreaded = new StringSearchThreaded.Program();

            stringSearchThreaded.Main(args);

            var totalMatches = stringSearchThreaded.totalMatches;

            Assert.AreEqual(expectedMatches, totalMatches);
        }

        [TestMethod]
        public void Question5Test()
        {
            var lines = "src";
            var search = "pat1";
            var SEARCH_OPTION = "1";
            var expectedMatches = 271;
            string[] args = { lines, search, SEARCH_OPTION };
            var stringSearchThreaded = new StringSearchThreaded.Program();

            stringSearchThreaded.Main(args);

            var totalMatches = stringSearchThreaded.totalMatches;

            Assert.AreEqual(expectedMatches, totalMatches);
        }

        [TestMethod]
        public void Question6Test()
        {
            var lines = "src";
            var search = "pat3";
            var SEARCH_OPTION = "2";
            var expectedMatches = 271;
            string[] args = { lines, search, SEARCH_OPTION };
            var stringSearchThreaded = new StringSearchThreaded.Program();

            stringSearchThreaded.Main(args);

            var totalMatches = stringSearchThreaded.totalMatches;

            Assert.AreEqual(expectedMatches, totalMatches);
        }

        [TestMethod]
        public void Question7Test()
        {
            var lines = "src";
            var search = "pat4";
            var SEARCH_OPTION = "2";
            var expectedMatches = 127;
            string[] args = { lines, search, SEARCH_OPTION };
            var stringSearchThreaded = new StringSearchThreaded.Program();

            stringSearchThreaded.Main(args);

            var totalMatches = stringSearchThreaded.totalMatches;

            Assert.AreEqual(expectedMatches, totalMatches);
        }

        [TestMethod]
        public void Question8Test()
        {
            var lines = "src";
            var search = "pat5";
            var SEARCH_OPTION = "2";
            var expectedMatches = 217;
            string[] args = { lines, search, SEARCH_OPTION };
            var stringSearchThreaded = new StringSearchThreaded.Program();

            stringSearchThreaded.Main(args);

            var totalMatches = stringSearchThreaded.totalMatches;

            Assert.AreEqual(expectedMatches, totalMatches);
        }

        [TestMethod]
        public void Question9Test()
        {
            var lines = "src";
            var search = "pat6";
            var SEARCH_OPTION = "3";
            var expectedMatches = 11;
            string[] args = { lines, search, SEARCH_OPTION };
            var stringSearchThreaded = new StringSearchThreaded.Program();

            stringSearchThreaded.Main(args);

            var totalMatches = stringSearchThreaded.totalMatches;

            Assert.AreEqual(expectedMatches, totalMatches);
        }

        [TestMethod]
        public void Question10Test()
        {
            var lines = "src";
            var search = "pat7";
            var SEARCH_OPTION = "3";
            var expectedMatches = 27;
            string[] args = { lines, search, SEARCH_OPTION };
            var stringSearchThreaded = new StringSearchThreaded.Program();

            stringSearchThreaded.Main(args);

            var totalMatches = stringSearchThreaded.totalMatches;

            Assert.AreEqual(expectedMatches, totalMatches);
        }

        [TestMethod]
        public void Question11Test()
        {
            var lines = "src";
            var search = "pat8";
            var SEARCH_OPTION = "3";
            var expectedMatches = 2;
            string[] args = { lines, search, SEARCH_OPTION };
            var stringSearchThreaded = new StringSearchThreaded.Program();

            stringSearchThreaded.Main(args);

            var totalMatches = stringSearchThreaded.totalMatches;

            Assert.AreEqual(expectedMatches, totalMatches);
        }
    }
}
